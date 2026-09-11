using System;
using System.Collections.Generic;
using System.Text;

namespace Day1.Shape
{
    public class Rectangle : _2SideShape
    {
        public int Length => _l2;
        public int Width => _l1;


        public Rectangle(int length, int width) : base(length, width)
        {
            _l1= width;
            _l2 = length;
        }


        public override double CalculateArea() => _l2 * _l1;


        public override double CalculatePerimeter() => 2 * (_l1 + _l2);

    }
}
