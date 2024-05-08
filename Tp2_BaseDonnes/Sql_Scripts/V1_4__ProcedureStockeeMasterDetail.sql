CREATE PROCEDURE GetEquipesByDateRange
@StartDate DATE,
@EndDate DATE

AS
BEGIN
    SELECT 
        EquipeId, 
        NomEquipe, 
        Pays, 
        CouleursEquipe, 
        DateFondation
    FROM 
        Equipes.Equipe
    WHERE 
        DateFondation BETWEEN @StartDate AND @EndDate;
END;
GO