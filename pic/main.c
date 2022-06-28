#pragma config FOSC = HS        // Oscillator Selection bits (HS oscillator)
#pragma config WDTE = OFF       // Watchdog Timer Enable bit (WDT disabled)
#pragma config PWRTE = ON       // Power-up Timer Enable bit (PWRT enabled)
#pragma config BOREN = ON       // Brown-out Reset Enable bit (BOR enabled)
#pragma config LVP = ON         // Low-Voltage (Single-Supply) In-Circuit Serial Programming Enable bit (RB3/PGM pin has PGM function; low-voltage programming enabled)
#pragma config CPD = OFF        // Data EEPROM Memory Code Protection bit (Data EEPROM code protection off)
#pragma config WRT = OFF        // Flash Program Memory Write Enable bits (Write protection off; all program memory may be written to by EECON control)
#pragma config CP = OFF         // Flash Program Memory Code Protection bit (Code protection off)


#include <xc.h>
#define _XTAL_FREQ 8000000

#define UPD_DELAY 3
#define TRUE 1
#define FALSE 0
#define BAUDRATE 9600

// Register settings

typedef struct {
	unsigned int bit0 : 1;
    unsigned int bit1 : 1;
    unsigned int bit2 : 1;
    unsigned int bit3 : 1;
    unsigned int bit4 : 1;
    unsigned int bit5 : 1;
    unsigned int bit6 : 1;
    unsigned int bit7 : 1;
}boolReg;

boolReg valReg1;
/*
 * 0 = millis trigger
 */
char picId = 0x01;
int placeHolder = 768;

int millis = 0;
int seconds = 0;

char dataArray[64];

void system_init(void);
void com_handler(void);
char id_request(void);
void adc_init(void);

// Serial communication functions
void uart_init(int);
void send_byte(char);
char send_array(char *);

// Timer functions
void timer_init(void);
void timer_handler(void);

void main(void) {
    system_init();
    while(1)
    {
        timer_handler();
        com_handler();
    }
}

void __interrupt() ISR()
{

    if (PIR1bits.RCIF)  // Interrupt RX
    {
        PORTD = RCREG;
        PIR1bits.RCIF = 0;
    }
    
    if (INTCONbits.TMR0IF)  // Interrupt timer
    {
        valReg1.bit0 = 1;
        INTCONbits.TMR0IF = 0;
    }

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
}


void com_handler()
{   
    char str[] = "prova";
    static boolReg comReg;
    
    if((!(seconds % UPD_DELAY) && comReg.bit0) || comReg.bit1)
    {
        comReg.bit1 = send_array(str);
    }

    if(!(seconds % UPD_DELAY))
        comReg.bit0 = FALSE;
    else
         comReg.bit0 = TRUE;
    
}

char id_request()
{
    
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

    RCSTAbits.SPEN = 1;     // Enable serial port
    RCSTAbits.CREN = 1;     // Enable continuous receive mode

    TXSTAbits.TXEN = 1;     // Enable transmission
    TXSTAbits.BRGH = 1;     //Enable Hight speed

    SPBRG = (_XTAL_FREQ/(long)(64UL*baudrate))-1;
}

void send_byte(char byte)
{
    if(PIR1bits.TXIF)
        PORTD = byte;
        TXREG = byte;
}

char send_array(char * array)
{
    static char pos = 0;
    if(PIR1bits.TXIF)
    {
        PORTB = array[pos];
        send_byte(array[pos]);
        // PORTB = array[pos];
        if(array[pos] == '\0')
        {
            pos = 0;
            return FALSE;
        }
        else
            pos++;
        return TRUE;
    }   
}

/*
 * Timer functions
 */

void timer_init()
{
    // Timer is configured to produce an interrupt ever 1ms at 8Mhz
    
    
    INTCONbits.TMR0IE = 1;      // Enable TIMER 0 interrupt
    OPTION_REGbits.T0CS = 0;    // Select internal clock
    OPTION_REGbits.PS1 = 1;     // Prescaler to 1:8
    TMR0 = 6;                   // Preload
}

void timer_handler()
{
    if(valReg1.bit0)
    {
        if(++millis >= 1000)
        {
            millis = 0;
            seconds++;
        }
        
        valReg1.bit0 = 0;
    }
}

