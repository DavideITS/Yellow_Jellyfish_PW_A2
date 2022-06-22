using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;
using System.Collections.Generic;

namespace TrainProjectWorkWebApp.Pages
{
    public class SeeTrainModel : PageModel
    {
        //Lista dei Treni, usata per trovare il numero di vagoni di ogni treno
        [BindProperty]
        public List<Dictionary<string, object>> trainList { get; set; }

        public void OnGet()
        {
            #region MongoDb Train List

            trainList = new List<Dictionary<string,object>>();

            //Lista dei treni presa da MongoDb
            trainList = MongoDb.Client
                    .GetDatabase("trainProjectWork")
                    .GetCollection<Dictionary<string, object>>("Trains")
                   .Find(Builders<Dictionary<string, object>>.Filter.Empty)
                   .ToList();

            #endregion MongoDb Train List

        }
    }
}
