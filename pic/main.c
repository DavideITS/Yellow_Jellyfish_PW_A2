#pragma config FOSC = HS        // Oscillator Selection bits (HS oscillator)
#pragma config WDTE = OFF       // Watchdog Timer Enable bit (WDT disabled)
#pragma config PWRTE = ON      // Power-up Timer Enable bit (PWRT enabled)
#pragma config BOREN = ON       // Brown-out Reset Enable bit (BOR enabled)
#pragma config LVP = ON         // Low-Voltage (Single-Supply) In-Circuit Serial Programming Enable bit (RB3/PGM pin has PGM function; low-voltage programming enabled)
#pragma config CPD = OFF        // Data EEPROM Memory Code Protection bit (Data EEPROM code protection off)
#pragma config WRT = OFF        // Flash Program Memory Write Enable bits (Write protection off; all program memory may be written to by EECON control)
#pragma config CP = OFF         // Flash Program Memory Code Protection bit (Code protection off)

#include <xc.h>
#include <stdlib.h>
#define _XTAL_FREQ 8000000

#define L_ON 0x0F
#define L_OFF 0x08
#define L_CLR 0x01

#define L_L1_C1 0x80
#define L_L2_C1 0xC0

#define L_L1_C3 0x82
#define L_L2_C3 0xC2

#define L_CR 0x0F
#define L_NCR 0x0C
#define L_CFG 0x38
#define L_CUR 0x0E

#define UPD_DELAY 3
#define TRUE 1
#define FALSE 0
#define BAUDRATE 9600
#define TXDATASIZE 8
#define RCDATASIZE 4
// Register settings

struct {
	unsigned int msTrig : 1;
    unsigned int pendingSend : 1;
    unsigned int isReceiving : 1;
} valReg1;

char picId = 1;

int millis = 0;
int seconds = 0;

char dataArray[TXDATASIZE] = {0};
char receivedArray[RCDATASIZE] = {0};
char receivedByte;
unsigned int analogVals[3];
unsigned int targetTemp;

char currentStateRB0;
char currentStateRB1;
char currentStateRB2;
char currentStateRB3;

char prevStateRB0;
char prevStateRB1;
char prevStateRB2;
char prevStateRB3;

char posMenu;

char voce1[] = "1 temp \t\tC";
char voce2[] = "2 setT \t\tC";
char voce3[] = "3 um   \t\t%";
char voce4[] = "4 fumo \t\t%";
char voce5[] = "5 porte     ";
char m1[4];

char menuPorte[4];

char portToOpen;

char provaMenu;

char initMenu;
void system_init(void);
void com_handler(void);

// Serial communication functions
void uart_init(int);
void send_byte(char);
char send_array(char *);
void rc_interrupt(void);

// Timer functions
void timer_init(void);
void timer_handler(void);
void timer_interrupt(void);

// ADC functions
void adc_init(void);
unsigned int read_analog(char);
void read_analog_ports(unsigned int *, char *);

// LCD functions
void send_LCD(char, char);
void LCD_init(void);
void send_string(char *);
void scorrimentoMenu(char *, char);

// Other functions
void string_Formatter(char *, char *);
char * int_to_ChArray(unsigned int);
int pow(int, int);

void main(void) {
    system_init();
    char updDisplayTrig = 0;
    char updDisplayTrigOld = 0;
    while(1)
    {

        timer_handler();
        com_handler();
        updDisplayTrig = seconds % 2;
        if(!updDisplayTrig && updDisplayTrigOld)
        {
            string_Formatter(voce1, int_to_ChArray(analogVals[0]));
            string_Formatter(voce2, int_to_ChArray(targetTemp));
            string_Formatter(voce3, int_to_ChArray(analogVals[1]));
            string_Formatter(voce4, int_to_ChArray(analogVals[2]));
        }

        currentStateRB2 = !PORTBbits.RB2;
        currentStateRB3 = !PORTBbits.RB3;

        if (currentStateRB2 && !prevStateRB2 && provaMenu == 0)
        {
            initMenu = 0;
        }
        else if(currentStateRB2 && !prevStateRB2 && provaMenu == 1)
        {
            initMenu = 0;
            provaMenu = 0;
        }

        if (provaMenu == 1 )
        {
            if (currentStateRB3 && !prevStateRB3)
            {
                //apriPorte(posMenu);
            }

        }
        else
        {
            scorrimentoMenu(m1, 5);
        }

        prevStateRB2 = currentStateRB2;
        prevStateRB3 = currentStateRB3;     
        

        updDisplayTrigOld = updDisplayTrig;
    }
}

