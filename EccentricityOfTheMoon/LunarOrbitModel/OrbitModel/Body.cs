using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrbitModel
{
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
            Acceleration = new double[3] { 0.0, 0.0, 0.0 };
        }

        public double[] Position { get; set; }

        public double[] Velocity { get; set; }

        public double[] Acceleration { get; set; }

        public void PrintTrajectory()
        {
            // Print Summary Position,Velocity,Accelerations for this body
            string _dashes = string.Concat(Enumerable.Repeat("-", 64)) + "\n";
            string _frmt = "0.0000";
            List<string> _hdrs = new List<string>
                { " ", "Position [m]","Velocity [m/s]","Acceleration [m/s/s]"};

            // Create StringBuilder Object to Hold String Summary
            var stringSummary = new StringBuilder();
            stringSummary.Append(String.Format("\nBody Summary:{0}", name));
            stringSummary.Append("\n" + _dashes);
            stringSummary.Append(String.Format("{0,-4} {1,-16} {2,-16} {3,-16}\n",
                                            _hdrs[0], _hdrs[1], _hdrs[2], _hdrs[3]));
            List<string> _components = new List<string> { "X", "Y", "Z" };
            for (int i = 0; i < 3; i++)
            {
                stringSummary.Append(String.Format("{0,-4} {1,-16} {2,-16} {3,-16}\n",
                    _components[i], Position[i], Velocity[i].ToString(_frmt), 
                    Acceleration[i].ToString(_frmt)));
            }
            stringSummary.Append(_dashes);
            Console.WriteLine(stringSummary);
        }

        public List<string> GetAttributes()
        {
            // Collect & return array of attributes
            List<string> _attrbs = new List<string>
            { name, Convert.ToString(mass), Convert.ToString(radius),
                Convert.ToString(volume), Convert.ToString(density)};
            return _attrbs;
        }

        public void Move()
        {
            // Use Current Acceleration to Update Veclocity
            double[] _oldVel = Velocity;
            Velocity = LinearAlgebra.VectorAdd(_oldVel, Acceleration);

            // Use Current Velocity to Update Position
            double[] _oldPos = Position;
            Position = LinearAlgebra.VectorAdd(_oldPos, Velocity);
        }


    }
}
