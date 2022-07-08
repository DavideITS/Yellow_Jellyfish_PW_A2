/*
 * File:   main_LCD_V2.c
 * Author: Marion Francesco
 *
 * Created on 5 novembre 2021, 10.55
 */
#pragma config FOSC = HS        // Oscillator Selection bits (HS oscillator)
#pragma config WDTE = OFF       // Watchdog Timer Enable bit (WDT disabled)
#pragma config PWRTE = ON       // Power-up Timer Enable bit (PWRT enabled)
#pragma config BOREN = ON       // Brown-out Reset Enable bit (BOR enabled)
#pragma config LVP = ON         // Low-Voltage (Single-Supply) In-Circuit Serial Programming Enable bit (RB3/PGM pin has PGM function; low-voltage programming enabled)
#pragma config CPD = OFF        // Data EEPROM Memory Code Protection bit (Data EEPROM code protection off)
#pragma config WRT = OFF        // Flash Program Memory Write Enable bits (Write protection off; all program memory may be written to by EECON control)
#pragma config CP = OFF         // Flash Program Memory Code Protection bit (Code protection off)

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



#include <xc.h>

void send_LCD(char inf, char comando);
void init_LCD(void);
void send_string(char *str);

void scorrimentoMenu(char *,char voci);
void apriPorte(char posMenu);


char currentStateRB0;
char currentStateRB1;
char currentStateRB2;
char currentStateRB3;

char prevStateRB0;
char prevStateRB1;
char prevStateRB2;
char prevStateRB3;

char posMenu;

char voce1[] = "1 temp";
char voce2[] = "2 um  ";
char voce3[] = "3 fumo";
char voce4[] = "4 port";
char m1[4];

char menuPorte[4];

char porta1[] = "port1";
char porta2[] = "port2";
char porta3[] = "port3";
char porta4[] = "port4";
char porte[4];
char portToOpen;

char provaMenu;

char initMenu;

void main(void) {
    init_LCD();
    PORTB = 0;
    m1[0] = voce1;
    m1[1] = voce2;
    m1[2] = voce3;
    m1[3] = voce4;
    
    porte[0] = porta1;
    porte[1] = porta2;
    porte[2] = porta3;
    porte[3] = porta4;

    
    
    while(1)
    {
        currentStateRB2 = !PORTBbits.RB2;
        currentStateRB3 = !PORTBbits.RB3;
        
        if (currentStateRB2 && !prevStateRB2 && provaMenu == 0)
        {
            initMenu = 0;
            provaMenu = 1;
        }
        else if(currentStateRB2 && !prevStateRB2 && provaMenu == 1)
        {
            initMenu = 0;
            provaMenu = 0;
        }
        
        if (provaMenu == 1 )
        {
            scorrimentoMenu(porte, 4);
            if (currentStateRB3 && !prevStateRB3)
            {
                apriPorte(posMenu);
            }
            
        }
        else
        {
            scorrimentoMenu(m1, 4);
        }
        
        prevStateRB2 = currentStateRB2;
        prevStateRB3 = currentStateRB3;
    }
    return;
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
        send_LCD(0, L_L1_C3);
        send_string(m[0]);
        send_LCD(0, L_L2_C3);
        send_string(m[1]);
        initMenu = 1;
    }
    
    if (currentStateRB1 && !prevStateRB1 && posMenu > 0)
      {
        posMenu--;
        send_LCD(0, L_L1_C1);
        send_string(">");
        send_LCD(0, L_L2_C1);
        send_string(" ");
        
        send_LCD(0, L_L1_C3);
        send_string(m[posMenu]);
        send_LCD(0, L_L2_C3);
        send_string(m[posMenu+1]);
        
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
        
        send_LCD(0, L_L1_C3);
        send_string(m[posMenu-1]);
        send_LCD(0, L_L2_C3);
        send_string(m[posMenu]);
      } 
   
    prevStateRB0 = currentStateRB0;   
    prevStateRB1 = currentStateRB1;
    
}

void apriPorte(char portToOpen)
{
    
}


void init_LCD(void){
    TRISE = 0;
    TRISA = 0;
    TRISD = 0;
    TRISB = 0;
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

void send_LCD(char inf, char comando){
    PORTE |= 0x02;
    PORTD = comando;
    if(!inf){
        PORTE &= ~0x04;
    }else{
        PORTE |= 0x04;
    }
    PORTE &= ~0x02;
    PORTE |= 0x02;
}

void send_string(char *str){
    for(unsigned char i=0;str[i]!='\0';i++){
        send_LCD(1, str[i]);
    }
}