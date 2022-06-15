#pragma config FOSC = HS        // Oscillator Selection bits (HS oscillator)
#pragma config WDTE = OFF       // Watchdog Timer Enable bit (WDT disabled)
#pragma config PWRTE = ON       // Power-up Timer Enable bit (PWRT enabled)
#pragma config BOREN = ON       // Brown-out Reset Enable bit (BOR enabled)
#pragma config LVP = ON         // Low-Voltage (Single-Supply) In-Circuit Serial Programming Enable bit (RB3/PGM pin has PGM function; low-voltage programming enabled)
#pragma config CPD = OFF        // Data EEPROM Memory Code Protection bit (Data EEPROM code protection off)
#pragma config WRT = OFF        // Flash Program Memory Write Enable bits (Write protection off; all program memory may be written to by EECON control)
#pragma config CP = OFF         // Flash Program Memory Code Protection bit (Code protection off)


#include <xc.h>
#define _XTAL_FREQ 16000000
#define TMR_PRE 6

char picId = 0x01;
int placeHolder = 768;
int millis = 0;
int seconds = 0;
char dataArray[64];


void send_byte(char);
char send_array(char *);
void send_update();
void init_UART(int);
void init_Timer();

void main(void) {
    TRISB = 0x00;
    TRISD = 0x00;
    TRISE = 0x00;
    PORTE = 0xFF;
    init_Timer();
    init_UART(9600);
    while(1){
        char str[] = "prova";
        if(!(seconds % 1))
            while(send_array(str));
    }

}

void send_byte(char byte)
{
    if(TXIF)
        TXREG = byte;
}

char send_array(char * array) // returns 0 if all data is sent
{
    static char pos = 0;

    if(TXIF)
    {
        send_byte(array[pos]);
        PORTB = array[pos];
        if(array[pos] == '\0')
        {
            pos = 0;
            return 0x00;
        }
        else
            pos++;
    }
    return 0xFF;
}

void init_Timer()
{
    INTCON |= 0xA0;
    OPTION_REG &= ~0x3C;
    OPTION_REG |= 0x03;
    TMR0 = TMR_PRE;
}

void init_UART(int baudRate)
{
    // Interrupt configuration
    INTCON |= 0xC0;
    PIE1 |= 0x22;
    TRISC |= 0x80; // set RC7 to input (RX)
    TRISC &= !0x40; // RC6 to output (TX)

    TXSTA = 0x24;
    RCSTA |= 0x90;

    SPBRG = (_XTAL_FREQ/(long)(64UL*baudRate))-1;
}

void __interrupt() ISR()
{
    if (RCIF){ // Interrupt RX
        RCIF = 0;
        PORTD = RCREG;
    }
    
    if (INTCON & 0x04) // Interrupt timer
    {
        if(++millis >= 1000)
        {
            millis = 0;
            seconds++;
        }
    INTCON &= ~0x04;
    }

}