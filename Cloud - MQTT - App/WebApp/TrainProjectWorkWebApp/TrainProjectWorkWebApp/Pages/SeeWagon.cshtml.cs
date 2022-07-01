using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace TrainProjectWorkWebApp.Pages
{
    public class SeeWagonModel : PageModel
    {
        //Lista dei Treni filtrata con solo l'ultimo dato salvato per ogni vagone
        [BindProperty]
        public List<Dictionary<string, object>> trainLiveDataFilterList { get; set; }

        //Lista dei Treni, usata per trovare il numero di vagoni di ogni treno
        List<Dictionary<string, object>> trainList = new List<Dictionary<string, object>>();
        //Lista dei dati salvati inviati dal treno
        List<Dictionary<string, object>> trainLiveDataList = new List<Dictionary<string, object>>();

        //Nr del treno
        [BindProperty]
        public int nrTrain { get; set; }

        //Nr del vagone
        [BindProperty]
        public int nrWagon { get; set; }

        //Errori da mostrare sulla pagina
        [BindProperty]
        public string ErrorToSee { get; set; }

        public void OnGet()
        {

            try
            {
                //Estrazione del Nr del treno dall'url
                nrTrain = int.Parse(this.HttpContext.Request.QueryString.Value.Replace("?handler=", ""));

                if (nrTrain == 0)
                {
                    RedirectToPage("Index");
                }

                #region MongoDb Train List

                //Lista dei treni presa da MongoDb
                trainList = MongoDb.Client
                        .GetDatabase("trainProjectWork")
                        .GetCollection<Dictionary<string, object>>("Trains")
                       .Find(Builders<Dictionary<string, object>>.Filter.Empty)
                       .ToList();

                #endregion MongoDb Train List

                //Estrazione dal Nr di vagoni da trainList
                nrWagon = int.Parse(trainList.Where(s => int.Parse(s["nrTrain"].ToString()) == nrTrain).Select(s => new string(s["nrWagon"].ToString().ToCharArray())).FirstOrDefault());

                #region MongoDb Get Data

                //Lista dei dati dei treni presa da MongoDb
                trainLiveDataList = MongoDb.Client
                        .GetDatabase("trainProjectWork")
                        .GetCollection<Dictionary<string, object>>("TrainLiveData")
                       .Find(Builders<Dictionary<string, object>>.Filter.Empty)
                       .ToList();

                //Lista in cui verranno salvati i dati filtrati da trainLiveDataList
                //Verrà salvato solo l'ultimo dato di ogni vagone del treno interessato 
                trainLiveDataFilterList = new List<Dictionary<string, object>>();

                //For per il nr di Vagoni
                for (int i = 1; i <= nrWagon; i++)
                {
                    //Creazione dizionario con gli ultimi dati del vagone i
                    Dictionary<string, object> objToInsert = trainLiveDataList
                        .Where(s => s["nrTrain"].ToString().Equals(nrTrain.ToString()) && s["nrWagon"].ToString().Equals(i.ToString()))
                        .OrderByDescending(s => s["date"])
                        .FirstOrDefault();

                    //Aggiunta dell'oggetto estratto nella lista dei dati filtrati
                    trainLiveDataFilterList.Add(objToInsert);
                }

                #endregion MongoDb Get Data
            }
            catch (System.Exception err)
            {
                ErrorToSee = "Error with MongoDb Connection";
                //Errori da mostrare sulla pagina

                trainLiveDataFilterList = new List<Dictionary<string, object>>();
            }
        }
    }
}
