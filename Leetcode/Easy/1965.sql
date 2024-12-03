-- noinspection SqlNoDataSourceInspectionForFile

-- № 1
with all_employee_ids as (
    select employee_id from Employees
    union
    select employee_id from Salaries
), missed_employee_ids as (
    select a.employee_id from all_employee_ids as a
    left join Employees as e on e.employee_id = a.employee_id
    where name is null
    union
    select a.employee_id from all_employee_ids as a
    left join Salaries as e on e.employee_id = a.employee_id
    where salary is null
)
select * from missed_employee_ids
order by employee_id;

-- № 2
with missed_employee_ids as (
    select s.employee_id from Salaries as s
    left join Employees as e on e.employee_id = s.employee_id
    where name is null
    union
    select e.employee_id from Employees as e
    left join Salaries as s on s.employee_id = e.employee_id
    where salary is null
)
select * from missed_employee_ids
order by employee_id;

-- № 3
select
    case
        when salary is null then e.employee_id
        when name is null then s.employee_id
        end as employee_id
from Employees as e
         full outer join Salaries as s on s.employee_id = e.employee_id
where salary is null or name is null
order by employee_id;