using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionLibrary
{
    public interface ISortable<T> where T : IComparable<T>
    {
        void SelectionSort(IComparer<T> comp = null);
        void InsertionSort(IComparer<T> comp = null);
        void ShellSort(IComparer<T> comp = null);
        void MergeSort(IComparer<T> comp = null);
    }
}
