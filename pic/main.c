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

#define UART_INTCON 0xC0    // Global and peripheral interrupt enabled
#define UART_PIE1 0x22      //

typedef struct {
	unsigned int msTrig : 1;
}valReg;

valReg valReg1;
char picId = 0x01;
int placeHolder = 768;

int millis = 0;
int seconds = 0;

char dataArray[64];

char boolReg = 0;
/*
 * 1 = device is sending data
 * 2 = send trigger state
 * 8 = millis interrupt
 */

void send_byte(char);
void send_array(char *);
void timer_handler(void);
void com_handler(void);
char id_request(void);

void system_init(void);
void uart_init(int);
void timer_init(void);
void adc_init(void);

void main(void) {
    system_init();
    while(1)
    {
        send_array('a');
    }
}

void send_byte(char byte)
{
    if(TXIF)
        TXREG = byte;
}

void send_array(char * array)
{
    static char pos = 0;
    boolReg |= 0x01;
    if(TXIF)
    {
        send_byte(array[pos]);
        // PORTB = array[pos];
        if(array[pos] == '\0')
        {
            pos = 0;
            boolReg &= !0x01;
        }
        else

            pos++;
    }
}

void timer_handler()
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

void com_handler()
{   
    if((!(seconds % UPD_DELAY) && (boolReg & 0x02)) || boolReg & 0x01)
    {
        char str[] = "prova";
        send_array(str);
    }

    if(!(seconds % UPD_DELAY))
        boolReg &= ~0x02;
    else
        boolReg |= 0x02;

}

char id_request()
{
    
}
void system_init()
{
    TRISB = 0x00;
    TRISD = 0x00;
    PORTD = 0x00;
    INTCONbits.GIE = 1; // Enable global interrupt
    INTCONbits.PEIE = 1; // Enable peripheral interrupt 
    uart_init(9600);
}

void uart_init(int baudrate)
{
    // Interrupt configuration
    INTCONbits.TMR0IE = 1;

    PIE1bits.TXIE = 1; // Enable TX interrupt
    PIE1bits.RCIE = 1; // Enable RC interrupt

    TRISCbits.TRISC7 = 1; // Set RC7 to input (RC)
    TRISCbits.TRISC6 = 0; // Set RC6 to output (TX)

    RCSTAbits.SPEN = 1; // Enable serial port
    RCSTAbits.CREN = 1;
    TXSTAbits.TXEN = 1; // Enable transmission


    SPBRG = (_XTAL_FREQ/(long)(64UL*baudrate))-1;
}

void timer_init()
{

    OPTION_REGbits.T0CS = 0;    // Select internal clock
    OPTION_REGbits.PS1 = 1;     // Prescaler to 1:8
    TMR0 = 6;                   // Preload
}

void __interrupt() ISR()
{
    if (PIR1bits.TXIF)  // Interrupt TX
    {

    }
  
    if (PIR1bits.RCIF)  // Interrupt RX
    {
        PORTB = 0xF0;
        PIR1bits.RCIF = 0;
        PORTD = RCREG;
    }
    
    if (INTCONbits.TMR0IF)  // Interrupt timer
    {
        valReg1.msTrig = 1;
        INTCONbits.TMR0IF = 0;
    }

}