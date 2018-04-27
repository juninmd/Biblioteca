	
    CREATE TABLE tbl_Livro(
		ID_Livro SMALLINT PRIMARY KEY IDENTITY(100,1),
		Nome_Livro VARCHAR(50) NOT NULL,
		ISBN VARCHAR(30) NOT NULL UNIQUE,
		ID_Autor SMALLINT NOT NULL,
		Data_Pub DATETIME NOT NULL,
		Preco_Livro MONEY NOT NULL
	)

	CREATE TABLE tbl_autores(
		ID_Autor SMALLINT NOT NULL PRIMARY KEY IDENTITY(1,1),
		Nome_Autor VARCHAR(50),
		Sobrenome_Autor VARCHAR(60)
	)

	CREATE TABLE tbl_editoras(
		ID_Editora SMALLINT PRIMARY KEY IDENTITY,
		Nome_Editora VARCHAR(50) NOT NULL
	)

	ALTER TABLE tbl_Livro
	DROP COLUMN ID_Autor;

	ALTER TABLE tbl_Livro
	ADD ID_Autor SMALLINT NOT NULL
	CONSTRAINT fk_ID_Autor FOREIGN KEY(ID_Autor)
	REFERENCES tbl_autores;

	ALTER TABLE tbl_Livro
	ALTER COLUMN ID_Autor SMALLINT

	ALTER TABLE tbl_Livro
	ADD ID_Editora SMALLINT NOT NULL
	CONSTRAINT fk_id_editora FOREIGN KEY(ID_Editora)
	REFERENCES tbl_editoras;

    INSERT INTO tbl_autores(Nome_Autor, Sobrenome_Autor) VALUES ('Stephen','King');
	INSERT INTO tbl_autores(Nome_Autor, Sobrenome_Autor) VALUES ('Carl','Sagan');
	INSERT INTO tbl_autores(Nome_Autor, Sobrenome_Autor) VALUES ('Neil','Gaiman');
	INSERT INTO tbl_autores(Nome_Autor, Sobrenome_Autor) VALUES ('Paul','Deitel');
	INSERT INTO tbl_autores(Nome_Autor, Sobrenome_Autor) VALUES ('Yeshua','Hamashia');


	INSERT INTO tbl_editoras(Nome_Editora) VALUES ('Copel');
	INSERT INTO tbl_editoras(Nome_Editora) VALUES ('Saint');
	INSERT INTO tbl_editoras(Nome_Editora) VALUES ('Rocco');
	INSERT INTO tbl_editoras(Nome_Editora) VALUES ('Pearson');
	INSERT INTO tbl_editoras(Nome_Editora) VALUES ('Madras');


	INSERT INTO tbl_Livro(Nome_Livro, ISBN, Data_Pub, Preco_Livro, ID_Autor, ID_Editora) VALUES ('O Iluminado', '43243232','20151104', 57.34,1,1);
	INSERT INTO tbl_Livro(Nome_Livro, ISBN, Data_Pub, Preco_Livro, ID_Autor, ID_Editora) VALUES ('Pale Blue Dot', '53263432','19880508', 89.90,2, 2);
	INSERT INTO tbl_Livro(Nome_Livro, ISBN, Data_Pub, Preco_Livro, ID_Autor, ID_Editora) VALUES ('O Oceano no Fim do Caminho', '23256232','20110514', 30.00 ,3, 3);
	INSERT INTO tbl_Livro(Nome_Livro, ISBN, Data_Pub, Preco_Livro, ID_Autor, ID_Editora) VALUES ('Java, Como Programar', '13263232','20000812', 310.60,4, 4);
	INSERT INTO tbl_Livro(Nome_Livro, ISBN, Data_Pub, Preco_Livro, ID_Autor, ID_Editora) VALUES ('C, Como Programar', '18269232','19950103', 287.30,4, 4);
	INSERT INTO tbl_Livro(Nome_Livro, ISBN, Data_Pub, Preco_Livro, ID_Autor, ID_Editora) VALUES ('O Iluminado', '65243232','20111207', 57.34,5, 5);
	INSERT INTO tbl_Livro(Nome_Livro, ISBN, Data_Pub, Preco_Livro, ID_Autor, ID_Editora) VALUES ('Use a cabe�a, JQuery!', '34269232','20130306', 25.90,NULL, 4);
	INSERT INTO tbl_Livro(Nome_Livro, ISBN, Data_Pub, Preco_Livro, ID_Autor, ID_Editora) VALUES ('Ardu�no B�sico', '45243232','20151207', 70.00,NULL, 5);