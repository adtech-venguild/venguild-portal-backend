-- Create database
CREATE DATABASE IF NOT EXISTS veng;
USE veng;

CREATE TABLE IF NOT EXISTS `UserTypes` (
    `id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,  -- Auto-incremented integer ID
    `name` VARCHAR(100) NOT NULL,                 -- Name of the user type
    `remarks` TEXT                                -- Optional remarks or description
);

-- User
CREATE TABLE IF NOT EXISTS `Users` (
    `Id` CHAR(36) NOT NULL PRIMARY KEY DEFAULT (UUID()),      -- Auto-generate UUID
    `Email` VARCHAR(255) NOT NULL UNIQUE,                     -- User's email
    `Password` VARCHAR(255) NOT NULL,                         -- Hashed password
    `Deleted` BOOLEAN NOT NULL DEFAULT FALSE,                 -- Soft delete flag
    `Status` VARCHAR(50) NOT NULL DEFAULT 'Active',           -- Status
    `Contact` VARCHAR(100),                                   -- Contact info
    `Verified` BOOLEAN NOT NULL DEFAULT FALSE,                -- Verification status
    `VerificationTerms` TEXT,                                 -- Verification-related info
    `UserTypeId` INT NOT NULL,                                -- FK to UserType
    `CreatedAt` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,  -- BaseEntity
    `UpdatedAt` DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    
    CONSTRAINT `FK_User_UserType`
        FOREIGN KEY (`UserTypeId`) REFERENCES `UserTypes`(`id`)
        ON DELETE RESTRICT
        ON UPDATE CASCADE
);


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
    Status VARCHAR(50),
    
    `UserId` CHAR(36) NOT NULL,
    
	CONSTRAINT `FK_People_User`
	FOREIGN KEY (`UserId`) REFERENCES `Users`(`id`)
	ON DELETE RESTRICT
	ON UPDATE CASCADE
);

CREATE TABLE IF NOT EXISTS `Address` (
    `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,      -- Unique ID for the address
    `PersonId` INT NOT NULL,                           -- Foreign key to People
    `AddressType` VARCHAR(50) NOT NULL,                -- 'present', 'permanent', etc.
    `BlkLotNumber` VARCHAR(100),                       -- Optional block/lot number
    `StreetName` VARCHAR(100),                         -- Street name
    `City` INT NOT NULL,                               -- Reference to a City table (optional FK)
    `BarangayId` INT NOT NULL,                         -- Reference to Barangay
    `ZipCode` VARCHAR(10),                             -- Zip code
    `DisplayAddress` TEXT,                             -- Full address display

    CONSTRAINT `FK_Address_Person`
        FOREIGN KEY (`PersonId`) REFERENCES `People`(`Id`)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

CREATE TABLE IF NOT EXISTS `Education` (
    `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,      -- Unique ID for the record
    `PersonId` INT NOT NULL,                           -- Foreign key to People table
    `Level` ENUM(
        'None', 
        'Elementary', 
        'HighSchool', 
        'Vocational', 
        'College', 
        'Bachelors', 
        'Masters', 
        'Doctorate'
    ) NOT NULL,                                         -- Educational Attainment Level
    `SchooName` VARCHAR(255) NOT NULL,                 -- School name (note: correct spelling in code is 'SchoolName')
    `YearStart` INT NOT NULL,                          -- Year started
    `YearEnd` INT NOT NULL,                            -- Year ended

    CONSTRAINT `FK_Education_Person`
        FOREIGN KEY (`PersonId`) REFERENCES `People`(`Id`)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

CREATE TABLE IF NOT EXISTS `Experience` (
    `Id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,   -- Unique ID
    `PersonId` INT NOT NULL,                        -- Foreign key to People table
    `CompanyName` VARCHAR(255) NOT NULL,            -- Name of the company
    `Position` VARCHAR(150) NOT NULL,               -- Job position
    `Description` TEXT,                             -- Description of responsibilities
    `WorkPlace` VARCHAR(150),                       -- On-site, remote, hybrid, etc.
    `StartDate` DATE NOT NULL,                      -- Start date of employment
    `EndDate` DATE,                                 -- Nullable (still working there)

    CONSTRAINT `FK_Experience_Person`
        FOREIGN KEY (`PersonId`) REFERENCES `People`(`Id`)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

