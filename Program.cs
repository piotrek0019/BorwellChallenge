using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorwellChallenge
{

    class Measurement
{
        public Measurement(double h, double w, double l, int c)
    {
        height = h;
        width = w;
        length = l;
        coverage = c;
    }
        double height = 0;
        double width = 0;
        double length = 0;
        int coverage = 0;

        double ceiling = 0;
        double walls = 0;

        decimal ceilingPaint = 0;
        decimal wallsPaint = 0;

        public double Flour()
        {
            return width * length;
        }

        public double Volume()
        {
            return height * width * length;
        }

        public void PaintRequired()
        {
            ceiling = width * length;
            walls = (length  * 2 + width * 2) * height;

            ceilingPaint = (decimal)ceiling / coverage;
            wallsPaint = (decimal)walls / coverage;

            Console.WriteLine("You need: " + decimal.Round(ceilingPaint, 2) + " liters of paint for ceiling ");
            Console.WriteLine("You need: " + decimal.Round(wallsPaint, 2) + " liters of paint for walls");

            Console.WriteLine("You need: " + decimal.Round(ceilingPaint + wallsPaint, 2) + " liters altogether");
            
            
        }
}

    class Program
    {
        static void Main(string[] args)
        {
            double height = 0;
            double width = 0;
            double length = 0;
            int coverage = 0;
            int selection = 0;

            char repeat = 'y';

            do
            {
                try
                {
                    try
                    {
                        Console.Write("Please enter height (meters) of your room: ");
                        height = double.Parse(Console.ReadLine());

                        Console.Write("please enter width (meters) of your room: ");
                        width = double.Parse(Console.ReadLine());

                        Console.Write("please enter length (meters) of your room: ");
                        length = double.Parse(Console.ReadLine());
                    }

                    catch (Exception Ex)
                    {
                        Console.WriteLine("\nPlease use numbers...\n");

                        Console.Write("Please enter height (meters) of your room: ");
                        height = double.Parse(Console.ReadLine());

                        Console.Write("please enter width (meters) of your room: ");
                        width = double.Parse(Console.ReadLine());

                        Console.Write("please enter length (meters) of your room: ");
                        length = double.Parse(Console.ReadLine());
                    }

                    Console.WriteLine("\nWhich paint would like to use:\n\n1-Matt Emulsion Paint\n2-One Coat Matt Emulsion\n3-Durable Matt Emulsion\n4-Other...");
                    try
                    {
                        selection = int.Parse(Console.ReadLine());
                    }
                    catch (Exception Ex)
                    {
                        Console.WriteLine("You did not press number...");
                    }

                    try
                    {
                        switch (selection)
                        {
                            case 1:
                                coverage = 13;
                                break;
                            case 2:
                                coverage = 20;
                                break;
                            case 3:
                                coverage = 30;
                                break;
                            case 4:
                                Console.Write("\nPlease enter coverage of your paint (square meters per litre): ");
                                coverage = int.Parse(Console.ReadLine());
                                break;
                            default:
                                Console.Write("\nYou have to enter coverage of your paint anyway (square meters per litre): ");
                                coverage = int.Parse(Console.ReadLine());
                                break;
                        }
                    }
                    catch (Exception Ex)
                    {
                        Console.WriteLine("\nDefault coverage is: 13 square meters per litre");
                        coverage = 13;
                    }




                    Console.WriteLine("\n\n\n");

                    Measurement measurement = new Measurement(height, width, length, coverage);

                    Console.WriteLine("Area of the floor equals: " + measurement.Flour() + " square meters \n");

                    Console.WriteLine("Volume of the room equals: " + measurement.Volume() + " cubic meters \n");

                    measurement.PaintRequired();

                    Console.Write("\nWould you like to do measuremnt again y/n: ");
                    repeat = char.Parse(Console.ReadLine());
                    Console.WriteLine();
                }
                catch (Exception Ex)
                {
                    Console.WriteLine("\n" + Ex + "\n");
                }
            }
            while (repeat == 'y');

            Console.Write("\nPress enter to exit...");
            Console.ReadLine();

        }
    }
}
