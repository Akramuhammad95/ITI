--1.	Display sum salary of employees who work in department number  10

SELECT SUM(salary) AS total_salary
FROM Employee e
WHERE e.Dno = 10;

--2.	Display average salaries of employees 

SELECT AVG(salary) AS average_salary
FROM Employee;


--3.	Display average salaries of employees in department number 10

SELECT avg(salary) AS total_salary
FROM Employee e
WHERE e.Dno = 10;

--4.	Count the employees who work in project number 100
select count(*) as employee_count 
from Works_for w
where w.Pno = 100;

--5.	Count the employees depends on their departments 

SELECT Dno, COUNT(*) AS employee_count
FROM Employee
GROUP BY Dno;

--6.	Sum hours of each project 
select sum(w.Hours) as Sum_of_hours from Works_for w
group by w.Pno;
 --7.	Display employee full name and project name 
 --where city of project = Cairo and the and the address of its employees has Giza

select e.Fname+e.Lname as EmpFullName,p.Pname from Employee e 
join
Works_for w 
on e.Ssn = w.Essn
join Project p
on w.Pno = p.Pnumber
where p.Plocation = 'Cairo' and e.Address like '%Giza%';



--8.	Display full name of employees and their salaries when salary greater than average of salaries 

select e.Fname+' '+e.Lname as EmpFullName, e.salary from Employee e
where e.salary >
(
select avg(salary) from Employee
);
 
 --9.	Display the super visor names without duplication

 select distinct sup.Fname+' '+ sup.Lname as SupervisorName from Employee sup
 join Employee e
 on sup.Ssn = e.Superssn;
