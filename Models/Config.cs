using System;
using System.ComponentModel.DataAnnotations;

namespace mvc.Models
{
    
    public class Config
    
    {
        [Key]
        public int ID {get ; set ;}
        public string EMAIL { get; set; }

        public int ID_Department {get;set;}

    }
}
