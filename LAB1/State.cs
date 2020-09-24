using System;
namespace CarSimulator
{
    public class State
    {
        public double position;
        public double velocity;
        public double acceleration;
        public double time;

        //implement methods like set, constructors (if applicable)

        public static void set(double position, double velocity, double acceleration, double time)
        {

        }

        public State(double position, double velocity, double acceleration, double time)
        {
            this.position = 0;
            this.velocity = 0;
            this.acceleration = 0;
            this.time = 0;

        }
        
    }
}
