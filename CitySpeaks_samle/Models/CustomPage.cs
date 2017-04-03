using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CitySpeaks_samle.Models
{
    public class CustomPage
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите название страницы")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "Пожалуйста, введите содержимое страницы")]
        [Display(Name = "Содержимое")]
        public string Page { get; set; }

        public byte[] BigImageData { get; set; }
        public string BigImageMimeType { get; set; }
        
        public bool IsShow { get; set; }
    }
}