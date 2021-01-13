using System;
using System.ComponentModel.DataAnnotations;

namespace mvc.Models
{
    
    public class Recruitment_plan
    
    {
        [Key]
        public int ID {get ; set ;}
        public int NUMBER_EMPLOYEE { get; set; }

        public int POSSION_ID {get;set;}

        public DateTime dateTime {get; set;}

        public int SALARY {get; set ;}

        public string  DESCRIPTION {get;set;}

    }
}
