using System;
using System.Collections.Generic;

namespace CSharpCourse_part4
{
    //метод расширения, используемый в методе DisplayLargestFileWithLINQ
    public static class LinqExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            foreach(var item in source)
            {
                action(item);
            }
        }
    }
}
