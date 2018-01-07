using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCDay1.Models
{
    public class Person
    {
        [Required(ErrorMessage = "输入正确的年龄")]
        public int Age { get; set; }
        public string QQ { get; set; }
    }
}