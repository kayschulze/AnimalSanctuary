using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AnimalSanctuary.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnimalSanctuary.Controllers
{
    public class AnimalsController : Controller
    {
		private AnimalSanctuaryContext db = new AnimalSanctuaryContext();

		// GET: /<controller>/
		public IActionResult Index()
		{
			return View(db.Animals.Include(animals => animals.Veterinarian).ToList());
		}

		public IActionResult Details(int id)
		{
			var thisAnimal = db.Animals.FirstOrDefault(animals => animals.AnimalId == id);
			return View(thisAnimal);
		}

		public IActionResult Create()
		{
			ViewBag.VeterinarianId = new SelectList(db.Veterinarians, "VeterinarianId", "Name");
			return View();
		}

		[HttpPost]
		public IActionResult Create(Animal animal)
		{
			db.Animals.Add(animal);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult Edit(int id)
		{
			var thisAnimal = db.Animals.FirstOrDefault(animal => animal.AnimalId == id);
			return View(thisAnimal);
		}

		[HttpPost]
		public IActionResult Edit(Animal animal)
		{
			db.Entry(animal).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult Delete(int id)
		{
			var thisAnimal = db.Animals.FirstOrDefault(animals => animals.AnimalId == id);
			return View(thisAnimal);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirmed(int id)
		{
			var thisAnimal = db.Animals.FirstOrDefault(animals => animals.AnimalId == id);
			db.Animals.Remove(thisAnimal);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
    }
}
