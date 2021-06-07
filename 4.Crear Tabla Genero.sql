USE Libreria
GO

IF OBJECT_ID (N'dbo.Genero', N'U') IS NOT NULL  
 DROP TABLE dbo.Genero
GO

CREATE TABLE Genero (
 IdGenero INT NOT NULL IDENTITY(1,1),
 Descripcion VARCHAR (250) NOT NULL,
 CONSTRAINT PK_Genero PRIMARY KEY NONCLUSTERED (IdGenero)

)