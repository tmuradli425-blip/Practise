using Microsoft.AspNetCore.Mvc;
using Practise.DAL;
using Practise.Models;

namespace Practise.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PositionController : Controller
    {
        private readonly AppDbContext _context;
        public PositionController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Position> positions = _context.Positions.ToList();
            return View(positions);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Position position)
        {
          // if (!ModelState.IsValid) return View();
            _context.Positions.Add(position);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult SoftDelete(int id)
        {
            var positions = _context.Positions.Find(id);
            if (positions == null) return NotFound();
            positions.IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var positions = _context.Positions.Find(id);

            if (positions == null)
                return NotFound();

            return View(positions);
        }
        [HttpPost]
        public IActionResult Restore(int id)
        {
            var position = _context.Positions.Find(id);

            if (position == null)
                return NotFound();

            position.IsDeleted = false;

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
