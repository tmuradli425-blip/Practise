using Microsoft.AspNetCore.Mvc;
using Practise.DAL;
using Practise.ViewModels;
using System.Diagnostics;

namespace Practise.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HomeVM vm = new HomeVM
            {
                Positions = _context.Positions.ToList(),
                Members = _context.Members.ToList()
            };
            return View();
        }

    }
}
