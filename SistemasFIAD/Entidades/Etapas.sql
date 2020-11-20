/*+-----------------------------------------------------------------------------------------------------------+
| AUTOR: Victor Rafael Velazquez Mejía,                                                                       |
| Sistema: Administración de Usuarios.                                                                        |
| Tablas: Etapas |
| Acciones: Insertar, Borrar  y Modificar los datos de un usuario.                                            |
+------------------------------------------------------------------------------------------------------------+*/


CREATE PROCEDURE [IBM_Etapas]
(
  @Accion  nvarchar(20),
  @IdEtapa		int,
  @ClaveEtapa		char,
  @NombreEtapa		nvarchar
)

AS

BEGIN
  IF @Accion = 'INSERTAR'
    BEGIN
      INSERT INTO Etapas(ClaveEtapa, NombreEtapa) VALUES(@ClaveEtapa, @NombreEtapa)
    END

  IF @Accion = 'BORRAR'
    BEGIN
      DELETE FROM Etapas WHERE IdEtapa = @IdEtapa
     END

  IF @Accion = 'MODIFICAR'
     BEGIN
       UPDATE Etapas SET
			  ClaveEtapa = @ClaveEtapa,
			  NombreEtapa = @NombreEtapa
		WHERE IdEtapa = @IdEtapa
     END
  END
