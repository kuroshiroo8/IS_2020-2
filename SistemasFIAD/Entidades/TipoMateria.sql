/*+-----------------------------------------------------------------------------------------------------------+
| AUTOR: Victor Rafael Velazquez Mejía,                                                                       |
| Sistema: Administración de Usuarios.                                                                        |
| Tablas: TipoMateria |
| Acciones: Insertar, Borrar  y Modificar los datos de un usuario.                                            |
+------------------------------------------------------------------------------------------------------------+*/


CREATE PROCEDURE [IBM_TipoMateria]
(
  @Accion  nvarchar(20),
  @IdTipoMateria		int,
  @NombreTipoMateria		nvarchar,
  @Etapa		nvarchar,
  @Semestre		int
)

AS

BEGIN
  IF @Accion = 'INSERTAR'
    BEGIN
      INSERT INTO TipoMateria(NombreTipoMateria, Etapa, Semestre) VALUES(@NombreTipoMateria, @Etapa, @Semestre)
    END

  IF @Accion = 'BORRAR'
    BEGIN
      DELETE FROM TipoMateria WHERE IdTipoMateria = @IdTipoMateria
     END

  IF @Accion = 'MODIFICAR'
     BEGIN
       UPDATE TipoMateria SET
			  NombreTipoMateria = @NombreTipoMateria,
			  Etapa = @Etapa,
			  Semestre = @Semestre
		WHERE IdTipoMateria = @IdTipoMateria
     END
  END
