------------------------------------------------------------
-- 1. Stored Procedure
-- Show number of students per department [ITI DB]
------------------------------------------------------------

USE ITI
GO

CREATE PROCEDURE GetStudentsCountPerDepartment
AS
BEGIN

SELECT 
    d.Dept_Name AS DepartmentName,
    COUNT(s.St_Id) AS NumberOfStudents
FROM Department d
LEFT JOIN Student s
ON d.Dept_Id = s.Dept_Id
GROUP BY d.Dept_Name
ORDER BY NumberOfStudents DESC

END
GO


------------------------------------------------------------
-- 2. Stored Procedure
-- Return even numbers between two integers
------------------------------------------------------------

CREATE PROCEDURE GetEvenNumbers
(
    @a INT,
    @b INT
)
AS
BEGIN

DECLARE @i INT

SET @i = @a

WHILE @i <= @b
BEGIN

    IF @i % 2 = 0
        PRINT @i

    SET @i = @i + 1

END

END
GO

-- Example
EXEC GetEvenNumbers 3 , 20
GO


------------------------------------------------------------
-- 3. Stored Procedure
-- Check number of employees in project P1 [Company DB]
------------------------------------------------------------

USE Company_SD
GO

CREATE PROCEDURE CheckEmployeesInProject
AS
BEGIN

DECLARE @NumOfEmp INT

SELECT @NumOfEmp = COUNT(*)
FROM Works_for
WHERE Pno = 100

IF @NumOfEmp >= 3
    PRINT 'The number of employees in project P1 is 3 or more'

ELSE
BEGIN

    PRINT 'The following employees work for project P1'

    SELECT 
        e.Fname,
        e.Lname
    FROM HumanResource.Employee e
    JOIN Works_for w
    ON e.SSN = w.ESSn
    WHERE w.Pno = 100

END

END
GO

EXEC CheckEmployeesInProject
GO


------------------------------------------------------------
-- 4. Stored Procedure
-- Replace old employee with new employee in project
------------------------------------------------------------

CREATE PROCEDURE ReplaceEmployeeInProject
(
    @OldEmp INT,
    @NewEmp INT,
    @ProjectNo INT
)
AS
BEGIN

UPDATE Works_for
SET ESSn = @NewEmp
WHERE ESSn = @OldEmp
AND Pno = @ProjectNo

END
GO


------------------------------------------------------------
-- 5. Add Budget column to Project table
------------------------------------------------------------

ALTER TABLE Company.Project
ADD Budget INT
GO


------------------------------------------------------------
-- 6. Create Audit Table
------------------------------------------------------------

CREATE TABLE Project_Audit
(
    ProjectNo INT,
    UserName VARCHAR(50),
    ModifiedDate DATETIME,
    Budget_Old INT,
    Budget_New INT
)
GO


------------------------------------------------------------
-- 7. Trigger to audit budget changes
------------------------------------------------------------

CREATE TRIGGER Budget_Audit
ON Company.Project
AFTER UPDATE
AS
BEGIN

IF UPDATE(Budget)
BEGIN

INSERT INTO Project_Audit

SELECT
    i.Pnumber,
    SUSER_NAME(),
    GETDATE(),
    d.Budget,
    i.Budget

FROM inserted i
JOIN deleted d
ON i.Pnumber = d.Pnumber

END

END
GO


------------------------------------------------------------
-- 8. Prevent insert in Department table [ITI DB]
------------------------------------------------------------

USE ITI
GO

CREATE TRIGGER PreventInsertDepartment
ON Department
INSTEAD OF INSERT
AS
BEGIN

PRINT 'You cannot insert a new record in Department table'

END
GO


------------------------------------------------------------
-- 9. Prevent insert in Employee table in March [Company DB]
------------------------------------------------------------

USE Company_SD
GO

CREATE TRIGGER PreventInsertEmployeeMarch
ON HumanResource.Employee
INSTEAD OF INSERT
AS
BEGIN

IF MONTH(GETDATE()) = 3

    PRINT 'Insertion is not allowed in March'

ELSE

    INSERT INTO HumanResource.Employee
    SELECT * FROM inserted

END
GO


------------------------------------------------------------
-- 10. Create Student Audit Table [ITI DB]
------------------------------------------------------------

USE ITI
GO

CREATE TABLE Student_Audit
(
    ServerUserName VARCHAR(50),
    Date DATETIME,
    Note VARCHAR(200)
)
GO


------------------------------------------------------------
-- 11. Trigger: Audit insert on Student table
------------------------------------------------------------

CREATE TRIGGER StudentAuditInsert
ON Student
AFTER INSERT
AS
BEGIN

INSERT INTO Student_Audit

SELECT
    SUSER_NAME(),
    GETDATE(),
    SUSER_NAME() +
    ' Insert New Row With Key = ' +
    CAST(i.St_Id AS VARCHAR) +
    ' in table Student'

FROM inserted i

END
GO


------------------------------------------------------------
-- 12. Trigger: Prevent delete on Student table
------------------------------------------------------------

CREATE TRIGGER StudentAuditDelete
ON Student
INSTEAD OF DELETE
AS
BEGIN

INSERT INTO Student_Audit

SELECT
    SUSER_NAME(),
    GETDATE(),
    SUSER_NAME() +
    ' tried to delete Row With Key = ' +
    CAST(d.St_Id AS VARCHAR) +
    ' in table Student'

FROM deleted d

END
GO