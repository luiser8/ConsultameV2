USE [PRD]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RecordsHA]
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
					DECLARE @lapsoacta AS VARCHAR(7)
					SELECT @lapsoacta=Lapso FROM [dbo].[lapsos] WHERE Activo=1

					SELECT    [dbo].[Cargas_Academicas].IdMateria, [dbo].[Electivas].Nombre_Opcion, 
								[dbo].[Horarios].Materia, [dbo].[Horarios].Turno, [dbo].[Horarios].Dia, 
									[dbo].[Horarios].Hora AS IdHora, [dbo].[Horas_Clases].Desde AS Hora, [dbo].[Horarios].Bloque, [dbo].[Horarios].Aula, [dbo].[Horarios].Seccion, 
										[dbo].[Horarios].Docente, [dbo].[Cargas_Academicas].Lapso,
											[dbo].[Dias_Clases].DiaID, [dbo].[Dias_Clases].Dia AS DiaClase
					FROM         [dbo].[Horarios] INNER JOIN
						  [dbo].[Cargas_Academicas] ON [dbo].[Horarios].Icc = [dbo].[Cargas_Academicas].Icc AND [dbo].[Horarios].Id_Materia = [dbo].[Cargas_Academicas].IdMateria AND 
						  [dbo].[Horarios].Lapso = [dbo].[Cargas_Academicas].Lapso AND [dbo].[Horarios].Id_Opcion = [dbo].[Cargas_Academicas].Id_Opcion AND [dbo].[Horarios].IdTr = [dbo].[Cargas_Academicas].IdTr AND 
						  [dbo].[Horarios].Seccion = [dbo].[Cargas_Academicas].Seccion LEFT OUTER JOIN
						  [dbo].[Electivas] ON [dbo].[Cargas_Academicas].IdMateria = [dbo].[Electivas].Id_Electiva AND [dbo].[Cargas_Academicas].Id_Opcion = [dbo].[Electivas].Id_Opcion AND 
						  [dbo].[Cargas_Academicas].Icc = [dbo].[Electivas].Icc 
						  INNER JOIN [dbo].[Dias_Clases] ON [dbo].[Horarios].Dia = [dbo].[Dias_Clases].DiaID
						  INNER JOIN [dbo].[Horas_Clases] ON [dbo].[Horarios].Hora = [dbo].[Horas_Clases].Hora
							WHERE [dbo].[Cargas_Academicas].IdAl=@IdAl
					END	
	END TRY
		BEGIN CATCH
			SELECT ERROR_MESSAGE() AS ERROR,
				ERROR_NUMBER() AS ERROR_NRO
		END CATCH;
END