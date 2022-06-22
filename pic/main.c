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
#define UPD_DELAY 3
#define TRUE 1
#define FALSE 0
#define BAUDRATE 9600

// Register settings

#define UART_INTCON 0xC0    // Global and peripheral interrupt enabled
#define UART_PIE1 0x22      //


char picId = 0x01;
int placeHolder = 768;
int millis = 0;
int seconds = 0;
char dataArray[64];
char counter = 0x02;

char boolReg = 0;
/*
 * 1 = device is sending data
 * 2 = send trigger state
 * 8 = millis interrupt
 */

void send_byte(char);
void send_array(char *);
void timer_handler();
void com_handler();
char id_request();
void init_UART(int);
void init_Timer();
void init_ADC();

void main(void) {
    TRISB = 0x00;
    TRISD = 0x00;
    TRISE = 0x00;
    PORTE = 0xFF;
    init_Timer();
    init_UART(BAUDRATE);
    while(1){
        timer_handler();
        com_handler();
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
    if(boolReg & 0x80)
    {
        if(++millis >= 1000)
        {
            millis = 0;
            seconds++;
        }
        
        boolReg &= ~0x80;
    }
}

void com_handler()
{   
    if((!(seconds % UPD_DELAY) && (boolReg & 0x02)) || boolReg & 0x01)
    {
        char str[] = "prova";
        send_array(str);
    }

    if(!(seconds % UPD_DELAY) && (boolReg & 0x02))
        counter++;

    if(!(seconds % UPD_DELAY))
        boolReg &= ~0x02;
    else
        boolReg |= 0x02;

}

char id_request()
{
    
}

void init_UART()
{
    // Interrupt configuration
    INTCON |= UART_INTCON;
    PIE1 |= 0x22;
    TRISC |= 0x80; // set RC7 to input (RX)
    TRISC &= !0x40; // RC6 to output (TX)

    TXSTA = 0x24;
    RCSTA |= 0x90;

    SPBRG = (_XTAL_FREQ/(long)(64UL*BAUDRATE))-1;
}

void init_Timer()
{
    INTCON |= 0xA0;
    OPTION_REG &= ~0x3C;
    OPTION_REG |= 0x03;
    TMR0 = TMR_PRE;
}

void __interrupt() ISR()
{
    if (TXIF)
    {
        PORTB = 0xFF;
    }
  
    if (RCIF){ // Interrupt RX
        RCIF = 0;
        PORTD = RCREG;
    }
    
    if (INTCON & 0x04) // Interrupt timer
    {
        boolReg |= 0x80;
        INTCON &= ~0x04;
    }

}