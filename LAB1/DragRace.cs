using System;
namespace CarSimulator
{
    public class DragRace
    {
       /* static void Main(string[] args)
        {

            Car myTesla = new Car("Tesla", 1500, 1000, 0.51);
            Car myPrius = new Car("Prius", 1000, 750, 0.43);


            // drive for 60 seconds with delta time of 1s
            double dt = 1;

            for (double t = 0; t < 60; t += dt)
            {
                double priusAcceleration = myPrius.myCarState.acceleration;
                double priusVelocity = myPrius.myCarState.velocity;
                double priusPosition = myPrius.myCarState.position;
                if (priusPosition < 402.3)
                    myPrius.drive(dt);

                double teslaAcceleration = myTesla.myCarState.acceleration;
                double teslaVelocity = myTesla.myCarState.velocity;
                double teslaPosition = myTesla.myCarState.position;
                if (teslaPosition < 402.3)
                    myTesla.drive(dt);

                // print the time and current state
                Console.WriteLine("t = " + t);
                Console.WriteLine("Prius Acceleration:{0}, Prius Velocity:{1}, Prius Position:{2} ", priusAcceleration, priusVelocity, priusPosition);
                Console.WriteLine("Tesla Acceleration:{0}, Tesla Velocity:{1}, Tesla Position:{2} ", teslaAcceleration, teslaVelocity, teslaPosition);

                // print who is in lead
                if (priusPosition > teslaPosition)
                    Console.WriteLine("Prius is in lead.");
                else if (teslaPosition > priusPosition)
                    Console.WriteLine("Tesla is in lead");
                else
                    Console.WriteLine("None of them is in lead");

                //The race between the two cars ends when they both cross the 402.3m mark
                if (priusPosition > 402.3 && teslaPosition > 402.3)
                {
                    Console.WriteLine("The race between two cars ends, and they both cross the 402.3 mark");
                    if (myTesla.myCarState.time < myPrius.myCarState.time)
                        Console.WriteLine("Tesla Win!");
                    else if (myTesla.myCarState.time > myPrius.myCarState.time)
                        Console.WriteLine("Prius Win!");
                    else
                        Console.WriteLine("Tie!");
                    break;
                    // print the time and current state
                    // print who is in lead
                }
            }


        }*/
        
    }
}

