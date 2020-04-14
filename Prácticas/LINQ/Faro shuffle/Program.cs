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

            /*  SelectMany to create a single sequence from combining each element in the first sequence with 
             *  each element in the second sequence. */
            var startingDeck = from s in Suits()
                                from r in Ranks()
                                select new { Suit = s, Rank = r };

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

        }
    }
}
