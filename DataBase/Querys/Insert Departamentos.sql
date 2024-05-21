USE [prueba]
GO

INSERT INTO [dbo].[Departamentos]
           ([codigo]
           ,[nombre]
           ,[activo]
           ,[idUsuarioCreacion])
     VALUES
          
           ('ADM', 'Administración',1,1),
           ('VTA', 'Ventas',1,1),
           ('SIS', 'Sistemas',1,1),
           ('LEG', 'Legal',1,1),
           ('LMP', 'Limpieza', 1, 1)
           
GO


