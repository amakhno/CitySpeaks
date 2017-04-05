using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CitySpeaks_samle.Models
{
    public class Workers
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите Имя работника")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите данные о работнике")]
        [Display(Name = "Описание (коротко)")]
        public string ShortDescription { get; set; }

        [Display(Name = "Страничка")]
        [AllowHtml]
        public string FullDescription { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }

        public byte[] BigImageData { get; set; }
        public string BigImageMimeType { get; set; }
    }
}