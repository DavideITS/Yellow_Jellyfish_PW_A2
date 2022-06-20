using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace TestRazorApges.Pages
{
    public class SeeWagonModel : PageModel
    {
        List<Dictionary<string, object>> trainList = new List<Dictionary<string, object>>();

        public void OnGet()
        {
            int nrTrain = int.Parse(this.HttpContext.Request.QueryString.Value.Replace("?handler=",""));

            #region MongoDb Train List

            trainList = MongoDb.Client
                    .GetDatabase("trainProjectWork")
                    .GetCollection<Dictionary<string, object>>("Trains")
                   .Find(Builders<Dictionary<string, object>>.Filter.Empty)
                   .ToList();

            #endregion MongoDb Train List

            int nrWagon = int.Parse(trainList.Where(s => int.Parse(s["nrTrain"].ToString()) == nrTrain).Select(s => new string(s["nrWagon"].ToString().ToCharArray())).FirstOrDefault());
        }
    }
}
