using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica_V
{
    public class Animal
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string imgPath { get; set; }

        public string soundPath { get; set; }
        public string description { get; set; }
        public int? AnimalClassId { get; set; }
        public AnimalClass AnimalClass { get; set; }

    }
}
