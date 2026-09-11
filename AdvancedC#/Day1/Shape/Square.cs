using System;
using System.Collections.Generic;
using System.Text;

namespace Day1.Shape
{
    internal class Square : _1SideShape
    {
        int SideLength=> _l;
        public Square(int SideLength) : base(SideLength)
        {
            _l = SideLength;
        }

        public override double CalculateArea()=> SideLength * SideLength;


        public override double CalculatePerimeter()=> 4 * SideLength;

    }
}
