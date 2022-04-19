select * from UserTable;

SET IDENTITY_INSERT UserTable ON;

insert into UserTable(UserID, UserName) values(1,'Zain');

insert into UserTable(UserID, UserName) values (2,'Shafi');

insert into UserTable(UserName) values ('Shafi123');



SET IDENTITY_INSERT UserTable OFF;

select * from Inventory;

SET IDENTITY_INSERT Inventory ON;

insert into Inventory(ItemID, ItemName, UserID, Quantity, Cost) values (1,'screws',1,10,20);

select * from UserTable;

SET IDENTITY_INSERT UserTable ON;