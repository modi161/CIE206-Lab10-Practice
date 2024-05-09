using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication2.Models;

namespace WebApplication2.Pages
{
    public class createModel : PageModel
    {


        [BindProperty]
        public User u { get; set; }

        private readonly DB db;


        public createModel(DB db) 
        { 
            this.db = db;
        }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {

            db.AddUser(u);

            return RedirectToPage("/Index");
        }




    }
}
