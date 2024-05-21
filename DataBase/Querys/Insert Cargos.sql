USE [prueba]
GO

INSERT INTO [dbo].[Cargos]
           ([codigo]
           ,[nombre]
           ,[activo]
           ,[idUsuarioCreacion])
     VALUES
           ('CA01', 'Administrador',1,1),
		   ('CA02', 'Contador',1,1),
		   ('CA03', 'Cajero',1,1),
		   ('CA04', 'Desarrollador',1,1),
		   ('CA05', 'Abogado',1,1)		   
GO


