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
        public State()
        {
            position = 0;
            velocity = 0;
            acceleration = 0;
            time = 0;

        }
        public State(double position, double velocity, double acceleration, double time)
        {
            this.position = position;
            this.velocity = velocity;
            this.acceleration = acceleration;
            this.time = time;

        }

        public static void set(double position, double velocity, double acceleration, double time)
        {

        }

        


    }
}
