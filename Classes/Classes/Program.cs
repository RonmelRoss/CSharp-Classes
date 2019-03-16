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
            /**************/
            //Handles Shape, Rectangle, RectangleConstruct class
            Console.WriteLine("DEMONSTRATION ON INHERITANCE");
            int w1 = 5;
            int h1 = 7;

            //Using a constructor and inheritance
            RectangleConstruct Recta = new RectangleConstruct(w1, h1);
            Console.WriteLine("Total Area(w/ Constructor): " + Recta.GetArea());

            Rectangle Rect = new Rectangle();
            /*Console.WriteLine("Input Width: ");
            w1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Input Height: ");
            h1 = Int32.Parse(Console.ReadLine());*/
            Rect.SetWidth(w1);
            Rect.SetHeight(h1);

            Console.WriteLine("Total area: {0}", Rect.getArea());
            /**************/

            /**************/
            //Handles Line class
            Console.WriteLine("\nDEMONSTRATION ON USING CONSTRUCTORS/DESTRUCTORS");
            Line line = new Line();    // set line length         
            line.setLength(6.0);
            Console.WriteLine("Length of line : {0}", line.getLength());
            /**************/

            /**************/
            //Handles StaticVar class
            Console.WriteLine("\nDEMONSTRATION ON USING STATIC MEMBERS");
            StaticVar s1 = new StaticVar();
            StaticVar s2 = new StaticVar();

            s1.count();
            s1.count();
            s1.count();
            s2.count();
            s2.count();
            s2.count();

            Console.WriteLine("Variable num for s1: {0}", s1.getNum());
            Console.WriteLine("Variable num for s2: {0}", s2.getNum());
            /**************/

            /**************/
            Console.WriteLine("\nDEMONSTRATION ON POLYMORPHISM");
            //Polymorph p = new Polymorph();
            Polymorph p = new Polymorph();

            // Call print to print integer
            p.Print(5);
            // Call print to print float          
            p.Print(500.263);
            // Call print to print string          
            p.Print("Hello C#");
            /**************/

            /**************/
            Console.WriteLine("\nDEMONSTRATION ON ABSTRACT CLASSES");
            Rectangle1 r = new Rectangle1(10, 7);
            double a = r.Area();
            Console.WriteLine("Area: {0}", a);
            /**************/

            /**************/
            Console.WriteLine("\nDEMONSTRATION ON DYNAMIC FUNCTION (Using Virtual Functions)");
            Rectangle2 rect2 = new Rectangle2(10, 7);
            Triangle t = new Triangle(10, 5);
            Caller c = new Caller();

            c.CallArea(rect2);
            c.CallArea(t);
            /**************/

            //DIFFERENCE CLASS
            //Computes maximum difference in a range of values
            //e.g. 1 2 3 4 5

            //Read user input on number of characters
            //Convert.ToInt32(Console.ReadLine());

            int[] b = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();

            Difference d = new Difference(b);

            d.computeDifference();

            Console.Write(d.maximumDifference);

            Console.ReadKey();
        }
    }
    //Demonstration on inheritance
    class Shape
    {
        //Base Class (or existing class)
        protected int width;
        protected int height;
        public void SetWidth(int w) { width = w; }
        public void SetHeight(int h) { height = h; }
    }
    class Rectangle : Shape
    {
        //Derived class
        //Demonstration on using inheritance
        public int getArea()
        {
            return (width * height);
        }
    }
    //Demonstration on using inheritance with constructors
    class RectangleConstruct : Shape
    {

        public RectangleConstruct(int w, int h)
        {
            width = w;
            height = h;
            Console.WriteLine("Rectangle Initiated.");
        }
        public int GetArea()
        {
            return width * height;
        }

    }
    //Demonstration on using constructors and deconstructors
    class Line
    {
        private double length;   // Length of a line              
        public Line()
        {
            Console.WriteLine("Object is being created.");
        }
        ~Line()
        {
            Console.WriteLine("Object is being deleted.");
            Console.ReadKey();
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
    //Demonstration on using static members
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
    //Demonstration on polymorphism (having many forms)
    //Static polymorphism - response to a function is decided at compile time
    class Polymorph
    {
        //Demonstrates function overloading
        public void Print(int i)
        {
            Console.WriteLine("Printing int: {0}", i);
        }
        public void Print(double f)
        {
            Console.WriteLine("Printing float: {0}", f);

        }
        public void Print(string s)
        {
            Console.WriteLine("Printing string: {0}", s);
        }
    }
    //Demonstration on Abstract Classes and Dynamic Polymorphism
    //Dynamic polymorphism - response to a function is decided at run-time
    abstract class Shape1
    {
        public abstract int Area();
    }
    class Rectangle1 : Shape1
    {
        private int length;
        private int width;
        public Rectangle1(int a = 0, int b = 0)
        {
            length = a;
            width = b;
        }
        public override int Area()
        {
            //Console.WriteLine("Rectangle class area :");
            return (width * length);
        }
    }
    //Dynamic polymorphism using virtual functions
    class Shape2
    {
        //Check the virtual function & the override
        protected int width, height;
        public Shape2(int a = 0, int b = 0)
        {
            width = a;
            height = b;
        }
        public virtual int area()
        {
            Console.WriteLine("Parent class area :");
            return 0;
        }
    }
    class Rectangle2 : Shape2
    {
        public Rectangle2(int a = 0, int b = 0) : base(a, b)
        {

        }
        public override int area()
        {
            Console.WriteLine("Rectangle class area :");
            return (width * height);
        }
    }
    class Triangle : Shape2
    {
        public Triangle(int a = 0, int b = 0) : base(a, b)
        {

        }
        public override int area()
        {
            Console.WriteLine("Triangle class area :");
            return (width * height / 2);
        }
    }
    class Caller
    {
        public void CallArea(Shape2 sh)
        {
            int a = sh.area();
            Console.WriteLine("Area: {0}", a);
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
