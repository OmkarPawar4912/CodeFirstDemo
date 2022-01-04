using DemoRepoPattern.Entities;
using DemoRepoPattern.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DemoRepoPattern.Controllers
{
    public class DivisionsController : Controller
    {
        private readonly IDivisionRepository _divisionRepository;
        public DivisionsController(IDivisionRepository divisionRepository)
        {
            _divisionRepository = divisionRepository;
        }

        // GET: Divisions
        public IActionResult Index()
        {
            return View(_divisionRepository.GetAll());
        }

        // GET: Divisions/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var division = _divisionRepository.Get((int)id);
            if (division == null)
            {
                return NotFound();
            }

            return View(division);
        }

        // GET: Divisions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Divisions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name")] Division division)
        {
            if (ModelState.IsValid)
            {
                _divisionRepository.Add(division);
                return RedirectToAction(nameof(Index));
            }
            return View(division);
        }

        // GET: Divisions/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var division = _divisionRepository.Get((int)id);
            if (division == null)
            {
                return NotFound();
            }
            return View(division);
        }

        // POST: Divisions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name")] Division division)
        {
            if (id != division.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _divisionRepository.Update(division);
                return RedirectToAction(nameof(Index));
            }
            return View(division);
        }

        // GET: Divisions/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var division = _divisionRepository.Get((int)id);
            if (division == null)
            {
                return NotFound();
            }

            return View(division);
        }

        // POST: Divisions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var division = _divisionRepository.Get(id);
            _divisionRepository.Remove(division);
            return RedirectToAction(nameof(Index));
        }
    }
}
