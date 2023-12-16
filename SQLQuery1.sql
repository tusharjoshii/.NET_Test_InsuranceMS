CREATE DATABASE InsuranceMS;

USE InsuranceMS;

--Users table
CREATE TABLE Users (
 user_id INT IDENTITY(1,1) PRIMARY KEY,
 username VARCHAR(50) NOT NULL,
 password VARCHAR(50) NOT NULL,
 role VARCHAR(50) CHECK (role IN ('admin', 'agent', 'client')) NOT NULL
);

--Policies table
CREATE TABLE Policies (
 policy_id INT IDENTITY(1,1) PRIMARY KEY,
 policy_number VARCHAR(20) NOT NULL,
 policy_type VARCHAR(50) NOT NULL,
 coverage_amount DECIMAL(10, 2) NOT NULL,
 premium_amount DECIMAL(8, 2) NOT NULL,
 start_date DATE NOT NULL,
 end_date DATE NOT NULL
);

--Clients table
CREATE TABLE Clients (
 client_id INT IDENTITY(1,1) PRIMARY KEY,
 client_name VARCHAR(100) NOT NULL,
 contact_info VARCHAR(255),
 policy_id INT,
 FOREIGN KEY (policy_id) REFERENCES Policies(policy_id)
);

--Claims table
CREATE TABLE Claims (
 claim_id INT IDENTITY(1,1) PRIMARY KEY,
 claim_number VARCHAR(20) NOT NULL,
 date_filed DATE NOT NULL,
 claim_amount DECIMAL(10, 2) NOT NULL,
 status VARCHAR(50) CHECK (status IN ('pending', 'approved', 'denied')) NOT NULL,
 policy_id INT,
 client_id INT,
 FOREIGN KEY (policy_id) REFERENCES Policies(policy_id),
 FOREIGN KEY (client_id) REFERENCES Clients(client_id)
);

--Payments table
CREATE TABLE Payments (
 payment_id INT IDENTITY(1,1) PRIMARY KEY,
 payment_date DATE NOT NULL,
 payment_amount DECIMAL(8, 2) NOT NULL,
 client_id INT,
 FOREIGN KEY (client_id) REFERENCES Clients(client_id)
);
