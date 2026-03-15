using System;
using System.Collections.Generic;

public class BubbleSorter<T> : ISorter<T>
{
    public void Sort(List<T> list, IComparer<T> comparer)
    {
        int n = list.Count;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (comparer.Compare(list[j], list[j + 1]) > 0)
                {
                    // Swap
                    T temp = list[j];
                    list[j] = list[j + 1];
                    list[j + 1] = temp;
                }
            }
        }
    }
}