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
        bool on = false;

        

        /// implement constructor and methods
        public Car()
        {
            this.mass = 0;
            this.model = null;
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
            

        }

        public string getModel()
        {
            return model;
        }

        public double getMass()
        {
            return mass;
        }

        public void accelerate(bool on)
        {
            

        }
        
        public void drive(double dt)
        {

        }

       
        //implement inheritence


    }
}
