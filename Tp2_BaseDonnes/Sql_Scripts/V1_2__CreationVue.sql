GO

CREATE VIEW VueStatistiquesJoueurs AS

SELECT 

    j.JoueurId,

    j.Nom,

    j.Prenom,

    COUNT(b.ButId) AS NombreButs,

    COUNT(DISTINCT m.MatchId) AS NombreMatchsJoues,

    e.NomEquipe

FROM Equipes.Joueur j

JOIN Matchs.But b ON j.JoueurId = b.JoueurID

JOIN Matchs.Match1 m ON b.MatchId = m.MatchId

JOIN Equipes.Equipe e ON m.EquipeId = e.EquipeId

GROUP BY j.JoueurId, j.Nom, j.Prenom, e.NomEquipe;