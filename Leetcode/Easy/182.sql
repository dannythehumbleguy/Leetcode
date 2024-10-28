-- noinspection SqlNoDataSourceInspectionForFile

select email from Person
group by email
having COUNT(email) > 1;