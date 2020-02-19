using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BI_CM_C1_2020.Models;


namespace BI_CM_C1_2020.Controllers
{
	public class HomeController : Controller
	{
        private DBContext db;
        public HomeController(DBContext context) {
            db = context;
        }

		public IActionResult Index()
		{
            return View();
		}

        [HttpGet, Route("get-items")]
        public JsonResult GetMessages() {
            Object Items = (from t in db.Messages orderby t.date descending select new {
                id = t.id,
                title = t.title,
                text = t.text,
                date = new {
                    time = t.date.ToString("HH:mm"),
                    hour_ago = Convert.ToInt32(DateTime.Now.Subtract(t.date).TotalHours)
                }
            }).ToList();
            return Json(Items);
        }

    }
}
