/*+-----------------------------------------------------------------------------------------------------------+
| AUTOR: Victor Rafael Velazquez Mejía,                                                                       |
| Sistema: Administración de Usuarios.                                                                        |
| Tablas: AreaConocimiento |
| Acciones: Insertar, Borrar  y Modificar los datos de un usuario.                                            |
+------------------------------------------------------------------------------------------------------------+*/


CREATE PROCEDURE [IBM_AreaConocimiento]
(
  @Accion  nvarchar(20),
  @IdAreaConocimiento		int,
  @ClaveAreaConocimiento		char,
  @DescripcionAreaConocimiento		nchar
)

AS

BEGIN
  IF @Accion = 'INSERTAR'
    BEGIN
      INSERT INTO AreaConocimiento(ClaveAreaConocimiento, DescripcionAreaConocimiento) VALUES(@ClaveAreaConocimiento, @DescripcionAreaConocimiento)
    END

  IF @Accion = 'BORRAR'
    BEGIN
      DELETE FROM AreaConocimiento WHERE IdAreaConocimiento = @IdAreaConocimiento
     END

  IF @Accion = 'MODIFICAR'
     BEGIN
       UPDATE AreaConocimiento SET
			  ClaveAreaConocimiento = @ClaveAreaConocimiento,
			  DescripcionAreaConocimiento = @DescripcionAreaConocimiento
		WHERE IdAreaConocimiento = @IdAreaConocimiento
     END
  END
