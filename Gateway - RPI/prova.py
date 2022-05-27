import serial
import binascii
import time
import threading

ser = serial.Serial()
def initSerial():
    global ser
    ser.baudrate = 9600
    #ser.port = '/dev/ttyUSB0'
    ser.port = 'COM8'
    #ser.timeout =0
    ser.stopbits = serial.STOPBITS_ONE
    ser.bytesize = 8
    ser.parity = serial.PARITY_NONE
    ser.rtscts = 0

def Read(a):
    initSerial()
    global ser
    ser.open()
    
    
    
    while True:
        mHex = ser.read(4)
        if len(mHex)!= 0:
            print(mHex)#,mHex.decode(),len(mHex),type(mHex),type(mHex[0]),mHex[1])#,binascii.hexlify(bytearray(mHex)))

        time.sleep(0.1)
        
        
def Write(a):
    while True:
        prova = input("enter a string:")
        encoded = prova.encode('utf-8')
        ser.write(encoded)

if __name__ == "__main__":
    a = 1
    thred1 = threading.Thread(target = Read, args = (a,))
    thred1.start()
    thred2 = threading.Thread(target = Write, args = (a,))
    thred2.start()
