using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace TrainProjectWorkWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        //Lista degli Utenti, usata per controllare Utente e Password e salvarsi il ruolo
        List<Dictionary<string, object>> userList = new List<Dictionary<string, object>>();

        //Username inserito dall'utente
        [BindProperty]
        public string Username { get; set; }

        //Password inserita dall'utente
        [BindProperty]
        public string Password { get; set; }

        //Errori da mostrare sulla pagina
        [BindProperty]
        public string ErrorToSee { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        //Metodo Get
        public IActionResult OnGet()
        {
            //Reset variabile
            ErrorToSee = "";
            //Controllo se ci sono degli elementi di input
            if (this.HttpContext.Request.QueryString.HasValue)
            {
                //Estrazione contenuto input
                string inputElement = this.HttpContext.Request.QueryString.Value.Replace("?handler=", "");
                //Se si vuole effettuare il Log Out
                if (inputElement.ToLower().Equals("logout"))
                {
                    //Pulizia della cache della sessione
                    HttpContext.Session.Clear();
                    //Return della pagina di login
                    return Page();
                }
            }
            //Get della stringa riguardante il ruolo salvata nella sessione
            var roleFromSession = HttpContext.Session.GetString("role");
            //Se non trova la stringa nella sessione, il valore è null
            if(roleFromSession != null)
            {
                //Controllo se il ruolo è Admin o CapoStazione
                if (roleFromSession.ToLower().Equals("admin") || roleFromSession.ToLower().Equals("stationmaster"))
                {
                    //Redirect su Seetrain
                    return RedirectToPage("SeeTrain");
                }
                else
                {
                    //Get dell'int (verrà convertito in int) riguardante il nr di Treno salvato nella sessione
                    string nrTrainStringFromSession = HttpContext.Session.GetString("nrTrain");
                    //Se non trova la stringa nella sessione, il valore è null
                    if (nrTrainStringFromSession != null)
                    {
                        //Conversione da str ad int
                        int nrTrainFromSession = int.Parse(nrTrainStringFromSession);
                        string nrTrainToPassFromSession = nrTrainFromSession.ToString();

                        //Redirect su SeeWagon in base al nr di treno
                        return RedirectToPage("SeeWagon", nrTrainToPassFromSession);
                    }
                    else
                    {
                        return Page();
                    }
                }
            }
            //Sennò mostra la pagin di Login
            return Page();
        }

        public IActionResult OnPost()
        {
            try
            {
                #region MongoDb User List

                //Lista degli utenti presa da MongoDb
                userList = MongoDb.Client
                        .GetDatabase("trainProjectWork")
                        .GetCollection<Dictionary<string, object>>("Users")
                       .Find(Builders<Dictionary<string, object>>.Filter.Empty)
                       .ToList();

                #endregion MongoDb User List

                //Se ci sono elementi nella lista degli utenti
                if (userList.Count > 0)
                {
                    //Cerca un'associazione utente/password con quelle inserite
                    var searchUser = userList.Where(s => s["nick"].ToString().Equals(Username) && s["password"].ToString().Equals(Password));
                    //Se viene trovata un'associazione
                    if (searchUser.Count() > 0)
                    {
                        //Estrae il ruolo dell'utente
                        string role = searchUser.Select(s => new string(s["role"].ToString())).FirstOrDefault();

                        //Controlla se viene trovato il suo ruolo
                        if (role != null)
                        {
                            //Se il ruolo è admin o capostazione
                            if (role.ToLower().Equals("admin") || role.ToLower().Equals("stationmaster"))
                            {
                                //Salva il ruolo ed il nr del treno sulla Sessione
                                HttpContext.Session.SetString("role", role);

                                //Redirect su Seetrain
                                return RedirectToPage("SeeTrain");
                            }
                            else
                            {
                                #region MongoDb Train List

                                //Lista dei Treni, usata per controllare a quale treno è associato l'utente
                                List<Dictionary<string, object>> trainList = new List<Dictionary<string, object>>();

                                //Lista dei treni presa da MongoDb
                                trainList = MongoDb.Client
                                        .GetDatabase("trainProjectWork")
                                        .GetCollection<Dictionary<string, object>>("Trains")
                                       .Find(Builders<Dictionary<string, object>>.Filter.Empty)
                                       .ToList();

                                #endregion MongoDb Train List

                                //Controllo se ci sono elementi nella lista
                                if (trainList.Count() > 0)
                                {
                                    //Estraggo il nr del treno con lui come conducente
                                    int nrTrain = trainList.Where(s => s["conductor"].ToString().Equals(Username)).Select(s => int.Parse(s["nrTrain"].ToString())).FirstOrDefault();
                                    //Se non c'è nessun treno associato, il valore di nrTrain è 0
                                    if (nrTrain == 0)
                                    {
                                        ErrorToSee = "No trains found for your account";
                                        return Page();
                                    }
                                    //Salva il ruolo ed il nr del treno sulla Sessione
                                    HttpContext.Session.SetString("role", role);
                                    HttpContext.Session.SetString("nrTrain", nrTrain.ToString());
                                    //Conversione del nr del treno per usarlo come dato
                                    string nrTrainToPass = nrTrain.ToString();
                                    return RedirectToPage("SeeWagon", nrTrainToPass);
                                }
                                else
                                {
                                    //Errore di connessione con MongoDb
                                    ErrorToSee = "Error connecting with MongoDb";
                                    return Page();
                                }
                            }
                        }
                    }
                    else
                    {
                        //Utente e Password Errati
                        ErrorToSee = "Wrong User and Password";
                        return Page();
                    }
                }
                else
                {
                    //Errore di connessione con MongoDb
                    ErrorToSee = "Error connecting with MongoDb";
                    return Page();
                }
                //Sennò mostra la pagin di Login
                return Page();
            }
            catch (Exception err)
            {
                ErrorToSee = "Error with MongoDb Connection";
                return Page();
            }
        }
    }
}
