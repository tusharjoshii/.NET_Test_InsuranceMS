using ConsoleApp.dao;
using ConsoleApp.Entities;
using ConsoleApp.exceptions;

public class MainModule
{
    public static void Main(string[] args)
    {
        IPolicyService policyService = new PolicyServiceImpl();

        try
        {
            // Ask for user input
            Console.Write("Enter Policy Number: ");
            string policyNumber = Console.ReadLine();

            Console.Write("Enter Policy Type: ");
            string policyType = Console.ReadLine();

            Console.Write("Enter Coverage Amount: ");
            double coverageAmount = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Premium Amount: ");
            double premiumAmount = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Start Date (yyyy-mm-dd): ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter End Date (yyyy-mm-dd): ");
            DateTime endDate = DateTime.Parse(Console.ReadLine());

            // Create a new policy
            Policy newPolicy = new Policy
            {
                PolicyNumber = policyNumber,
                PolicyType = policyType,
                CoverageAmount = (decimal)coverageAmount,
                PremiumAmount = (decimal)premiumAmount,
                StartDate = startDate,
                EndDate = endDate
            };
            bool isPolicyCreated = policyService.CreatePolicy(newPolicy);
            Console.WriteLine(isPolicyCreated ? "Policy created successfully." : "Failed to create policy.");

            // Get a policy
            Console.Write("Enter Policy ID to retrieve: ");
            int policyId = Convert.ToInt32(Console.ReadLine());
            Policy policy = policyService.GetPolicy(policyId);
            Console.WriteLine(policy.ToString());

            // Get all policies
            List<Policy> policies = policyService.GetAllPolicies();
            foreach (Policy p in policies)
            {
                Console.WriteLine(p.ToString());
            }

            // Update a policy
            Console.Write("Enter Policy ID to update: ");
            policyId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter new Premium Amount: ");
            premiumAmount = Convert.ToDouble(Console.ReadLine());
            newPolicy.PolicyId = policyId;
            newPolicy.PremiumAmount = (decimal)premiumAmount;
            bool isPolicyUpdated = policyService.UpdatePolicy(newPolicy);
            Console.WriteLine(isPolicyUpdated ? "Policy updated successfully." : "Failed to update policy.");

            // Delete a policy
            Console.Write("Enter Policy ID to delete: ");
            policyId = Convert.ToInt32(Console.ReadLine());
            bool isPolicyDeleted = policyService.DeletePolicy(policyId);
            Console.WriteLine(isPolicyDeleted ? "Policy deleted successfully." : "Failed to delete policy.");
        }
        catch (PolicyNumberNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
