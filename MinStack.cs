using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CodeSnippets
{
    //public class MinStack<T> : IComparable<T>
    public class MinStack<T> where T : IComparable
    {
        private readonly Stack<T> stack = new Stack<T>();
        private T min;
        
        public MinStack()
        {
            stack = new Stack<T>();
            min = default(T);

        }
        public void Push(T val)
        {
            stack.Push(val);
            var minvalue = this.GetMin();
            

            if (val.CompareTo(minvalue) <= 0)
            {
                min = val;
            }

        }

        public void Pop()
        {
            var popvalue = stack.Pop();
            var minvalue = this.GetMin();

            if (popvalue.CompareTo(minvalue) == 0)
            {
                var elements = stack.ToList<T>();
                min = elements.Min();
            }
        }

        public T Top() => stack.Peek();
        public T GetMin() => min;


        //    public int CompareTo(T? other)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }
}
