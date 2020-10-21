using System;
using System.Collections.Generic;
using System.Text;

namespace OrbitModel
{

    public class OrbitSystem
    {
        // Represents a System of Interacting masses
        private string name;
        private List<Body> bodies;
        private int nBodies;
        
        public OrbitSystem(string _name)
        {
            // Contructor Method for Bpody Instance
            this.name = _name;
            this.bodies = new List<Body>();
            this.nBodies = 0;
        }

        public void AddBody(Body newBody)
        {
            // Add Body to This orbital System
            try         // Attempt to add to system
                { bodies.Add(newBody); }
            catch       // If failure:
                { throw new NotImplementedException();}                
            nBodies = bodies.Count;
        }

        public double TotalMass()
        {
            // Compute total mass of all bodies in system:
            double _totalMass = 1e-10;  
            for (int i = 0; i < bodies.Count; i++)
                _totalMass += bodies[i].mass;
            // Note: init CoM is non-zero for numerical stability
            return _totalMass;
        }

        public double[] CenterOfMass()
        {
            // Compute [x,y,z] Center of Mass of System
            double _totalMass = TotalMass();
            double[] _centerOfMass = new double[] { 0.0, 0.0, 0.0 };
            for (int i = 0; i < 3; i++)
            {
                // Each of the three components, [x,y,z]
                for (int j = 0; j < bodies.Count; j++)
                {
                    // Go through each body
                    _centerOfMass[i] += bodies[j].mass * bodies[j].Position[i];
                }
            }
            _centerOfMass = LinearAlgebra.VectorScale(_centerOfMass, 1.0/_totalMass);
            return _centerOfMass;
        }

        public void SystemSummary()
        {
            // Print Summary of This System
            throw new NotImplementedException();
        }
    } 




    public class Body
    {
        // Represents an Object that Graviationally interacts with other bodies
        private string name;
        public double mass;
        private double radius;
        private double volume;
        private double density;

        public Body(string _name, double _mass, double _rad)
        {
            // Constructor Method for Body Instance
            this.name = _name;
            this.mass = _mass;
            this.radius = _rad;
            this.volume = (4 / 3) * Math.PI * Math.Pow(radius, 3);
            this.density = mass / volume;
            Position = new double[3] { 0.0, 0.0, 0.0 };
            Velocity = new double[3] { 0.0, 0.0, 0.0 };
            Acceleration = new double[3] { 0.0, 0.0, 0.0 };
        }

        public Body(string _name, double _mass, double _rad,
                    double[] _x0, double[] _v0)
        {
            // Constructor Method for Body Instance
            this.name = _name;
            this.mass = _mass;
            this.radius = _rad;
            this.volume = (4 / 3) * Math.PI * Math.Pow(radius, 3);
            this.density = mass / volume;
            Position = _x0;
            Velocity = _v0;
        }

        public double[] Position { get; set; }

        public double[] Velocity { get; set; }

        public double[] Acceleration { get; set; }


    }
}
