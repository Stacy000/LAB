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

        }
        public Car(string model, double mass, double engineForce, double dragArea,)
        {
            this.mass = mass;
            this.model = model;
            this.dragArea = dragArea;
            this.engineForce = engineForce;

        }

        public static string getModel()
        {
            string hello = "hello";

            return hello ;
        }

        public static double getMass()
        {
            return 0;
        }

        public static void accelerate(bool on)
        {

        }
        
        public static void drive(double dt)
        {

        }

        public static State getState()
        {
            
        }
         
        //implement inheritence


    }
}
