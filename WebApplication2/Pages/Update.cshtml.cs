using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication2.Models;

namespace WebApplication2.Pages
{
    public class UpdateModel : PageModel
    {

        [BindProperty]
        public User u { get; set; }

        [BindProperty]
        public int id { get; set; }
        private readonly DB db;
        

        public UpdateModel(DB db)
        {
            this.db = db;

        }
        public void OnGet(int id)
        {
            this.id = id;

            u = db.GetUserInfo(id);
        }

        public IActionResult OnPost()
        {
            u.ID = id;
            db.UpdateUserInfo(u);
            return RedirectToPage("/index");

        }


    }
}
