﻿using System;
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

        public void set(double pos, double vel, double acc, double t)
        {
            position = pos;
            velocity = vel;
            acceleration=acc;
            time=t;

            Console.WriteLine("position:{0}, velocity:{1}, acceleration:{2}, time:{3} ", pos, vel, acc, t);

        }

    }
}
