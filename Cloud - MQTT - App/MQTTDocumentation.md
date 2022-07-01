# MQTT

The protocol used is MQTT to transfer the data between gateway (Raspberry PI) and the database (Mongo DB).
We choose this protocol for its easy implementation and its scalability which is necessary to determinate the wagoon thatt is sending the data

Broker:

        Mqtt broker written in c #

Options:

        Ip: same as hivemq
        Nr° Port: 1883

Topic: 

        trainProjectWork/TrainID(numeric)/liveData 2
                                         /command


[gateway]: https://github.com/DavideITS/Yellow_Jellyfish_PW_A2/tree/main/Gateway%20-%20RPI
[database]: https://github.com/DavideITS/Yellow_Jellyfish_PW_A2/tree/main/MongoDb