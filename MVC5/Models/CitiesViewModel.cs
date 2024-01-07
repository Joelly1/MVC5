using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5.Models
{
	public class CitiesViewModel
	{
		public IEnumerable<SelectListItem> Cities { set; get; }
		public IEnumerable<string> SelectedCities { set; get; }
	}
}