using System;
using System.Collections.Generic;
using System.Text;

namespace Day1.Shape
{
    public abstract class _1SideShape : IShape
    {
        protected int _l;
        protected _1SideShape(int l)
        {

            _l = l;
        }

        public abstract double CalculateArea();


        public abstract double CalculatePerimeter();
    }
}
