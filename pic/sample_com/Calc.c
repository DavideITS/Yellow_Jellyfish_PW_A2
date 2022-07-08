/*
 Viotto Davide
 Ci sono problemi con il primo valore negativo
 Il display non è formattato correttamente
 Per confermare il calcolo, si utilizza uno dei due tasti + o -, dopo aver inserito i due numeri*/

// CONFIG
#pragma config FOSC = HS        // Oscillator Selection bits (HS oscillator)
#pragma config WDTE = OFF       // Watchdog Timer Enable bit (WDT disabled)
#pragma config PWRTE = ON       // Power-up Timer Enable bit (PWRT enabled)
#pragma config BOREN = ON       // Brown-out Reset Enable bit (BOR enabled)
#pragma config LVP = ON         // Low-Voltage (Single-Supply) In-Circuit Serial Programming Enable bit (RB3/PGM pin has PGM function; low-voltage programming enabled)
#pragma config CPD = OFF        // Data EEPROM Memory Code Protection bit (Data EEPROM code protection off)
#pragma config WRT = OFF        // Flash Program Memory Write Enable bits (Write protection off; all program memory may be written to by EECON control)
#pragma config CP = OFF         // Flash Program Memory Code Protection bit (Code protection off)

// Flags
#define TRUE 1
#define FALSE 0
#define NULL (void *)0

//Buttons
#define BT_DW 0x01
#define BT_UP 0x02

// Keypad
#define TROWS TRISD
#define ROWS PORTD
#define TCOLS TRISB
#define COLS PORTB

//Timer
#define OFBIT 0x04      //Overflow bit
#define PLTRM0 206        //Timer preload
#define PRESCALL 0x02   //Prescaler 1:8

//LCD PORTS
#define E 0x02 
#define RS 0x04
#define LCDDATA PORTD
#define LCDSYS PORTE
#define TRLCDDATA TRISD
#define TRLCDSYS TRISE

// LCD
#define L_ON 0x0F
#define L_OFF 0x08
#define L_CLR 0x01
#define L_L1 0x80
#define L_L2 0xC0
#define L_CR 0x0F
#define L_NCR 0x0C
#define L_CFG 0x38
#define L_CUR 0x0E
#define _XTAL_FREQ 16000000

#include <xc.h>

char * calc(char);
char * int_to_ChArray(long); // Converte un intero in un array di caratteri
char * string_Formatter(char *, char *); // Rimpiazza i caratteri "\t" nel primo array con i valori del secondo, in ordine
char char_to_Num(char); // Converte un carattere nel suo equivalente numerico
int pow(int, int);
void init_PIC(void);
char readKeyPad(void);
void init_LCD(void);
void send_LCD(char, char);
void string_LCD(char *);
void clear_LCD(void);
void enable_LCD(char);

