

/*Ouvrir la cl� */
OPEN SYMMETRIC KEY MySymmetricKey
DECRYPTION BY CERTIFICATE MyCert;

/*Encrypter les donn�es existantes*/
UPDATE Matchs.But
SET DescriptionMasquee = EncryptByKey(Key_GUID('MySymmetricKey'), descriptionBut);
/* Fermer la cl�:*/
CLOSE SYMMETRIC KEY MySymmetricKey;
/*Supprimer le champ original descriptionBut:*/
ALTER TABLE Matchs.But
DROP COLUMN descriptionBut;
/*Cr�er une table pour les descriptions non crypt�es*/
CREATE TABLE Matchs.DescriptionBut (
    ButId int,
    DescriptionBut nvarchar(25)
);
go

/*Cr�er une proc�dure pour d�crypter DescriptionMasquee*/
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
