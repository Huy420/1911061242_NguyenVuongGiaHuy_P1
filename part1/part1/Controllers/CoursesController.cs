using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using part1.Models;
namespace part1.Controllers
{
    public class CoursesController : Controller
    {

        // GET: Courses
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            BigSchoolContext context = new BigSchoolContext();
            Course objCourse = new Course();
            objCourse.listCategory = context.Categories.ToList();
            return View(objCourse);
        }
        [Authorize]
        [HttpPost]

        public ActionResult Create(Course objCourse)
        {
            BigSchoolContext context = new BigSchoolContext();

            ModelState.Remove("LecturerId");
            if(!ModelState.IsValid)
            {
                objCourse.listCategory = context.Categories.ToList();
                return View("Create", objCourse);
            }    

            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            objCourse.LecturerId = user.Id;

            context.Courses.Add(objCourse);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}