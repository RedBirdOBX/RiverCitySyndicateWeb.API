-- Postgres

-- DROP TABLE IF EXISTS public.photos;
CREATE TABLE IF NOT EXISTS public.photos
(
    id integer NOT NULL DEFAULT nextval('photos_id_seq'::regclass),
    file_name character varying COLLATE pg_catalog."default" NOT NULL,
    heading character varying COLLATE pg_catalog."default" NOT NULL,
    description character varying COLLATE pg_catalog."default" NOT NULL,
    photo_date date NOT NULL,
    added date NOT NULL,
    active boolean NOT NULL DEFAULT true,
    CONSTRAINT photos_pkey PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.photos
    OWNER to postgres;

--SQL SERVER
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Photos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [varchar](100) NOT NULL,
	[Heading] [varchar](100) NOT NULL,
	[Description] [varchar](500) NOT NULL,
	[PhotoDate] [date] NOT NULL,
	[Height] [int] NULL,
	[Width] [int] NULL,
	[Added] [datetime] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Photos] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Photos] ADD  CONSTRAINT [DF_Photos_Added]  DEFAULT (getdate()) FOR [Added]
GO

