--CREATE DATABASE db_Biblioteca;

--CRIANDO PROCEDURES DE CONSULTAS BÁSICAS DO AUTOR--
 
--**INSERINDO DADOS COM PROCEDURES**


--EXEC BLTC_SelectAutor

--CRIAÇÃO DAS PROCEDURES DO AUTOR TERMINA AQUI --


--CRIANDO PROCEDURES DA EDITORA--



GO

--CRIANDO PROCEDURES DOS LIVROS--

--SELECIONANDO OS LIVROS


--PROCEDURES DOS LIVROS TERMINAM AQUI

SELECT name, 
       type
  FROM dbo.sysobjects
 WHERE (type = 'P')

GO

CREATE PROCEDURE SHOW_PROCS
AS
	BEGIN 
		SELECT
			name, type
		FROM
			dbo.sysobjects
		WHERE type = 'P'
	END

GO


/*
	--SELECT DISTINCT

	SELECT DISTINCT ID_Autor FROM tbl_Livro;
*/


/*
	--ORDER BY (usado para ordenar os valores da tabela, sendo em decrescente ou crescente)
	SELECT * FROM tbl_Livro ORDER BY Nome_Livro, Preco_Livro ASC;
*/

/*
	--TRUNCATE (usado para limpar os dados da tabela, sem necess�riamente excluir a mesma)
	TRUNCATE TABLE tbl_Livro;
*/

/*
	--UPDATE
		UPDATE tbl_Livro
		SET Preco_Livro = 50.00
			WHERE ID_Autor = 5;
*/

/*
	--SELECT TOP
	SELECT TOP 50 PERCENT *
	FROM tbl_Livro;

	ou

	SELECT TOP 3 *
	FROM tbl_Livro;
*/


/*
	INNER JOIN e ALIAS

	SELECT te.Nome_Editora, ta.Nome_Autor, ta.Sobrenome_Autor
		FROM tbl_Livro AS tl
			INNER JOIN tbl_editoras AS te
				ON tl.ID_Editora = te.ID_Editora
			INNER JOIN tbl_autores AS ta
				ON tl.ID_Autor = ta.ID_Autor;
*/

/*

	UNION -- Combinar o conjunto de resultados de dois ou mais SELECTS

	SELECT tl.Nome_Livro, tl.Preco_Livro
		FROM tbl_Livro AS tl
	UNION --Poderia usar 'UNION ALL' para mostrar valores repetidos
	SELECT te.Nome_Editora, te.ID_Editora
		FROM tbl_editoras AS te;

*/

/*
	SELECT tl.ID_Livro,tl.Nome_Livro, tl.ISBN, ta.Nome_Autor
		INTO Livro_ISBN
			FROM tbl_Livro as tl
				INNER JOIN tbl_autores ta
					ON tl.ID_Autor = ta.ID_Autor;
*/

/*
	SELECT Nome_Livro as Livro, Preco_Livro as Preço
	FROM tbl_Livro
	WHERE Preco_Livro BETWEEN 30.00 AND 100.00;
*/

/*
	SELECT MIN(Preco_Livro) FROM tbl_Livro
	SELECT MAX(Preco_Livro) FROM tbl_Livro
	SELECT AVG(Preco_Livro) FROM tbl_Livro
	SELECT SUM(Preco_Livro) FROM tbl_Livro
	SELECT COUNT(Preco_Livro) FROM tbl_Livro
*/


/*
	LIKE AND NOT LIKE

	% qualquer cadeia de 0 ou mais caracteres

	_ sublinhado, qualquer caractere �nico

	[] Qualquer caractere �nico no intervalo ou conjunto especificado

	[^] Qualquer caractere �nico que n�o esteja no intervalo ou conjunto especificado

	o% -> significa alguma cadeia que come�a com a letra 'O'

	%o -> alguma cadeia que termina com a letra 'O'

	_a% -> especifica um padr�o com as senten�as que tenham a 
	sua segunda letra sendo a letra 'a'


	'[OP]%' -> palavras que come�am com esse conjunto
	de caracteres, n�o importa o que vem depois

	%[OP] -> palavras que terminam com esses caracteres

	LIKE '_i__o' -> primeira letra n�o importa, nem 3, 4 etc..


*/

