using System;
using System.Collections.Generic;
using System.IO;
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

        /* This time, instead of yield returning each element, the matching elements of each sequence will be
         * compared. When the entire sequence has been enumerated, if every element matches, the sequences are 
         * the same */
        public static bool SequenceEquals<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            var firstIter = first.GetEnumerator();
            var secondIter = second.GetEnumerator();

            while (firstIter.MoveNext() && secondIter.MoveNext())
            {
                if (!firstIter.Current.Equals(secondIter.Current))
                {
                    return false;
                }
            }
            return true;
        }

        /* This extension method creates a new file called debug.log within the project directory and 
         * records what query is currently being executed to the log file. 
         * This extension method can be appended to any query to mark that the query executed. */
        public static IEnumerable<T> LogQuery<T>(this IEnumerable<T> sequence, string tag)
        {
            // File.AppendText creates a new file if the file doesn't exist.
            using (var writer = File.AppendText("debug.log"))
            {
                writer.WriteLine($"Executing query {tag}");
            }
            return sequence;
        }
    }
}
