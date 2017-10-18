using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AnimalSanctuary.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnimalSanctuary.Controllers
{
    public class AnimalsController : Controller
    {
        private IAnimalRepository animalRepo;

        public AnimalsController(IAnimalRepository thisRepo = null)
        {
            if (thisRepo == null)
            {
                this.animalRepo = new EFAnimalRepository();
            }
            else
            {
                this.animalRepo = thisRepo;
            }
        }

        public IActionResult Index()
		{
			return View(animalRepo.Animals.ToList());
		}

		public IActionResult Details(int id)
		{
			var thisAnimal = animalRepo.Animals.FirstOrDefault(x => x.AnimalId == id);
			return View(thisAnimal);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Animal animal)
		{
			animalRepo.Save(animal);
			return RedirectToAction("Index");
		}

		public IActionResult Edit(int id)
		{
			var thisAnimal = animalRepo.Animals.FirstOrDefault(x => x.AnimalId == id);
			return View(thisAnimal);
		}

		[HttpPost]
		public IActionResult Edit(Animal animal)
		{
            animalRepo.Edit(animal);
			return RedirectToAction("Index");
		}

		public ActionResult Delete(int id)
		{
			var thisAnimal = animalRepo.Animals.FirstOrDefault(x => x.AnimalId == id);
			return View(thisAnimal);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirmed(int id)
		{
            Animal thisAnimal = animalRepo.Animals.FirstOrDefault(x => x.AnimalId == id);
            animalRepo.Remove(thisAnimal);
			return RedirectToAction("Index");
		}
    }
}
