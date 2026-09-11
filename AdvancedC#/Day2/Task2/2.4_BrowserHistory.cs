using System;
using System.Collections.Generic;
using System.Text;

namespace Day2.Task2
{
    public class BrowserHistory<T>

    {
        Stack<T> _browserHistory = new Stack<T>();

        public void Visit(T url)
        {
            _browserHistory.Push(url);
        }

        public T Back()
        {
            if (_browserHistory.Count == 0)
            {
                throw new InvalidOperationException("No pages in history");
            }
            return _browserHistory.Pop();
        }
         public void VisitedPages()
        {
            if (_browserHistory.Count == 0)
            {
                Console.WriteLine("No pages in history");
                return;
            }
            
            Console.WriteLine("Browser History:");
            foreach (var url in _browserHistory)
            {
                Console.WriteLine(url);
            }
        }


    }
}
