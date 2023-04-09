using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Laba1.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Укажите первое значение")]
        public ushort Operand1 { get; set; }

        [Required(ErrorMessage = "Укажите второе значение")]
        [Compare("Operand1", ErrorMessage = "Значения операндов не совпадают")]
        public ushort Operand2 { get; set; }

        public string Operation { get; set; }

        public decimal Result { get; set; }
    }

}