void __interrupt() ISR()
{
    rc_interrupt();
    timer_interrupt();
}

void system_init()
{
    TRISD = 0x00;
    TRISB = 0x00;
    TRISE = 0x00;
    TRISC = 0x1F;           // RC0:5 are door switches
    INTCONbits.GIE = 1;     // Enable global interrupt
    INTCONbits.PEIE = 1;    // Enable peripheral interrupt 
    LCD_init();
    uart_init(9600);
    timer_init();
    adc_init();
}

void com_handler()
{
    static char currentState = 0;
    static char prevState = 0;

    currentState = seconds % UPD_DELAY;
    char analogPorts[4] = {0, 1, 2, '\0'};
    read_analog_ports(analogVals, analogPorts);
    char doorsStatus = PORTC;
    doorsStatus &= ~0xE0;
    if((!currentState && prevState) || valReg1.pendingSend)
    {
        dataArray[0] = picId;
        dataArray[1] = (char) (analogVals[0] >> 8);
        dataArray[2] = (char) analogVals[0];
        dataArray[3] = (char)(analogVals[1] >> 8);
        dataArray[4] = (char) analogVals[1];
        dataArray[5] = (char)(analogVals[2] >> 8);
        dataArray[6] = (char) analogVals[2];
        dataArray[7] = doorsStatus;
        valReg1.pendingSend = send_array(dataArray);
    } 
    
    if(valReg1.isReceiving)
    {
        static char pos = 0;
        if(pos < RCDATASIZE)
        {
            receivedArray[pos] = receivedByte;
        }

        PORTB = pos;
        if(pos == 3)
        {
            if(receivedArray[0] == picId)
            {
                PORTD = receivedArray[3];
                targetTemp = receivedArray[2] + (receivedArray[1] << 8);
               
            }
            pos = 0;
        }
        else
        {
            pos++;
        }
        
    }
    valReg1.isReceiving = FALSE;
    prevState = currentState;
    

}

/*
 * Serial communication functions
 */

void uart_init(int baudrate)
{
    // Interrupt configuration
    PIE1bits.RCIE = 1;      // Enable RC interrupt
    
    TRISCbits.TRISC7 = 1;   // Set RC7 to input (RC)
    TRISCbits.TRISC6 = 0;   // Set RC6 to output (TX)

    RCSTAbits.CREN = 1;
    TXSTAbits.TXEN = 1;     // Enable transmission
    TXSTAbits.BRGH = 1;     //Enable Hight speed

    SPBRG = (_XTAL_FREQ/(unsigned long)(16UL*(unsigned long)baudrate))-1;
    RCSTAbits.SPEN = 1;     // Enable serial port
}

void send_byte(char byte)
{
    if(PIR1bits.TXIF)
    {
        TXREG = byte;     
    }

}

char send_array(char * array)
{
    static char pos = 0;
    if(PIR1bits.TXIF)
    {
        send_byte(array[pos]);
        if(pos < TXDATASIZE - 1)
            pos++;
        else
        {
            pos = 0;
            return FALSE;
        }
        return TRUE;
    }   
}

void rc_interrupt()
{
    if (PIR1bits.RCIF)      // Interrupt RX
    {
        valReg1.isReceiving = !valReg1.pendingSend;
        receivedByte = RCREG;
        PIR1bits.RCIF = 0;
    }
}

/*
 * Timer functions
 */

