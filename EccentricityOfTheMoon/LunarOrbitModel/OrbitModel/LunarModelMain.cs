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
            EarthMoon.AddBody(new Body("Earth", 5.972e24, 6.3710e6));
            EarthMoon.AddBody(new Body("Moon", 7.342e22 , 1.7374e6,
                new double[] {4.054e11,0,0}, new double[] {0,1.06e3,0}));
            EarthMoon.SystemSummary();


        }


    }
}
