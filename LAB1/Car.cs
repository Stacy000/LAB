using System;
namespace CarSimulator
{
    public class Car
    {
        private double mass;
        private string model;
        private double dragArea;
        private double engineForce;
        public State myCarState;
        


        /// implement constructor and methods
        public Car()
        {
            this.mass = 0;
            this.model = null;
            this.dragArea = 0;
            this.engineForce = 0;

          //  myCarState = new State();

        }
        public Car(string model, double mass, double engineForce, double dragArea)
        {
            this.mass = mass;
            this.model = model;
            this.dragArea = dragArea;
            this.engineForce = engineForce;
            

        }

        public string getModel()
        {
            return model;
        }

        public double getMass()
        {
            return mass;
        }

     
        
        public void drive(double dt)
        {

            double f= 0.5 * 1.225 * dragArea * myCarState.velocity * myCarState.velocity;
            double acc = Physics1D.compute_acceleration(engineForce - f, mass);
            double vel = Physics1D.compute_velocity(myCarState.velocity, myCarState.acceleration, dt);
            double pos = Physics1D.compute_position(myCarState.position, myCarState.velocity, dt);
            double t = myCarState.time + dt;


            myCarState.set(pos, vel, acc, t);
        }


        public State getState()
        {
            return myCarState;

        }


        //implement inheritence


    }
}
