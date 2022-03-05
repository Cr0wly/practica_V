using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica_V
{
    public class AnimalClass
    {
        public int Id { get; set; }
        public string name { get; set; }
        public ICollection<Animal> animals { get; set; }
        public AnimalClass()
        {
            animals = new List<Animal>();
        }
    }
}
