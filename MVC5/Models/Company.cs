using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5.Models
{
	public class Company
	{
		public string SelectDepartment { get; set; }
		public List<Department> departments
		{
			get
			{
				SampleDB db = new SampleDB();
				return db.Departments.ToList();
			}
		}
		
	}
}