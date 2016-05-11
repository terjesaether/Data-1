using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Data_1.Models
{
    public class CreateOrEditViewModel
    {
        public Movie Movie { get; set; }

        public IEnumerable<SelectListItem> Genres { get; set; } // Selectlist med Genres
    }
}