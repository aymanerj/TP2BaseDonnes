
alter table Equipes.Equipe
add Identifiant uniqueidentifier NOT NULL rowguidcol;
go

alter table  Equipes.Equipe add constraint UC_Equipe_Identifiant
unique (Identifiant);
go

alter table  Equipes.Equipe add constraint DF_Equipe_Identifiant
default newid() for Identifiant;

go
alter table Equipes.Equipe add
FichierImage varbinary(max) FILESTREAM null;
go	