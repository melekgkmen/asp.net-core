using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Controllers
{
    public class RecordController:Controller
    {
        private readonly DataContext _context;
        public RecordController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var Records=await _context
                .Records
                .Include(x => x.Student)
                .Include(x => x.Course)
                .ToListAsync();
            return View(Records);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Students = new SelectList(await _context.Students.ToArrayAsync(), "StudentId","NameSurname");
            ViewBag.Courses = new SelectList(await _context.Courses.ToArrayAsync(), "CourseId","Title");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Record model)
        {
            model.RecordTime= DateTime.Now;
            _context.Records.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}