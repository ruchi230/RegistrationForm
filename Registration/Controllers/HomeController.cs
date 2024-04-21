using Registration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Registration.Controllers
{
    public class HomeController : Controller
    {
        private db_StudentEntities db = new db_StudentEntities();
        public ActionResult AddDetails()
        {
            ViewBag.list = db.tbl_Student;
            return View();
        }
        [HttpPost]
        public ActionResult AddDetails(FormCollection fc)
        {
            ViewBag.list = db.tbl_Student;
            tbl_Student student = new tbl_Student();

            student.FirstName = fc["FirstName"];
            student.LastName = fc["LastName"];
            student.EmailId = fc["Email"];
            student.Mobile = fc["Mobile"];
            student.Gender = fc["Gender"];
            student.City = fc["City"];
            student.Address = fc["Address"];
            student.Course = fc["Course"];
            student.Fees = int.Parse(fc["Fees"]);

           db.tbl_Student.Add(student);
           db.SaveChanges();

            ViewBag.msg = "Student details saved successfully";

            return View();
        }
    }
}