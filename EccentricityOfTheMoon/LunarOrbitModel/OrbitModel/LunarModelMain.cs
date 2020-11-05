/*
 * Landon Buell, Tan Dao
 * Prof. Long
 * PHYS 705.01 - Eccentricity of The moon
 * 20 October 2020
 */

using System;

namespace OrbitModel
{
    class LunarModelMain
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Earth-Moon System Simulation");

            // Create the System, Add the Earth & Moon
            OrbitSystem EarthMoon = new OrbitSystem("Stellata");
            Body Earth = new Body("Earth", 5.972e24, 6.3710e6);
            Body Moon = new Body("Moon", 7.342e22, 1.7374e6,
                new double[] { 4.054e11, 0, 0 }, new double[] { 0, 1.06e3, 0 });
            EarthMoon.AddBody(Earth);
            EarthMoon.AddBody(Moon);
            EarthMoon.SystemSummary();

            // Check initial Conditions
            EarthMoon.GetBody(0).PrintTrajectory();
            EarthMoon.GetBody(1).PrintTrajectory();

            // Run system
            int nSteps = 3600;
            EarthMoon.__Call__(nSteps);

            // Check final conditions
            EarthMoon.GetBody(0).PrintTrajectory();
            EarthMoon.GetBody(1).PrintTrajectory();


            Console.WriteLine("=)");

        }
    }
}
