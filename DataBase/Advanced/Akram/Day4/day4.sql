------------------------------------------------------------
-- Cursor to increase employee salary based on salary value
-- Company_SD DB
------------------------------------------------------------

USE Company_SD
GO

DECLARE EmpCursor CURSOR
FOR
SELECT Salary
FROM HumanResource.Employee
FOR UPDATE

DECLARE @Salary INT

OPEN EmpCursor

FETCH NEXT FROM EmpCursor INTO @Salary

WHILE @@FETCH_STATUS = 0
BEGIN

    IF @Salary < 3000
        UPDATE HumanResource.Employee
        SET Salary = @Salary * 1.10
        WHERE CURRENT OF EmpCursor

    ELSE
        UPDATE HumanResource.Employee
        SET Salary = @Salary * 1.20
        WHERE CURRENT OF EmpCursor

    FETCH NEXT FROM EmpCursor INTO @Salary

END

CLOSE EmpCursor
DEALLOCATE EmpCursor
GO


------------------------------------------------------------
-- Display department name with its manager name using cursor
-- ITI DB
------------------------------------------------------------

USE ITI
GO

DECLARE DeptCursor CURSOR
FOR
SELECT d.Dept_Name , i.Ins_Name
FROM Department d
JOIN Instructor i
ON d.Dept_Manager = i.Ins_Id

DECLARE @DeptName VARCHAR(50)
DECLARE @ManagerName VARCHAR(50)

OPEN DeptCursor

FETCH NEXT FROM DeptCursor INTO @DeptName , @ManagerName

WHILE @@FETCH_STATUS = 0
BEGIN

    PRINT @DeptName + ' - ' + @ManagerName

    FETCH NEXT FROM DeptCursor INTO @DeptName , @ManagerName

END

CLOSE DeptCursor
DEALLOCATE DeptCursor
GO


------------------------------------------------------------
-- Display all student first names in one cell separated by comma
-- Using Cursor
------------------------------------------------------------

USE ITI
GO

DECLARE StudentCursor CURSOR
FOR
SELECT St_Fname
FROM Student

DECLARE @Name VARCHAR(50)
DECLARE @AllNames VARCHAR(1000) = ''

OPEN StudentCursor

FETCH NEXT FROM StudentCursor INTO @Name

WHILE @@FETCH_STATUS = 0
BEGIN

    SET @AllNames = @AllNames + @Name + ', '

    FETCH NEXT FROM StudentCursor INTO @Name

END

CLOSE StudentCursor
DEALLOCATE StudentCursor

SELECT @AllNames AS StudentsNames
GO


------------------------------------------------------------
-- Create Full Backup and Differential Backup
-- Company_SD DB
------------------------------------------------------------

BACKUP DATABASE Company_SD
TO DISK = 'E:\SD30_Company_Full.bak'
WITH FORMAT,
NAME = 'Full Backup of Company_SD'
GO

BACKUP DATABASE Company_SD
TO DISK = 'E:\SD30_Company_Diff.bak'
WITH DIFFERENTIAL,
NAME = 'Differential Backup of Company_SD'
GO


------------------------------------------------------------
-- Create Login Ahmed and give permissions
------------------------------------------------------------

USE master
GO

CREATE LOGIN Ahmed
WITH PASSWORD = 'Ahmed@123'
GO

USE ITI
GO

CREATE USER Ahmed FOR LOGIN Ahmed
GO

GRANT SELECT , UPDATE ON Department TO Ahmed
GRANT SELECT , UPDATE ON Course TO Ahmed
GO


------------------------------------------------------------
-- Create table Works_for without PK
------------------------------------------------------------

USE ITI
GO

CREATE TABLE Work
(
    EmpID INT,
    ProjectID INT,
    Hours INT
)

INSERT INTO Work VALUES (11,121,5)
INSERT INTO Work VALUES (11,121,30)
INSERT INTO Work VALUES (11,122,4)
INSERT INTO Work VALUES (21,131,6)
INSERT INTO Work VALUES (21,152,2)
INSERT INTO Work VALUES (21,152,30)


------------------------------------------------------------
-- Sum hours grouped by EmpID with subtotal
------------------------------------------------------------

SELECT
    EmpID,
    SUM(Hours) AS TotalHours
FROM Work
GROUP BY ROLLUP(EmpID)


------------------------------------------------------------
-- Sum hours grouped by EmpID and ProjectID with subtotal
------------------------------------------------------------

SELECT
    EmpID,
    ProjectID,
    SUM(Hours) AS TotalHours
FROM Work
GROUP BY ROLLUP(EmpID , ProjectID)