-- noinspection SqlNoDataSourceInspectionForFile

-- № 1
select c.name as Customers 
from Customers as c
left join Orders as o on c.id = o.customerId
where o.id is null;


-- № 2
select c.name as Customers
from Customers as c
where c.id not in (select distinct customerId from Orders);