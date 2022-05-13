CREATE TYPE yn_type AS ENUM ( 'Y', 'N' );

Create table Products (product_id int, low_fats yn_type, recyclable yn_type);
insert into Products (product_id, low_fats, recyclable) values ('0', 'Y', 'N');
insert into Products (product_id, low_fats, recyclable) values ('1', 'Y', 'Y');
insert into Products (product_id, low_fats, recyclable) values ('2', 'N', 'Y');
insert into Products (product_id, low_fats, recyclable) values ('3', 'Y', 'Y');
insert into Products (product_id, low_fats, recyclable) values ('4', 'N', 'N');

SELECT product_id FROM Products WHERE low_fats = 'Y' AND recyclable = 'Y';