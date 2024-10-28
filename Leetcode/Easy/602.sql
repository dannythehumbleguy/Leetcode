-- noinspection SqlNoDataSourceInspectionForFile

-- without handling the case with multiple persons who have the most friends number 
with users as (
    select requester_id from RequestAccepted
    union all
    select accepter_id as requester_id from RequestAccepted
)
select requester_id as id, COUNT(*) as num from users
group by requester_id
order by COUNT(*) desc
limit 1;

-- with handling the case with multiple persons who have the most friends number 
WITH users AS (
    SELECT requester_id
    FROM RequestAccepted
    UNION ALL
    SELECT accepter_id
    FROM RequestAccepted
),
     user_counts AS (
         SELECT requester_id AS id, COUNT(*) AS num
         FROM users
         GROUP BY requester_id
     )
SELECT id, num
FROM user_counts
WHERE num = (SELECT MAX(num) FROM user_counts)
ORDER BY id;