using System.Collections.Generic;

public interface ISorter<T>
{
    void Sort(List<T> list, IComparer<T> comparer);
}
