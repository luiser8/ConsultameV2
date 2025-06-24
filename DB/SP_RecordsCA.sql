USE [PRD]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RecordsCA]
	@IdAl INT = NULL
AS
SET NOCOUNT ON;
BEGIN
	BEGIN TRY
		IF @IdAl IS NOT NULL
			IF EXISTS(SELECT IdAl
							FROM [dbo].[Alumnos]
								WHERE IdAl = @IdAl)
				BEGIN
					SELECT    DISTINCT	  [dbo].[Materias].Codmateria, [dbo].[Materias].NombreMateria, [dbo].[Materias].TH, [dbo].[Materias].UC, 
										  [dbo].[Plantafisica].aula, [dbo].[Turnos].NombreTurno, [dbo].[Cargas_Academicas].Seccion, 
										  [dbo].[Electivas].Nombre_Opcion, [dbo].[Materias].Semestre, CHH, Prel
					FROM         [dbo].[Cargas_Academicas] INNER JOIN
										  [dbo].[Materias] ON [dbo].[Cargas_Academicas].Icc = [dbo].[Materias].Icc AND [dbo].[Cargas_Academicas].IdMateria = [dbo].[Materias].Codmateria INNER JOIN
										  [dbo].[Plantafisica] ON [dbo].[Cargas_Academicas].Id_Aula = [dbo].[Plantafisica].Id_Aula INNER JOIN
										  [dbo].[Turnos] ON [dbo].[Cargas_Academicas].IdTr = [dbo].[Turnos].IdTr LEFT OUTER JOIN
										  [dbo].[Electivas] ON [dbo].[Cargas_Academicas].Id_Opcion = [dbo].[Electivas].Id_Opcion AND [dbo].[Cargas_Academicas].IdMateria = [dbo].[Electivas].Id_Electiva AND 
										  [dbo].[Cargas_Academicas].Icc = [dbo].[Electivas].Icc WHERE [dbo].[Cargas_Academicas].IdAl = @IdAl
										  ORDER BY 
											[dbo].[Materias].Semestre, Codmateria
					END	
	END TRY
		BEGIN CATCH
			SELECT ERROR_MESSAGE() AS ERROR,
				ERROR_NUMBER() AS ERROR_NRO
		END CATCH;
END