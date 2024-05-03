using CrudApp.Models;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.Mvc.Async;

namespace CrudApp.Controllers
{
    public class HomeController : Controller
    {

        TaskEntities DB = new TaskEntities();
        // GET: Home
        public ActionResult Index()
        {
            var Data = DB.PersonInfoes.ToList();
            return View(Data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PersonInfo ps)
        {
            DB.PersonInfoes.Add(ps);
            int Res = DB.SaveChanges();

            if(Res > 0)
            {
                TempData["InsertMsg"] = "<scipt>alert('Inserted Succesfully !!!')</script>";
                return Redirect("Index"); 
            }
            else
            {
                TempData["InsertMsg"] = "<scipt>alert('Having Issue to Insert Data !!!')</script>";
            }
            return View();
        }

        public ActionResult Edit(int Id)
        {
            var Row = DB.PersonInfoes.Where(model => model.ID == Id).FirstOrDefault();
            return View(Row);
        }
        [HttpPost]
        public ActionResult Edit(PersonInfo P)
        {
                DB.Entry(P).State = EntityState.Modified;
                int Res = DB.SaveChanges();
                if (Res > 0)
                {
                    TempData["UpdateMsg"] = "<scipt>alert('Record Updated Succesfully !!!')</scripy>";
                    return Redirect("Index");
                }
                else
                {
                    TempData["UpdateMsg"] = "<scipt>alert('Having Issue to Update Data !!!')</scripy>";
                }
            return View();
        }
        public ActionResult Delete(int Id)
        {
            var DRow = DB.PersonInfoes.Where(model => model.ID == Id).FirstOrDefault();
            return View(DRow);
        }

        [HttpPost]

        public ActionResult Delete(PersonInfo Ps)
        {
                DB.Entry(Ps).State = EntityState.Deleted;
                int Result = DB.SaveChanges();
                if (Result > 0)
                {
                    TempData["DeleteMsg"] = "<scipt>alert('Record Deleted Succesfully !!!')</script>";
                    return Redirect("Index");
                }
                else
                {
                    TempData["DeleteMsg"] = "<scipt>alert('Having Issue to Delete Data !!!')</script>";
                }
            return View();
        }

    }
} 