/*
 * File:   SerialCom2.c
 * Author: Francesco
 *
 * Created on 3 dicembre 2021, 11.40
 */

// CONFIG
#pragma config FOSC = HS        // Oscillator Selection bits (HS oscillator)
#pragma config WDTE = OFF       // Watchdog Timer Enable bit (WDT disabled)
#pragma config PWRTE = ON       // Power-up Timer Enable bit (PWRT enabled)
#pragma config BOREN = ON       // Brown-out Reset Enable bit (BOR enabled)
#pragma config LVP = ON         // Low-Voltage (Single-Supply) In-Circuit Serial Programming Enable bit (RB3/PGM pin has PGM function; low-voltage programming enabled)
#pragma config CPD = OFF        // Data EEPROM Memory Code Protection bit (Data EEPROM code protection off)
#pragma config WRT = OFF        // Flash Program Memory Write Enable bits (Write protection off; all program memory may be written to by EECON control)
#pragma config CP = OFF         // Flash Program Memory Code Protection bit (Code protection off)

// #pragma config statements should precede project file includes.
// Use project enums instead of #define for ON and OFF.

#include <xc.h>
#define _XTAL_FREQ 20000000
#define SFT_SER 0x08
#define SFT_SCK 0x02
#define SFT_EN 0x04

char ReceivedMessage;
void initUart(int BD);


void initUart(int BD){
    TRISC=0x80;
    TRISB=0x00;
    TXSTA |= 0b00100010;
    RCSTA |= 0b10010000;
    SPBRG = (_XTAL_FREQ/(long)(64UL*BD))-1;
}

void SendData(char Value){
    while(!(TXSTA & 0x02));
    TXREG = Value;
    while(!(TXSTA & 0x02));
}

void __interrupt() ISR(){
    if (RCIF){
        RCIF = 0;
        ReceivedMessage = RCREG;
    }
}

void main(void) {
    INTCON |= 0b11000000;
    PIE1 |= 0b00100000;
    
    initUart(9600);
    char Message;
    Message = 'a';
    while(1){
        SendData(Message);
    }
    /*PORTB = 0x00;
    while(1)
        PORTB = ReceivedMessage;*/
}
