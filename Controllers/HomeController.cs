using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using task22.Models;

namespace task22.Controllers
{
    public class HomeController : Controller
    {
        StudentsDbContext db = new StudentsDbContext();


        //the first parameter is the option that we choose and the second parameter will use the textbox value  
        public ActionResult Index(string option, string search , int? pageNumber)
        {

            //if a user choose the radio button option as Subject
            if (option == "Male")
            {
                return View(db.Students.Where(x => x.Name.StartsWith(search) && x.Gender == "Male" || search == null).ToList().ToPagedList(pageNumber ??  1,10));

            }
            else if(option == "Female")
            {
                return View(db.Students.Where(x => x.Name.StartsWith(search) && x.Gender == "Female" || search == null).ToList().ToPagedList(pageNumber ?? 1, 10));
            }
            else
            {
                return View(db.Students.Where(x => x.Name.StartsWith(search) || search == null).ToList().ToPagedList(pageNumber ?? 1, 10));
            }
        }
    }
}