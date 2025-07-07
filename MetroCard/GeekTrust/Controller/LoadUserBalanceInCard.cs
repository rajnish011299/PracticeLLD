using System.Collections.Generic;

namespace GeekTrust
{
    public class LoadUserBalanceInCard : TransactionControllerBase
    {
        public LoadUserBalanceInCard()
        {

        }

        public override void ExecuteTransaction(string[] transaction)
        {
            string metroCardId = transaction[1].Trim();
            int balance = int.Parse(transaction[2].Trim());
            passengers.Add(metroCardId, new Passenger(metroCardId, balance));
        }
    }
}