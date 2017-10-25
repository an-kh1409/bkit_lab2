using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Rect rect = new Rect(3, 2);
            Square square = new Square(7);
            Circle circle = new Circle(4);
            rect.Print();
            square.Print();
            circle.Print();

            Console.ReadLine();
        }
    }

    abstract class Figure : IComparable
    {
        public string Type
        {
            get
            {
                return this._Type;
            }
            protected set
            {
                this._Type = value;
            }
        }
        string _Type;

        public abstract double Area();

        public override string ToString()
        {
            return this.Type + " площадью " + this.Area().ToString();
        }

        public int CompareTo(object obj)
        {
            Figure p = (Figure)obj;

            if (this.Area() < p.Area()) return -1;
            else if (this.Area() == p.Area()) return 0;
            else return 1;
        }
    }

    interface IPrint
    {
        void Print();
    }

    class Rect : Figure, IPrint
    {
        double height, width;
        public Rect(double ph, double pw)
        {
            this.height = ph;
            this.width = pw;
            this.Type = "Прямоугольник";
        }

        public override double Area()
        {
            double result = this.width * this.height;
            return result;
        }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }

    class Square : Rect, IPrint
    {
        public Square(double size) : base(size, size)
        {
            this.Type = "Квадрат";
        }
    }

    class Circle : Figure, IPrint
    {
        double radius;

        public Circle(double pr)
        {
            this.radius = pr;
            this.Type = "Круг";
        }

        public override double Area()
        {
            double result = Math.PI * this.radius * this.radius;
            return result;
        }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }

    }
}

