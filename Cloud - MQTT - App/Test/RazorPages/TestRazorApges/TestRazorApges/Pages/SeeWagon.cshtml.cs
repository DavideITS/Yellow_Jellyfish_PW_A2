using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;
using MQTTnet;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client.Options;
using MQTTnet.Extensions.ManagedClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestRazorApges.Pages
{
    public class SeeWagonModel : PageModel
    {
        [BindProperty]
        public List<Dictionary<string, object>> trainLiveDataFilterList { get; set; }

        List<Dictionary<string, object>> trainList = new List<Dictionary<string, object>>();
        List<Dictionary<string, object>> trainLiveDataList = new List<Dictionary<string, object>>();

        [BindProperty]
        public int nrTrain { get; set; }

        [BindProperty]
        public int nrWagon { get; set; }

        [BindProperty]
        public string mqttTest { get; set; }

        public void OnGet()
        {
            #region Get Role in Http Session

            var role = HttpContext.Session.GetString("role");

            #endregion Get Role in Http Session

            nrTrain = int.Parse(this.HttpContext.Request.QueryString.Value.Replace("?handler=", ""));

            #region MongoDb Train List

            trainList = MongoDb.Client
                    .GetDatabase("trainProjectWork")
                    .GetCollection<Dictionary<string, object>>("Trains")
                   .Find(Builders<Dictionary<string, object>>.Filter.Empty)
                   .ToList();

            #endregion MongoDb Train List

            nrWagon = int.Parse(trainList.Where(s => int.Parse(s["nrTrain"].ToString()) == nrTrain).Select(s => new string(s["nrWagon"].ToString().ToCharArray())).FirstOrDefault());

            #region MongoDb Get Data

            trainLiveDataList = MongoDb.Client
                    .GetDatabase("trainProjectWork")
                    .GetCollection<Dictionary<string, object>>("TrainLiveData")
                   .Find(Builders<Dictionary<string, object>>.Filter.Empty)
                   .ToList();

            trainLiveDataFilterList = new List<Dictionary<string, object>>();
            for (int i = 1; i <= nrWagon; i++)
            {
                Dictionary<string, object> objToInsert = trainLiveDataList
                    .Where(s => s["nrTrain"].ToString().Equals(nrTrain.ToString()) && s["nrWagon"].ToString().Equals(i.ToString()))
                    .OrderByDescending(s => s["date"])
                    .FirstOrDefault();

                trainLiveDataFilterList.Add(objToInsert);
            }

            #endregion MongoDb Get Data
        }
    }
}
