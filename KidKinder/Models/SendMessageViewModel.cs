using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KidKinder.Models
{
    public class SendMessageViewModel
    {
        [Required(ErrorMessage ="Lütfen adınızı yazınız.")]
        [StringLength(30,ErrorMessage ="En fazla 30 karakter!")]
        public string NameSurname { get; set; }

        [Required(ErrorMessage = "Lütfen mail adresinizi yazınız.")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter!")]
        [EmailAddress(ErrorMessage ="Lütfen geçerli bir mail adresi giriniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen konu yazınız.")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter!")]
        [MinLength(5,ErrorMessage ="En az 5 karakter!")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Lütfen mesajınızı yazınız.")]
        [StringLength(1000, ErrorMessage = "En fazla 1000 karakter!")]
        public string Message { get; set; }
     }
}