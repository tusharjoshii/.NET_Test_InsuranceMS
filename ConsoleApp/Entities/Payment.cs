using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Entities
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public DateTime PaymentDate { get; set; }
        public double PaymentAmount { get; set; }
        public Client Client { get; set; } 

        // Default constructor
        public Payment() { }

        // Parameterized constructor
        public Payment(int paymentId, DateTime paymentDate, double paymentAmount, Client client)
        {
            PaymentId = paymentId;
            PaymentDate = paymentDate;
            PaymentAmount = paymentAmount;
            Client = client;
        }

        // ToString method
        public override string ToString()
        {
            return $"Payment ID: {PaymentId}, Payment Date: {PaymentDate}, Payment Amount: {PaymentAmount}";
        }
    }
}
