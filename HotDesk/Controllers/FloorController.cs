using HotDesk.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace HotDesk.Controllers
{
    public class FloorController : Controller
    {
        public ActionResult FloorDetails(int id)
        {
            var model = new FloorModel(id);

            model.AvailableWP = new List<int>()
            {
                123, 56
            };

            return View(model);
        }

        public ActionResult WpDetail(int id)
        {
            var model = new WpModel(3, id);

            model.Available = false;

            return View(model);
        }

        public ActionResult Confirmation()
        {
            var model = new WpModel(3, 123);

            return View(model);
        }
    }
}