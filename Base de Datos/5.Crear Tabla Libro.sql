USE Libreria
GO

IF OBJECT_ID (N'dbo.Libro', N'U') IS NOT NULL  
 DROP TABLE dbo.Libro
GO

CREATE TABLE Libro (
 IdLibro INT NOT NULL IDENTITY(1,1),
 Titulo VARCHAR (250) NOT NULL,
 Anio INT NOT NULL,
 IdGenero INT NOT NULL,
 NumeroPaginas BIGINT NOT NULL,
 IdEditorial INT NOT NULL,
 IdAutor INT NOT NULL,
 CONSTRAINT PK_Libro PRIMARY KEY NONCLUSTERED (IdLibro),
 CONSTRAINT FK_Libro_Genero FOREIGN KEY (IdGenero)
        REFERENCES [dbo].[Genero] (IdGenero),
 CONSTRAINT FK_Libro_Editorial FOREIGN KEY (IdEditorial)
        REFERENCES [dbo].[Editorial] (IdEditorial),
 CONSTRAINT FK_Libro_Autor FOREIGN KEY (IdAutor)
        REFERENCES [dbo].[Autor] (IdAutor)

)