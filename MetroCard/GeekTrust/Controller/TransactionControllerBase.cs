using System.Collections.Generic;

namespace GeekTrust
{
    public abstract class TransactionControllerBase
    {
        protected static Dictionary<string, Passenger> passengers = new Dictionary<string, Passenger>();
        public abstract void ExecuteTransaction(string[] transaction);
    }
}