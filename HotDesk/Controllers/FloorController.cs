using HotDesk.Models;
using System.Web.Mvc;
using System.Linq;
using HotDesk.Helpers;

namespace HotDesk.Controllers
{
    public class FloorController : Controller
    {
        public ActionResult FloorDetails(int id)
        {
            var model = new FloorModel(id);

            // Get available work points
            var data = FileHelper.GetAppData();
            model.AvailableWP = data.Where(p => p / 1000 == id).Select(p => p % 1000).ToList();

            return View(model);
        }

        public ActionResult WpDetail(int id)
        {
            // Get the work point
            var model = new WpModel()
            {
                Id = id,
                Level = id / 1000,
                Num = id % 1000
            };

            // See if the work point is on the available list
            var data = FileHelper.GetAppData();
            model.Available = data.Contains(id);

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
                FileHelper.UpdateAppData(model.Id, model.Available);
            }

            return View("Confirmation", model);
        }

        public ActionResult Confirmation(WpModel model)
        {
            return View(model);
        }
    }
}