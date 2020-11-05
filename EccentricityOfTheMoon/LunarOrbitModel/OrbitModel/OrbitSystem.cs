using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrbitModel
{

    public class OrbitSystem
    {
        // Represents a System of Interacting masses
        private string name;
        private List<Body> bodies;
        private int nBodies;
        private int niters;
        
        public OrbitSystem(string _name)
        {
            // Contructor Method for OrbitSystem Instance
            this.name = _name;
            this.bodies = new List<Body>();
            this.nBodies = 0;
            this.niters = 0;
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

        public Body GetBody(int index)
        {
            // Get i-th body in list
            return bodies[index];
        }

        private double TotalMass()
        {
            // Compute total mass of all bodies in system:
            double _totalMass = 1e-10;  
            for (int i = 0; i < bodies.Count; i++)
                _totalMass += bodies[i].mass;
            // Note: init CoM is non-zero for numerical stability
            return _totalMass;
        }

        private double[] CenterOfMass()
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
            string _dashes = string.Concat(Enumerable.Repeat("-", 64)) + "\n";
            List<string> _hdrs = new List<string>
                { "Index","Name","Mass [kg]","Radius [m]","Volume [m^3]","Density [kg/m^3]"};

            // Create StringBuilder Object to Hold String Summary
            var stringSummary = new StringBuilder();
            stringSummary.Append(String.Format("\nSystem Summary:{0}", name));
            stringSummary.Append("\n"+_dashes);
            stringSummary.Append(String.Format("{0,-8} {1,-16} {2,-16} {3,-16} {4,-16} {5,-16}\n",
                                            _hdrs[0],_hdrs[1],_hdrs[2],_hdrs[3],_hdrs[4],_hdrs[5]));
            for (int i = 0; i <nBodies; i++)
            {
                // Go to each body in system & collect attributes
                List<string> _attrbs = bodies[i].GetAttributes();
                string _bodyDetails = String.Format("{0,-8} {1,-16} {2,-16} {3,-16} {4,-16} {5,-16}\n",
                    Convert.ToString(i), _attrbs[0],_attrbs[1], _attrbs[2], _attrbs[3], _attrbs[4]) ;
                stringSummary.Append(_bodyDetails);
            }
            stringSummary.Append(_dashes);

            Console.WriteLine(stringSummary);
        }

        private void MoveAllBodies()
        {
            // Move each body in the system according to updates
            for (int i = 0; i < nBodies; i++)
                bodies[i].Move();
        }

        private void ComputeAccelerations()
        {
            // Clear all acceleration vectors for step
            for (int i = 0; i < nBodies; i++)
                bodies[i].Acceleration = new double[]{ 0.0,0.0,0.0,};

            // Compute Acceleration vectors action on each body
            for (int i = 0; i < nBodies;i++)
            {
                for (int j = 0; j < nBodies; j++)
                {
                    if (i == j) { continue; }       // Skip if body is the same
                    double[] _oldAcl = bodies[i].Acceleration;
                    double[] _newAcl = Physics.ComputeAcceleration(bodies[i], bodies[j]);
                    bodies[i].Acceleration = LinearAlgebra.VectorAdd(_oldAcl, _newAcl);
                }
            }
        }

        public void __Call__(int iters)
        {
            // Call this system
            for (int i=0; i < iters; i++)
            {
                // Compute the Accelertation acting on each body
                ComputeAccelerations();
                MoveAllBodies();
            }
        }


    } 
}