/*
	--Pegando todos os livros, incluindo os que n�o tem autor-- (LEFT JOIN)
	SELECT *
		FROM tbl_Livro
			LEFT JOIN tbl_autores
				ON tbl_Livro.ID_Autor = tbl_autores.ID_Autor


	--Pegando os livros que tem autor--
	SELECT *
		FROM tbl_Livro
			INNER JOIN tbl_autores
				ON tbl_Livro.ID_Autor = tbl_autores.ID_Autor


	-- Excluindo as Correspond�ncias [apenas livros que n�o possuem autor]
	SELECT *
		FROM tbl_Livro
			LEFT JOIN tbl_autores
				ON tbl_Livro.ID_Autor = tbl_autores.ID_Autor
		WHERE tbl_Livro.ID_Autor IS NULL

*/

/*
	--Exemplo de FULL JOIN
	SELECT li.Nome_Livro, li.ID_Autor, tba.Nome_Autor
		FROM tbl_Livro AS li
			FULL JOIN tbl_autores AS tba
				ON li.ID_Autor = tba.ID_Autor

	--Excluindo Correspond�ncias com FULL JOIN--

	SELECT li.Nome_Livro, li.ID_Autor, tba.Nome_Autor
		FROM tbl_Livro AS li
			FULL JOIN tbl_autores AS tba
				ON li.ID_Autor = tba.ID_Autor
		WHERE li.ID_Autor IS NULL OR tba.ID_Autor IS NULL


--FULL OUTER JOIN
SELECT 
	FROM tbl_autores AS a
		FULL OUTER JOIN tbl_Livro AS l
			ON a.ID_Autor = l.ID_Autor
		FULL OUTER JOIN tbl_editoras e
			ON e.ID_Editora = l.ID_Editora;
*/

/*
	COMANDOS IN e NOT IN

		S�O USADOS PARA VERIFICAR SE UM DETERMINADO VALOR 
		CORRESPONDE � UMA CONSULTA
		
		AO INV�S DE USAR AND ATRIBUTO = '', uso IN ou NOT IN

		-- TAMB�M PODE SUBSTITUIR O OPERADOR OR PARA QUERIES COM MAIS 
		DE UMA CONDI��O
	*/

	/*

	'IN' e 'NOT IN' S�O FILTROS

	SELECT * 
		FROM tbl_autores ta
			WHERE ta.ID_Autor IN (1,2)
*/




/*	
	--CREATE RULE r1_preco AS @VALOR > 10.00;
	UMA SP_BINDRULE � uma PROCEDURE pronta 
	� usado para vincular regras

 --	EXECUTE SP_BINDRULE r1_preco, 'tbl_Livro.Preco_Livro'
*/


/*
	-- CONCATENA��O DE STRINGS --

	� FEITA COM O COMANDO SELECT

	Ex: 
		String1 | coluna + string2 | coluna

		Ex: 

		SELECT Nome_Autor + ' ' + Sobrenome_Autor AS 'Nome Completo' FROM tbl_autores

		Ex 2: 

		SELECT 'Eu gosto do Livro ' + Nome_Livro AS 'Meu Livro' 
	FROM tbl_Livro
		WHERE ID_Autor = 2
*/


/*
	Collation -> Cola��o/Agrupamento
	Trata-se da codifica��o dos caracteres em uma ordem padr�o

	-- Usado para ver as op��es de agrupamento dispon�veis
	SELECT * FROM fn_helpcollations()

	--Esquemad e cola��o usado atualmente pelo servidor
	SELECT SERVERPROPERTY('Collation') AS Current_Collation


	--Alterar o esquema de coleções do BDD
	SELECT DATABASEPROPERTYEX('db_Biblioteca','Collation') AS colacao

*/


/*
	CL�USULA WITH TIES
	-- Usado para exibir itens adjacentes
	Ex: TOP 4 retorna os 4 primeiros Livros da tabela 'livro' levando em considera��o o ID_Editora
	Por�m, existem IDs com o mesmo valor, e estes ficar�o de fora dos itens retornados, a Cl�usula
	WITH TIES faz com que estes itens, (que possuem o mesmo valor de ID_Editora) tamb�m sejam inclusos 
	no resultado

	SELECT TOP(4) WITH TIES Nome_Livro, ID_Editora
	FROM tbl_Livro
		ORDER BY ID_Editora ASC
*/

