using System;
using System.Collections.Generic;
using System.Linq;

namespace Faro_shuffle
{
    class Program
    {
        /* Create two sequences to represent suits and ranks by creating a simple pair of iterator methods 
             * that will generate the ranks and suits as IEnumerable<T>s of strings
             */

        static IEnumerable<string> Suits()
        {
            /* You use a yield return statement to return each element one at a time. 
             * The sequence returned from an iterator method can be consumed by using a foreach statement 
             * or LINQ query. Each iteration of the foreach loop calls the iterator method. 
             * When a yield return statement is reached in the iterator method, expression is returned, 
             * and the current location in code is retained. Execution is restarted from that location 
             * the next time that the iterator function is called. 
             * The yield keyword effectively creates a lazy enumeration over collection items that can be 
             * much more efficient. For example, if your foreach loop iterates over just the first 5 items 
             * of 1 million items then that's all yield returns, and you didn't build up a collection of 
             * 1 million items internally first. Likewise you will want to use yield with IEnumerable<T> 
             * return values in your own programming scenarios to achieve the same efficiencies.
             */
            yield return "clubs";
            yield return "diamonds";
            yield return "hearts";
            yield return "spades";
        }

        static IEnumerable<string> Ranks()
        {
            yield return "two";
            yield return "three";
            yield return "four";
            yield return "five";
            yield return "six";
            yield return "seven";
            yield return "eight";
            yield return "nine";
            yield return "ten";
            yield return "jack";
            yield return "queen";
            yield return "king";
            yield return "ace";
        }
        static void Main(string[] args)
        {
            /* Use the iterator methods to create the deck of cards. */

            /* SelectMany to create a single sequence from combining each element in the first sequence with 
             * each element in the second sequence. 
             * LogQuery is an extension method used to log each query execution 
             * ToArray helps to improve performance on lazy evaluation */
            var startingDeck = (from s in Suits()
                                from r in Ranks()
                                select new { Suit = s, Rank = r }).LogQuery("Starting Deck").ToArray();

            /* Same sentence written in method syntax 
            var startingDeck = Suits().SelectMany(suit => Ranks().Select(rank => new { Suit = suit, Rank = rank}))*/

            // Display each card that we've generated and placed in startingDeck in the console
            foreach (var card in startingDeck)
            {
                Console.WriteLine(card);
            }

            /* Now shuffle the cards in the deck.
             * First split the deck in two using Take and Skip methods of LINQ APIs 
             * 52 cards in a deck, so 52/2 = 26
             */
            var top = startingDeck.Take(26);
            var bottom = startingDeck.Skip(26);

            /* Create the shuffle method
             * To add some funcionality to an IEnumerable<T> extension methods are used
             * An extension method is a special purpose static method that adds new functionality to an
             * already existing type without having to modify the original type 
             * The extension methods will be collected in a new static class file of the program 
             * called Extensions.cs
             */
            var shuffle = top.InterleaveSequenceWith(bottom);
            Console.WriteLine("\nShuffled deck");
            foreach (var c in shuffle)
            {
                Console.WriteLine(c);
            }

            /* Now determine how many times the deck must be shuffled to get back to its original order:
             * Shuffle code inside a loop, and stop when the sequence is back in its original order by applying 
             * the SequenceEquals() extension method. It would always be the final method in any query, 
             * because it returns a single value instead of a sequence
             * 
             * This shows a second LINQ idiom: terminal methods. They take a sequence as input (or in this case, 
             * two sequences), and return a single scalar value. 
             * When using terminal methods, they are always the final method in a chain of methods for a 
             * LINQ query, hence the name "terminal".
             * */
            var times = 0;
            shuffle = startingDeck;
            Console.WriteLine("\nShuffling until equal to original deck");
            do
            {
                /* Out shuffle, where the top and bottom cards stay the same on each run */
                //shuffle = shuffle.Take(26).LogQuery("Top half").InterleaveSequenceWith(shuffle.Skip(26).LogQuery("Bottom half")).LogQuery("Shuffle");

                /* In shuffle, where all 52 cards change position
                 * For an in shuffle the deck is interleaved so that the first card in the bottom half becomes 
                 * the first card in the deck. That means the last card in the top half becomes the bottom card.*/

                shuffle = shuffle.Skip(26).LogQuery("Bottom half").InterleaveSequenceWith(shuffle.Take(26).LogQuery("Top half")).LogQuery("Shuffle").ToArray();

                /* It takes 52 iterations for the deck to reorder itself and some serious performance 
                 * degradations as the program continues to run. One of the major causes of this 
                 * performance drop: inefficient use of lazy evaluation.
                 * Lazy evaluation states that the evaluation of a statement is not performed until its value 
                 * is needed. LINQ queries are statements that are evaluated lazily. The sequences are generated 
                 * only as the elements are requested. Usually, that's a major benefit of LINQ. However, in a 
                 * use such as this program, this causes exponential growth in execution time: 
                 * The original deck is generated using a LINQ query. Each shuffle is generated by performing 
                 * three LINQ queries on the previous deck. All these are performed lazily. 
                 * That also means they are performed again each time the sequence is requested. 
                 * By the time it gets to the 52nd iteration, it's regenerating the original deck many, 
                 * many times.
                 * 
                 * The performance of the code here can be improved. A simple fix is to cache the results 
                 * of the original LINQ query that constructs the deck of cards. Currently, the queries 
                 * are executed again and again every time the do-while loop goes through an iteration, 
                 * re-constructing the deck of cards and reshuffling it every time. 
                 * To cache the deck of cards, the LINQ methods ToArray and ToList can be useful; 
                 * when appended to the queries, they'll perform the same actions, but now they'll store 
                 * the results in an array or a list. 
                 * 
                 * In practice, some algorithms run well using eager evaluation, and others run well using 
                 * lazy evaluation. For daily usage, lazy evaluation is usually a better choice when the 
                 * data source is a separate process, like a database engine. 
                 * For databases, lazy evaluation allows more complex queries to execute only one round trip 
                 * to the database process and back to the rest of the code. 
                 * LINQ is flexible whether to choose to utilize lazy or eager evaluation, 
                 * the kind of evaluation that gives best performance should be picked.
                 */

                foreach (var card in shuffle)
                {
                    Console.WriteLine(card);
                }
                Console.WriteLine();
                times++;
            } while (!startingDeck.SequenceEqual(shuffle));

            Console.WriteLine(times);
        }
    }
}
