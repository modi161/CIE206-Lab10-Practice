using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication2.Models;

namespace WebApplication2.Pages
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public int id { get; set; }
        private readonly DB db;

        public DeleteModel(DB db)
        {
            this.db = db;
        }
        public void OnGet(int id)
        {
            this.id = id;
        }

        public IActionResult OnPost()
        {
            db.DeleteUser(id);
            return RedirectToPage("/index");

        }




    }
}
