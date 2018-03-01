using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC
{
    public class DataReader
    {
        public Data GetData(string file)
        {
            var data = new Data { Rides = new List<Ride>() };
            using (StreamReader streamReader = new StreamReader(file))
            {
                var header = streamReader.ReadLine();
                var headers = header.Split(' ').Select(x=>Int64.Parse(x)).ToList();
                data.Rows = headers[0];
                data.Cols = headers[1];
                data.Vehicles = headers[2];
                data.Cars = new List<Car>();
                for (int i = 0; i < data.Vehicles; i++)
                {
                    data.Cars.Add(new Car { CurrentPosition = new Position { X = 0, Y = 0 } });
                }
                data.RidesCount = headers[3];
                data.Bonus = headers[4];
                data.Steps = headers[5];
                var index = 0;
                while (!streamReader.EndOfStream)
                {
                    var carData = streamReader.ReadLine().Split(' ').Select(x => Int64.Parse(x)).ToList();
                    var ride = new Ride {
                        From = new Position { X = carData[0], Y = carData[1] },
                        To = new Position { X = carData[2], Y = carData[3] },
                        EarliestStart = carData[4],
                        LatestFinish = carData[5],
                        Index = index
                        };
                    data.Rides.Add(ride);
                    index++;
                }
                return data;
            }
        }
    }
}
