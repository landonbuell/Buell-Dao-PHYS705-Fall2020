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
        }

        public double[] Position { get; set; }

        public double[] Velocity { get; set; }

        public double[] Acceleration { get; set; }

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
            // Move according to position Update
            throw new NotImplementedException();
        }


    }
}
