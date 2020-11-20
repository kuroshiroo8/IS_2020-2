/*+-----------------------------------------------------------------------------------------------------------+
| AUTOR: Victor Rafael Velazquez Mejía,                                                                       |
| Sistema: Administración de Usuarios.                                                                        |
| Tablas: PlanEstudio |
| Acciones: Insertar, Borrar  y Modificar los datos de un usuario.                                            |
+------------------------------------------------------------------------------------------------------------+*/


CREATE PROCEDURE [IBM_PlanEstudio]
(
  @Accion  nvarchar(20),
  @IdPlanEstudio		int,
  @IdNivelAcademico		int,
  @IdCarrera		int,
  @ClavePlanEstudio		nvarchar,
  @PlanEstudio		varchar,
  @ProgramaEducativo		nvarchar,
  @FechaCreacion		nvarchar,
  @TotalCreditos		int,
  @EstadoPlanEstudios		bit,
  @Comentarios		nvarchar,
  @PerfilDeIngreso		text,
  @PerfilDeEgreso		text,
  @CampoOcupacional		text
)

AS

BEGIN
  IF @Accion = 'INSERTAR'
    BEGIN
      INSERT INTO PlanEstudio(IdNivelAcademico, IdCarrera, ClavePlanEstudio, PlanEstudio, ProgramaEducativo, FechaCreacion, TotalCreditos, EstadoPlanEstudios, Comentarios, PerfilDeIngreso, PerfilDeEgreso, CampoOcupacional) VALUES(@IdNivelAcademico, @IdCarrera, @ClavePlanEstudio, @PlanEstudio, @ProgramaEducativo, @FechaCreacion, @TotalCreditos, @EstadoPlanEstudios, @Comentarios, @PerfilDeIngreso, @PerfilDeEgreso, @CampoOcupacional)
    END

  IF @Accion = 'BORRAR'
    BEGIN
      DELETE FROM PlanEstudio WHERE IdPlanEstudio = @IdPlanEstudio
     END

  IF @Accion = 'MODIFICAR'
     BEGIN
       UPDATE PlanEstudio SET
			  IdNivelAcademico = @IdNivelAcademico,
			  IdCarrera = @IdCarrera,
			  ClavePlanEstudio = @ClavePlanEstudio,
			  PlanEstudio = @PlanEstudio,
			  ProgramaEducativo = @ProgramaEducativo,
			  FechaCreacion = @FechaCreacion,
			  TotalCreditos = @TotalCreditos,
			  EstadoPlanEstudios = @EstadoPlanEstudios,
			  Comentarios = @Comentarios,
			  PerfilDeIngreso = @PerfilDeIngreso,
			  PerfilDeEgreso = @PerfilDeEgreso,
			  CampoOcupacional = @CampoOcupacional
		WHERE IdPlanEstudio = @IdPlanEstudio
     END
  END
