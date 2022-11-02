create database CrCrud 
GO
use CrCrud
GO
create table datos(
id int identity(1,1) primary key,
producto varchar(255),
valor int
);

select * from datos
select * from usuarios

DELETE FROM usuarios