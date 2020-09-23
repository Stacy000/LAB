using System;
namespace CarSimulator
{

    public class Physics1D
    {
        // Implement the methods
        public static double compute_position(double x0, double v, double dt)
        {
            double position = x0 + v * dt;

            return position;
        }
        public static double compute_velocity(double v0, double a, double dt)
        {
            double velocity_1 = v0 + a * dt;

            return velocity_1;
        }
        public static double compute_velocity(double x0, double t0, double x1, double t1)
        {
            double velocity_2 = (x1 - x0) / (t1 - t0);

            return velocity_2;
        }
        public static double compute_acceleration(double v0, double t0, double v1, double t1)
        {
            double acceleration_1 = (v1 - v0) / (t1 - t0);

            return acceleration_1;
        }

        public static double compute_acceleration(double f, double m)
        {
            double acceleration_2 = f / m;

            return acceleration_2;
        }
    }

}
