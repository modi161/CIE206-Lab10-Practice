using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication2.Models;
using System.Data;

namespace WebApplication2.Pages

{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private DB DB { get; set; }
        public List<User> Users { get; set; } = new List<User>();

        public DataTable dt { get; set; }


        public IndexModel(ILogger<IndexModel> logger, DB db)
        {
            _logger = logger;
            this.DB = db;
        }


        public void OnGet()
        {
            dt = DB.ReadTable("Users");

            for(int i = 0; i < dt.Rows.Count; i++)
            {

                User u = new User();

                u.ID = (int)dt.Rows[i]["id"];
                u.Fname = (string)dt.Rows[i]["First_name"];
                u.Lname = (string)dt.Rows[i]["Last_name"];
                u.Email = (string)dt.Rows[i]["Email"];
                u.Gender = (string)dt.Rows[i]["Gender"];

                Users.Add(u);
            }

        }


    }
}