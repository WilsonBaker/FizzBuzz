using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzz.Models
{
    public class Result
    {
        [Key]
        public int Id { get; set; }

        public String Output { get; set; }
    }
}
