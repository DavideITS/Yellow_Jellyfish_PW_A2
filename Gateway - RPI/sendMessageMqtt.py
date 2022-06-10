import paho.mqtt.client as paho

broker="localhost"                              #Da Cambiare
port=707
def on_publish(client,userdata,result):             #create function for callback
    print("Data published \n")
    pass
client1= paho.Client("nomeClientPub")                    #create client object
client1.username_pw_set("myTestAppPub", "testPassword000")
client1.on_publish = on_publish                     #assign function to callback
client1.connect(broker,port)                        #establish connection
client1.publish("trainProjectWork/4/1/liveData","dataIntoMessageToSend")            #publish