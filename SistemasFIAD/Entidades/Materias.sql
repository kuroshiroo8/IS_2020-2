/*+-----------------------------------------------------------------------------------------------------------+
| AUTOR: Victor Rafael Velazquez Mejía,                                                                       |
| Sistema: Administración de Usuarios.                                                                        |
| Tablas: Materias |
| Acciones: Insertar, Borrar  y Modificar los datos de un usuario.                                            |
+------------------------------------------------------------------------------------------------------------+*/


CREATE PROCEDURE [IBM_Materias]
(
  @Accion  nvarchar(20),
  @IdMateria		int,
  @ClaveMateria		varchar,
  @NombreMateria		varchar,
  @HC		int,
  @HL		int,
  @HT		int,
  @HE		int,
  @HPP		int,
  @CR		int,
  @PropositoGeneral		text,
  @Competencia		text,
  @Evidencia		text,
  @Metodologia		text,
  @Criterios		text,
  @BibliografiaBasica		text,
  @BibliografiaComplementaria		text,
  @PerfilDocente		text,
  @EstadoMateria		bit,
  @PathPUA		nvarchar
)

AS

BEGIN
  IF @Accion = 'INSERTAR'
    BEGIN
      INSERT INTO Materias(ClaveMateria, NombreMateria, HC, HL, HT, HE, HPP, CR, PropositoGeneral, Competencia, Evidencia, Metodologia, Criterios, BibliografiaBasica, BibliografiaComplementaria, PerfilDocente, EstadoMateria, PathPUA) VALUES(@ClaveMateria, @NombreMateria, @HC, @HL, @HT, @HE, @HPP, @CR, @PropositoGeneral, @Competencia, @Evidencia, @Metodologia, @Criterios, @BibliografiaBasica, @BibliografiaComplementaria, @PerfilDocente, @EstadoMateria, @PathPUA)
    END

  IF @Accion = 'BORRAR'
    BEGIN
      DELETE FROM Materias WHERE IdMateria = @IdMateria
     END

  IF @Accion = 'MODIFICAR'
     BEGIN
       UPDATE Materias SET
			  ClaveMateria = @ClaveMateria,
			  NombreMateria = @NombreMateria,
			  HC = @HC,
			  HL = @HL,
			  HT = @HT,
			  HE = @HE,
			  HPP = @HPP,
			  CR = @CR,
			  PropositoGeneral = @PropositoGeneral,
			  Competencia = @Competencia,
			  Evidencia = @Evidencia,
			  Metodologia = @Metodologia,
			  Criterios = @Criterios,
			  BibliografiaBasica = @BibliografiaBasica,
			  BibliografiaComplementaria = @BibliografiaComplementaria,
			  PerfilDocente = @PerfilDocente,
			  EstadoMateria = @EstadoMateria,
			  PathPUA = @PathPUA
		WHERE IdMateria = @IdMateria
     END
  END