void timer_init(void)
{
    // Timer is configured to produce an interrupt ever 1ms at 8Mhz
     
    INTCONbits.TMR0IE = 1;      // Enable TIMER 0 interrupt
    OPTION_REGbits.T0CS = 0;    // Select internal clock
    OPTION_REGbits.PS1 = 1;     // Prescaler to 1:8
    TMR0 = 6;                   // Preload
}

void timer_handler(void)
{
    if(valReg1.msTrig)
    {
        if(++millis >= 1000)
        {
            millis = 0;
            seconds++;
        }
        
        valReg1.msTrig = 0;
    }
}

void timer_interrupt(void)
{
    if (INTCONbits.TMR0IF)     // Interrupt timer
    {
        valReg1.msTrig = 1;
        INTCONbits.TMR0IF = 0;
    }
}

/*
 * ADC Functions
 */

void adc_init()
{
    TRISAbits.TRISA0 = 1;
    TRISAbits.TRISA2 = 1;
    ADCON1 = 0x02; // Set RA0:4 as analogic input
    ADCON1bits.ADFM = 1; // Right justified
    ADCON0bits.ADON = 1;    // Enable ADC converter
    ADCON0bits.ADCS0 = 0;
    ADCON0bits.ADCS1 = 1;   // 1:32 frequency conversion
}

unsigned int read_analog(char port)
{
    static unsigned int val = 0;
    ADCON0bits.CHS0 = port;
    ADCON0bits.CHS1 = port >> 1;
    ADCON0bits.CHS2 = port >> 2;
    if(!ADCON0bits.GO_DONE)
    {
        ADCON0bits.GO_DONE = 1;
        val = ADRESL + (ADRESH << 8);
    }

    return val;
}

void read_analog_ports(unsigned int * array, char * ports)
{
    static char pos = 0;
    static char prevState = 0;
    
    char state = millis % 100;
    if(!state && prevState)
        pos++;
    
    if(ports[pos] == '\0')
        pos = 0;
        
    array[pos] = read_analog(ports[pos]);
    
    prevState = state;
    
}

/*
 * LCD functions
 */

void LCD_init(void){
    PORTD = 0;
    TRISBbits.TRISB3 = 1;
    TRISBbits.TRISB2 = 1;
    TRISBbits.TRISB1 = 1;
    TRISBbits.TRISB0 = 1;
    
    PORTE &= ~0x06;
    __delay_ms(20);
    PORTE |= 0x02;
    send_LCD(0, L_CFG);
    __delay_ms(5);
    send_LCD(0, L_CFG);
    __delay_ms(1);
    send_LCD(0, L_CFG);
    send_LCD(0, L_OFF);
    send_LCD(0, L_ON);
    send_LCD(0, L_CLR);
    send_LCD(0, L_CUR);
    
    provaMenu = 0;
    posMenu = 0;
    initMenu = 0;
}

void send_LCD(char inf, char command){
    PORTE |= 0x02;
    PORTD = command;
    if(!inf){
        PORTE &= ~0x04;
    }else{
        PORTE |= 0x04;
    }
    PORTE &= ~0x02;
    PORTE |= 0x02;
}

void send_string(char *str){
    for(char i=0;str[i]!='\0';i++){
        send_LCD(1, str[i]);
    }
}

