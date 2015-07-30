namespace Assertions_Homework.Algorithms
{
    using System;
    using System.Diagnostics;
    using Assertions_Homework.Utilities;

    public static class SearchingAlgorithms
    {
        public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
        {
            return BinarySearch(arr, value, 0, arr.Length - 1);
        }

        private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr != null, "Array is null.");
            Debug.Assert(arr.Length > 0, "Array is empty.");
            Debug.Assert(value != null, "Search value is null.");
            Debug.Assert(startIndex >= 0 && startIndex < arr.Length, "Start index is out of range.");
            Debug.Assert(endIndex >= 0 && endIndex < arr.Length, "End index is out of range.");
            Debug.Assert(startIndex <= endIndex, "Start index is greater than end index.");
            Debug.Assert(ValidatorMethods.IsSorted(arr), "Array is not sorted.");

            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;
                if (arr[midIndex].Equals(value))
                {
                    return midIndex;
                }

                if (arr[midIndex].CompareTo(value) < 0)
                {
                    // Search on the right half
                    startIndex = midIndex + 1;
                }
                else
                {
                    // Search on the right half
                    endIndex = midIndex - 1;
                }
            }

            // Searched value not found
            Debug.Assert(!ValidatorMethods.HasValue(arr, value), "The array has the searchead value but returns -1.");
            return -1;
        }
    }
}
