using System;
using System.Collections.Generic;

namespace CodeSnippets
{
    class Program
    {
        /**
         * 
         * Author: HarAman Singh Chadha
         */
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MinStack<int> minStack = new MinStack<int>();
            minStack.Push(-2);
            minStack.Push(0);
            minStack.Push(-3);
            Console.WriteLine(minStack.GetMin()); // return -3
            minStack.Pop();
            minStack.Pop();    // return 0
            Console.WriteLine(minStack.GetMin()); // return -2
          
            Console.WriteLine("() => " + IsParanthesesValid("()"));
            Console.WriteLine("()[]{} => " + IsParanthesesValid("()[]{}"));
            Console.WriteLine("(] => " + IsParanthesesValid("(]"));
            Console.WriteLine("([)] => " + IsParanthesesValid("([)]"));
            Console.WriteLine("{[]} => " + IsParanthesesValid("{[]}"));
            

        }

        private static bool IsParanthesesValid(string input)
        {
            //check odd length
            if (string.IsNullOrEmpty(input) || input.Length % 2 != 0) return false;
            //push first half in stack, pop them and compare
            // this is the case ({[]})
            Stack<char> data = new Stack<char>();
            int halfLength = input.Length / 2;
            var firstHalfAndSecondHalfMatch = true;
            var consecutiveMatch = true;
            for (int i = 0; i < input.Length; i++)
            {
                if (i < halfLength)
                {
                    data.Push(input[i]);
                }
                else
                {
                    var firstHalfChar = data.Pop();
                    if ((firstHalfChar == '(' && input[i] == ')') || (firstHalfChar == '{' && input[i] == '}') || (firstHalfChar == '[' && input[i] == ']'))
                    {
                        continue;          
                       
                    } else
                    {
                        firstHalfAndSecondHalfMatch = false;
                        break;
                    }
                                  
                }
            }
            if (firstHalfAndSecondHalfMatch) return true;
            //check for ()[]{}..
            data.Clear();
            for (int i = 0; i < input.Length; i++)
            {
                data.Push(input[i]);
            }
            for (int i = 0; i < halfLength; i++)
            {
                var lastChar = data.Pop();
                var secondLastChar = data.Pop();
                if ((secondLastChar == '(' && lastChar == ')') || (secondLastChar == '{' && lastChar == '}') || (secondLastChar == '[' && lastChar == ']'))
                {
                    continue;

                }
                else
                {
                    consecutiveMatch = false;
                    break;
                }
            }
            
            return consecutiveMatch;


        }
    }
}
