using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CitySpeaks_samle.Models
{
    public class Contact
    {
        [Required(ErrorMessage = "Пожалуйста, введите ваше имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите E-mail")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите номер телефона")]
        public string PhoneNumber { get; set; }

        public string Theme { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите сообщение")]
        public string Message { get; set; }

        public string Know { get; set; }
    }
}