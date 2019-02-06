using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SammysAuto.Data;
using SammysAuto.Models;
using SammysAuto.Utility;

namespace SammysAuto.Controllers
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UsersController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(string option = null, string search = null)
        {
            var users = _db.Users.ToList();

            if (option == "email" && search != null)
            {
                users = _db.Users.Where(u => u.Email.ToLower().Contains(search.ToLower())).ToList();
            }
            else
            {
                if (option == "name" && search != null)
                {
                    users = _db.Users.Where(n => n.Nome.ToLower().Contains(search.ToLower()) || 
                        n.Sobrenome.ToLower().Contains(search.ToLower())).ToList();
                }
                else
                {
                    if (option == "phone" && search != null)
                    {
                        users = _db.Users.Where(p => p.NumeroTelefone.ToLower().Contains(search.ToLower())).ToList();
                    }
                }
            }

            return View(users);
        }

        //GET Details
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ApplicationUser user = await _db.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        //GET Edit
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ApplicationUser user = await _db.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        //POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ApplicationUser user)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", user);
            }
            else
            {
                var userInDb = await _db.Users.SingleOrDefaultAsync(u => u.Id == user.Id);
                if (userInDb == null)
                {
                    return NotFound();
                }
                else
                {
                    userInDb.Nome = user.Nome;
                    userInDb.Sobrenome = user.Sobrenome;
                    userInDb.NumeroTelefone = user.NumeroTelefone;
                    userInDb.Endereco = user.Endereco;
                    userInDb.Cidade = user.Cidade;
                    userInDb.CodigoPostal = user.CodigoPostal;

                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
        }

        //GET Delete
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ApplicationUser user = await _db.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var userInDb = await _db.Users.SingleOrDefaultAsync(u => u.Id == id);

            var cars = _db.Cars.Where(x => x.UserId == userInDb.Id);

            List<Car> listCar = cars.ToList();

            foreach (var car in listCar)
            {
                var services = _db.Services.Where(x => x.CarId == car.Id);

                _db.Services.RemoveRange(services);
            }

            _db.Cars.RemoveRange(cars);
            _db.Users.Remove(userInDb);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
        }
    }
}