void scorrimentoMenu(char *m, char voci)
{
    currentStateRB0 = !PORTBbits.RB0;   
    currentStateRB1 = !PORTBbits.RB1;
    
    if (initMenu == 0)
    {
        posMenu = 0;
        send_LCD(0, L_CLR);
        send_LCD(0, L_L1_C1);
        send_string(">");
        send_LCD(0, L_L2_C1);
        send_string(" ");
        
        if (provaMenu == 0)
        {
            send_LCD(0, L_L1_C3);
            send_string(voce1);
            send_LCD(0, L_L2_C3);
            send_string(voce2);
        }
        if (provaMenu == 1)
        {
            send_LCD(0, L_L1_C3);
            send_string(m);//m[posMenu-1]);
            send_LCD(0, L_L2_C3);
            send_string(m);//m[posMenu]); 
        }
        
                    
        initMenu = 1;
    }
    
    if (currentStateRB1 && !prevStateRB1 && posMenu > 0)
      {
        posMenu--;
        send_LCD(0, L_L1_C1);
        send_string(">");
        send_LCD(0, L_L2_C1);
        send_string(" ");
        
        if (provaMenu == 1)
        {
            send_LCD(0, L_L1_C3);
            send_string(m);
            send_LCD(0, L_L2_C3);
            send_string(m);//m[posMenu+1]);
        }
        
        
        if (provaMenu == 0)
        {
            //send_LCD(0, L_CLR);
            switch(posMenu)
            {
                case 0:
                    send_LCD(0, L_L1_C3);
                    send_string(voce1);
                    send_LCD(0, L_L2_C3);
                    send_string(voce2);
                    break;
                case 1:
                    send_LCD(0, L_L1_C3);
                    send_string(voce2);
                    send_LCD(0, L_L2_C3);
                    send_string(voce3);
                    break;
                case 2:
                    send_LCD(0, L_L1_C3);
                    send_string(voce3);
                    send_LCD(0, L_L2_C3);
                    send_string(voce4);
                    break;
                case 3:
                    send_LCD(0, L_L1_C3);
                    send_string(voce4);
                    send_LCD(0, L_L2_C3);
                    send_string(voce5);
                    break;
                case 4:
                    send_LCD(0, L_L1_C3);
                    send_string(voce4);
                    send_LCD(0, L_L2_C3);
                    send_string(voce5);
                    break;
            }
        }
        
      } 
    if (currentStateRB0 && !prevStateRB0 && posMenu < voci-1)
      {
        posMenu++;
        
        send_LCD(0, L_L1_C1);
        if (posMenu == 0)
            send_string(">");
        else
            send_string(" ");
        
        send_LCD(0, L_L2_C1);
        if (posMenu == 0)
            send_string(" ");
        else
            send_string(">");
        
        if (provaMenu == 1)
        {
            send_LCD(0, L_L1_C3);
            send_LCD(0, L_L1_C3);
            send_string(m);//[posMenu]);
            send_LCD(0, L_L2_C3);
            send_string(m);//m[posMenu]); 
        }
        
        if (provaMenu == 0)
        {
            //send_LCD(0, L_CLR);
            switch(posMenu)
            {
                case 1:
                    send_LCD(0, L_L1_C3);
                    send_string(voce1);
                    send_LCD(0, L_L2_C3);
                    send_string(voce2);
                    break;
                case 2:
                    send_LCD(0, L_L1_C3);
                    send_string(voce2);
                    send_LCD(0, L_L2_C3);
                    send_string(voce3);
                    break;
                case 3:
                    send_LCD(0, L_L1_C3);
                    send_string(voce3);
                    send_LCD(0, L_L2_C3);
                    send_string(voce4);
                    break;
                case 4:
                    send_LCD(0, L_L1_C3);
                    send_string(voce4);
                    send_LCD(0, L_L2_C3);
                    send_string(voce5);
                    break;
            }
        }
            
      } 
   
    prevStateRB0 = currentStateRB0;   
    prevStateRB1 = currentStateRB1;
    
}
/*
 * Other functions
 */

int pow(int numBase, int pwr)
{
    int result = 1;
    int i = 0;
    for(i; i < pwr; i++)
    {
        result = result * numBase;
    }
    
    return result;
}

void string_Formatter(char * text, char * vals)
{
    char valIndex = 0;
    int i = 0;
    for(i; text[i] != 0; i++)
    {
        if(text[i] == '\t')
        {
            text[i] = vals[valIndex];
            valIndex++;
        }
    }
}

char * int_to_ChArray(unsigned int number)
{
    if(number == 0)
    {
        return "0";
    }
    char numArray[2] = { 0 };
    char i;
    char numStart = 0;
    for(i = 0; i <= 2; i++)
    {
        int digit = number / pow(10, 2-i) % 10;
		
		if(digit != 0 && numStart == 0)
			numStart = i;
		
		if(numStart)
		{
			int pos = i-numStart;
			numArray[pos] = digit + '0';		
		}
    }
    
    return numArray;
}