CREATE PROCEDURE GetButsByEquipe(@EquipeId) 

AS
BEGIN
 SELECT M.MatchId,M.Date,M.Heure,M.Duree.M.Gagnant,M.Perdant,M.EquipeId
 from Matchs.Match1 M
inner join Equipes.Equipe E on E.EquipeId = M.EquipeId
Where E.EquipeId =7
    GROUP BY 
        e.EquipeId, e.NomEquipe;
END;
GO
