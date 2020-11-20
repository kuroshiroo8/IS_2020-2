/*+-----------------------------------------------------------------------------------------------------------+
| AUTOR: Victor Rafael Velazquez Mejía,                                                                       |
| Sistema: Administración de Usuarios.                                                                        |
| Tablas: NivelAcademico |
| Acciones: Insertar, Borrar  y Modificar los datos de un usuario.                                            |
+------------------------------------------------------------------------------------------------------------+*/


CREATE PROCEDURE [IBM_NivelAcademico]
(
  @Accion  nvarchar(20),
  @IdNivelAcademico		int,
  @ClaveNivelAcademico		nvarchar,
  @NombreNivelAcademico		nvarchar
)

AS

BEGIN
  IF @Accion = 'INSERTAR'
    BEGIN
      INSERT INTO NivelAcademico(ClaveNivelAcademico, NombreNivelAcademico) VALUES(@ClaveNivelAcademico, @NombreNivelAcademico)
    END

  IF @Accion = 'BORRAR'
    BEGIN
      DELETE FROM NivelAcademico WHERE IdNivelAcademico = @IdNivelAcademico
     END

  IF @Accion = 'MODIFICAR'
     BEGIN
       UPDATE NivelAcademico SET
			  ClaveNivelAcademico = @ClaveNivelAcademico,
			  NombreNivelAcademico = @NombreNivelAcademico
		WHERE IdNivelAcademico = @IdNivelAcademico
     END
  END
