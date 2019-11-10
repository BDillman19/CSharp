using System;
using System.Collections.Generic;

namespace Dominoes
{
    class Program
    {
        static void Main(string[] args)
        {
            // args = new string[1];
            // args[0] = ".L.R....L";
            if (args.Length < 1)
            {
                Console.WriteLine("Requires one command Line Argument");
                return;
            }

            Console.WriteLine("main " + args[0]);

            
            List<Domino> test = new List<Domino>();

            test.Add(new Domino("."));
            test.Add(new Domino("."));
            test.Add(new Domino("."));

            foreach (Domino domino in test)
            {
                domino.fallLeft();
            }

            foreach (Domino domino in test)
            {
                Console.WriteLine(domino.state);
            }


            finalDominoState(args[0]);
        }

        public static String finalDominoState(String initialState)
        {  
            List<Domino> tempList = new List<Domino>();
            List<Domino> result = new List<Domino>();
            List<Domino> dominoes = new List<Domino>();
            var states = initialState.ToCharArray();

            

            foreach (var state in states)
            {
                dominoes.Add(new Domino(state.ToString()));
            }

            /* find the first L or R in the list. create a subList of the two new lists
                if L then all in that sublist should be L
                if R then all in that Sublist should be . except for the R and set
                    the carry flag to true
                if none found then return original list as no changes would occur
                
                find the next sublist and check carry flag
                if L and flag is true then check is size is even or odd
                    if even half are set to R and half are set to L
                        ex R....L => RRRLLL
                    if odd then center object is preserved as . and ones 
                        before are set to R and after are set to L
                        ex R.....L =? RRR.LLL
                    set flag to false
                if L and flag is false then set all to L 
                        ex L.....L => LLLLLLL
                if R and flag is true then set all to R
                        ex R.....R => RRRRRRR
                if R and flag is false then preserve all as .
                        ex L.....R => L.....R
                    preserve flag as true

                repeat second block of logic until end of list

                convert list<Domino> to string of Domino.state
            */

            //find the first L or R in the list. create a subList of the two new lists
            var index = dominoes.FindIndex(dom => dom.state.Equals("R") || dom.state.Equals("L"));
            bool flag = false;
            List<Domino> sub = new List<Domino>();

            // if none found then return original list as no changes would occur
            if (index.Equals(null) || index < 0)
            {
                return dominoes.ToString();
            } else if (dominoes[index].state.Equals("L"))
            {
                //if L then all in that sublist should be L add to result
                sub = dominoes.GetRange(1, index);
                tempList = dominoes.GetRange(index, dominoes.Count);

                foreach (Domino domino in sub) {
                    domino.fallLeft();
                }

                result.AddRange(sub);
            } else if (dominoes[index].state.Equals("R"))
            {
                // if R then all in that Sublist should be . except for the R and set
                // the carry flag to true
                sub = dominoes.GetRange(1, index);
                tempList = dominoes.GetRange(index, dominoes.Count);

                foreach (Domino domino in sub) {
                    domino.fallRight();
                }

                flag = true;
                result.AddRange(sub);
            }

            // find the next sublist and check carry flag
            index = tempList.FindIndex(dom => dom.state.Equals("R") || dom.state.Equals("L"));

            return null;
        }

        public String convertDominoesToString(List<Domino> dominoes) 
        {
            String result = "";
            foreach (Domino domino in dominoes)
            {
                 result = string.Concat(result, domino.state);
            }

            return result;
        }
    }
}
