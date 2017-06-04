use MinionsDB

create table Towns (
  Id int identity primary key,
  TownName varchar(40),
  CountryName varchar(40)
)

create table Minions (
  Id int identity primary key,
  Name varchar(20),
  Age int,
  TownId int,
  constraint FK_Minions_Towns foreign key (TownId) references Towns(Id)
)

create table Villains (
  Id int identity primary key,
  Name varchar(40),
  EvilnessFactor varchar(10),
  constraint CH_EvilnessFactor check (EvilnessFactor in ('good', 'bad', 'evil', 'super evil'))
)

create table VillainsMinions (
  VillainId int,
  MinionId int,
  constraint PK_VillainsMinions primary key (VillainId, MinionId)
)

insert into Towns (TownName, CountryName) values 
('Sofia', 'Bulgaria'),
('Mexico', 'Mexico'),
('Madrid', 'Spain'),
('Paris', 'France'),
('Moscow', 'Russia')

insert into Minions (Name, Age, TownId) values
('Kev', 11, 1),
('Bobb', 12, 2),
('Stew', 5, 3),
('Malk', 3, 5),
('Tosh', 1 , 4)

insert into Villains (Name, EvilnessFactor) values
('Gosho', 'bad'),
('Tosho', 'good'),
('Misho', 'Evil'),
('Gogo', 'super evil'),
('Toho', 'bad')

insert into VillainsMinions (VillainId, MinionId) values 
(1,1),
(1,2),
(1,3),
(1,4),
(1,5),
(2,2),
(3,1),
(3,2),
(3,3),
(3,4),
(3,5),C:\Users\gyurg\Documents\Visual Studio 2015\Projects\DB-Advanced\Introduction_to_DB_Apps\Introduction_to_DB_Apps\MinionsDB.sql
(4,4),
(5,5)