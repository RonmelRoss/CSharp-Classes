using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class Start
    {
        static void Main(string[] args)
        {
            //Testing StaticVar Class
            Console.WriteLine("DEMO: StaticVar Class");
            StaticVar s1 = new StaticVar();
            StaticVar s2 = new StaticVar();
            s1.count();
            s1.count();
            s1.count();
            s2.count();
            s2.count();
            Console.WriteLine("Variable num for s1: {0}", s1.getNum());
            Console.WriteLine("Variable num for s2: {0}", s2.getNum());

            //Testing Line Class
            Console.WriteLine("\nDEMO: Line Class");
            Line line = new Line(10.0);
            Console.WriteLine("Length of line: {0}", line.getLength());

            //Set line length
            line.setLength(6.0);
            Console.WriteLine("Modified Length: {0}", line.getLength());

            //DIFFERENCE CLASS
            //Computes maximum difference in a range of values
            //e.g. 1 2 3 4 5
            
            //Read user input on number of characters
            //Convert.ToInt32(Console.ReadLine());

            int[] a = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();

            Difference d = new Difference(a);

            d.computeDifference();

            Console.Write(d.maximumDifference);

            Console.ReadKey();
        }
    }
    class StaticVar
    {
        public static int num;

        public void count()
        {
            num++;
        }

        public int getNum()
        {
            return num;
        }
    }
    class Line
    {
        private double length;   // Length of a line

        public Line(double len) //Parameterized constructor
        {  
            Console.WriteLine("Object is being created. Initial Length = {0}", len);
            length = len;
        }
        public void setLength(double len)
        {
            length = len;
        }
        public double getLength()
        {
            return length;
        }
    }
    class Difference
    {
        private int[] elements;
        public int maximumDifference;
        //USING LIST TO DETERMINE MAXIMUM DIFFERENCE
        /*
        private List<int> result = new List<int>();

        public Difference(int[] a)
        {
            //Console.WriteLine("Elements retrieved.");
            elements = a;
        }
        public void computeDifference()
        {
            int y = elements.Length;

            for (int i = 0; i < (y - 1); i++)
            {
                //j = i + 1;
                for (int j = i + 1; j < y; j++)
                {
                    int k = elements[i] - elements[j];
                    result.Add(Math.Abs(k));
                }
            }
            maximumDifference = result.Max();
        }
        */
        public Difference(int[] a)
        {
            elements = a;
        }
        public void computeDifference()
        {
            int y = elements.Length;
            maximumDifference = 0;

            for (int i = 0; i < (y - 1); i++)
            {
                for (int j = i + 1; j < y; j++)
                {
                    int k = Math.Abs(elements[i] - elements[j]);
                    if (k > maximumDifference)
                    {
                        maximumDifference = k;
                    }
                }
            }
        }


    }
}
