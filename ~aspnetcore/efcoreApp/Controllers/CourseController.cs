using efcoreApp.Data;
using efcoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace efcoreApp.Controllers
{
    public class CourseController:Controller
    {
        private readonly DataContext _context;
        public CourseController(DataContext context)
        {
            _context =context;
        }

        public async Task<IActionResult> Index()
        {
            var courses= await _context.Courses.Include(c=>c.Teacher).ToListAsync();
            return View(courses);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Teachers= new SelectList(await _context.Teachers.ToListAsync(), "TeacherId","NameSurname");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course model)
        {
            _context.Courses.Add(model);
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

            var course = await _context
                                .Courses
                                .Include(c=> c.Records)
                                .ThenInclude(c=> c.Student)
                                .Select(c=> new CourseViewModel
                                {
                                    CourseId=c.CourseId,
                                    Title=c.Title,
                                    TeacherId=c.TeacherId,
                                    Records=c.Records
                                })
                                .FirstOrDefaultAsync(c=> c.CourseId==id);
            
            if(course==null)
            {
                return NotFound();
            }

            ViewBag.Teachers = new SelectList(await _context.Teachers.ToListAsync(),"TeacherId","NameSurname");
            
            return View(course);       
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CourseViewModel model)
        {
            if(id != model.CourseId)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
               try
               {
                    _context.Update(new Course(){CourseId=model.CourseId, Title= model.Title, TeacherId= model.TeacherId});
                    await _context.SaveChangesAsync();
               }
               catch(DbUpdateException)
               {
                    if(!_context.Courses.Any(s => s.CourseId==model.CourseId))
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

            var course = await _context.Courses.FindAsync(id);
            
            if(course==null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpPost]
        public async Task<IActionResult> Delete ([FromForm] int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if(course==null)
            {
                return NotFound();
            }
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}