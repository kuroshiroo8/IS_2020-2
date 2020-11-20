/*+-----------------------------------------------------------------------------------------------------------+
| AUTOR: Victor Rafael Velazquez Mejía,                                                                       |
| Sistema: Administración de Usuarios.                                                                        |
| Tablas: PlanEstudioMateria |
| Acciones: Insertar, Borrar  y Modificar los datos de un usuario.                                            |
+------------------------------------------------------------------------------------------------------------+*/


CREATE PROCEDURE [IBM_PlanEstudioMateria]
(
  @Accion  nvarchar(20),
  @IdPlanEstudioMateria		int,
  @IdPlanEstudio		int,
  @IdMateria		int,
  @IdTipoMateria		int,
  @IdEtapa		int,
  @IdAreaConocimiento		int,
  @Semestre		int
)

AS

BEGIN
  IF @Accion = 'INSERTAR'
    BEGIN
      INSERT INTO PlanEstudioMateria(IdPlanEstudio, IdMateria, IdTipoMateria, IdEtapa, IdAreaConocimiento, Semestre) VALUES(@IdPlanEstudio, @IdMateria, @IdTipoMateria, @IdEtapa, @IdAreaConocimiento, @Semestre)
    END

  IF @Accion = 'BORRAR'
    BEGIN
      DELETE FROM PlanEstudioMateria WHERE IdPlanEstudioMateria = @IdPlanEstudioMateria
     END

  IF @Accion = 'MODIFICAR'
     BEGIN
       UPDATE PlanEstudioMateria SET
			  IdPlanEstudio = @IdPlanEstudio,
			  IdMateria = @IdMateria,
			  IdTipoMateria = @IdTipoMateria,
			  IdEtapa = @IdEtapa,
			  IdAreaConocimiento = @IdAreaConocimiento,
			  Semestre = @Semestre
		WHERE IdPlanEstudioMateria = @IdPlanEstudioMateria
     END
  END
