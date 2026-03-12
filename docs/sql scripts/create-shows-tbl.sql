-- POSTGRES
-- Table: public.shows
-- DROP TABLE IF EXISTS public.shows;
CREATE TABLE IF NOT EXISTS public.shows
(
    id integer NOT NULL DEFAULT nextval('shows_id_seq'::regclass),
    title character varying(100) COLLATE pg_catalog."default" NOT NULL,
    location character varying(100) COLLATE pg_catalog."default" NOT NULL,
    date date NOT NULL,
    "time" character varying(100) COLLATE pg_catalog."default" NOT NULL,
    description character varying COLLATE pg_catalog."default" NOT NULL,
    image character varying(50) COLLATE pg_catalog."default" NOT NULL,
    url character varying(100) COLLATE pg_catalog."default",
    mapurl character varying(500) COLLATE pg_catalog."default",
    added date NOT NULL,
    active boolean NOT NULL,
    CONSTRAINT shows_pkey PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.shows
    OWNER to postgres;


-- SQL SERVER
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Shows](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[Location] [varchar](100) NOT NULL,
	[Date] [date] NOT NULL,
	[Time] [varchar](50) NOT NULL,
	[Description] [varchar](1000) NOT NULL,
	[Image] [varchar](50) NOT NULL,
	[Url] [varchar](100) NULL,
	[MapUrl] [varchar](500) NULL,
	[Added] [datetime] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Shows] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Shows] ADD  CONSTRAINT [DF_Shows_Added]  DEFAULT (getdate()) FOR [Added]
GO

ALTER TABLE [dbo].[Shows] ADD  CONSTRAINT [DF_Shows_Active]  DEFAULT ((1)) FOR [Active]
GO



