using Assignment4._3._1.Models;

namespace Assignment4._3._1
{
    internal class Program
    {
        static int customerId;
        static string? name;
        static double unitConsumed;
        static double chargePerUnit;
        static double unitPrice;
        static double surcharge;
        static double netBill;

        Constants constants = new Constants();
        static void Main(string[] args)
        {
            GetInputs();
            CalculateElectricityBill();
            PrintOutput();
        }

        public static void GetInputs()
        {
            Console.Write($"Enter Your ID: ");
            customerId = Convert.ToInt32(Console.ReadLine());
            Console.Write($"Enter Your Name: ");
            name = Console.ReadLine();
            Console.Write($"Electricity Consumed (Total Unit): ");
            unitConsumed = Convert.ToDouble(Console.ReadLine());
        }

        public static void CalculateElectricityBill()
        {
            switch(unitConsumed)
            {
                case double uc when (uc < 200):
                    unitPrice = unitConsumed * Constants.upto199;
                    chargePerUnit = Constants.upto199;
                    break;
                case double uc when (uc >= 200 && uc < 400):
                    unitPrice = unitConsumed * Constants.from200to399;
                    chargePerUnit = Constants.from200to399;
                    break;
                case double uc when (uc >= 400 && uc < 600):
                    unitPrice = unitConsumed * Constants.from400to599;
                    chargePerUnit = Constants.from400to599;
                    break;
                case double uc when (uc >= 600):
                    unitPrice = unitConsumed * Constants.above600;
                    chargePerUnit = Constants.above600;
                    break;
                default:
                    Console.WriteLine($"Invalid Unit: {unitConsumed}");
                    break;
            }

            switch(unitPrice)
            {
                case < 401:
                    surcharge = 0;
                    netBill = unitPrice;
                    break;
                case > 400:
                    surcharge = unitPrice * Constants.surcharge;
                    netBill = unitPrice + surcharge;
                    break;
                default :
                    Console.WriteLine($"Invalid Input");
                    break;
            }
                                
        }

        public static void PrintOutput()
        {
            Console.WriteLine($"Customer ID NO: {customerId}\r\nCustomer Name: {name}\r\nunit Consumed: {unitConsumed}\r\n" +
                $"Amount Charges @$ {chargePerUnit} per unit: {unitPrice}\r\nSurcharge Amount: {surcharge}\r\nNet Amount Paid By the Customer: {netBill}");
        }
    }
}
