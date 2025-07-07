using System;
using System.Collections.Generic;

namespace GeekTrust
{
    public class Passenger
    {
        public readonly string metroCardId;

        public int balance;

        public Dictionary<MetroStation, int> totaldDiscount;

        public Dictionary<MetroStation, int> expenseTillDate;

        public MetroStation lastRideFrom;

        public Dictionary<MetroStation, Dictionary<PassengerType, int>> totalRidesTakenForThisCard;

        public Passenger(string metroCardId, int balance)
        {
            this.metroCardId = metroCardId;
            this.balance = balance;
            lastRideFrom = MetroStation.None;
            totaldDiscount = new Dictionary<MetroStation, int>();
            expenseTillDate = new Dictionary<MetroStation, int>();
            totalRidesTakenForThisCard = new Dictionary<MetroStation, Dictionary<PassengerType, int>>();
            // init Dicts with 0s.
            foreach (MetroStation station in Enum.GetValues(typeof(MetroStation)))
            {
                totaldDiscount.Add(station, 0);
                expenseTillDate.Add(station, 0);
                totalRidesTakenForThisCard.Add(station, new Dictionary<PassengerType, int>());
                foreach (PassengerType passengerType in Enum.GetValues(typeof(PassengerType)))
                {
                    totalRidesTakenForThisCard[station].Add(passengerType, 0);
                }
            }
        }
    }
}