using System.Linq;
using System.Web.Mvc;
using Login.Models;

namespace Login.Controllers
{
    public class ExampleController : Controller
    {
        public ViewResult AllStudents()
        {
            var context = new MiniEntities();
            var model = context.HostelDatas.ToList();
            return View(model);
        }

        public ViewResult Find(string id)
        {
            int RollNo = int.Parse(id);
            var context = new MiniEntities();
            var model = context.HostelDatas.FirstOrDefault((e) => e.RollNo == RollNo);
            return View(model);

        }
        [HttpPost]
        public ActionResult Find(HostelData stu)
        {
            var context = new MiniEntities();
            var model = context.HostelDatas.FirstOrDefault((e) => e.RollNo == stu.RollNo);
            model.Name = stu.Name;
            model.RoomNo = stu.RoomNo;
            model.HostelName = stu.HostelName;
            model.ContactNo = stu.ContactNo;
            context.SaveChanges();
            return RedirectToAction("AllStudents");
        }

        public ViewResult NewStudent()
        {
            var model = new HostelData();
            return View(model);
        }

        [HttpPost]

        public ActionResult NewStudent(HostelData stu)
        {
            var context = new MiniEntities();
            context.HostelDatas.Add(stu);
            context.SaveChanges();
            return RedirectToAction("AllStudents");
        }
        public ActionResult Delete(string id)
        {
            int RollNo = int.Parse(id);

            var context = new MiniEntities();
            var model = context.HostelDatas.FirstOrDefault((e) => e.RollNo == RollNo);
            context.HostelDatas.Remove(model);
            context.SaveChanges();
            return RedirectToAction("AllStudents");
        }

    }
}