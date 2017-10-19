using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AnimalSanctuary.Models;

namespace AnimalSanctuary.Controllers
{
    public class VeterinariansController : Controller
    {
        private IVeterinarianRepository veterinarianRepo;

        public VeterinariansController(IVeterinarianRepository thisRepo = null)
        {
            if (thisRepo == null)
            {
                this.veterinarianRepo = new EFVeterinarianRepository();
            }
            else
            {
                this.veterinarianRepo = thisRepo;
            }
        }

        public IActionResult Index()
        {
            return View(veterinarianRepo.Veterinarians.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisVeterinarian = veterinarianRepo.Veterinarians.FirstOrDefault(x => x.VeterinarianId == id);
            return View(thisVeterinarian);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Veterinarian veterinarian)
        {
            veterinarianRepo.Save(veterinarian);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisVeterinarian = veterinarianRepo.Veterinarians.FirstOrDefault(x => x.VeterinarianId == id);
            return View(thisVeterinarian);
        }

        public ActionResult Delete(int id)
        {
            var thisVeterinarian = veterinarianRepo.Veterinarians.FirstOrDefault(x => x.VeterinarianId == id);
            return View(thisVeterinarian);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Veterinarian thisVeterinarian = veterinarianRepo.Veterinarians.FirstOrDefault(x => x.VeterinarianId == id);
            veterinarianRepo.Remove(thisVeterinarian);
            return RedirectToAction("Index");
        }
    }
}
