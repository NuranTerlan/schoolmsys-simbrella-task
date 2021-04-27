using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Commons;

namespace SchoolManagementSystem.Domain.Entities
{
    public class Psychologist : ApplicationUser
    {
        [MaxLength(5)]
        public string IndividualRoom { get; set; }

        public virtual ICollection<SchoolClass> SchoolClasses { get; set; }
    }
}