using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CitySpeaks_samle.Models
{
    public class MainPage
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите заголовок сайта")]
        [Display(Name = "Заголовок")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите подзаголовок")]
        [Display(Name = "Подзаголовок")]
        public string Subtitle { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "Пожалуйста, введите описание полностью")]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        public byte[] MainImageData { get; set; }
        public string MainImageMimeType { get; set; }

        public byte[] LogolImageData { get; set; }
        public string LogoImageMimeType { get; set; }
    }
}