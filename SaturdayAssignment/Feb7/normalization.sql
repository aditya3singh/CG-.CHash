use NormalizationTest;
-----------------------------------------------------------
create table student
(
    studentid int primary key,
    studentname varchar(50),
    joiningdate date
);

-------------------------------------------------------------

insert into student (studentid, studentname, joiningdate, rewardpoints)
values
(201, 'kumar', '2021-06-10', 0),
(202, 'riya', '2022-07-15', 0),
(203, 'amit', '2020-01-20', 0),
(204, 'neha', '2023-03-05', 0),
(205, 'rohit', '2021-11-12', 0);

---------------------------------------------------------
create table trainer
(
    trainerid int primary key,
    trainername varchar(50)
);

insert into trainer (trainerid, trainername)
values
(1, 'rajesh'),
(2, 'sunita'),
(3, 'anil');

-----------------------------------------------------
create table course
(
    courseid int primary key,
    coursename varchar(50),
    coursefee decimal(10,2),
    trainerid int,
    foreign key (trainerid) references trainer(trainerid)
);

insert into course (courseid, coursename, coursefee, trainerid)
values
(101, 'sql', 8000, 1),
(102, 'csharp', 10000, 2),
(103, 'java', 12000, 3);
-----------------------------------------------------------

create table marks
(
    markid int identity primary key,
    studentid int,
    courseid int,
    exammonth int,
    examyear int,
    marks int,
    foreign key (studentid) references student(studentid),
    foreign key (courseid) references course(courseid)
);

insert into marks (studentid, courseid, exammonth, examyear, marks)
values
(201, 101, 6, year(getdate()), 85),
(202, 102, 7, year(getdate()), 72),
(203, 103, 5, year(getdate()), 90),
(204, 101, 8, year(getdate()), 38),
(205, 102, 6, year(getdate()), 65);
----------------------------------------------------------

--2
alter table student
add rewardpoints int default 0;

select studentid, studentname, rewardpoints
from student;


------------------------------------------------------
---3
alter table student
add constraint chk_rewardpoints
check (rewardpoints between 0 and 100);

---------------------------------------------------------
--4
select 
    s.studentname,
    c.coursename,
    t.trainername,
    m.exammonth,
    m.examyear,
    m.marks
from marks m
inner join student s on m.studentid = s.studentid
inner join course c on m.courseid = c.courseid
inner join trainer t on c.trainerid = t.trainerid;


------------------------------------------------------------
--5
select 
    s.studentname,
    sum(m.marks) as totalmarks
from marks m
inner join student s on m.studentid = s.studentid
where m.examyear = year(getdate())
group by s.studentname;

------------------------------------------------------
--6
select 
    s.studentname,
    left(s.studentname, 3) +
    left(c.coursename, 2) +
    cast(s.studentid as varchar) as loginid
from student s
inner join marks m on s.studentid = m.studentid
inner join course c on m.courseid = c.courseid;

--------------------------------------------------------
--7
select 
    s.studentname,
    sum(m.marks) as totalmarks
from marks m
inner join student s on m.studentid = s.studentid
group by s.studentname
having sum(m.marks) >
(
    select avg(marks)
    from marks
);

-------------------------------------------------------
--8
select 
    s.studentname,
    m.marks,
    'HIGH' as category
from marks m
inner join student s on m.studentid = s.studentid
where m.marks > 80

union

select 
    s.studentname,
    m.marks,
    'LOW' as category
from marks m
inner join student s on m.studentid = s.studentid
where m.marks < 40;

---------------------------------------------------------
--9
create trigger trg_updaterewardpoint
on marks
after insert
as
begin
    update s
    set rewardpoints =
        rewardpoints +
        case
            when i.marks >= 80 then 10
            when i.marks >= 60 then 5
            else 2
        end
    from student s
    inner join inserted i on s.studentid = i.studentid;
end;

-----------------------------------------------------------
--10

select
    s.studentname,
    s.joiningdate,
    datediff(year, s.joiningdate, getdate()) as yearsofstudy,
    case
        when datediff(year, s.joiningdate, getdate()) > 3
        then 10000
        else 0
    end as scholarshipamount
from student s;
