-- noinspection SqlNoDataSourceInspectionForFile

select p.project_id, ROUND(SUM(e.experience_years) / COUNT(e.experience_years)::numeric, 2) as average_years
from Project as p
inner join Employee as e on p.employee_id = e.employee_id
group by p.project_id;