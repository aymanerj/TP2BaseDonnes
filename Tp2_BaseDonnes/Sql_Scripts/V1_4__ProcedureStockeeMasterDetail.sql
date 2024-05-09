CREATE PROCEDURE GetMatchsByEquipe
@EquipeId int
AS
BEGIN
	SELECT M.MatchId,M.Heure,M.Date,M.Duree, M.Gagnant,M.Perdant,M.EquipeId
	from Matchs.Match1 M
	inner join Equipes.Equipe E on E.EquipeId = M.EquipeId
	Where E.EquipeId = @EquipeId
END;
GO
