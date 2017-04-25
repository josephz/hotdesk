using HotDesk.Models;
using System.Web.Mvc;
using System.Linq;
using HotDesk.Repository;

namespace HotDesk.Controllers
{
    public class FloorController : Controller
    {
        private WpRepository WpRepo = new WpRepository();

        public ActionResult FloorDetails(int id)
        {
            var model = new FloorModel(id);

            // Get available work points
            model.AvailableWP = WpRepo.GetWpListByLevel(id).ToList();

            return View(model);
        }

        public ActionResult WpDetail(int id)
        {
            // Get the work point
            var model = new WpModel()
            {
                Id = id,
            };
            UpdateWpModelProperty(ref model);

            // See if the work point is on the available list
            model.Available = WpRepo.SearchFor(wp => wp.Id == id).Any();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult WpDetail(WpModel model)
        {
            if (ModelState.IsValid)
            {
                model.Available = !model.Available;

                // Set the work point
                WpRepo.SetWpAvailability(model.Id, model.Available);
                UpdateWpModelProperty(ref model);
            }

            return View("Confirmation", model);
        }

        //public ActionResult Confirmation(WpModel model)
        //{
        //    return View(model);
        //}

        private void UpdateWpModelProperty(ref WpModel model)
        {
            model.Level = model.Id / 1000;
            model.Num = model.Id % 1000;
        }
    }
}