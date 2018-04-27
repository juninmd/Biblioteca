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

CREATE PROCEDURE BLTC_InsertAutor(
	@NomeAutor VARCHAR(50),
	@SobrenomeAutor VARCHAR(60)
)
	AS 
		BEGIN
			INSERT INTO tbl_autores(
				Nome_Autor, Sobrenome_Autor
			)
			VALUES(@NomeAutor, @SobrenomeAutor);
		END
GO


GO
CREATE PROCEDURE BLTC_SelectAutor
	AS
		BEGIN
			SELECT * 
				FROM tbl_autores;
		END
GO

EXEC BLTC_SelectAutor

GO
CREATE PROCEDURE BLTC_AlteraAutor(
		@ID SMALLINT,
		@NovoNome VARCHAR(50),
		@NovoSobrenome VARCHAR(60)
)
	AS
		BEGIN
			UPDATE tbl_autores 
				SET Nome_Autor = @NovoNome,
					Sobrenome_Autor = @NovoSobrenome
				WHERE ID_Autor = @ID;
		END

EXEC BLTC_AlteraAutor 5, 'Yeshua', 'Hamashia';

GO
	CREATE PROCEDURE BLTC_DeletaAutor(
		@ID SMALLINT
	)
	AS
		BEGIN
			DELETE FROM tbl_autores
				WHERE ID_Autor = @ID; 
		END
	EXEC BLTC_DeletaAutor 10;