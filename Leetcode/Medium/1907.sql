-- noinspection SqlNoDataSourceInspectionForFile

WITH rates AS (
    SELECT case
               when income < 20000 then 'Low Salary'
               when income between 20000 and 50000 then 'Average Salary'
               when income > 50000 then 'High Salary' END AS category,
           1 AS is_real FROM Accounts
    UNION ALL
    SELECT * FROM (VALUES ('Low Salary', 0), ('Average Salary', 0), ('High Salary', 0)))
SELECT r.category, SUM(r.is_real) as accounts_count
FROM rates AS r
GROUP BY r.category;
