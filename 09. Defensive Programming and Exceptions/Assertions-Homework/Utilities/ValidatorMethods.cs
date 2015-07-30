namespace Assertions_Homework.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ValidatorMethods
    {
       internal static bool IsSorted<T>(IEnumerable<T> list) where T : IComparable<T>
       {
           var y = list.First();
           return list.Skip(1).All(x =>
           {
               bool b = y.CompareTo(x) < 0;
               y = x;
               return b;
           });
       }

       internal static bool IsMinValue<T>(IEnumerable<T> list, T value, int start, int end) where T : IComparable<T>
       {
           return list.Skip(start)
               .Take(end - start)
               .Min()
               .CompareTo(value) > -1;
       }

       internal static bool HasValue<T>(IEnumerable<T> list, T value) where T : IComparable<T>
       {
           return list.Any(x => x.Equals(value));
       }
    }
}
