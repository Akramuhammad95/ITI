create table instructors (
	instructor_id int primary key identity,
	first_name nvarchar(50) not null,
	last_name nvarchar(50) not null,
	hire_date date not null,
	department nvarchar(100) not null,
	address nvarchar(200) not null ,
	overtime_hours int not null,
	birth_date date not null, 
	age as(year(getdate())-year(birth_date)),
	salary money not null default 3000,
	net_salary as (isnull(salary,0)+isnull(overtime_hours,0)*20) persisted,
	--• Address has only cairo or alex value
	constraint c1 check(address in ('cairo','alex')) ,
	--• All salaries in the range from 1000 to 5000
	constraint c2 check (salary between 1000 and 5000),
	--• Overtime is unique
	constraint c3 unique(overtime_hours)
	)

	create table Course (
	CID int primary key identity,
	Cname nvarchar(50)   not null,
	Duration int not null)

	create table InstructorCourses(
	CID int not null, 
	inID int not null,
	constraint pk primary key(CID,inID)
	)

	create table lab(
	LID int primary key identity ,
	Location nvarchar(50) ,
	Capacity int ,
	CID int not null ,
	constraint fk1 foreign key(CID) 
	--• Lab is weak entity
	references  Course(CID) on delete cascade on update cascade ,
	--• Capacity of each lab under 20 seats
	constraint uD check(capacity < 20)
	)
	--• Duration of each course is unique
	alter table course 
	add constraint c unique(duration)

