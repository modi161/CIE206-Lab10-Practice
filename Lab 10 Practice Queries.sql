-- Creation --
Create Database RealUsers

Use RealUsers

Create Table Users
(
id int Primary Key IDENTITY(1, 1),
First_name varchar(50),
Last_name varchar(50),
Email varchar(100),
Gender varchar(10),

);

-- Read --
select * from Users

-- Insert --
INSERT INTO Users (First_name, Last_name, Email, Gender)
VALUES ('Ahmed', 'Youssef', 'A_youssef@gmail.com', 'Male');

-- Delete --
DELETE FROM Users
WHERE id = 4;

-- Get Info of user by id --
select * from Users where id = 2


-- Update User Values --
UPDATE Users
SET First_name = 'Ahmad',
    Last_name = 'Ali',
    Email = 'Ali12@gmail.com',
    Gender = 'Male' 
WHERE id = 2;
