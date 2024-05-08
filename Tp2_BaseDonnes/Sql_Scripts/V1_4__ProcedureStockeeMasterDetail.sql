CREATE PROCEDURE GetDetailedButs
@StartDate DATE,
@EndDate DATE,
@EquipeId INT
AS
BEGIN
    SELECT
        b.ButId,
        b.DateBut,
        b.MinuteBut,
        b.descriptionBut,
        j.JoueurId,
        j.Nom AS JoueurNom,
        j.Prenom AS JoueurPrenom,
        e.EquipeId,
        e.NomEquipe,
        m.MatchId,
        m.Date AS MatchDate,
        m.Heure AS MatchHeure,
        m.Duree AS MatchDuree
    FROM
        Matchs.But b
    INNER JOIN Equipes.Joueur j ON b.JoueurID = j.JoueurId
    INNER JOIN Contrats.ContratJoueur cj ON j.JoueurId = cj.JoueurID
    INNER JOIN Equipes.Equipe e ON cj.EquipeId = e.EquipeId
    INNER JOIN Matchs.Match1 m ON b.MatchId = m.MatchId
    WHERE
        m.Date BETWEEN @StartDate AND @EndDate
        AND e.EquipeId = @EquipeId;
END;
GO
