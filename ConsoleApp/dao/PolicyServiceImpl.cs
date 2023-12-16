using ConsoleApp.Entities;
using ConsoleApp.exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.util;
using System.Data.SqlClient;
using ConsoleApp.exceptions;

namespace ConsoleApp.dao
{
    public class PolicyServiceImpl : IPolicyService
    {
        private string connectionString;
        SqlCommand cmd = null;

        public PolicyServiceImpl()
        {
            connectionString = DBConnection.GetConnectionString();
            cmd = new SqlCommand();
        }

        //CreatePolicy method
        public bool CreatePolicy(Policy policy)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "INSERT INTO Policies (policy_number, policy_type, coverage_amount, premium_amount, start_date, end_date) VALUES (@PolicyNumber, @PolicyType, @CoverageAmount, @PremiumAmount, @StartDate, @EndDate)";
                cmd.Parameters.AddWithValue("@PolicyNumber", policy.PolicyNumber);
                cmd.Parameters.AddWithValue("@PolicyType", policy.PolicyType);
                cmd.Parameters.AddWithValue("@CoverageAmount", policy.CoverageAmount);
                cmd.Parameters.AddWithValue("@PremiumAmount", policy.PremiumAmount);
                cmd.Parameters.AddWithValue("@StartDate", policy.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", policy.EndDate);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int addPolicyStatus = cmd.ExecuteNonQuery();
                return addPolicyStatus > 0;
            }
        }

        //GetPolicy method
        public Policy GetPolicy(int policyId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT * FROM Policies WHERE policy_id = @PolicyId";
                cmd.Parameters.AddWithValue("@PolicyId", policyId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Policy
                        {
                            PolicyId = (int)reader["policy_id"],
                            PolicyNumber = (string)reader["policy_number"],
                            PolicyType = (string)reader["policy_type"],
                            CoverageAmount = (decimal)reader["coverage_amount"],
                            PremiumAmount = (decimal)reader["premium_amount"],
                            StartDate = (DateTime)reader["start_date"],
                            EndDate = (DateTime)reader["end_date"]
                        };
                    }
                    else
                    {
                        throw new PolicyNumberNotFoundException($"Policy with ID {policyId} not found.");
                    }
                }
            }
        }

        //GetAllPolicies method
        public List<Policy> GetAllPolicies()
        {
            List<Policy> policies = new List<Policy>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT * FROM Policies";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        policies.Add(new Policy
                        {
                            PolicyId = (int)reader["policy_id"],
                            PolicyNumber = (string)reader["policy_number"],
                            PolicyType = (string)reader["policy_type"],
                            CoverageAmount = (decimal)reader["coverage_amount"],
                            PremiumAmount = (decimal)reader["premium_amount"],
                            StartDate = (DateTime)reader["start_date"],
                            EndDate = (DateTime)reader["end_date"]
                        });
                    }
                }
            }
            return policies;
        }

        //UpdatePolicy method
        public bool UpdatePolicy(Policy policy)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "UPDATE Policies SET policy_number = @PolicyNumber, policy_type = @PolicyType, coverage_amount = @CoverageAmount, premium_amount = @PremiumAmount, start_date = @StartDate, end_date = @EndDate WHERE policy_id = @PolicyId";
                cmd.Parameters.AddWithValue("@PolicyId", policy.PolicyId);
                cmd.Parameters.AddWithValue("@PolicyNumber", policy.PolicyNumber);
                cmd.Parameters.AddWithValue("@PolicyType", policy.PolicyType);
                cmd.Parameters.AddWithValue("@CoverageAmount", policy.CoverageAmount);
                cmd.Parameters.AddWithValue("@PremiumAmount", policy.PremiumAmount);
                cmd.Parameters.AddWithValue("@StartDate", policy.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", policy.EndDate);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int updatePolicyStatus = cmd.ExecuteNonQuery();
                return updatePolicyStatus > 0;
            }
        }

        //DeletePolicy method
        public bool DeletePolicy(int policyId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "DELETE FROM Policies WHERE policy_id = @PolicyId";
                cmd.Parameters.AddWithValue("@PolicyId", policyId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int deletePolicyStatus = cmd.ExecuteNonQuery();
                return deletePolicyStatus > 0;
            }
        }
    }
}