------------------------------------------------------------
-- Increase the budget of the project where the manager number is 10102 by 10%
------------------------------------------------------------

UPDATE p
SET p.Budget = p.Budget * 1.10
FROM Company.Project p
JOIN Company.Departments d
ON p.Dnum = d.Dnum
WHERE d.MgrSSN = 10102



------------------------------------------------------------
-- Change the name of the department for which the employee named James works
-- The new department name is Sales
------------------------------------------------------------

UPDATE d
SET d.Dname = 'Sales'
FROM Company.Departments d
JOIN HumanResource.Employee e
ON d.Dnum = e.Dno
WHERE e.Fname = 'James'



------------------------------------------------------------
-- Change the manager start date for the departments of employees
-- who work in project P1 and belong to department 'Sales'
-- New date = 12-12-2007
------------------------------------------------------------

UPDATE d
SET d.[MgrStart Date] = '2007-12-12'
FROM Company.Departments d
JOIN HumanResource.Employee e
ON d.Dnum = e.Dno
JOIN Works_for w
ON e.SSN = w.ESSn
WHERE w.Pno = 100
AND d.Dname = 'Sales'



------------------------------------------------------------
-- Delete from Works_for for employees who work in department
-- located in KW
------------------------------------------------------------

DELETE w
FROM Works_for w
JOIN HumanResource.Employee e
ON w.ESSn = e.SSN
JOIN Company.Departments d
ON e.Dno = d.Dnum
JOIN Company.Project p
ON d.Dnum = p.Dnum
WHERE p.City = 'KW'