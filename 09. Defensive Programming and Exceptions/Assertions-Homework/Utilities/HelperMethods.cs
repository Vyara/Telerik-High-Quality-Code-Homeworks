namespace Assertions_Homework.HelperMethods
{
    using System;
    using System.Diagnostics;
    using Assertions_Homework.Utilities;

    public class HelperMethods
    {
        internal static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
    where T : IComparable<T>
        {
            Debug.Assert(arr != null, "Array is null.");
            Debug.Assert(arr.Length > 0, "Array is empty.");
            Debug.Assert(startIndex >= 0 && startIndex <= arr.Length - 1, "Invalid startIndex value.");
            Debug.Assert(endIndex >= 0 && endIndex <= arr.Length - 1, "Invalid endIndex value.");
            Debug.Assert(startIndex <= endIndex, "Invalid start- and endIndex values.");

            int minElementIndex = startIndex;
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }

            Debug.Assert(ValidatorMethods.IsMinValue(arr, arr[minElementIndex], startIndex, endIndex), "Min element index has an invalid value.");
            return minElementIndex;
        }

        internal static void Swap<T>(ref T x, ref T y)
        {
            Debug.Assert(x != null, "First value for swapping is null.");
            Debug.Assert(y != null, "Second value for swapping is null.");

            T oldX = x;
            x = y;
            y = oldX;
        }
    }
}
