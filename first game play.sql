-- MS SQL Server T-SQL used here
Create table Activity (player_id int, device_id int, event_date date, games_played int);
Truncate table Activity;
insert into Activity (player_id, device_id, event_date, games_played) values ('1', '2', '2016-03-01', '5');
insert into Activity (player_id, device_id, event_date, games_played) values ('1', '2', '2016-05-02', '6');
insert into Activity (player_id, device_id, event_date, games_played) values ('2', '3', '2017-06-25', '1');
insert into Activity (player_id, device_id, event_date, games_played) values ('3', '1', '2016-03-02', '0');
insert into Activity (player_id, device_id, event_date, games_played) values ('3', '4', '2018-07-03', '5');

-- Select player id and first login (most recent event_date for a given player_id) from activity
-- Only select player_id and event_date
-- Order by player_id
-- Only select the most recent event_date for each player_id
SELECT player_id, MIN(event_date) AS first_login
 FROM Activity 
 GROUP BY player_id
 ORDER BY first_login ASC;