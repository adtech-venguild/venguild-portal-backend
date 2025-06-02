-- Create database
CREATE DATABASE IF NOT EXISTS venguild;
USE venguild;

-- Create table
-- Check if the table exists before creating
CREATE TABLE IF NOT EXISTS People (
    Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    FirstName VARCHAR(100) NOT NULL,
    LastName VARCHAR(100) NOT NULL,
    MiddleName VARCHAR(100),
    Suffix VARCHAR(20),
    BirthDate DATE NOT NULL,
    Gender VARCHAR(10),
    Photo TEXT,
    MobileNumber VARCHAR(20),
    TelephoneNumber VARCHAR(20),
    Email VARCHAR(150),
    TaxNumber VARCHAR(50),
    PhilHealthNumber VARCHAR(50),
    PagIbigNumber VARCHAR(50),
    SSSNumber VARCHAR(50),
    Status VARCHAR(50)
);