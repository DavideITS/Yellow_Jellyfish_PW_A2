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

char picId = 23;

int millis = 0;
int seconds = 0;

char dataArray[TXDATASIZE] = {0};
char receivedArray[RCDATASIZE] = {0};
char receivedByte;

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

void main(void) {
    system_init();
    PORTDbits.RD2 = 2 >> 1;
    while(1)
    {
        timer_handler();
        com_handler();
    }
}

void __interrupt() ISR()
{
    rc_interrupt();
    timer_interrupt();
}

void system_init()
{
    TRISB = 0x00;
    TRISD = 0x00;
    PORTD = 0x00;
    INTCONbits.GIE = 1;     // Enable global interrupt
    INTCONbits.PEIE = 1;    // Enable peripheral interrupt 
    uart_init(9600);
    timer_init();
    adc_init();
}

void com_handler()
{
    static char currentState = 0;
    static char prevState = 0;

    currentState = seconds % UPD_DELAY;
    static unsigned int analogVals[3];
    static char pos = 0;
    analogVals[pos] = read_analog(pos);
    if((!currentState && prevState) || valReg1.pendingSend)
    {
        dataArray[0] = picId;
        dataArray[1] = (char) (p0 >> 8);
        dataArray[2] = (char) p0;
        dataArray[3] = (char)(p1 << 8);
        dataArray[4] = (char) p1;
        dataArray[5] = (char)(temp >> 8);
        dataArray[6] = (char) temp;
        valReg1.pendingSend = send_array(dataArray);
    } 
    
    if(valReg1.isReceiving)
    {
        static char pos = 0;
        PORTD = pos;
        if(pos < RCDATASIZE)
        {
            receivedArray[pos++] = receivedByte;
        }
        else
        {
            pos = 0;
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
    ADCON1 = 0x02; // Set RA0 as analogic input
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

/*
 * LCD functions
 */

void lcd_init()
{
    
}