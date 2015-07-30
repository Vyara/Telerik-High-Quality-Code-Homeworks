namespace Assertions_Homework.Algorithms
{
    using System;
    using System.Diagnostics;
    using Assertions_Homework.HelperMethods;
    using Assertions_Homework.Utilities;

    public class SortingAlgorithms
    {
        internal static void SelectionSort<T>(T[] arr) where T : IComparable<T>
        {
            Debug.Assert(arr != null, "Array is null.");
            Debug.Assert(arr.Length > 0, "Array is empty.");

            for (int index = 0; index < arr.Length - 1; index++)
            {
                int minElementIndex = HelperMethods.FindMinElementIndex(arr, index, arr.Length - 1);
                HelperMethods.Swap(ref arr[index], ref arr[minElementIndex]);
            }

            Debug.Assert(ValidatorMethods.IsSorted(arr), "Array is not sorted.");
        }
    }
}
