USE Libreria
GO

IF NOT EXISTS (SELECT * FROM Genero WHERE Descripcion = 'Biografia')
BEGIN
  INSERT INTO Genero (
  Descripcion
  ) VALUES (
  'Biografia'
  )
END

IF NOT EXISTS (SELECT * FROM Genero WHERE Descripcion = 'Novela')
BEGIN
  INSERT INTO Genero (
  Descripcion
  ) VALUES (
  'Novela'
  )
END

IF NOT EXISTS (SELECT * FROM Genero WHERE Descripcion = 'Historia')
BEGIN
  INSERT INTO Genero (
  Descripcion
  ) VALUES (
  'Historia'
  )
END
GO
