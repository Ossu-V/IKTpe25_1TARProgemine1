using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using University.Data;
using University.Dto;
using University.Models;
using University.ServiceInterface;
using University.ViewModel;
using University.ViewModel.CourseVM;

namespace University.Controllers
{
    public class CourseController : Controller
    {
        private readonly UniversityContext _context;
        private readonly IFileServices _fileServices;

        public CourseController
            (
                UniversityContext context,
            IFileServices fileServices
            )
        {
            _context = context;
            _fileServices = fileServices;
        }

        public async Task<IActionResult> Index()
        {
            var course = _context.Courses
                .Select(c => new CourseIndexViewModel
                {
                    CourseId = c.CourseId,
                    Credits = c.Credits,
                    Title = c.Title,
                    DepartmentId = c.DepartmentId,
                    Department = new CourseDepartmentIndexViewModel
                    {
                        DepartmentName = c.Departments.Name
                    }
                });

            return View(course);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vm = await _context.Courses
                .Where(c => c.CourseId == id)
                .Select(c => new CourseUpdateViewModel
                {
                    CourseId = c.CourseId,
                    Credits = c.Credits,
                    Title = c.Title,
                    Department = new CourseDepartmentIndexViewModel
                    {
                        DepartmentName = c.Departments != null ? c.Departments.Name : null
                    }
                })
                .FirstOrDefaultAsync();

            if (vm == null)
            {
                return NotFound();
            }

            // LISAME SIIA PILDID: Küsime pildid andmebaasist otse vaatemudelisse kaasa
            var courseImage = await _context.FileToApis
                .Where(f => f.CourseId == vm.CourseId)
                .Select(f => new ImageViewModel
                {
                    FilePath = f.ExistingFilePath // Kasutame baasi välja nime
                })
                .ToListAsync();

            if (courseImage != null && courseImage.Any())
            {
                vm.Image = courseImage;
            }

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(CourseUpdateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                // 1. Otsime olemasoleva kursuse andmebaasist (et me ei lõhuks seoseid)
                var course = await _context.Courses.FindAsync(vm.CourseId);

                if (course == null)
                {
                    return NotFound();
                }

                // 2. Uuendame tekstiväljad
                course.Title = vm.Title;
                course.Credits = vm.Credits;
                // Kuna osakonna muutmine käib tavaliselt ID kaudu, siis veendu, et uuendad vajadusel ka DepartmentId

                // 3. KUI KASUTAJA VALIS UUEDA FAILI: Käivitame failiteenuse
                if (vm.File != null)
                {
                    // Teeme kiirest kohapeal Create vaatemudeli, mida teenus ootab
                    var createVmForService = new CourseCreateViewModel
                    {
                        File = vm.File
                    };

                    // Söödame teenusele sisse täpselt selle mudeli, mida ta tahab
                    _fileServices.FilesToApi(createVmForService, course);
                }

                // 4. Salvestame muudatused
                _context.Update(course);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(vm);
        }

        public IActionResult Create()
        {
            PopulateDepartmentDropDownList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Course course = new Course
                {
                    CourseId = vm.CourseId,
                    Title = vm.Title,
                    Credits = vm.Credits,
                    DepartmentId = vm.DepartmentId
                };

                // Käivitame pildi salvestamise teenuse
                _fileServices.FilesToApi(vm, course);

                _context.Add(course);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            // KUI ANDMED POLNUD VALIIDSED:
            // Kasutame 'vm.DepartmentId' (kuna 'course' muutujat siin ei eksisteeri)
            PopulateDepartmentDropDownList(vm.DepartmentId);

            // Tagastame vaate koos sisestatud andmetega, et kasutaja näeks vigu
            return View(vm);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Küsime kursuse andmed baasist ilma vigase seoseta
            var course = await _context.Courses
                .Include(c => c.Departments)
                .Where(c => c.CourseId == id)
                .Select(c => new CourseDetailsViewModel
                {
                    CourseId = c.CourseId,
                    Credits = c.Credits,
                    Title = c.Title,
                    DepartmentId = c.DepartmentId,
                    Department = new CourseDepartmentIndexViewModel
                    {
                        DepartmentName = c.Departments.Name
                    }
                })
                .FirstOrDefaultAsync();

            if (course == null)
            {
                return NotFound();
            }

            // Kuna seose täpne nimi pole teada, küsime pildid otse FileToApi tabelist kursuse ID järgi:
            var courseImage = await _context.FileToApis  // Kui tabeli nimi on FilesToApi
                .Where(f => f.CourseId == course.CourseId) // eeldusel, et tabelis on CourseId olemas
                .Select(f => new ImageViewModel
                {
                    FilePath = f.ExistingFilePath
                })
                .ToListAsync();

            if (courseImage != null && courseImage.Any())
            {
                course.Image = courseImage;
            }

            return View(course);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.Departments)
                .Where(c => c.CourseId == id)
                .Select(c => new CourseDeleteViewModel
                {
                    CourseId = c.CourseId,
                    Credits = c.Credits,
                    Title = c.Title,
                    DepartmentId = c.DepartmentId,
                    Department = new CourseDepartmentIndexViewModel
                    {
                        DepartmentName = c.Departments.Name
                    }
                })
                .FirstOrDefaultAsync();

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course != null)
            {
                // Otsime üles selle kursuse pildi
                var img = await _context.FileToApis
                    .FirstOrDefaultAsync(x => x.CourseId == id);

                // Kui pilt on olemas, kustutame faili arvutist ja andmebaasist
                if (img != null)
                {
                    var dto = new FileToApiDto
                    {
                        Id = img.Id,
                        ExistingFilePath = img.ExistingFilePath
                    };
                    await _fileServices.RemoveImageFromApi(dto);
                }

                _context.Courses.Remove(course);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private void PopulateDepartmentDropDownList(object selectedDepartment = null)
        {
            var departmentsQuery = _context.Departments
                .OrderBy(d => d.Name)
                .GroupBy(d => d.Name)
                .Select(g => g.First());

            ViewBag.DepartmentId = new SelectList(departmentsQuery
                .AsNoTracking(), "DepartmentId", "Name", selectedDepartment);
        }
    }
}