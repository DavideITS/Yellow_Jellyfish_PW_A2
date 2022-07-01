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

#define UPD_DELAY 2
#define TRUE 1
#define FALSE 0
#define BAUDRATE 9600
#define DATASIZE 2
// Register settings

struct {
	unsigned int msTrig : 2;
    unsigned int isSending : 2;
} valReg1;

char picId = 23;
int placeHolder = 0x3E8;

int millis = 0;
int seconds = 0;

char dataArray[DATASIZE] = {0};

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

// ADC functions
void adc_init(void);
int read_analog(void);

void main(void) {
    system_init();
    while(1)
    {
        placeHolder = read_analog();
        PORTD = ADRESL;
        PORTB = ADRESH;
        timer_handler();
        com_handler();
    }
}

void __interrupt() ISR()
{

    if (PIR1bits.RCIF)      // Interrupt RX
    {
        RCREG = 0x00;
        PIR1bits.RCIF = 0;
    }
    
    if (INTCONbits.TMR0IF)     // Interrupt timer
    {
        valReg1.msTrig = 1;
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
    adc_init();
}

void com_handler()
{
    static char currentState = 0;
    static char prevState = 0;
    
    currentState = seconds % UPD_DELAY;
    
    if((!(seconds % UPD_DELAY) && prevState) || valReg1.isSending)
    {
        dataArray[0] = ADRESH;
        dataArray[1] = ADRESL;
        valReg1.isSending = send_array(dataArray);
    }
    
    prevState = seconds % UPD_DELAY;

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

    SPBRG = (_XTAL_FREQ/(long)(16UL*baudrate))-1;
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
        send_byte(array[pos]);
        if(pos < DATASIZE - 1)
            pos++;
        else
        {
            PORTD = 0xF0;
            pos = 0;
            return FALSE;         
        }

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

/*
 * ADC Functions
 */

void adc_init()
{
    TRISAbits.TRISA0 = 1;
    ADCON1 = 0x0E; // Set RA0 as analogic input
    ADCON1bits.ADFM = 1; // Right justified
    ADCON0bits.ADON = 1;    // Enable ADC converter
    ADCON0bits.ADCS0 = 0;
    ADCON0bits.ADCS1 = 1;   // 1:32 frequency conversion
    
    ADCON0bits.CHS0 = 0;
    ADCON0bits.CHS1 = 0;
    ADCON0bits.CHS2 = 0; // Select AN0 (RA0)
}

int read_analog()
{
    static int val = 0;

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