/*
	VIEWS

	Uma View é uma tabela virtual baseada no conjunto de resultados de uma consulta SQL. (Sempre mostra dados atualizados)

	ALTER VIEW vw_LivrosAutores
	AS SELECT tbl_Livro.Nome_Livro AS Livro, tbl_autores.Nome_Autor AS Autor, tbl_autores.Sobrenome_Autor AS Sobrenome, tbl_Livro.Preco_Livro AS Pre�o
		FROM tbl_Livro
			INNER JOIN tbl_autores
				ON tbl_Livro.ID_Autor = tbl_autores.ID_Autor;

SELECT *
	FROM vw_LivrosAutores
*/

use db_Biblioteca;

/*
	DECLARE @codigo INT
	SET @codigo = 100

	WHILE @codigo < 106
		BEGIN
			SELECT ID_Livro AS ID, Nome_Livro AS Livro, Preco_Livro AS Preço
			FROM tbl_Livro
				WHERE ID_Livro = @codigo
				SET @codigo = @codigo + 1
		END;

*/

GO

/*
CREATE PROCEDURE p_LivroValor
	AS
		SELECT Nome_Livro, Preco_Livro
			FROM tbl_Livro; 

EXEC sp_helptext p_LivroValor; --sp_helptext é usado para mostrar o conteúdo[codigofonte] da procedure

-----------------------------------------------------------------------------------------

--Passando Parâmetros para a procedure--
	ALTER PROCEDURE p_LivroValor
	(@ID INT)
	AS
		SELECT tlivro.ID_Editora, tlivro.Nome_Livro, tlivro.Preco_Livro
			FROM tbl_Livro AS tlivro
				WHERE tlivro.ID_Livro = @ID;


	EXEC p_LivroValor 105;
*/



CREATE FUNCTION busca_autor(@ID SMALLINT)
RETURNS TABLE
AS 
	RETURN(
		SELECT A.Nome_Autor
			FROM tbl_autores AS A
				WHERE ID_Autor = @ID)
GO 

GO 

--Função de Valor de tabela embutida
CREATE FUNCTION retorna_itens(@valor REAL)
RETURNS TABLE
AS
	RETURN(
		SELECT L.Nome_Livro, A.Nome_Autor, E.Nome_Editora
			FROM tbl_Livro AS L
				INNER JOIN tbl_autores AS A
					ON L.ID_Autor = A.ID_Autor
				INNER JOIN tbl_editoras AS E
					ON L.ID_Editora = E.ID_Editora
						WHERE L.Preco_Livro > @valor)

GO
--Como usar a função: 
SELECT Nome_Livro, Nome_Autor
	FROM retorna_itens(300)

GO

GO


CREATE TRIGGER triggertop
	ON tbl_editoras
		AFTER INSERT 
	AS 
		EXEC BLTC_InsertAutor 'Paulo', 'Coelho'
			EXEC BLTC_InsertLivros 'O Alquimista', '444345543', '19901003', 32.12, 18, 23;

DROP TRIGGER triggertop

EXEC BLTC_InsereEditora 'Palo Alto'


EXEC BLTC_SelectAutor;
EXEC BLTC_SelectLivros;
EXEC BLTC_SelectEditora;


--

/*
	EXEC sp_helptrigger @tabname=tbl_editoras; [mostrando os triggers da tabela editoras]
	
	MOSTRANDO TODOS OS TRIGGERS DO BANCO

SELECT *
	FROM sys.triggers
		WHERE is_disabled = 0;
*/
GO

--Determinando colunas à serema atualizadas
CREATE TRIGGER trigger_autores
	ON tbl_autores
		AFTER INSERT, UPDATE 
	AS 	
	IF UPDATE(Nome_Autor)
		BEGIN
			PRINT 'O nome do brother AKA autor foi alterado!'	
		END
	ELSE
		BEGIN 
			PRINT 'Nome não foi modificado'
		END
GO

--Desabilitando um TRIGGER 
ALTER TABLE tbl_autores
	ENABLE TRIGGER trigger_autores;

GO


CREATE TABLE trig_table(
	codigo INT PRIMARY KEY
)

GO