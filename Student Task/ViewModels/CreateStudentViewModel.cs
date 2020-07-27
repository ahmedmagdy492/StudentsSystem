using Student_Task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student_Task.ViewModels
{
    public class StudentViewModel
    {
        public Student Student { get; set; }
        public IEnumerable<SelectListItem> Neighborhoods { get; set; }
        public IEnumerable<SelectListItem> Fields { get; set; }
        public IEnumerable<SelectListItem> Governorates { get; set; }
    }
}