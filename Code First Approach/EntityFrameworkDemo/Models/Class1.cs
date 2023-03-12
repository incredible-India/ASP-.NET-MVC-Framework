using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntityFrameworkDemo.Models
{
    public class StudentInfo
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
    }
}