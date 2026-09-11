using System;
using System.Collections.Generic;
using System.Text;

namespace Day1.Shape
{
    internal class Circle : _1SideShape
    {
        public int Raduis=> _l;
        public Circle(int Raduis) : base(Raduis)
        {
            _l = Raduis;
        }

        public override double CalculateArea() => Math.PI * Raduis * Raduis;


        public override double CalculatePerimeter() => 2 * Math.PI * Raduis;
    }
}
