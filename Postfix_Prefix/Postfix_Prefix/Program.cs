using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postfix_Prefix
{
    class Program
    {
        static void Main(string[] args)
        {
            string infix = "";
            string postfix = "";
            if (args.Length == 1)
            {
                infix = args[0];
                convert(ref infix, out postfix);
                Console.WriteLine("Infix  :\t" + infix);
                Console.WriteLine("Postfix:\t" + postfix);
            }
            else
            {
                infix = "a+b*c-d";
                convert(ref infix, out postfix);
                Console.WriteLine("Infix   :\t" + infix);
                Console.WriteLine("Postfix :\t" + postfix);
                Console.WriteLine();
                infix = "a+b*c-d/e*f";
                convert(ref infix, out postfix);
                Console.WriteLine("Infix   :\t" + infix);
                Console.WriteLine("Postfix :\t" + postfix);
                Console.WriteLine();
                infix = "a-b/c*d-e--f/g*h++i-/j";
                convert(ref infix, out postfix);
                Console.WriteLine("Infix   :\t" + infix);
                Console.WriteLine("Postfix :\t" + postfix);
                Console.WriteLine();
                Console.ReadLine();
            }
        }
        static bool convert(ref string infix, out string postfix)
        {
            int p = 0;
            postfix = "";
            Stack<Char> stack = new Stack<char>();
            for (int i = 0; i < infix.Length; i++)
            {
                char chrVal = infix[i];
                if (chrVal == '+' || chrVal == '-' || chrVal == '*' || chrVal == '/')
                {
                    if (stack.Count <= 0)
                        stack.Push(chrVal);
                    else
                    {
                        if (stack.Peek() == '*' || stack.Peek() == '/')
                            p = 1;
                        else
                            p = 0;
                        if (p == 1)
                        {
                            if (chrVal == '+' || chrVal == '-')
                            {
                                postfix += stack.Pop();
                                i--;
                            }
                            else
                            {
                                postfix += stack.Pop();
                                i--;
                            }
                        }
                        else
                        {
                            if (chrVal == '+' || chrVal == '-')
                            {
                                postfix += stack.Pop();
                                stack.Push(chrVal);
                            }
                            else
                            {
                                stack.Push(chrVal);
                            }
                        }
                    }
                }
                else
                {
                    postfix += chrVal;
                }
            }
            int length = stack.Count;
            for (int j = 0; j < length; j++)
            {
                postfix += stack.Pop();
            }
            return true;
        }
    }
}


