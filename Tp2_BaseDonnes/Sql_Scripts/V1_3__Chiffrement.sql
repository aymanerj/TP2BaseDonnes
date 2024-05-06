

/*Ouvrir la clé */
OPEN SYMMETRIC KEY MySymmetricKey
DECRYPTION BY CERTIFICATE MyCert;

/*Encrypter les données existantes*/
UPDATE Matchs.But
SET DescriptionMasquee = EncryptByKey(Key_GUID('MySymmetricKey'), descriptionBut);
/* Fermer la clé:*/
CLOSE SYMMETRIC KEY MySymmetricKey;
/*Supprimer le champ original descriptionBut:*/
ALTER TABLE Matchs.But
DROP COLUMN descriptionBut;
/*Créer une table pour les descriptions non cryptées*/
CREATE TABLE Matchs.DescriptionBut (
    ButId int,
    DescriptionBut nvarchar(25)
);
go

/*Créer une procédure pour décrypter DescriptionMasquee*/
CREATE PROCEDURE DecryptDescriptionBut
@ButId int
AS
BEGIN
    DECLARE @Description nvarchar(25);
    OPEN SYMMETRIC KEY MySymmetricKey
    DECRYPTION BY CERTIFICATE MyCert;

    SELECT @Description = CONVERT(nvarchar(25), DecryptByKey(DescriptionMasquee))
    FROM Matchs.But
    WHERE ButId = @ButId;

    CLOSE SYMMETRIC KEY MySymmetricKey;
    RETURN @Description;
END;
