USE veng;


-- Insert Admin UserType if not exists
INSERT INTO `UserTypes` (`name`, `remarks`)
SELECT 'Admin', 'Administrator with full access'
WHERE NOT EXISTS (
    SELECT 1 FROM `UserTypes` WHERE `name` = 'Admin'
);

-- Insert Regular UserType if not exists
INSERT INTO `UserTypes` (`name`, `remarks`)
SELECT 'Regular', 'Standard user with limited access'
WHERE NOT EXISTS (
    SELECT 1 FROM `UserTypes` WHERE `name` = 'Regular'
);
-- /////////////////////////////////////////////////
-- Insert admin user
INSERT INTO `Users` (
    `Id`, `Email`, `Password`, `Deleted`, `Status`, `Contact`,
    `Verified`, `VerificationTerms`, `UserTypeId`
)
SELECT
    '11111111-1111-1111-1111-111111111111',
    'admin@example.com',
    'hashed_admin_pass',
    FALSE,
    'Active',
    '09171234567',
    TRUE,
    'Accepted terms',
    (SELECT `id` FROM `UserTypes` WHERE `name` = 'Admin')
WHERE NOT EXISTS (
    SELECT 1 FROM `Users` WHERE `Email` = 'admin@example.com'
);

-- Insert regular user
INSERT INTO `Users` (
    `Id`, `Email`, `Password`, `Deleted`, `Status`, `Contact`,
    `Verified`, `VerificationTerms`, `UserTypeId`
)
SELECT
    '22222222-2222-2222-2222-222222222222',
    'user@example.com',
    'hashed_user_pass',
    FALSE,
    'Active',
    '09179876543',
    TRUE,
    'Accepted terms',
    (SELECT `id` FROM `UserTypes` WHERE `name` = 'Regular')
WHERE NOT EXISTS (
    SELECT 1 FROM `Users` WHERE `Email` = 'user@example.com'
);

-- /////////////////////////////////////////////////
-- Person linked to Admin
INSERT INTO `People` (
    `FirstName`, `LastName`, `MiddleName`, `Suffix`, `BirthDate`, `Gender`,
    `Photo`, `MobileNumber`, `TelephoneNumber`, `Email`, `TaxNumber`,
    `PhilHealthNumber`, `PagIbigNumber`, `SSSNumber`, `Status`, `UserId`
)
SELECT
    'Alice', 'Admin', 'A.', NULL, '1990-01-01', 'Female',
    NULL, '09171234567', NULL, 'admin@example.com', '123-456-789',
    'PH123456789', 'PG123456789', 'SSS123456789', 'Active', '11111111-1111-1111-1111-111111111111'
WHERE NOT EXISTS (
    SELECT 1 FROM `People` WHERE `Email` = 'admin@example.com'
);

-- Person linked to Regular User
INSERT INTO `People` (
    `FirstName`, `LastName`, `MiddleName`, `Suffix`, `BirthDate`, `Gender`,
    `Photo`, `MobileNumber`, `TelephoneNumber`, `Email`, `TaxNumber`,
    `PhilHealthNumber`, `PagIbigNumber`, `SSSNumber`, `Status`, `UserId`
)
SELECT
    'Bob', 'User', 'B.', NULL, '1995-05-15', 'Male',
    NULL, '09179876543', NULL, 'user@example.com', '987-654-321',
    'PH987654321', 'PG987654321', 'SSS987654321', 'Active', '22222222-2222-2222-2222-222222222222'
WHERE NOT EXISTS (
    SELECT 1 FROM `People` WHERE `Email` = 'user@example.com'
);
