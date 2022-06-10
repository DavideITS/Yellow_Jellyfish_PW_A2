from this import d
import serial
import binascii
import time
import threading
import json

ser = serial.Serial()
def initSerial():
    global ser
    ser.baudrate = 9600
    #ser.port = '/dev/ttyUSB0'
    ser.port = 'COM7'
    #ser.timeout =0
    ser.stopbits = serial.STOPBITS_ONE
    ser.bytesize = 8
    ser.parity = serial.PARITY_NONE
    ser.rtscts = 0
    
def write_json(strInput):
    nrTrain = strInput[0]
    nrWagon = strInput[1]
    Temp = strInput[2:4]
    hum = strInput[4:6]
    smoke = strInput[6]
    Toilet = strInput[7] 
    port = [strInput[8],strInput[9],strInput[10],strInput[11]] 
    x = {
    "nrTrain" : nrTrain,
    "nrWagon" : nrWagon,
    "Temp" : Temp,
    "hum" : hum,
    "smoke" : smoke,
    "Toilet" : Toilet,
    "port" : port  
    }

    # convert into JSON:
    y = json.dumps(x,indent=4)

    # the result is a JSON string:
    print(y)






def Read(a):
    initSerial()
    global ser
    ser.open()
    while True:
        
        SerialInput = ser.read(12)
        SerialInput = SerialInput.decode()
        write_json(SerialInput)
        print(SerialInput)#,mHex.decode(),len(mHex),type(mHex),type(mHex[0]),mHex[1])#,binascii.hexlify(bytearray(mHex)))

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
