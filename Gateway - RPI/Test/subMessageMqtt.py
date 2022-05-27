import paho.mqtt.client as paho

broker="localhost"                              #Da Cambiare
port=707

def on_message(client, userdata, msg):  # The callback for when a PUBLISH message is received from the server.
    dataPayload = str(msg.payload)  #Da modificare
    print("Message received-> " + msg.topic + " " + dataPayload)  # Print a received msg

client1= paho.Client("nomeClientSub")                    #create client object
client1.username_pw_set("myTestAppSub", "testPassword000")
client1.on_message = on_message                     #assign function to callback
client1.connect(broker,port)                        #establish connection
client1.subscribe("trainProjectWork/#")                  #sub
client1.loop_forever()