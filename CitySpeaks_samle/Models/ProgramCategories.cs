using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CitySpeaks_samle.Models
{
    public class ProgramCategories
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите название категории")]
        [Display(Name = "Название")]
        public string Name { get; set; }
    }
}