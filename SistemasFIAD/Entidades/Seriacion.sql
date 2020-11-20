/*+-----------------------------------------------------------------------------------------------------------+
| AUTOR: Victor Rafael Velazquez Mejía,                                                                       |
| Sistema: Administración de Usuarios.                                                                        |
| Tablas: Seriacion |
| Acciones: Insertar, Borrar  y Modificar los datos de un usuario.                                            |
+------------------------------------------------------------------------------------------------------------+*/


CREATE PROCEDURE [IBM_Seriacion]
(
  @Accion  nvarchar(20),
  @IdSeriacion		int,
  @IdMateria		int,
  @IdMateriaSeriada		int
)

AS

BEGIN
  IF @Accion = 'INSERTAR'
    BEGIN
      INSERT INTO Seriacion(IdMateria, IdMateriaSeriada) VALUES(@IdMateria, @IdMateriaSeriada)
    END

  IF @Accion = 'BORRAR'
    BEGIN
      DELETE FROM Seriacion WHERE IdSeriacion = @IdSeriacion
     END

  IF @Accion = 'MODIFICAR'
     BEGIN
       UPDATE Seriacion SET
			  IdMateria = @IdMateria,
			  IdMateriaSeriada = @IdMateriaSeriada
		WHERE IdSeriacion = @IdSeriacion
     END
  END
