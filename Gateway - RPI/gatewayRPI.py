from this import d
import serial
import redis
import time
import threading
import json
import requests
import paho.mqtt.client as paho

#creazione variabile per utilizzare la porta seriale
ser = serial.Serial()

#creazione oggetto per utilizzare redis
r = redis.Redis(host='127.0.0.1', port=6379, db=0)

#broker mqtt
brokerMQTT="broker.hivemq.com"                          
portMQTT=1883
client1= paho.Client("nomeClientPub")                    #create client object
client1.username_pw_set("myTestAppPub", "testPassword000")
def on_publish(client,userdata,result):             #create function for callback
    print("Data published \n")
    pass
client1.on_publish = on_publish                    #assign function to callback

def initSerial():
    global ser
    ser.baudrate = 9600
    #ser.port = '/dev/ttyUSB0'
    ser.port = 'COM5'
    #ser.timeout =0
    ser.stopbits = serial.STOPBITS_ONE
    ser.bytesize = 8
    ser.parity = serial.PARITY_NONE
    ser.rtscts = 0
    
def write_json(strInput):
    nrWagon = int.from_bytes(strInput[0], "big")
    Temp = int.from_bytes(strInput[1]+strInput[2], "big") 
    hum = int.from_bytes(strInput[3]+strInput[4], "big") 
    smoke = int.from_bytes(strInput[5]+strInput[6], "big") 
    ToiletPort = int.from_bytes(strInput[7], "big")
    ToiletPort = bin(ToiletPort)
    
    jsonData = {
    "nrWagon" : nrWagon,
    "Temp" : Temp,
    "Hum" : hum,
    "Smoke" : smoke,
    "Port1" : ToiletPort[4+2],
    "Port2" : ToiletPort[3+2],
    "Port3" : ToiletPort[2+2],
    "Port4" : ToiletPort[1+2],
    "Toilette" : ToiletPort[0+2]
    }

    # convert into JSON:
    jsonDataString = json.dumps(jsonData,indent=4)

    # the result is a JSON string:
    print(jsonDataString)

    RedisInsertElement(jsonDataString)
    while(CheckConnection() and r.llen("NomeCoda")>0):
        PublishMQTT(RedisCheckElement())
        




def Read(a):
    initSerial()
    global ser
    ser.open()
    while True:
        messaggio = []
        for item in range(0,8):
            SerialInput = ser.read(1)
            messaggio.append(SerialInput)
        write_json(messaggio)
        
        time.sleep(0.1)


def Write(a):
    while True:
        prova = input("enter a string:")
        encoded = prova.encode('utf-8')
        ser.write(encoded)
        
        
def RedisInsertElement(testjson):
    #Connesione a Redis try catch
    try:
        #testjson = "test"
        dato = r.rpush('NomeCoda', testjson)
        print("dato inserito in coda")
        return dato
    except ValueError:
        print("Connection Error with Redis.")
        #5 secondi di attesa
        time.sleep( 10 )
        RedisInsertElement()

def RedisCheckElement():
    #Connesione a Redis try catch
    try:
        # Collegamento a Redis
        # Controllo se la lista ha elementi all'interno
        while (r.llen('NomeCoda')==0):
            print("There are no items in the Redis Queue.")
            #5 secondi di attesa nel caso non ci fossero elementi in coda
            time.sleep( 10 )
        # RPOP dalla lista
        dato = r.lpop('NomeCoda')
        return dato
    except ValueError:
        print("Connection Error with Redis.")
        #5 secondi di attesa
        time.sleep( 10 )
        RedisCheckElement()
        


def PublishMQTT(Jsonstrin):
    client1.connect(brokerMQTT,portMQTT)                        #establish connection
    client1.publish("trainProjectWork/1/liveData",Jsonstrin)            #publish

def CheckConnection():
    url = "http://www.hivemq.com"
    timeout = 5
    try:
        request = requests.get(url, timeout=timeout)
        return(True)
    except (requests.ConnectionError, requests.Timeout) as exception:
        print("No internet connection.")
        return(False)

if __name__ == "__main__":
    a = 1
    thred1 = threading.Thread(target = Read, args = (a,))
    thred1.start()
    thred2 = threading.Thread(target = Write, args = (a,))
    thred2.start()
