using System;
using System.Collections.Generic;
using System.Linq;

namespace GeekTrust
{
    public class PrintSummary : TransactionControllerBase
    {
        public PrintSummary()
        {

        }

        public override void ExecuteTransaction(string[] transaction)
        {
            foreach (MetroStation station in Enum.GetValues(typeof(MetroStation)))
            {
                if (station == MetroStation.None)
                {
                    continue;
                }

                int totalCollection = 0;
                int totaldDiscount = 0;
                Dictionary<PassengerType, int> totalRides = new Dictionary<PassengerType, int>();
                foreach (Passenger passenger in passengers.Values)
                {
                    totalCollection += passenger.expenseTillDate[station];
                    totaldDiscount += passenger.totaldDiscount[station];
                    var ridesForThisStation = passenger.totalRidesTakenForThisCard[station];
                    foreach (KeyValuePair<PassengerType, int> ride in ridesForThisStation)
                    {
                        if (totalRides.ContainsKey(ride.Key))
                        {
                            totalRides[ride.Key] += ride.Value;
                        }
                        else
                        {
                            totalRides[ride.Key] = ride.Value;
                        }
                    }
                }

                var sortedTotalRides = totalRides.OrderByDescending(kvp => kvp.Value).ThenBy(kvp => kvp.Key.ToString());

                string output = $"TOTAL_COLLECTION {station} {totalCollection} {totaldDiscount}";
                Console.WriteLine(output);
                Console.WriteLine("PASSENGER_TYPE_SUMMARY");
                foreach (var ride in sortedTotalRides)
                {
                    if (ride.Value != 0)
                    {
                        Console.WriteLine($"{ride.Key} {ride.Value}");
                    }
                }
            }
        }
    }
}