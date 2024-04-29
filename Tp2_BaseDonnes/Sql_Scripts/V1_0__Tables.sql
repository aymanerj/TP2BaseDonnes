USE Foot

/* creation des tables  */
create table Equipes.Joueur(
JoueurId int identity(1,1),
Nom varchar(20),
Prenom varchar(20),
DateNaissance Date,
sexe varchar(10) ,
age int ,
constraint PK_Joueur_JoueurID primary key (JoueurId),
);
go
create table Equipes.GardienBut(
GardienButId int identity(1,1),
ButEncaisse int,
CleanSheet int,
JoueurId int,
constraint PK_GardienBut_GardienButId primary key (GardienButId)
)
go
create table Equipes.Equipe(
EquipeId int identity(1,1),
NomEquipe varchar(20),
Pays varchar(20),
CouleursEquipe varchar(15),
DateFondation date,
constraint PK_Equipe_EquipeId primary key (EquipeId)
)
go
create table Equipes.Entraineur(
EntraineurId int identity(1,1),
Nom varchar(20),
Prenom varchar(20),
DateNaissance Date,
Specialite varchar(15),
age int,
constraint PK_Entraineur_EntraineurId primary key (EntraineurId)
)
go
create table Matchs.Match1(
MatchId int identity(1,1),
Date Date,
Heure Date,
Duree int,
Gagnant varchar(25),
Perdant varchar(25),
EquipeId int,
constraint PK_Match_MatchId primary key (MatchId)
)
go
create table Matchs.But(
ButId int identity(1,1),
DateBut  Date,
MinuteBut  int,
descriptionBut  varchar(25),
JoueurID int,
MatchId int,
constraint PK_But_ButId primary key (ButId)
)
go

create table Contrats.ContratJoueur(
ContratJoueurId int identity(1,1),
JoueurID int,
EquipeId int,
constraint PK_ContratJoueur_ContratJoueurId primary key (ContratJoueurId)
)
go
create table Contrats.ContratEntraineur(
ContratentraineurId int identity(1,1),
EntraineurId int,
EquipeId int,
constraint PK_ContratEntraineur_ContratentraineurId primary key (ContratentraineurId)
)
go
/* foreign key de la table Joueur  */
alter table Equipes.Joueur
add constraint CK_Joueur_Sexe CHECK (Sexe IN ('Homme', 'Femme', 'Autre'));
ALTER TABLE Equipes.Joueur
ADD CONSTRAINT UQ_Joueur_Nom_Prenom UNIQUE (Nom, Prenom, DateNaissance);
/* foreign key de la table GardienBut  */
alter table  Equipes.GardienBut add constraint FK_GardienBut_JoueurId
Foreign key(JoueurId)
references Equipes.Joueur(JoueurId);
go
alter table  Equipes.GardienBut 
add constraint DF_GardienBut_ButEncaisse default 0 for ButEncaisse;
alter table  Equipes.GardienBut 
add constraint DF_GardienBut_CleanSheet default 0 for CleanSheet;
alter table  Equipes.GardienBut 
add constraint CK_GardienBut_ButEncaisse CHECK (ButEncaisse >= 0);
alter table  Equipes.GardienBut 
add constraint CK_GardienBut_CleanSheet CHECK (CleanSheet >= 0);

/* clés étrangères, les contraintes de la table Equipe  */
alter table  Equipes.Equipe
add constraint UQ_Equipe_NomEquipe UNIQUE (NomEquipe);
/* clés étrangères, les contraintes de la table Entraineur  */
alter table Equipes.Entraineur
add CONSTRAINT UQ_Entraineur_Nom_Prenom UNIQUE (Nom, Prenom, DateNaissance)

/* clés étrangères, les contraintes de la table ContratJoueur  */
alter table Contrats.ContratJoueur add constraint FK_ContratJoueur_JoueurId
Foreign key(JoueurId)
references Equipes.Joueur(JoueurId);
go

alter table Contrats.ContratJoueur add constraint FK_ContratJoueur_EquipeId
Foreign key(EquipeId)
references Equipes.Equipe(EquipeId);
go

/* clés étrangères, les contrainte de la table ContratEntraineur  */
alter table Contrats.ContratEntraineur add constraint FK_ContratEntraineur_EntraineurId
Foreign key(EntraineurId)
references Equipes.Entraineur(EntraineurId);
go
alter table Contrats.ContratEntraineur add constraint FK_ContratEntraineur_EquipeId
Foreign key(EquipeId)
references Equipes.Equipe(EquipeId);
go
/* clés étrangères, les contraintes de la table match  */
alter table  Matchs.Match1 
add constraint CK_Match1_Duree CHECK (Duree > 0);
alter table Matchs.Match1 add constraint FK_Match1_EquipeId 
Foreign key(EquipeId)
references Equipes.Equipe(EquipeId);
go

/* clés étrangères, les contraintes de la table But  */
alter table  Matchs.But add constraint FK_But_MatchId
Foreign key(MatchId)
references Matchs.Match1(MatchId);
go
alter table  Matchs.But add constraint FK_But_JoueurId
Foreign key(JoueurId)
references Equipes.Joueur(JoueurId);
go