Create table Users (user_id int, name varchar(40))
Truncate table Users
insert into Users (user_id, name) values ('1', 'aLice')
insert into Users (user_id, name) values ('2', 'bOB')


-- Display the names of all users, formatted so that only the first letter is capitalized
SELECT user_id, UPPER(LEFT(name,1))+LOWER(SUBSTRING(name,2,LEN(name))) AS name FROM Users
ORDER BY user_id ASC;