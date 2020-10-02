using System;
namespace CarSimulator
{
    public class Car
    {
        protected double mass;
        private string model;
        protected double dragArea;
        protected double engineForce;
        public State myCarState;
        


        /// implement constructor and methods
        public Car()
        {
            this.mass = 0;
            this.model = "";
            this.dragArea = 0;
            this.engineForce = 0;
            myCarState = new State();
            

        }
        public Car(string model, double mass, double engineForce, double dragArea)
        {
            this.mass = mass;
            this.model = model;
            this.dragArea = dragArea;
            this.engineForce = engineForce;
            myCarState = new State();

        }

        public string getModel()
        {
            return model;
        }

        public double getMass()
        {
            return mass;
        }

     
        
        public virtual void drive(double dt)
        {

            double f= 0.5 * 1.225 * dragArea * myCarState.velocity * myCarState.velocity;
            double acc = Physics1D.compute_acceleration(engineForce - f, mass);
            double vel = Physics1D.compute_velocity(myCarState.velocity, acc, dt);
            double pos = Physics1D.compute_position(myCarState.position, vel, dt);
            double t = myCarState.time + dt;


            myCarState.set(pos, vel, acc, t);
        }


        public State getState()
        {
            return myCarState;

        }


        //implement inheritence


    }

    class Prius : Car
    {
        public Prius() : base()
        {

        }

        public Prius(string model, double mass, double engineForce, double dragArea) : base(model, mass, engineForce, dragArea)
        {

        }
    }

    class Mazda : Car
    {
        public Mazda() : base()
        {

        }

        public Mazda(string model, double mass, double engineForce, double dragArea) : base(model, mass, engineForce, dragArea)
        {

        }
    }
    class Tesla : Car
    {
        public Tesla() : base()
        {

        }

        public Tesla(string model, double mass, double engineForce, double dragArea) : base(model, mass, engineForce, dragArea)
        {
            
        }
    }
    class Herbie : Car
    {
        Random random = new Random();
        
        public Herbie() : base()
        {

        }

        public Herbie(string model, double mass, double engineForce, double dragArea) : base(model, mass, engineForce, dragArea)
        {

        }
        public override void drive(double dt)
        {
            
            Console.WriteLine("myCarState={0}", myCarState.velocity);
            double f = 0.5 * 1.225 * dragArea * myCarState.velocity * myCarState.velocity;
            double a = Physics1D.compute_acceleration(engineForce-f, mass);
            double v = Physics1D.compute_velocity(myCarState.velocity, a, dt);
            Console.WriteLine("v={0} ", v);
            v += random.Next(50); 
            Console.WriteLine("v={0} ", v);
            double p = Physics1D.compute_position(myCarState.position, v, dt);
            double t = myCarState.time + dt;
            myCarState.set(p, v, a, t);
        }
    }

}
