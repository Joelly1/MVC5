using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MVC5.Models;

namespace MVC5.Controllers
{
	public class HomeController : Controller
	{
		[HttpGet]
		public ActionResult Index()
		{
			Company company = new Company();

			return View(company);
		}
		[HttpPost]
		public string Index(Company company)
		{
			if (string.IsNullOrEmpty(company.SelectDepartment))
			{
				return "You did not select any department";
			}

			else
			{
				return "Your selected department with Id = " + company.SelectDepartment;
			}
		}
		[HttpGet]
		public ActionResult About()
		{
			SampleDB db = new SampleDB();

			return View(db.Cities);
		}
		[HttpPost]
		public string About(IEnumerable<City> cities)
		{
			if (cities.Count(x => (bool)x.IsSelected) == 0)
			{
				return "you didn't select anything";
			}
			else
			{
				StringBuilder sb = new StringBuilder();
				sb.Append("You selected - ");
				foreach(City city in cities)
				{
					if ((bool)city.IsSelected)
					{
						sb.Append(city.Name + ",");
					}
				}
				sb.Remove(sb.ToString().LastIndexOf(","), 1);
				return sb.ToString();
			}
		}
		[HttpGet]
		public ActionResult Contact()
		{
			SampleDB db = new SampleDB();
			List<SelectListItem> listSelectListItem = new List<SelectListItem>();

			foreach (City city in db.Cities)
			{
				SelectListItem selectListItem = new SelectListItem()
				{
					Text = city.Name,
					Value = city.ID.ToString(),
					Selected = city.IsSelected
				};

				listSelectListItem.Add(selectListItem);
			}
			CitiesViewModel citiesViewModel = new CitiesViewModel
			{
				Cities = listSelectListItem
			};
			return View(citiesViewModel);
		}
		[HttpPost]
		public string Contact(IEnumerable<string> selectedCities)
		{
			if(selectedCities == null)
			{
				return "You didn't select any city";	
			}
			else
			{
				StringBuilder sb = new StringBuilder();
				sb.Append("You Selected - " + string.Join(",", selectedCities));
				return sb.ToString();
			}
		}

		}
}