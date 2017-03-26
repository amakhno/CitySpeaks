using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CitySpeaks_samle.Models
{
    public class Programs
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProgramId { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите название программы")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите короткое описание")]
        [Display(Name = "Описание (коротко)")]
        public string ShortDescription { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "Пожалуйста, введите описание")]
        [Display(Name = "Описание (поностью)")]
        public string FullDescription { get; set; }

        public byte[] BigImageData { get; set; }
        public string BigImageMimeType { get; set; }

        public byte[] SmallImageData { get; set; }
        public string SmallImageMimeType { get; set; }

        public int CategoryId { get; set; }
        public virtual ProgramCategories Category { get; set; }

        public static SelectList GetListOfCategories()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            List<string> model = new List<string>();
            foreach (ProgramCategories category in context.Categories)
            {
                model.Add(category.Name);
            }
            return new SelectList(model.ToArray());
        }

        public static int GetCategoryByName(string name)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            return context.Categories.Where(x => x.Name == name).First().CategoryId;
        }

        public static string GetCategoryNameByid(int id)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            return context.Categories.Where(x => x.CategoryId == id).First().Name;
        }
    }
}