using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Zoo : IEnumerable
    {
        private List<IAnimal> _animals = new List<IAnimal>();

        public int Name { get; set; }
        public int Id { get; set; }

     

        public void Add(IAnimal animal)
        {
            _animals.Add(animal);
        }


        public IEnumerator GetEnumerator()
        {
            foreach (var animal in _animals)
            {
                yield return animal;
            }
        }
    }
}
