using System;
using System.Collections.Generic;
using System.Linq;

namespace Faro_shuffle
{
    public static class Extensions
    {
        /* The "this" modifier on the first argument of the method means that you call the method as though 
         * it were a member method of the type of the first argument.
         * This method declaration also follows a standard idiom where the input and output types are IEnumerable<T>. 
         * That practice enables LINQ methods to be chained together to perform more complex queries.*/
        public static IEnumerable<T> InterleaveSequenceWith<T> (this IEnumerable<T> first, IEnumerable<T> second)
        {
            /* The IEnumerable<T> interface has one method: GetEnumerator. The object returned by GetEnumerator 
             * has a method to move to the next element, and a property that retrieves the current element 
             * in the sequence. Those two members will be used to enumerate the collection and return the elements. 
             * This Interleave method will be an iterator method that instead of building a collection and 
             * returning the collection will use the yield return syntax */
            var firstIter = first.GetEnumerator(); 
            var secondIter = second.GetEnumerator();

            while(firstIter.MoveNext() && secondIter.MoveNext())
            {
                yield return firstIter.Current;
                yield return secondIter.Current;
            }
        }
        
    }
}
