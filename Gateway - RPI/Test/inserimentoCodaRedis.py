#IMPORT:

from datetime import datetime
import redis
import json
import time

#FUNZIONI:

#Funzione per il controllo di connessione con Redis ed estrazione dati dalla Coda
def RedisInsertElement():
    #Connesione a Redis try catch
    try:
        # Collegamento a Redis
        r = redis.Redis(host='127.0.0.1', port=6379, db=0)
        # RPUSH dalla lista (VALORE DA CAMBIARE)
        testjson = "{\"NrTrain\": 1, \"NrWagon\": 1, \"Temp\": 20.5, \"Hum\": 50.1, \"Gas\": True}"
        #testjson = "test"
        dato = r.rpush('NomeCoda', testjson)
        return dato
    except ValueError:
        print("Connection Error with Redis.")
        #5 secondi di attesa
        time.sleep( 10 )
        RedisInsertElement()

#CODICE:

RedisInsertElement()
    
print("Data sent correctly.")