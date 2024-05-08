ALTER TABLE Equipes.Equipe
ADD CouleurMasQue varbinary(MAX);
go

/*Ouvrir la cl� */
OPEN SYMMETRIC KEY MySymmetricKey DECRYPTION BY CERTIFICATE MyCert;

/*Encrypter les donn�es existantes*/
UPDATE Equipes.Equipe SET CouleurMasQue = EncryptByKey(Key_GUID('MySymmetricKey'), CouleurEquipe);
/* Fermer la cl�:*/
CLOSE SYMMETRIC KEY MySymmetricKey;
/*Supprimer le champ original descriptionBut:*/
ALTER TABLE Equipes.Equipe
DROP COLUMN CouleursEquipe;
/*Cr�er une table pour les descriptions non crypt�es*/
CREATE TABLE Equipes.CouleurDEquipe (
    couleurEquipe nvarchar(25)
);
go


CREATE PROCEDURE DecryptCouleurEquipe
@EquipeId int
AS
BEGIN
    
    OPEN SYMMETRIC KEY MySymmetricKey
    DECRYPTION BY CERTIFICATE MyCert;

    SELECT CONVERT(nvarchar(25), DecryptByKey(CouleurMasQue)) 
    FROM Equipes.Equipe
    WHERE EquipeId = @EquipeId;

    CLOSE SYMMETRIC KEY MySymmetricKey;
END;
go
