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

void init_UART(int);

void main(void) {
    //TRISB = 0x00;
    //PORTB = 0x00;
    init_UART(9600);
    while(1){
        __delay_ms(500);
        while(TXIF);
        TXREG = 'a';
        while(!(TXSTA & 0x02));

    }

    
}

void init_UART(int baudRate)
{
    // Interrupt configuration
    INTCON = 0xC0;
    PIE1 |= 0x02;
    
    TRISC |= 0x80; // set RC7 to input (RX)
    TRISC &= !0x40; // RC6 to output (TX)
    TXSTA = 0x24;
    RCSTA |= 0x80;
    SPBRG = (_XTAL_FREQ/(long)(64UL*baudRate))-1;
}

void __interrupt() ISR()
{
    
}