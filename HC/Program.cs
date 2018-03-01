using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC
{
    class Program
    {
        static string a = "a_example.in";
        static string b = "b_should_be_easy.in";
        static string c = "c_no_hurry.in";
        static string d = "d_metropolis.in";

       

        static void Main(string[] args)
        {
            Simulator simulator = new Simulator();
            simulator.Simulate();
            string ansv = "";
            foreach (var car in simulator.Data.Cars)
            {
                ansv += car.CompletedRides.Count + " " + string.Join(" ", car.CompletedRides) + Environment.NewLine;
            }
            File.WriteAllText("ans_a.txt", ansv);
        }
    }
}
