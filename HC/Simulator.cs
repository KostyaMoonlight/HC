using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC
{
    public class Simulator
    {
        string a = "a_example.in";
        string b = "b_should_be_easy.in";
        string c = "c_no_hurry.in";
        string d = "d_metropolis.in";
        int globalTurn = 0;
        public Data Data { get; set; }
        public Simulator()
        {
            DataReader dataReader = new DataReader();
            Data = dataReader.GetData(a);
        }

        public void Simulate()
        {
            for (int step = 0; step < Data.Steps; step++)
            {
                foreach (var ride in Data.Rides.Where(x => x.Car == null && x.IsCompleted == false))
                {
                    Car bestCar = null;
                    double bestMatch = 0;
                    foreach (var car in Data.Cars.Where(x => x.Ride == null))
                    {
                        var match = Match(ride, car, step);
                        if (match > 0 && match > bestMatch)
                        {
                            bestMatch = match;
                            bestCar = car;
                        }
                    }
                    if (bestCar != null)
                    {
                        bestCar.Ride = ride;
                        ride.Car = bestCar;
                        bestCar.Dist = bestCar.Ride.From.Dist(bestCar.CurrentPosition) + bestCar.Ride.Dist;
                    }


                }

                foreach (var car in Data.Cars.Where(x=>x.Ride!=null))
                {
                    car.Run();
                }

            }
        }

        public double Match(Ride ride, Car car, int globalTurn)
        {
            var distToStart = ride.From.Dist(car.CurrentPosition);
            var bonus = (globalTurn + distToStart) - ride.EarliestStart;
            var point = ride.Dist + ((bonus <= 0) ? Data.Bonus : 0);
            var turnsElaps = distToStart + ride.Dist + (ride.LatestFinish -( ride.EarliestStart - (globalTurn+ distToStart)));
            double cost = (double)point / turnsElaps;
            return cost;

        }


    }
}
