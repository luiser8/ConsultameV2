USE [PRD]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RecordsMV]
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
					SELECT Codmateria, Semestre, NombreMateria, HT, HP, HL,TH, UC
						FROM Materias 
							WHERE Icc= (SELECT TOP 1 Icc FROM Cargas_Academicas WHERE IdAl = @IdAl ORDER BY Icc DESC) AND
							CodMateria NOT IN (SELECT Codmateria 
												FROM Notas_Alumnos 
													WHERE IdAl = @IdAl  AND
													Cualitativa=1 AND Icc=(SELECT TOP 1 Icc FROM Cargas_Academicas WHERE IdAl = @IdAl  ORDER BY Icc DESC)) AND
													CodMateria NOT IN(SELECT IdMateria 
														FROM Cargas_Academicas Where IdAl = @IdAl  AND
															 Cargas_Academicas.Icc=(SELECT TOP 1 Icc FROM Cargas_Academicas WHERE IdAl = @IdAl  ORDER BY Icc DESC)) 
																ORDER BY Semestre, Codmateria
																
					END	
	END TRY
		BEGIN CATCH
			SELECT ERROR_MESSAGE() AS ERROR,
				ERROR_NUMBER() AS ERROR_NRO
		END CATCH;
END