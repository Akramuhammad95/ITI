using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4.Searchers
{
     interface ISearchers<T>
    {
         int  Search(List<T> list, T value);
    }
}
