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
	CREATE PROCEDURE BLTC_InsereEditora(
	@nome VARCHAR(50))
	AS 
		BEGIN
			INSERT INTO tbl_editoras(
				Nome_Editora
			)
			VALUES(@nome);
		END
GO
	CREATE PROCEDURE BLTC_SelectEditora
		AS
			BEGIN
				SELECT *
					FROM tbl_editoras;
			END

	EXEC BLTC_SelectEditora;
GO

	CREATE PROCEDURE BLTC_AlteraEditora(
			@ID SMALLINT,
			@NovoNome VARCHAR(50)
		)

		AS
			BEGIN
				UPDATE tbl_editoras
					SET Nome_Editora = @NovoNome
						WHERE ID_Editora = @ID;
			END

		EXEC BLTC_AlteraEditora 3, 'Rocco';

GO 
	CREATE PROCEDURE BLTC_DeletaEditora(
			@ID SMALLINT
		)

		AS
			BEGIN
				DELETE 
					FROM tbl_editoras
						WHERE ID_Editora = @ID;
			END

	EXEC BLTC_DeletaEditora 6;
