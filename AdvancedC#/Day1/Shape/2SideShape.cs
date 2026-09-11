using System;
using System.Collections.Generic;
using System.Text;

namespace Day1.Shape
{
    public abstract class _2SideShape : IShape
    {
        protected int _l1;
        protected int _l2;
        protected _2SideShape(int l1,int l2)
        {
            _l1 = l1;
            _l2 = l2;   
            
        }

        public abstract double CalculateArea();


        public abstract double CalculatePerimeter();
    }
}
