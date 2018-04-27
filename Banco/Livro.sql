IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[GKSSP_NomeProcedure]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[GKSSP_NomeProcedure]
GO

CREATE PROCEDURE [dbo].[GKSSP_NomeProcedure]

	AS

	/*
	Documentação
	Arquivo Fonte.....: ArquivoFonte.sql
	Objetivo..........: Objetivo
	Autor.............: SMN - Thiago Teixeira
 	Data..............: 01/01/2018
	Ex................: EXEC [dbo].[GKSSP_NomeProcedure]

	*/

	BEGIN
	
		

	END
GO

GO
	CREATE PROCEDURE BLTC_SelectLivros
	AS
		BEGIN
			SELECT *
				FROM tbl_Livro;
		END

	EXEC BLTC_SelectLivros;

GO
	--INSERINDO OS LIVROS

	CREATE PROCEDURE BLTC_InsertLivros(
		@NomeLivro VARCHAR(50),
		@ISBN VARCHAR(30),
		@DataPub DATETIME,
		@PrecoLivro MONEY,
		@IDAutor SMALLINT,
		@IDEditora SMALLINT
	)
	AS
		BEGIN
			INSERT INTO tbl_Livro(
				Nome_Livro,
				ISBN,
				Data_Pub,
				Preco_Livro,
				ID_Autor,
				ID_Editora
			)
			VALUES(
				@NomeLivro,
				@ISBN,
				@DataPub,
				@PrecoLivro,
				@IDAutor,
				@IDEditora
			);
		END

	--EXEC BLTC_InsertLivros 'Uma breve historia do tempo', '444343343', '19951204', 32.12, 7, 3;

GO

	--ALTERANDO LIVROS

	CREATE PROCEDURE BLTC_AlterarLivro(
		@ID SMALLINT,
		@NovoNome VARCHAR(50),
		@NovoISBN VARCHAR(30),
		@NovaData DATETIME,
		@NovoIdAutor SMALLINT,
		@NovoIdEditora SMALLINT
	)
	AS 
		BEGIN
			UPDATE tbl_Livro
				SET 
					Nome_Livro = @NovoNome,
					ISBN = @NovoISBN,
					Data_Pub = @NovaData,
					ID_Autor = @NovoIdAutor,
					ID_Editora = @NovoIdEditora
				WHERE
					ID_Livro = @ID;
		END
GO
--EXEC BLTC_AlterarLivro 108, 'Uma Breve História do Tempo', '44434341', '19801204', 30.00, 7, 3;



	--EXCLUINDO LIVROS
GO

	CREATE PROCEDURE BLTC_DeletarLivro(
		@ID SMALLINT
	)
	AS 
		BEGIN
			DELETE FROM tbl_Livro
				WHERE 
					ID_Livro = @ID;
		END
	--EXEC BLTC_DeletarLivro 108;
GO


-- BUSCANDO LIVROS DOS AUTORES
	
	CREATE PROCEDURE BLTC_SelectLivroAutor(
		@IDAutor SMALLINT
	)
	AS 
		BEGIN 	
			SELECT	TL.ID_Livro,
					TL.Nome_Livro, 
					TL.ISBN,
					TA.ID_Autor,
					TA.Nome_Autor,
					TA.Sobrenome_Autor
			FROM tbl_Livro AS TL
				INNER JOIN tbl_autores TA 
					ON TL.ID_Autor = TA.ID_Autor
			WHERE TL.ID_Autor = @IDAutor
		END