char keys [13] = {'\0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '0', '-'};
void main()
{
    init_PIC();
    while(TRUE)
    {
        static char oldKp;
        char kp = readKeyPad();
        __delay_ms(10);
        if(kp != oldKp && kp)
        {
            calc(keys[kp]);
        }
        oldKp = kp;

    }
}

char * calc(char digit)
{
    send_LCD(FALSE, digit);
    static char textIndex;
    static char numIndex;
    static int nums[2] = {0};
    static int signs[2] = {0};
    int result;
    if(!nums[0])
    {
        if(digit == '-')
            signs[numIndex] = -1;
        else
            signs[numIndex] = 1;
    }

    if(digit != '-' && digit != '+')
    {
        nums[numIndex] = nums[numIndex] * 10;
        nums[numIndex] =+ char_to_Num(digit);
    }
    
    if((digit == '-' || digit == '+') )
    {
        if(nums[0] && !nums[1])
        {
            numIndex++;
            if(digit == '-')
                signs[numIndex] = -1;
            else
                signs[numIndex] = 1;
        } else 
        {
            result = nums[0] * signs[0] + nums[1] * signs[1];
            clear_LCD();
            
            string_LCD(int_to_ChArray(result));
            nums[0] = 0;
            signs[0] = 0;
            nums[1] = 0;
            signs[1] = 0;
            //string_LCD(string_Formatter(rStr, int_to_ChArray(result)));
        }
    }
    return 0;
}


char * int_to_ChArray(long number)
{
    if(number == 0)
    {
        return "0";
    }
    char numArray[12] = { 0 };
    char i;
    char numStart = 0;
    for(i = 0; i <= 12; i++)
    {
        int digit = number / pow(10, 12-i) % 10;
		
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

char * string_Formatter(char * text, char * vals)
{
    char valIndex = 0;
    for(int i = 0; text[i] != 0; i++)
    {
        if(text[i] == '\t')
        {
            text[i] = vals[valIndex];
            valIndex++;
        }
    }
}

char char_to_Num(char c)
{
        return c - '0';
}


int pow(int numBase, int pwr)
{
    int result = 1;
    for(int i = 0; i < pwr; i++)
    {
        result = result * numBase;
    }
    
    return result;
}

void init_PIC()
{
    INTCON = 0xE0;
    OPTION_REG = PRESCALL;
    TMR0 = PLTRM0;
    TRISB = 0xFF;
    PORTB = 0x00;
    init_LCD();
}

// KEYPAD
char readKeyPad()
{
    TROWS |= 0x0F;
    TCOLS &= ~0x07;
    COLS = 0x00;
    char activeCol = 0x01;
    char activeRow = 0x00;
    char colNum = 0;
    char rowNum = 0;
    for(int i = 0; i < 4; i++){
        COLS = ~activeCol;
        __delay_ms(1);
        if(~(ROWS | ~0x0F))
        {
            
            activeRow = ~(ROWS | ~0x0F);
            for(char k = 1; activeCol > 0; k++)
            {
                colNum = k;
                activeCol >>= 1;
            }
            for(char k = 1; activeRow > 0; k++)
            {
                rowNum = k;
                activeRow >>= 1;
            }
            char result = colNum + ((4-rowNum) * 3);
            
            return result;
        }
        activeCol <<= 1;
    }
    
    return 0;
}

// LCD FUNCTIONS
void init_LCD()
{
    TRLCDDATA = 0x00;
    TRLCDSYS &= ~(E | RS);
    LCDSYS &= ~(E | RS);
    __delay_ms(20);
    enable_LCD(TRUE);
    send_LCD(TRUE, L_CFG);
    __delay_ms(5);
    send_LCD(TRUE, L_CFG);
    __delay_ms(1);
    send_LCD(TRUE, L_CFG);
    send_LCD(TRUE, L_CFG);
    send_LCD(TRUE, L_OFF);
    send_LCD(TRUE, L_ON);
    send_LCD(TRUE, L_CLR);
    send_LCD(TRUE, L_CUR);
    send_LCD(TRUE, L_L1);
}

void enable_LCD(char enable)
{
    if(enable)
        LCDSYS |= E;
    else
        LCDSYS &= ~E;
}

void send_LCD(char isCommand, char byte)
{
    TRLCDDATA = 0x00;
    enable_LCD(TRUE);
    LCDDATA = byte;
    if(isCommand)
        LCDSYS &= ~RS;
    else
        LCDSYS |= RS;
 
    __delay_ms(3);
    enable_LCD(FALSE);
    __delay_ms(3);
    enable_LCD(TRUE);
}

void clear_LCD()
{
    send_LCD(TRUE, 0x01);
}

void string_LCD(char *text)
{
    for(int i = 0;  text[i] != 0; i++)
    {
        if(text[i] == '\n')
        {
                send_LCD(TRUE, 0xC0);
        } else
            send_LCD(FALSE, text[i]);
    }
    
    send_LCD(TRUE, 0x80);
}

void __interrupt() ISR()
{
    if(INTCON&OFBIT)
    {
        INTCON &= ~OFBIT;
        TMR0 = PLTRM0;
    }
}