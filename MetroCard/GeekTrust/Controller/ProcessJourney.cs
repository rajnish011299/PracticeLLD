using System;

namespace GeekTrust
{
    public class ProcessJourney : TransactionControllerBase
    {
        private const double serviceFeePercentage = 0.02;
        private const double returnJournerDiscount = 0.5;
        public ProcessJourney()
        {

        }

        public override void ExecuteTransaction(string[] transaction)
        {
            FetchPassengerAndStationAndFair(transaction, out int fare, out Passenger passenger, out PassengerType type, out MetroStation currentStation);

            int discountedFare = fare;
            if (passenger.lastRideFrom != currentStation && passenger.lastRideFrom != MetroStation.None)
            {
                discountedFare = (int)(fare * returnJournerDiscount);
                passenger.lastRideFrom = MetroStation.None; // discount given for round trip
            }
            else
            {
                passenger.lastRideFrom = currentStation;
            }
            passenger.totaldDiscount[currentStation] += fare - discountedFare;
            passenger.totalRidesTakenForThisCard[currentStation][type] += 1;

            CalculateServiceFeeAndDeductFare(passenger, discountedFare, out int serviceFee);

            passenger.expenseTillDate[currentStation] += discountedFare + serviceFee;
        }

        #region private methods

        private void FetchPassengerAndStationAndFair(string[] transaction, out int fare, out Passenger passenger, out PassengerType type, out MetroStation currentStation)
        {
            string metroCardId = transaction[1].Trim();
            string passengerType = transaction[2].Trim();
            string metroStationName = transaction[3].Trim();

            type = (PassengerType)Enum.Parse(typeof(PassengerType), passengerType, ignoreCase: true);
            fare = ((FareAttribute)Attribute.GetCustomAttribute(typeof(PassengerType).GetField(type.ToString()), typeof(FareAttribute))).Value;

            passenger = passengers[metroCardId];

            currentStation = (MetroStation)Enum.Parse(typeof(MetroStation), metroStationName, ignoreCase: true);
        }

        private void CalculateServiceFeeAndDeductFare(Passenger passenger, int discountedFare, out int serviceFee)
        {
            // deduct fare
            serviceFee = 0;
            if (passenger.balance < discountedFare)
            {
                int balanceToLoadFromAccount = discountedFare - passenger.balance;
                serviceFee = (int)(serviceFeePercentage * balanceToLoadFromAccount);
                passenger.balance = 0;
            }
            else
            {
                passenger.balance -= discountedFare;
            }
        }

        #endregion
    }
}