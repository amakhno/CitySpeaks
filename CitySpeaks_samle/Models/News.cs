using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CitySpeaks_samle.Models
{
    public class News
    {
        [Key]
        public int NewsId { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите название программы")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите короткое описание")]
        [Display(Name = "Описание (коротко)")]
        public string ShortDescription { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "Пожалуйста, введите описание полностью")]
        [Display(Name = "Описание (полностью)")]
        public string FullDescription { get; set; }

        public DateTime Date { get; set; }

        public byte[] BigImageData { get; set; }
        public string BigImageMimeType { get; set; }

        public byte[] SmallImageData { get; set; }
        public string SmallImageMimeType { get; set; }
    }
}