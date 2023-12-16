using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Entities
{
    public enum ClaimStatus
    {
        PENDING, APPROVED, DENIED
    }

    public class Claim
    {
        public int ClaimId { get; set; }
        public string ClaimNumber { get; set; }
        public DateTime DateFiled { get; set; }
        public double ClaimAmount { get; set; }
        public ClaimStatus Status { get; set; }
        public Policy Policy { get; set; }
        public Client Client { get; set; } 

        // Default constructor
        public Claim() { }

        // Parameterized constructor
        public Claim(int claimId, string claimNumber, DateTime dateFiled, double claimAmount, ClaimStatus status, Policy policy, Client client)
        {
            ClaimId = claimId;
            ClaimNumber = claimNumber;
            DateFiled = dateFiled;
            ClaimAmount = claimAmount;
            Status = status;
            Policy = policy;
            Client = client;
        }

        // ToString method
        public override string ToString()
        {
            return $"Claim ID: {ClaimId}, Claim Number: {ClaimNumber}, Date Filed: {DateFiled}, Claim Amount: {ClaimAmount}, Status: {Status}";
        }
    }
}
