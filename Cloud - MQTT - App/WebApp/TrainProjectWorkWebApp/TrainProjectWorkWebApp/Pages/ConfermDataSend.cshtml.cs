using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TrainProjectWorkWebApp.Pages
{
    public class ConfermDataSendModel : PageModel
    {
        //Varibile nella quale mostrare la scritta di output
        [BindProperty]
        public string ResultStr { get; set; }

        public void OnGet()
        {
            ResultStr = "Data Send Correctly";
        }
    }
}
