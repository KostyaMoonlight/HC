using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC
{
    public class Data
    {
        public Int64 Rows { get; set; }
        public Int64 Cols { get; set; }
        public Int64 Vehicles { get; set; }
        public Int64 RidesCount { get; set; }
        public Int64 Bonus { get; set; }
        public Int64 Steps { get; set; }
        public List<Ride> Rides { get; set; }
        public List<Car> Cars { get; set; }

    }

    public class Ride
    {
        public int Index { get; set; }
        public Position From { get; set; }
        public Position To { get; set; }
        public Int64 EarliestStart { get; set; }
        public Int64 LatestFinish { get; set; }
        public Car Car { get; set; }
        public Int64 Dist { get => To.Dist(From); }
        public bool IsCompleted { get; set; } = false;
    }

    public class Car
    {
        public Position CurrentPosition { get; set; }
        public Int64 Dist { get; set; }
        public Ride Ride { get; set; }
        public List<int> CompletedRides { get; set; } = new List<int>();
        public void Run()
        {
            Dist--;
            if (Dist==0)
            {
                CurrentPosition = Ride.To;
                CompletedRides.Add(Ride.Index);
                Ride.IsCompleted = true;
                Ride.Car = null;
                Ride = null;
            }
        }

    }
}
