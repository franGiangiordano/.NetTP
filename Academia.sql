USE [Academia]
GO
/****** Object:  Table [dbo].[alumnos_inscripciones]    Script Date: 23/07/2022 21:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[alumnos_inscripciones](
	[id_inscripcion] [int] IDENTITY(1,1) NOT NULL,
	[id_alumno] [int] NOT NULL,
	[id_curso] [int] NOT NULL,
	[condicion] [varchar](50) NOT NULL,
	[nota] [int] NULL,
 CONSTRAINT [PK_alumnos_inscripciones] PRIMARY KEY CLUSTERED 
(
	[id_inscripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[comisiones]    Script Date: 23/07/2022 21:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[comisiones](
	[id_comision] [int] IDENTITY(1,1) NOT NULL,
	[desc_comision] [varchar](50) NOT NULL,
	[anio_especialidad] [int] NOT NULL,
	[id_plan] [int] NOT NULL,
 CONSTRAINT [PK_comisiones] PRIMARY KEY CLUSTERED 
(
	[id_comision] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[cursos]    Script Date: 23/07/2022 21:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cursos](
	[id_curso] [int] IDENTITY(1,1) NOT NULL,
	[id_materia] [int] NOT NULL,
	[id_comision] [int] NOT NULL,
	[anio_calendario] [int] NOT NULL,
	[cupo] [int] NOT NULL,
 CONSTRAINT [PK_cursos] PRIMARY KEY CLUSTERED 
(
	[id_curso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[docentes_cursos]    Script Date: 23/07/2022 21:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[docentes_cursos](
	[id_dictado] [int] IDENTITY(1,1) NOT NULL,
	[id_curso] [int] NOT NULL,
	[id_docente] [int] NOT NULL,
	[cargo] [int] NOT NULL,
 CONSTRAINT [PK_docentes_cursos] PRIMARY KEY CLUSTERED 
(
	[id_dictado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[especialidades]    Script Date: 23/07/2022 21:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[especialidades](
	[id_especialidad] [int] IDENTITY(1,1) NOT NULL,
	[desc_especialidad] [varchar](50) NOT NULL,
 CONSTRAINT [PK_especialidades] PRIMARY KEY CLUSTERED 
(
	[id_especialidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[materias]    Script Date: 23/07/2022 21:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[materias](
	[id_materia] [int] IDENTITY(1,1) NOT NULL,
	[desc_materia] [varchar](50) NOT NULL,
	[hs_semanales] [int] NOT NULL,
	[hs_totales] [int] NOT NULL,
	[id_plan] [int] NOT NULL,
 CONSTRAINT [PK_materias] PRIMARY KEY CLUSTERED 
(
	[id_materia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[modulos]    Script Date: 23/07/2022 21:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[modulos](
	[id_modulo] [int] IDENTITY(1,1) NOT NULL,
	[desc_modulo] [varchar](50) NULL,
	[ejecuta] [varchar](50) NULL,
 CONSTRAINT [PK_modulos] PRIMARY KEY CLUSTERED 
(
	[id_modulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[modulos_usuarios]    Script Date: 23/07/2022 21:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[modulos_usuarios](
	[id_modulo_usuario] [int] IDENTITY(1,1) NOT NULL,
	[id_modulo] [int] NOT NULL,
	[id_usuario] [int] NOT NULL,
	[alta] [bit] NULL,
	[baja] [bit] NULL,
	[modificacion] [bit] NULL,
	[consulta] [bit] NULL,
 CONSTRAINT [PK_modulos_usuarios] PRIMARY KEY CLUSTERED 
(
	[id_modulo_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[personas]    Script Date: 23/07/2022 21:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[personas](
	[id_persona] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[direccion] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[telefono] [varchar](50) NULL,
	[fecha_nac] [datetime] NOT NULL,
	[legajo] [int] NULL,
	[tipo_persona] [int] NOT NULL,
	[id_plan] [int] NOT NULL,
 CONSTRAINT [PK_personas] PRIMARY KEY CLUSTERED 
(
	[id_persona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[planes]    Script Date: 23/07/2022 21:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[planes](
	[id_plan] [int] IDENTITY(1,1) NOT NULL,
	[desc_plan] [varchar](50) NOT NULL,
	[id_especialidad] [int] NOT NULL,
 CONSTRAINT [PK_planes] PRIMARY KEY CLUSTERED 
(
	[id_plan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 23/07/2022 21:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre_usuario] [varchar](50) NOT NULL,
	[clave] [varchar](50) NOT NULL,
	[habilitado] [bit] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[email] [varchar](50) NULL,
	[cambia_clave] [bit] NULL,
	[id_persona] [int] NULL,
 CONSTRAINT [PK_usuarios] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[alumnos_inscripciones] ON 

INSERT [dbo].[alumnos_inscripciones] ([id_inscripcion], [id_alumno], [id_curso], [condicion], [nota]) VALUES (5, 10, 5, N'Inscripto', NULL)
INSERT [dbo].[alumnos_inscripciones] ([id_inscripcion], [id_alumno], [id_curso], [condicion], [nota]) VALUES (6, 10, 6, N'Inscripto', NULL)
INSERT [dbo].[alumnos_inscripciones] ([id_inscripcion], [id_alumno], [id_curso], [condicion], [nota]) VALUES (7, 8, 7, N'Aprobado', 9)
INSERT [dbo].[alumnos_inscripciones] ([id_inscripcion], [id_alumno], [id_curso], [condicion], [nota]) VALUES (8, 8, 9, N'Regular', -1)
INSERT [dbo].[alumnos_inscripciones] ([id_inscripcion], [id_alumno], [id_curso], [condicion], [nota]) VALUES (9, 8, 7, N'Libre', -1)
INSERT [dbo].[alumnos_inscripciones] ([id_inscripcion], [id_alumno], [id_curso], [condicion], [nota]) VALUES (10, 9, 6, N'Inscripto', NULL)
INSERT [dbo].[alumnos_inscripciones] ([id_inscripcion], [id_alumno], [id_curso], [condicion], [nota]) VALUES (11, 9, 9, N'Inscripto', NULL)
SET IDENTITY_INSERT [dbo].[alumnos_inscripciones] OFF
SET IDENTITY_INSERT [dbo].[comisiones] ON 

INSERT [dbo].[comisiones] ([id_comision], [desc_comision], [anio_especialidad], [id_plan]) VALUES (4, N'403', 2022, 2)
INSERT [dbo].[comisiones] ([id_comision], [desc_comision], [anio_especialidad], [id_plan]) VALUES (5, N'404', 2022, 2)
INSERT [dbo].[comisiones] ([id_comision], [desc_comision], [anio_especialidad], [id_plan]) VALUES (6, N'405', 2022, 2)
SET IDENTITY_INSERT [dbo].[comisiones] OFF
SET IDENTITY_INSERT [dbo].[cursos] ON 

INSERT [dbo].[cursos] ([id_curso], [id_materia], [id_comision], [anio_calendario], [cupo]) VALUES (5, 9, 4, 2022, 3)
INSERT [dbo].[cursos] ([id_curso], [id_materia], [id_comision], [anio_calendario], [cupo]) VALUES (6, 10, 4, 2022, 2)
INSERT [dbo].[cursos] ([id_curso], [id_materia], [id_comision], [anio_calendario], [cupo]) VALUES (7, 11, 4, 2022, 2)
INSERT [dbo].[cursos] ([id_curso], [id_materia], [id_comision], [anio_calendario], [cupo]) VALUES (8, 12, 4, 2022, 4)
INSERT [dbo].[cursos] ([id_curso], [id_materia], [id_comision], [anio_calendario], [cupo]) VALUES (9, 13, 4, 2022, 2)
SET IDENTITY_INSERT [dbo].[cursos] OFF
SET IDENTITY_INSERT [dbo].[docentes_cursos] ON 

INSERT [dbo].[docentes_cursos] ([id_dictado], [id_curso], [id_docente], [cargo]) VALUES (1, 5, 3, 1)
INSERT [dbo].[docentes_cursos] ([id_dictado], [id_curso], [id_docente], [cargo]) VALUES (2, 5, 6, 0)
INSERT [dbo].[docentes_cursos] ([id_dictado], [id_curso], [id_docente], [cargo]) VALUES (3, 6, 7, 1)
INSERT [dbo].[docentes_cursos] ([id_dictado], [id_curso], [id_docente], [cargo]) VALUES (4, 6, 8, 0)
INSERT [dbo].[docentes_cursos] ([id_dictado], [id_curso], [id_docente], [cargo]) VALUES (5, 7, 6, 1)
INSERT [dbo].[docentes_cursos] ([id_dictado], [id_curso], [id_docente], [cargo]) VALUES (6, 7, 8, 0)
INSERT [dbo].[docentes_cursos] ([id_dictado], [id_curso], [id_docente], [cargo]) VALUES (7, 8, 3, 0)
INSERT [dbo].[docentes_cursos] ([id_dictado], [id_curso], [id_docente], [cargo]) VALUES (8, 8, 7, 1)
INSERT [dbo].[docentes_cursos] ([id_dictado], [id_curso], [id_docente], [cargo]) VALUES (9, 9, 7, 0)
INSERT [dbo].[docentes_cursos] ([id_dictado], [id_curso], [id_docente], [cargo]) VALUES (10, 9, 8, 1)
SET IDENTITY_INSERT [dbo].[docentes_cursos] OFF
SET IDENTITY_INSERT [dbo].[especialidades] ON 

INSERT [dbo].[especialidades] ([id_especialidad], [desc_especialidad]) VALUES (1, N'ISI')
INSERT [dbo].[especialidades] ([id_especialidad], [desc_especialidad]) VALUES (2, N'IQ')
SET IDENTITY_INSERT [dbo].[especialidades] OFF
SET IDENTITY_INSERT [dbo].[materias] ON 

INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan]) VALUES (9, N'TDC', 2, 4, 2)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan]) VALUES (10, N'AMII', 2, 4, 2)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan]) VALUES (11, N'Quimica', 2, 4, 2)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan]) VALUES (12, N'Fisica', 2, 4, 2)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan]) VALUES (13, N'.NET', 2, 4, 2)
SET IDENTITY_INSERT [dbo].[materias] OFF
SET IDENTITY_INSERT [dbo].[modulos] ON 

INSERT [dbo].[modulos] ([id_modulo], [desc_modulo], [ejecuta]) VALUES (1, N'Principal', NULL)
INSERT [dbo].[modulos] ([id_modulo], [desc_modulo], [ejecuta]) VALUES (2, N'Especialidades', NULL)
INSERT [dbo].[modulos] ([id_modulo], [desc_modulo], [ejecuta]) VALUES (3, N'Cursos', NULL)
INSERT [dbo].[modulos] ([id_modulo], [desc_modulo], [ejecuta]) VALUES (4, N'Materias', NULL)
INSERT [dbo].[modulos] ([id_modulo], [desc_modulo], [ejecuta]) VALUES (5, N'AlumnoInscripciones', NULL)
INSERT [dbo].[modulos] ([id_modulo], [desc_modulo], [ejecuta]) VALUES (6, N'AlumnoInscripcionDesktop', NULL)
INSERT [dbo].[modulos] ([id_modulo], [desc_modulo], [ejecuta]) VALUES (7, N'Docentes', NULL)
SET IDENTITY_INSERT [dbo].[modulos] OFF
SET IDENTITY_INSERT [dbo].[modulos_usuarios] ON 

INSERT [dbo].[modulos_usuarios] ([id_modulo_usuario], [id_modulo], [id_usuario], [alta], [baja], [modificacion], [consulta]) VALUES (18, 1, 8, 1, 1, 1, 1)
INSERT [dbo].[modulos_usuarios] ([id_modulo_usuario], [id_modulo], [id_usuario], [alta], [baja], [modificacion], [consulta]) VALUES (19, 2, 8, 1, 1, 1, 1)
INSERT [dbo].[modulos_usuarios] ([id_modulo_usuario], [id_modulo], [id_usuario], [alta], [baja], [modificacion], [consulta]) VALUES (20, 3, 8, 1, 1, 1, 1)
INSERT [dbo].[modulos_usuarios] ([id_modulo_usuario], [id_modulo], [id_usuario], [alta], [baja], [modificacion], [consulta]) VALUES (21, 4, 8, 1, 1, 1, 1)
INSERT [dbo].[modulos_usuarios] ([id_modulo_usuario], [id_modulo], [id_usuario], [alta], [baja], [modificacion], [consulta]) VALUES (22, 5, 8, 1, 1, 1, 1)
INSERT [dbo].[modulos_usuarios] ([id_modulo_usuario], [id_modulo], [id_usuario], [alta], [baja], [modificacion], [consulta]) VALUES (23, 6, 8, 1, 1, 1, 1)
INSERT [dbo].[modulos_usuarios] ([id_modulo_usuario], [id_modulo], [id_usuario], [alta], [baja], [modificacion], [consulta]) VALUES (24, 1, 9, 0, 0, 0, 1)
INSERT [dbo].[modulos_usuarios] ([id_modulo_usuario], [id_modulo], [id_usuario], [alta], [baja], [modificacion], [consulta]) VALUES (25, 2, 9, 0, 0, 0, 0)
INSERT [dbo].[modulos_usuarios] ([id_modulo_usuario], [id_modulo], [id_usuario], [alta], [baja], [modificacion], [consulta]) VALUES (26, 3, 9, 0, 0, 0, 0)
INSERT [dbo].[modulos_usuarios] ([id_modulo_usuario], [id_modulo], [id_usuario], [alta], [baja], [modificacion], [consulta]) VALUES (27, 4, 9, 0, 0, 0, 0)
INSERT [dbo].[modulos_usuarios] ([id_modulo_usuario], [id_modulo], [id_usuario], [alta], [baja], [modificacion], [consulta]) VALUES (28, 5, 9, 1, 1, 0, 1)
INSERT [dbo].[modulos_usuarios] ([id_modulo_usuario], [id_modulo], [id_usuario], [alta], [baja], [modificacion], [consulta]) VALUES (29, 6, 9, 1, 1, 0, 1)
INSERT [dbo].[modulos_usuarios] ([id_modulo_usuario], [id_modulo], [id_usuario], [alta], [baja], [modificacion], [consulta]) VALUES (30, 1, 10, 0, 0, 1, 1)
INSERT [dbo].[modulos_usuarios] ([id_modulo_usuario], [id_modulo], [id_usuario], [alta], [baja], [modificacion], [consulta]) VALUES (31, 2, 10, 0, 0, 0, 0)
INSERT [dbo].[modulos_usuarios] ([id_modulo_usuario], [id_modulo], [id_usuario], [alta], [baja], [modificacion], [consulta]) VALUES (32, 3, 10, 0, 0, 0, 0)
INSERT [dbo].[modulos_usuarios] ([id_modulo_usuario], [id_modulo], [id_usuario], [alta], [baja], [modificacion], [consulta]) VALUES (33, 4, 10, 0, 0, 0, 0)
INSERT [dbo].[modulos_usuarios] ([id_modulo_usuario], [id_modulo], [id_usuario], [alta], [baja], [modificacion], [consulta]) VALUES (34, 5, 10, 0, 0, 1, 1)
INSERT [dbo].[modulos_usuarios] ([id_modulo_usuario], [id_modulo], [id_usuario], [alta], [baja], [modificacion], [consulta]) VALUES (35, 6, 10, 0, 0, 1, 1)
INSERT [dbo].[modulos_usuarios] ([id_modulo_usuario], [id_modulo], [id_usuario], [alta], [baja], [modificacion], [consulta]) VALUES (36, 1, 11, 0, 0, 0, 1)
INSERT [dbo].[modulos_usuarios] ([id_modulo_usuario], [id_modulo], [id_usuario], [alta], [baja], [modificacion], [consulta]) VALUES (37, 2, 11, 0, 0, 0, 0)
INSERT [dbo].[modulos_usuarios] ([id_modulo_usuario], [id_modulo], [id_usuario], [alta], [baja], [modificacion], [consulta]) VALUES (38, 3, 11, 0, 0, 0, 0)
INSERT [dbo].[modulos_usuarios] ([id_modulo_usuario], [id_modulo], [id_usuario], [alta], [baja], [modificacion], [consulta]) VALUES (39, 4, 11, 0, 0, 0, 0)
INSERT [dbo].[modulos_usuarios] ([id_modulo_usuario], [id_modulo], [id_usuario], [alta], [baja], [modificacion], [consulta]) VALUES (40, 5, 11, 1, 1, 0, 1)
INSERT [dbo].[modulos_usuarios] ([id_modulo_usuario], [id_modulo], [id_usuario], [alta], [baja], [modificacion], [consulta]) VALUES (41, 6, 11, 1, 1, 0, 1)
INSERT [dbo].[modulos_usuarios] ([id_modulo_usuario], [id_modulo], [id_usuario], [alta], [baja], [modificacion], [consulta]) VALUES (42, 1, 12, 0, 0, 1, 1)
INSERT [dbo].[modulos_usuarios] ([id_modulo_usuario], [id_modulo], [id_usuario], [alta], [baja], [modificacion], [consulta]) VALUES (43, 2, 12, 0, 0, 0, 0)
INSERT [dbo].[modulos_usuarios] ([id_modulo_usuario], [id_modulo], [id_usuario], [alta], [baja], [modificacion], [consulta]) VALUES (44, 3, 12, 0, 0, 0, 0)
INSERT [dbo].[modulos_usuarios] ([id_modulo_usuario], [id_modulo], [id_usuario], [alta], [baja], [modificacion], [consulta]) VALUES (45, 4, 12, 0, 0, 0, 0)
INSERT [dbo].[modulos_usuarios] ([id_modulo_usuario], [id_modulo], [id_usuario], [alta], [baja], [modificacion], [consulta]) VALUES (46, 5, 12, 0, 0, 1, 1)
INSERT [dbo].[modulos_usuarios] ([id_modulo_usuario], [id_modulo], [id_usuario], [alta], [baja], [modificacion], [consulta]) VALUES (47, 6, 12, 0, 0, 1, 1)
INSERT [dbo].[modulos_usuarios] ([id_modulo_usuario], [id_modulo], [id_usuario], [alta], [baja], [modificacion], [consulta]) VALUES (48, 7, 9, 0, 0, 0, 0)
INSERT [dbo].[modulos_usuarios] ([id_modulo_usuario], [id_modulo], [id_usuario], [alta], [baja], [modificacion], [consulta]) VALUES (49, 7, 11, 0, 0, 0, 0)
INSERT [dbo].[modulos_usuarios] ([id_modulo_usuario], [id_modulo], [id_usuario], [alta], [baja], [modificacion], [consulta]) VALUES (50, 7, 10, 0, 0, 0, 1)
INSERT [dbo].[modulos_usuarios] ([id_modulo_usuario], [id_modulo], [id_usuario], [alta], [baja], [modificacion], [consulta]) VALUES (51, 7, 12, 0, 0, 0, 1)
INSERT [dbo].[modulos_usuarios] ([id_modulo_usuario], [id_modulo], [id_usuario], [alta], [baja], [modificacion], [consulta]) VALUES (53, 7, 8, 1, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[modulos_usuarios] OFF
SET IDENTITY_INSERT [dbo].[personas] ON 

INSERT [dbo].[personas] ([id_persona], [nombre], [apellido], [direccion], [email], [telefono], [fecha_nac], [legajo], [tipo_persona], [id_plan]) VALUES (1, N'admin', N'admin', N'Ocampo 345', N'', N'', CAST(N'1996-08-10T00:00:00.000' AS DateTime), 1, 2, 2)
INSERT [dbo].[personas] ([id_persona], [nombre], [apellido], [direccion], [email], [telefono], [fecha_nac], [legajo], [tipo_persona], [id_plan]) VALUES (3, N'Marco', N'Alonso', N'Chacabuco 123', NULL, N'31331', CAST(N'1998-02-06T00:00:00.000' AS DateTime), 12324, 1, 2)
INSERT [dbo].[personas] ([id_persona], [nombre], [apellido], [direccion], [email], [telefono], [fecha_nac], [legajo], [tipo_persona], [id_plan]) VALUES (5, N'Julian', N'Maldonado', N'Chacabuco 123', N'', N'', CAST(N'2006-10-09T00:00:00.000' AS DateTime), 4567, 0, 2)
INSERT [dbo].[personas] ([id_persona], [nombre], [apellido], [direccion], [email], [telefono], [fecha_nac], [legajo], [tipo_persona], [id_plan]) VALUES (6, N'Sandra', N'Guzman', N'Belgrano 123', N'', N'', CAST(N'2001-08-01T00:00:00.000' AS DateTime), 45871, 1, 2)
INSERT [dbo].[personas] ([id_persona], [nombre], [apellido], [direccion], [email], [telefono], [fecha_nac], [legajo], [tipo_persona], [id_plan]) VALUES (7, N'Roberto', N'Garcia', N'Centenario 432', N'', N'', CAST(N'1998-10-02T00:00:00.000' AS DateTime), 67123, 1, 2)
INSERT [dbo].[personas] ([id_persona], [nombre], [apellido], [direccion], [email], [telefono], [fecha_nac], [legajo], [tipo_persona], [id_plan]) VALUES (8, N'Florencia', N'Gentilli', N'Colon 435', N'', N'', CAST(N'1995-02-04T00:00:00.000' AS DateTime), 74814, 1, 2)
INSERT [dbo].[personas] ([id_persona], [nombre], [apellido], [direccion], [email], [telefono], [fecha_nac], [legajo], [tipo_persona], [id_plan]) VALUES (9, N'Ezequiel', N'Lombardo', N'San Lorenz 43', N'ezelomb@hotmail.com', N'45718904', CAST(N'1996-04-07T00:00:00.000' AS DateTime), 4571, 0, 2)
INSERT [dbo].[personas] ([id_persona], [nombre], [apellido], [direccion], [email], [telefono], [fecha_nac], [legajo], [tipo_persona], [id_plan]) VALUES (10, N'Agustina', N'Lopez', N'Moreno 450', N'', N'', CAST(N'1999-08-06T00:00:00.000' AS DateTime), 5901, 0, 2)
SET IDENTITY_INSERT [dbo].[personas] OFF
SET IDENTITY_INSERT [dbo].[planes] ON 

INSERT [dbo].[planes] ([id_plan], [desc_plan], [id_especialidad]) VALUES (2, N'2008', 1)
INSERT [dbo].[planes] ([id_plan], [desc_plan], [id_especialidad]) VALUES (3, N'1995', 1)
SET IDENTITY_INSERT [dbo].[planes] OFF
SET IDENTITY_INSERT [dbo].[usuarios] ON 

INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [nombre], [apellido], [email], [cambia_clave], [id_persona]) VALUES (8, N'admin', N'ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc9', 1, N'admin', N'admin', N'admin@gmail.com', NULL, 1)
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [nombre], [apellido], [email], [cambia_clave], [id_persona]) VALUES (9, N'alumno', N'ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc9', 1, N'alumno', N'alumno', N'asd@gmail.com', NULL, 10)
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [nombre], [apellido], [email], [cambia_clave], [id_persona]) VALUES (10, N'docente', N'ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc9', 1, N'docente', N'docente', N'doc@gmail.com', NULL, 8)
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [nombre], [apellido], [email], [cambia_clave], [id_persona]) VALUES (11, N'alumno2', N'ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc9', 1, N'alumno', N'alumno', N'alumno2@gmail.com', NULL, 9)
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [nombre], [apellido], [email], [cambia_clave], [id_persona]) VALUES (12, N'docente2', N'ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc9', 1, N'docente', N'docente', N'docente2@gmail.com', NULL, 7)
SET IDENTITY_INSERT [dbo].[usuarios] OFF
ALTER TABLE [dbo].[alumnos_inscripciones]  WITH CHECK ADD  CONSTRAINT [FK_alumnos_inscripciones_cursos] FOREIGN KEY([id_curso])
REFERENCES [dbo].[cursos] ([id_curso])
GO
ALTER TABLE [dbo].[alumnos_inscripciones] CHECK CONSTRAINT [FK_alumnos_inscripciones_cursos]
GO
ALTER TABLE [dbo].[alumnos_inscripciones]  WITH CHECK ADD  CONSTRAINT [FK_alumnos_inscripciones_personas] FOREIGN KEY([id_alumno])
REFERENCES [dbo].[personas] ([id_persona])
GO
ALTER TABLE [dbo].[alumnos_inscripciones] CHECK CONSTRAINT [FK_alumnos_inscripciones_personas]
GO
ALTER TABLE [dbo].[comisiones]  WITH CHECK ADD  CONSTRAINT [FK_comisiones_planes] FOREIGN KEY([id_plan])
REFERENCES [dbo].[planes] ([id_plan])
GO
ALTER TABLE [dbo].[comisiones] CHECK CONSTRAINT [FK_comisiones_planes]
GO
ALTER TABLE [dbo].[cursos]  WITH CHECK ADD  CONSTRAINT [FK_cursos_comisiones] FOREIGN KEY([id_comision])
REFERENCES [dbo].[comisiones] ([id_comision])
GO
ALTER TABLE [dbo].[cursos] CHECK CONSTRAINT [FK_cursos_comisiones]
GO
ALTER TABLE [dbo].[cursos]  WITH CHECK ADD  CONSTRAINT [FK_cursos_materias] FOREIGN KEY([id_materia])
REFERENCES [dbo].[materias] ([id_materia])
GO
ALTER TABLE [dbo].[cursos] CHECK CONSTRAINT [FK_cursos_materias]
GO
ALTER TABLE [dbo].[docentes_cursos]  WITH CHECK ADD  CONSTRAINT [FK_docentes_cursos_cursos] FOREIGN KEY([id_curso])
REFERENCES [dbo].[cursos] ([id_curso])
GO
ALTER TABLE [dbo].[docentes_cursos] CHECK CONSTRAINT [FK_docentes_cursos_cursos]
GO
ALTER TABLE [dbo].[docentes_cursos]  WITH CHECK ADD  CONSTRAINT [FK_docentes_cursos_personas] FOREIGN KEY([id_docente])
REFERENCES [dbo].[personas] ([id_persona])
GO
ALTER TABLE [dbo].[docentes_cursos] CHECK CONSTRAINT [FK_docentes_cursos_personas]
GO
ALTER TABLE [dbo].[materias]  WITH CHECK ADD  CONSTRAINT [FK_materias_planes] FOREIGN KEY([id_plan])
REFERENCES [dbo].[planes] ([id_plan])
GO
ALTER TABLE [dbo].[materias] CHECK CONSTRAINT [FK_materias_planes]
GO
ALTER TABLE [dbo].[modulos_usuarios]  WITH CHECK ADD  CONSTRAINT [FK_modulos_usuarios_modulos] FOREIGN KEY([id_modulo])
REFERENCES [dbo].[modulos] ([id_modulo])
GO
ALTER TABLE [dbo].[modulos_usuarios] CHECK CONSTRAINT [FK_modulos_usuarios_modulos]
GO
ALTER TABLE [dbo].[modulos_usuarios]  WITH CHECK ADD  CONSTRAINT [FK_modulos_usuarios_usuarios] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuarios] ([id_usuario])
GO
ALTER TABLE [dbo].[modulos_usuarios] CHECK CONSTRAINT [FK_modulos_usuarios_usuarios]
GO
ALTER TABLE [dbo].[personas]  WITH CHECK ADD  CONSTRAINT [FK_personas_planes] FOREIGN KEY([id_plan])
REFERENCES [dbo].[planes] ([id_plan])
GO
ALTER TABLE [dbo].[personas] CHECK CONSTRAINT [FK_personas_planes]
GO
ALTER TABLE [dbo].[planes]  WITH CHECK ADD  CONSTRAINT [FK_planes_especialidades] FOREIGN KEY([id_especialidad])
REFERENCES [dbo].[especialidades] ([id_especialidad])
GO
ALTER TABLE [dbo].[planes] CHECK CONSTRAINT [FK_planes_especialidades]
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD  CONSTRAINT [FK_usuarios_personas] FOREIGN KEY([id_persona])
REFERENCES [dbo].[personas] ([id_persona])
GO
ALTER TABLE [dbo].[usuarios] CHECK CONSTRAINT [FK_usuarios_personas]
GO
