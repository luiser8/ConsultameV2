USE [PRD]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RecordsCV]
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
					SELECT DISTINCT [dbo].[Materias].Codmateria, [dbo].[Materias].NombreMateria, [dbo].[Materias].TH, [dbo].[Materias].UC, [dbo].[Electivas].Nombre_Opcion, 
						  ROUND([dbo].[Cargas_Academicas].Porc11,1) AS Porc11, ROUND([dbo].[Cargas_Academicas].Porc21,1) AS Porc21, ROUND([dbo].[Cargas_Academicas].Corte1,1) AS Corte1, 
						  ROUND([dbo].[Cargas_Academicas].Porc12,1) AS Porc12, ROUND([dbo].[Cargas_Academicas].Porc22,1) AS Porc22, ROUND([dbo].[Cargas_Academicas].Corte2,1) AS Corte2,
						  ROUND([dbo].[Cargas_Academicas].Porc13,1) AS Porc13, ROUND([dbo].[Cargas_Academicas].Porc23,1) AS Porc23, ROUND([dbo].[Cargas_Academicas].corte3,1) AS Corte3, 
						  [dbo].[Cargas_Academicas].Rev, ROUND(ROUND([dbo].[Cargas_Academicas].Corte1,1)+ROUND([dbo].[Cargas_Academicas].Corte2,1) + ROUND([dbo].[Cargas_Academicas].corte3,1),0) AS Definitiva, 
						  [dbo].[Materias].Semestre, Inasist1,Inasist2,Inasist3
					FROM         [dbo].[Cargas_Academicas] INNER JOIN
										  [dbo].[Materias] ON [dbo].[Cargas_Academicas].Icc = [dbo].[Materias].Icc AND [dbo].[Cargas_Academicas].IdMateria = [dbo].[Materias].Codmateria LEFT OUTER JOIN
										  [dbo].[Electivas] ON [dbo].[Cargas_Academicas].Id_Opcion = [dbo].[Electivas].Id_Opcion AND [dbo].[Cargas_Academicas].IdMateria = [dbo].[Electivas].Id_Electiva AND 
										  [dbo].[Cargas_Academicas].Icc = [dbo].[Electivas].Icc
					WHERE     ([dbo].[Cargas_Academicas].IdAl = @IdAl)
					ORDER BY [dbo].[Materias].Semestre, Materias.Codmateria
					END	
	END TRY
		BEGIN CATCH
			SELECT ERROR_MESSAGE() AS ERROR,
				ERROR_NUMBER() AS ERROR_NRO
		END CATCH;
END