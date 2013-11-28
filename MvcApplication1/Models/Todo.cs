using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class Todo
    {
        public int id { get; set; }
        
        [Required]
        [Display(Name = "Title")]
        public string title { get; set; }

        [Display(Name = "Note")]
        public string note { get; set; }

        [Display(Name = "Date created")]
        public DateTime createdDate { get; set; }

        [Display(Name = "Completed")]
        public bool isCompleted { get; set; }

        public string username { get; set; }
    }
}