use Day8db

create table Products
(Pid nvarchar(6) primary key,
PName nvarchar(50) not null,
PPrice float not null,
MfgDate DateTime not null,
ExpDate DateTime not null)

select * from Products
