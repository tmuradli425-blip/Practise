using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practise.DAL;
using Practise.Models;
using Practise.Utilities.ImageFile;

namespace Practise.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MemberController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public MemberController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Member> members = await _context.Members.Include(x => x.Position).ToListAsync();
            return View(members);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Positions = await _context.Positions.Where(x => !x.IsDeleted).ToListAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Member member)
        {
            //    if (!ModelState.IsValid)
            //    {
            //        ViewBag.Positions = await _context.Positions.Where(x => !x.IsDeleted).ToListAsync();
            //      return View();
            //    }
            //    if (member.ImageFile != null)
            //    {
            //        string folder = Path.Combine(_env.WebRootPath, "img");
            //        string fileName = Guid.NewGuid().ToString() + "_" + member.ImageFile.FileName;
            //        string filePath = Path.Combine(folder, fileName);
            //        using (var stream = new FileStream(filePath, FileMode.Create))
            //        {
            //            await member.ImageFile.CopyToAsync(stream);
            //        }
            //        member.ImageUrl = "/img/" + fileName;
            //    }
            //    await _context.Members.AddAsync(member);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            member.ImageUrl = member.ImageFile.SaveImage(_env, "uploads/members");
            //if (!ModelState.IsValid)
            //{
            //    ViewBag.Positions = await _context.Positions.Where(_ => !_.IsDeleted).ToListAsync();
            //    return View();
            //}
               
            await _context.Members.AddAsync(member);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
            [HttpPost]
        public async Task<IActionResult> SoftDelete(int id)
        {
            Member? member = await _context.Members
                .FirstOrDefaultAsync(x => x.Id == id);

            if(member == null)
            {
                return NotFound();
            }
                member.IsDeleted = true;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            Member? member = await _context.Members
                .FirstOrDefaultAsync(x => x.Id == id);

            ViewBag.Positions = await _context.Positions
                .Where(x => !x.IsDeleted)
                .ToListAsync();

            return View(member);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Member member)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Positions = await _context.Positions
                    .Where(x => !x.IsDeleted)
                    .ToListAsync();

                return View();
            }

            _context.Members.Update(member);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
