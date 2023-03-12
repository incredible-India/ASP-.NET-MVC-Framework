using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Emp
    {
        public string name { get; set; }
        public string last { get; set; }
    }

   public class stu
    {  
        [Required (ErrorMessage ="Fname daal de bete")]
        [StringLength(9,MinimumLength =3,ErrorMessage ="N string lenth")]
       // [RegularExpression(@"[1-9]",ErrorMessage ="Regex no numbers")]

        public string fname { get; set; }
        [Required(ErrorMessage = "Lname daal de bete")]
      //  [DataType(DataType.Password)] //use EditorFor instaed of texboxfor in views then it will work
        [System.ComponentModel.DisplayName("Last Name")]
       // [System.ComponentModel.ReadOnly(true)]
       // [Compare("fname",ErrorMessage ="Fname and lname are not matching")]
        public string lname { get; set; }

    }



}