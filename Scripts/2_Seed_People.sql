USE venguild;

INSERT INTO People (
    FirstName, LastName, MiddleName, Suffix, BirthDate, Gender, Photo,
    MobileNumber, TelephoneNumber, Email,
    TaxNumber, PhilHealthNumber, PagIbigNumber, SSSNumber, Status
) VALUES
('Juan', 'Dela Cruz', 'Santos', 'Jr.', '1990-05-15', 'Male', NULL,
 '09171234567', '1234567', 'juan@example.com',
 'TIN-001', 'PH-001', 'PAGIBIG-001', 'SSS-001', 'Active'),

('Maria', 'Reyes', 'Lopez', NULL, '1988-11-03', 'Female', NULL,
 '09181234567', NULL, 'maria.reyes@example.com',
 'TIN-002', 'PH-002', 'PAGIBIG-002', 'SSS-002', 'Active'),

('Pedro', 'Penduko', NULL, NULL, '1995-01-22', 'Male', NULL,
 '09191234567', NULL, 'pedro@example.com',
 'TIN-003', 'PH-003', 'PAGIBIG-003', 'SSS-003', 'Inactive'),

('Ana', 'Santos', 'Cruz', NULL, '1992-07-08', 'Female', NULL,
 '09201234567', '7654321', 'ana.santos@example.com',
 'TIN-004', 'PH-004', 'PAGIBIG-004', 'SSS-004', 'Active'),

('Luis', 'Garcia', NULL, 'Sr.', '1980-03-10', 'Male', NULL,
 '09211234567', NULL, 'luis.garcia@example.com',
 'TIN-005', 'PH-005', 'PAGIBIG-005', 'SSS-005', 'Inactive');
