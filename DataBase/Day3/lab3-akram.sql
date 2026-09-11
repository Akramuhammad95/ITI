
--1.	Display the Department id, name and id and the name of its manager.
select dnum , fname , ssn
from Departments d
 join Employee e on d.MGRSSN = e.SSN
--2.	Display the name of the departments and the name of the projects under its control.
select dname , pname
from Departments d
inner join Project p on d.Dnum = p.Dnum
--3.	Display the full data about all the dependence associated with the name of the employee they depend on him/her.
select d.* , e.Fname
from Employee e
right  join Dependent d
on e.SSN = d.ESSN

--4.	Display the Id, name and location of the projects in Cairo or Alex city.
select Pnumber , pname , plocation
from Projectx
where City = 'cairo' or City = 'alex'

--5.	Display the Projects full data of the projects with a name starts with "a" letter.
select *
from Project
where Pname like 'a%'
--6.	display all the employees in department 30 whose salary from 1000 to 2000 LE monthly
select e.*
from Employee e
inner join Departments d
on e.dno = d.Dnum and Salary between 1000 and 2000
--7.	Retrieve the names of all employees in department 10 who works more than or equal10 hours per week on "AL Rabwah" project.
select fname
from Employee e
inner join Works_for w
on e.SSN = w.ESSn 
and Hours >= 10 
and  e.Dno = 10
inner join Project p 
on w.Pno = p.Pnumber and p.Pname = 'AL Rabwah'

--8.	Find the names of the employees who directly supervised with Kamel Mohamed.
select s.Fname
from Employee e, Employee s
where e.SSN = s.Superssn and e.Fname = 'Kamel' and e.Lname = 'Mohamed'

--9.	Retrieve the names of all employees and the names of the projects they are working on, sorted by the project name.
select fname ,pname
from Employee e
inner join Project p
on e.Dno = p.Dnum 
order by Pname


--10.	For each project located in Cairo City , find the project number, 
--the controlling department name ,the department manager last name ,address and birthdate.
select p.Pnumber, dname, lname,Address, bdate
from Departments d
inner join project p
on d.Dnum = p.Dnum and p.city = 'cairo'
inner join Employee e
on d.Dnum = e.Dno 
--11.	Display All Data of the managers
select distinct  em.*
from Employee e, Employee em
where e.Superssn = em.SSN
--12.	Display All Employees data and the data of their dependents even if they have no dependents
select *
from Employee e
full outer join Dependent d
on e.SSN = d.ESSN
--13.	Insert your personal data to the employee table as a new employee in department number 30,
select *
from Employee
--SSN = 102672, Superssn = 112233, salary=3000.
insert into Employee
values ('akram' , 'muhammad kamel', 102672, 1995-7-20 , 'banha' , 'm',3000,112233,30)
--14.	Insert another employee with personal data your friend as new employee in department number 30,
--SSN = 102660, but don’t enter any value for salary or supervisor number to him.
insert into Employee (Fname,Lname,SSN,Dno)
values ('Maryam','muhammad',102660,30)
--15.	Upgrade your salary by 20 % of its last value. And display your data .
update Employee
set Salary = Salary*1.2
where ssn = 102672