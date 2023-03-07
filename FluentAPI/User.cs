using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace FluentAPI
{
    [Table("ApplicationUsers")]
    public class User
    {
        public int Id { get; set; }
       
        [Column("Fullname")]
        public string? Name { get; set; }
        
        [Column("HowOld")]
        public int Age { get; set; }
        
        public bool IsMarried { get; set; }
        
        [NotMapped]
        public string? Address { get; set; }

        public User(string? name, int age, bool isMarried)
        {
            Name = name;
            Age = age;
            IsMarried = isMarried;
        }

        public User()
        {

        }
    }
}
