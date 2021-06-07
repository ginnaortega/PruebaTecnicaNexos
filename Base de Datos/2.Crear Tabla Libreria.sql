USE Libreria
GO

IF OBJECT_ID (N'dbo.Editorial', N'U') IS NOT NULL  
 DROP TABLE dbo.Editorial
GO

CREATE TABLE Editorial (
 IdEditorial INT NOT NULL IDENTITY(1,1),
 Nombre VARCHAR (200) NOT NULL,
 DireccionCorrespondencia VARCHAR(100) NOT NULL,
 Telefono VARCHAR(50) NOT NULL,
 Email VARCHAR(50) NOT NULL,
 MaximoLibros BIGINT NOT NULL,
 CONSTRAINT PK_Editorial PRIMARY KEY NONCLUSTERED (IdEditorial)

)