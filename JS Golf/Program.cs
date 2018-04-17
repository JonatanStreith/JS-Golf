using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS_Golf
{
    class Program
    {
        static void Main(string[] args)
        {


            try
            {
            PlayGolf();              //Calls separate function - keeps it tidy!

            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.ParamName);
                Console.WriteLine();
                Console.WriteLine("G A M E   O V E R");
                Console.ReadKey();
                Environment.Exit(0);
            }

            


        }

        public static double MakeSwing(double angle, double velocity)
        {
            double angleInRadians = (Math.PI / 180) * angle;
            double shotLength = Math.Pow(velocity, 2) / 9.8 * Math.Sin(2 * angleInRadians);

            return shotLength;
        }


        public static void PlayGolf()
        {
            double swingAngle;
            double swingVelocity;
            double shotLength;              //How far the latest shot goes
            double playLength;              //How much of the course is left to play
            int numberOfSwings = 0;
            bool correctEntry;

            Random courseRandomizer = new Random();
            playLength = Convert.ToDouble(courseRandomizer.Next(300, 600));            //generate course



            Console.WriteLine("Welcome to the wonderful world of golf!");
            Console.WriteLine($"The course before you is {playLength} meters long. How many swings will it take you to finish it?");
            Console.WriteLine("Time to swing for it! Choose the angle of your swing, and the velocity.");


            do
            {
                Console.WriteLine();
                Console.WriteLine($"You have {Math.Round(playLength, 2)} meters to cover. You've made {numberOfSwings} swings so far.");

                //Swing, calculate distance of shot, calculate remaining distance
                Console.Write("Angle: ");
                correctEntry = double.TryParse(Console.ReadLine(), out swingAngle);
                if (!correctEntry)
                {
                    Console.WriteLine("That's not a number.");
                    continue;
                }
                Console.Write("Velocity: ");
                correctEntry = double.TryParse(Console.ReadLine(), out swingVelocity);
                if (!correctEntry)
                {
                    Console.WriteLine("That's not a number.");
                    continue;
                }



                shotLength = MakeSwing(swingAngle, swingVelocity);

                Console.WriteLine($"A beautiful swing! The ball flies {Math.Round(shotLength, 2)} meters.");

                playLength = Math.Abs(playLength - shotLength);

                numberOfSwings++;


                if (numberOfSwings > 10)
                {
                    throw new ArgumentOutOfRangeException("You just keep swinging and swinging. Get more practice before you try this course again, okay?");
                }

                if (playLength > 1000)
                {
                    throw new ArgumentOutOfRangeException("Oh, too bad! You're out of bounds!");
                }


            }
            while (playLength > 0.01);

            Console.WriteLine($"The ball is in! You completed this course in {numberOfSwings} swings.");
            Console.ReadLine();


        }

    }
}
