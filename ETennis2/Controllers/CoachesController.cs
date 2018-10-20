using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETennis2.Data;
using ETennis2.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ETennis2.Controllers
{
    public class CoachesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<TennisUser> _userManager;

        public CoachesController(ApplicationDbContext context, UserManager<TennisUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        
        // GET: AllCoaches
        public async Task<IActionResult> Index()
        {
            var coachList = (from u in _context.TennisUser.AsEnumerable()
                                                 join ur in _context.TennisUserRole.AsEnumerable()
                                                 on u.Id equals ur.UserId
                                                 join r in _context.TennisRole.AsEnumerable()
                                                 on ur.RoleId equals r.Id
                                                 where r.Name == "Coach"
                                                 select new
                                                 {
                                                     u.Id,
                                                     u.UserName,
                                                     u.Nickname,
                                                     u.Dob,
                                                     u.Biography
                                                 });

            //return View(await coachList);
            return View(await coachList.CopyToDataTable().ToListAsync());
        }

        // GET: Coaches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coach = await _context.TennisUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coach == null)
            {
                return NotFound();
            }

            return View(coach);
        }

        // GET: Coaches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Coaches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Email,Nickname,Gender,Dob,Biography")] TennisUser coach)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coach);
                await _userManager.AddToRoleAsync(coach, "Coach");
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coach);
        }

        // GET: Coaches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coach = await _context.TennisUser.FindAsync(id);
            if (coach == null)
            {
                return NotFound();
            }
            return View(coach);
        }

        // POST: Coaches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Email,Nickname,Gender,Dob,Biography")] TennisUser coach)
        {
            if (id != coach.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoachExists(coach.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(coach);
        }

        // GET: Coaches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coach = await _context.TennisUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coach == null)
            {
                return NotFound();
            }

            return View(coach);
        }

        // POST: Coaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coach = await _context.TennisUser.FindAsync(id);
            _context.TennisUser.Remove(coach);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoachExists(int id)
        {
            var coachList = (from u in _context.TennisUser
                             join ur in _context.TennisUserRole
                             on u.Id equals ur.UserId
                             join r in _context.TennisRole
                             on ur.RoleId equals r.Id
                             where r.Name == "Coach"
                             select new { u.Id, u.UserName }).Distinct();
            return coachList.Any(e => e.Id == id);
        }
    }
}
