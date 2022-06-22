using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Microsoft.AspNetCore.Http;

namespace TestRazorApges.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        List<Dictionary<string, object>> userList = new List<Dictionary<string, object>>();

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string textToChange { get; set; }

        [BindProperty]
        public int variableToPass { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            //Null se non c'è, se c'è reindirizzo in base al ruolo
            var testSession = HttpContext.Session.GetString("role");
            var nrTrainFromSession = HttpContext.Session.GetString("nrTrain");
        }

        public IActionResult OnPost()
        {

            textToChange = "Riuscito";

            #region MongoDb User List

            userList = MongoDb.Client
                    .GetDatabase("trainProjectWork")
                    .GetCollection<Dictionary<string, object>>("Users")
                   .Find(Builders<Dictionary<string, object>>.Filter.Empty)
                   .ToList();

            #endregion MongoDb User List

            if (userList.Count > 0)
            {
                var searchUser = userList.Where(s => s["nick"].ToString().Equals(Username) && s["password"].ToString().Equals(Password));
                if (searchUser.Count() > 0)
                {
                    Console.WriteLine("Login Corretto");
                    string role = searchUser.Select(s => new string(s["role"].ToString())).FirstOrDefault();
                    HttpContext.Session.SetString("role", role);
                    HttpContext.Session.SetString("nrTrain", "1");
                    return RedirectToPage("SeeWagon","1");
                }
                else
                {
                    Console.WriteLine("Login Non Avvenuto");
                    return Page();
                }
            }
            else
            {
                return Page();
            }

        }

        
    }
}
