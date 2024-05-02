using System.Reflection.Metadata;
using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Controllers
{
    public class TeacherController: Controller
    {
        private readonly DataContext _context;
        public TeacherController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Teachers.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Teacher model)
        {
            _context.Teachers.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

         [HttpGet]
        public async Task<IActionResult> Edit (int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

            var tea=await _context
                                .Teachers
                                .FirstOrDefaultAsync(s=> s.TeacherId==id);
            //var std=await _context.Students.FirstOrDefaultAsync(s => s.StudentId==id);

            if(tea==null)
            {
                return NotFound();
            }

            return View(tea);       
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Teacher model)
        {
            if(id != model.TeacherId)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
               try
               {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
               }
               catch(DbUpdateConcurrencyException)
               {
                    if(!_context.Students.Any(s => s.StudentId==model.TeacherId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
               }
               return RedirectToAction("Index");
            }
             return View(model);
        }

        [HttpGet]

        public async Task<IActionResult> Delete (int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            
            if(student==null)
            {
                return NotFound();
            }

            return View(student);
        }

    }
}