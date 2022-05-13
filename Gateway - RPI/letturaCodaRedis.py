#IMPORT:

from datetime import datetime
import redis
import json
import time

#FUNZIONI:

#Funzione per il controllo di connessione con Redis ed estrazione dati dalla Coda
def RedisCheckElement():
    #Connesione a Redis try catch
    try:
        # Collegamento a Redis
        r = redis.Redis(host='localhost', port=6379, db=0)
        # Controllo se la lista ha elementi all'interno
        while (r.llen('NomeCoda')==0):
            print("Nessun elemento è presente in coda")
            #5 secondi di attesa nel caso non ci fossero elementi in coda
            time.sleep( 10 )
        # RPOP dalla lista
        dato = r.lpop('NomeCoda')
        return dato
    except ValueError:
        print("Connessione ad Influx scaduta")
        #5 secondi di attesa
        time.sleep( 10 )
        RedisCheckElement()

#CODICE:

while True:
    #Estrazione dato da Redis
    datoFromRedis = RedisCheckElement()
    #Trasformo dato in stringa per non aver problemi nella conversione
    datoFromRedis = str(datoFromRedis)
    #Tolgo la prima b dalla stringa ed i 2 singoli apici (ad inizio e fine stringa)
    datoFromRedis = datoFromRedis.replace("b", "", 1)
    datoFromRedis = datoFromRedis.replace("'", "")
   
    #Stringa in Json
    convertedFromRedis = json.loads(str(datoFromRedis))

    #Estrazione i dati da Json
    datiEstrattiFromJson = convertedFromRedis['values']

    #ESTRAZIONE DI TUTTI I DATI ED INVIO A MODBUS DA AGGIUNGERE
    #Topic Modbus:  trainProjectWork/idTreno(Numerico)/idPIC(Numerico)/liveData
    
    print("Data sent correctly")
