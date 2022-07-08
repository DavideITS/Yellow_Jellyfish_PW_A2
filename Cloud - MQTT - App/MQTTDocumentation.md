# MQTT

The protocol used is MQTT to transfer the data between [gateway](..//Gateway%20-%20RPI//gatewayDocumentation.md) (Raspberry PI) and the [database](MongoDbDocumentation.md) (Mongo DB).
We choose this protocol for its easy implementation and its scalability which is necessary to determinate the wagoon thatt is sending the data

-- --

## Broker

The Mqtt broker used is hivemq because it's one of the best free and online broker, the pub/sub logic is written in C#

-- --

## Connection Options

        Ip: broker.hivemq.com
        Nr° Port: 1883

-- --

## Pub/Sub Topic Levels


        trainProjectWork/TrainID(numeric)/liveData
                                         /command

        |____Level1_____|____Level2______|_Level3_|

### Level 1

This first level of the Topic never change and is the name of the project

### Level 2

The second second of the Topic is the numeric ID of the train that is sending the data or the train to send the command

### Level 3

The third level of the Topic set the mode that is in use:

- **liveData** to send a message from the Gateway to the DB stored in Cloud

- **command** to send a message from the DB stored in Cloud to the Gateway

-- --

## JSON-LiveData Message Example

                {
                        "nrWagon" :1,
                        "Temp" :22.6,
                        "Hum" :59.0,
                        "Smoke" :false,
                        "Toilette" :true,
                        "Port" :[
                                false,
                                false,
                                false,
                                false
                        ]
                }

                {
                        "nrWagon" :1,
                        "Temp" :24,1,
                        "Hum" :59.0,
                        "Smoke" :false,
                        "Toilette" :true,
                        "Port1" :false,
                        "Port2" :true,
                        "Port3" :true,
                        "Port4" :false,
                }

When this message is received it is saved on the MongoDB database, it is also a check of the variable if there is some incongruention with the accepted value an error message is sent to the Telegram Group

-- --

## JSON-Command Message Example

Example for a change of temperature

                {
                        "nrTrain" :1,
                        "nrWagon" :1,
                        "change" :"Temp",
                        "newValue" :23
                }

Example for a change of port status(close to open or vice versa)


                {
                        "nrTrain" :1,
                        "nrWagon" :1,
                        "change" :"Port1",
                        "newValue" :true
                }