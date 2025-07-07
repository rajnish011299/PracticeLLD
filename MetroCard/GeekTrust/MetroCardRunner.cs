using System;
using System.IO;

namespace GeekTrust
{
    public class MetrocardRunner
    {
        public MetrocardRunner()
        {

        }

        public void RouteTransaction(string filePath)
        {
            string[] inputData = File.ReadAllLines(filePath);
            TransactionControllerBase controllerBase;

            foreach (string line in inputData)
            {
                string[] lineParts = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (lineParts.Length < 1)
                {
                    throw new Exception("Invalid input");
                }

                TransactionType commandType = (TransactionType)Enum.Parse(typeof(TransactionType), lineParts[0].Trim());
                switch (commandType)
                {
                    case TransactionType.BALANCE:
                        {
                            controllerBase = new LoadUserBalanceInCard();
                            break;
                        }
                    case TransactionType.CHECK_IN:
                        {
                            controllerBase = new ProcessJourney();
                            break;
                        }
                    case TransactionType.PRINT_SUMMARY:
                        {
                            controllerBase = new PrintSummary();
                            break;
                        }
                    default:
                        throw new Exception("Not a valid input command");
                }
                controllerBase.ExecuteTransaction(lineParts);
            }
        }
    }
}