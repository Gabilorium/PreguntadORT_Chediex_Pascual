USE [PreguntadOrt]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 28/9/2022 10:41:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](max) NULL,
	[Foto] [varchar](max) NULL,
 CONSTRAINT [PK_Categorias] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dificultades]    Script Date: 28/9/2022 10:41:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dificultades](
	[IdDificultad] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](max) NULL,
 CONSTRAINT [PK_Dificultades] PRIMARY KEY CLUSTERED 
(
	[IdDificultad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Preguntas]    Script Date: 28/9/2022 10:41:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Preguntas](
	[IdPregunta] [int] IDENTITY(1,1) NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[IdDificultad] [int] NOT NULL,
	[Enunciado] [varchar](max) NULL,
	[Foto] [varchar](max) NULL,
 CONSTRAINT [PK_Preguntas] PRIMARY KEY CLUSTERED 
(
	[IdPregunta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Respuestas]    Script Date: 28/9/2022 10:41:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Respuestas](
	[IdRespuesta] [int] IDENTITY(1,1) NOT NULL,
	[IdPregunta] [int] NOT NULL,
	[Opcion] [int] NULL,
	[Contenido] [varchar](max) NULL,
	[Correcta] [bit] NULL,
	[Foto] [varchar](max) NULL,
 CONSTRAINT [PK_Respuestas] PRIMARY KEY CLUSTERED 
(
	[IdRespuesta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ScoreBoard]    Script Date: 28/9/2022 10:41:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScoreBoard](
	[IdPuntaje] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](max) NULL,
	[Puntaje] [int] NULL,
	[Dia] [datetime] NULL,
 CONSTRAINT [PK_ScoreBoard] PRIMARY KEY CLUSTERED 
(
	[IdPuntaje] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categorias] ON 

INSERT [dbo].[Categorias] ([IdCategoria], [Nombre], [Foto]) VALUES (1, N'personajes', NULL)
INSERT [dbo].[Categorias] ([IdCategoria], [Nombre], [Foto]) VALUES (2, N'lugares', NULL)
INSERT [dbo].[Categorias] ([IdCategoria], [Nombre], [Foto]) VALUES (3, N'referencias', NULL)
SET IDENTITY_INSERT [dbo].[Categorias] OFF
GO
SET IDENTITY_INSERT [dbo].[Dificultades] ON 

INSERT [dbo].[Dificultades] ([IdDificultad], [Nombre]) VALUES (1, N'facil')
INSERT [dbo].[Dificultades] ([IdDificultad], [Nombre]) VALUES (2, N'medio')
INSERT [dbo].[Dificultades] ([IdDificultad], [Nombre]) VALUES (3, N'dificil')
SET IDENTITY_INSERT [dbo].[Dificultades] OFF
GO
SET IDENTITY_INSERT [dbo].[Preguntas] ON 

INSERT [dbo].[Preguntas] ([IdPregunta], [IdCategoria], [IdDificultad], [Enunciado], [Foto]) VALUES (1, 1, 1, N'¿Quién es Jane?', N'incognito.jpg')
INSERT [dbo].[Preguntas] ([IdPregunta], [IdCategoria], [IdDificultad], [Enunciado], [Foto]) VALUES (2, 1, 1, N'¿Cuál es la nueva identidad que toma Saul Goodman cuando termina Breaking Bad?', N'Gene.jpg')
INSERT [dbo].[Preguntas] ([IdPregunta], [IdCategoria], [IdDificultad], [Enunciado], [Foto]) VALUES (3, 1, 1, N'¿Quién de estos NO es un amigo de Jesse Pinkman?', N'JesseAmigos.jpg')
INSERT [dbo].[Preguntas] ([IdPregunta], [IdCategoria], [IdDificultad], [Enunciado], [Foto]) VALUES (4, 1, 2, N'¿Quién es Todd Alquist?', N'incognito.jpg')
INSERT [dbo].[Preguntas] ([IdPregunta], [IdCategoria], [IdDificultad], [Enunciado], [Foto]) VALUES (5, 1, 2, N'¿Cómo se llama el arquitecto que construyó el laboratorio de metanfetamina de Gustavo Fring?', N'lab.jpg')
INSERT [dbo].[Preguntas] ([IdPregunta], [IdCategoria], [IdDificultad], [Enunciado], [Foto]) VALUES (6, 1, 3, N'¿Quién asesinó a Hank Schrader?', N'HankMuerto.jpg')
INSERT [dbo].[Preguntas] ([IdPregunta], [IdCategoria], [IdDificultad], [Enunciado], [Foto]) VALUES (7, 1, 3, N'¿Cuándo aparece por primera vez Francesca (en la línea temporal)?', N'francesca.jpg')
INSERT [dbo].[Preguntas] ([IdPregunta], [IdCategoria], [IdDificultad], [Enunciado], [Foto]) VALUES (8, 2, 1, N'¿Cómo se llama la cadena de restaurantes de Gustavo Fring?', N'gus1.jpg')
INSERT [dbo].[Preguntas] ([IdPregunta], [IdCategoria], [IdDificultad], [Enunciado], [Foto]) VALUES (9, 2, 1, N'¿De dónde es Gustavo Fring?', N'gus2.jpg')
INSERT [dbo].[Preguntas] ([IdPregunta], [IdCategoria], [IdDificultad], [Enunciado], [Foto]) VALUES (10, 2, 1, N'¿En qué negocio Walter White comienza a lavar su dinero?', N'lavadoDinero.jpg')
INSERT [dbo].[Preguntas] ([IdPregunta], [IdCategoria], [IdDificultad], [Enunciado], [Foto]) VALUES (11, 2, 2, N'¿Hacia qué Estado se va Jesse en el final de El Camino?', N'jesseElCamino.jpg')
INSERT [dbo].[Preguntas] ([IdPregunta], [IdCategoria], [IdDificultad], [Enunciado], [Foto]) VALUES (12, 2, 2, N'¿De qué es el supuesto negocio que llama Walter White para cambiar su identidad? ', N'aspiradoras.jpg')
INSERT [dbo].[Preguntas] ([IdPregunta], [IdCategoria], [IdDificultad], [Enunciado], [Foto]) VALUES (13, 2, 3, N'¿De qué universidad se recibió de abogado Jimmy McGill?', N'universidad.jfif')
INSERT [dbo].[Preguntas] ([IdPregunta], [IdCategoria], [IdDificultad], [Enunciado], [Foto]) VALUES (14, 2, 3, N'¿Dónde nació y creció Kim Wexler?', N'kim.jpg')
INSERT [dbo].[Preguntas] ([IdPregunta], [IdCategoria], [IdDificultad], [Enunciado], [Foto]) VALUES (15, 3, 1, N'¿A qué hace referencia “Better Call Saul”, el nombre del capítulo 8 de la temporada 2 de Breaking Bad?', N'cap8t2.jpg')
INSERT [dbo].[Preguntas] ([IdPregunta], [IdCategoria], [IdDificultad], [Enunciado], [Foto]) VALUES (16, 3, 1, N'¿A qué hace referencia “Breaking Bad”, el nombre del capítulo 11 de la temporada 6 de Better Call Saul?', N'cap11t6.jpg')
INSERT [dbo].[Preguntas] ([IdPregunta], [IdCategoria], [IdDificultad], [Enunciado], [Foto]) VALUES (17, 3, 2, N'¿A qué hace referencia el nombre “Saul Gone” del último capítulo de Better Call Saul?', N'saulGone.jfif')
INSERT [dbo].[Preguntas] ([IdPregunta], [IdCategoria], [IdDificultad], [Enunciado], [Foto]) VALUES (18, 3, 2, N'¿A qué hace referencia “Saul Goodman”, el nombre laboral de Jimmy McGill? ', N'saulGoodman.jpg')
INSERT [dbo].[Preguntas] ([IdPregunta], [IdCategoria], [IdDificultad], [Enunciado], [Foto]) VALUES (19, 3, 3, N'¿A qué hace referencia la dirección juan tabo 6353?', N'pregunta.jpg')
INSERT [dbo].[Preguntas] ([IdPregunta], [IdCategoria], [IdDificultad], [Enunciado], [Foto]) VALUES (20, 3, 3, N'¿A qué hacen referencia las iniciales “W.W” en las notas de un libro de Gale que Hank le muestra a Walter?', N'ww.PNG')
INSERT [dbo].[Preguntas] ([IdPregunta], [IdCategoria], [IdDificultad], [Enunciado], [Foto]) VALUES (21, 3, 3, N'¿A qué hace referencia el nombre “Ozymandias”, del capítulo 14 de la temporada 5 de Breaking Bad?', N'ozymandias.jpg')
SET IDENTITY_INSERT [dbo].[Preguntas] OFF
GO
SET IDENTITY_INSERT [dbo].[Respuestas] ON 

INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (1, 1, 1, N'La nieta de Mike', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (2, 1, 2, N'La novia de Jesse', 1, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (3, 1, 3, N'La hija de Walter White', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (4, 1, 4, N'La esposa de Hank', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (5, 2, 1, N'James McGill', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (6, 2, 2, N'Charles McGill', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (7, 2, 3, N'Gabriel Takovic', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (8, 2, 4, N'Gene Takovic', 1, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (9, 3, 1, N'Skinny Pete', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (10, 3, 2, N'Combo', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (11, 3, 3, N'Tuco Salamanca', 1, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (12, 3, 4, N'Badger', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (13, 4, 1, N'Un ladrón de trenes', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (14, 4, 2, N'Miembro de una banda de neonazis', 1, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (15, 4, 3, N'Un drogadicto', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (16, 4, 4, N'El compañero de Hank Schrader', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (17, 5, 1, N'Michael Ehrmantraut', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (18, 5, 2, N'Timo Werner', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (19, 5, 3, N'Rich Schweichart', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (20, 5, 4, N'Werner Ziegler', 1, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (21, 6, 1, N'Walter White', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (22, 6, 2, N'Jesse Pinkman', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (23, 6, 3, N'Jack Walker', 1, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (24, 6, 4, N'Todd Alquist', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (25, 7, 1, N'Como secretaria de Saul Goodman', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (26, 7, 2, N'Como secretaria de Kim y Jimmy', 1, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (27, 7, 3, N'Trabajando con Jimmy en el buffet Davis & Main', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (28, 7, 4, N'Como clienta de Saul Goodman', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (29, 8, 1, N'Los Hermanos Pollo', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (30, 8, 2, N'The Chicken brothers', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (31, 8, 3, N'Los Pollos Hermanos', 1, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (32, 8, 4, N'Fried Chicken', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (33, 9, 1, N'México', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (34, 9, 2, N'Costa Rica', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (35, 9, 3, N'Belice', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (36, 9, 4, N'Chile', 1, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (37, 10, 1, N'Fichines', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (38, 10, 2, N'Lavadero de autos', 1, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (39, 10, 3, N'Los Pollos Hermanos', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (40, 10, 4, N'Control de plagas', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (41, 11, 1, N'Nebraska', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (42, 11, 2, N'Alaska', 1, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (43, 11, 3, N'Alabama', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (44, 11, 4, N'California', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (45, 12, 1, N'Lavadoras', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (46, 12, 2, N'Aspiradoras', 1, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (47, 12, 3, N'Flores', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (48, 12, 4, N'Muebles', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (49, 13, 1, N'Universidad de Albuquerque', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (50, 13, 2, N'Universidad de Nuevo México', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (51, 13, 3, N'Universidad de Samoa Americana', 1, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (52, 13, 4, N'Universidad de California', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (53, 14, 1, N'Nebraska', 1, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (54, 14, 2, N'Albuquerque', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (55, 14, 3, N'California', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (56, 14, 4, N'Florida', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (57, 15, 1, N'A Saul Goodman', 1, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (58, 15, 2, N'A un call center', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (59, 15, 3, N'A kim Wexler', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (60, 15, 4, N'A HHM', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (61, 16, 1, N'A que Jimmy McGill se vuelve malo', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (62, 16, 2, N'A la aparición de Walter White y Jesse Pinkman', 1, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (63, 16, 3, N'A que aparece un hombre con cáncer en el episodio', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (64, 16, 4, N'A que Gus Fring mata a Lalo', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (65, 17, 1, N'A que Jimmy McGill pudo bajar su condena', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (66, 17, 2, N'A que Jimmy McGill terminó preso', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (67, 17, 3, N'A que Jimmy McGill se reencontró con Kim', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (68, 17, 4, N'A que Saul Goodman dejó de ser parte de Jimmy McGill', 1, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (69, 18, 1, N'A la frase en inglés “It´s all good man”', 1, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (70, 18, 2, N'Al nombre de un amigo suyo de Chicago', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (71, 18, 3, N'Al nombre que usó en una propaganda', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (72, 18, 4, N'A que es una buena persona', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (73, 19, 1, N'A la dirección del laboratorio de Gus Fring', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (74, 19, 2, N'A la dirección de la casa Gus Fring', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (75, 19, 3, N'A la dirección de Gale que Walter le dice a Mike', 1, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (76, 19, 4, N'A la dirección de la casa de los padres de Jesse', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (77, 20, 1, N'Walter White', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (78, 20, 2, N'Willy Wonka', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (79, 20, 3, N'Walt Whitman', 1, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (80, 20, 4, N'Woodrow Wilson', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (81, 21, 1, N'Al poema de un rey que lo pierde todo', 1, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (82, 21, 2, N'A la muerte de Hank Schrader', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (83, 21, 3, N'A una canción de Beethoven', 0, NULL)
INSERT [dbo].[Respuestas] ([IdRespuesta], [IdPregunta], [Opcion], [Contenido], [Correcta], [Foto]) VALUES (84, 21, 4, N'A que capturan a Jesse Pinkman', 0, NULL)
SET IDENTITY_INSERT [dbo].[Respuestas] OFF
GO
SET IDENTITY_INSERT [dbo].[ScoreBoard] ON 

INSERT [dbo].[ScoreBoard] ([IdPuntaje], [Username], [Puntaje], [Dia]) VALUES (1, N'Gabilo', 900, CAST(N'2022-09-28T10:37:41.063' AS DateTime))
SET IDENTITY_INSERT [dbo].[ScoreBoard] OFF
GO
ALTER TABLE [dbo].[Preguntas]  WITH CHECK ADD  CONSTRAINT [FK_Preguntas_Categorias] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categorias] ([IdCategoria])
GO
ALTER TABLE [dbo].[Preguntas] CHECK CONSTRAINT [FK_Preguntas_Categorias]
GO
ALTER TABLE [dbo].[Preguntas]  WITH CHECK ADD  CONSTRAINT [FK_Preguntas_Dificultades] FOREIGN KEY([IdDificultad])
REFERENCES [dbo].[Dificultades] ([IdDificultad])
GO
ALTER TABLE [dbo].[Preguntas] CHECK CONSTRAINT [FK_Preguntas_Dificultades]
GO
ALTER TABLE [dbo].[Respuestas]  WITH CHECK ADD  CONSTRAINT [FK_Respuestas_Preguntas] FOREIGN KEY([IdPregunta])
REFERENCES [dbo].[Preguntas] ([IdPregunta])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Respuestas] CHECK CONSTRAINT [FK_Respuestas_Preguntas]
GO
