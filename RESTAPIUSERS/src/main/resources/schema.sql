-- User: "XamarinAccount"
-- DROP USER "XamarinAccount";

CREATE USER "XamarinAccount" WITH
  LOGIN
  NOSUPERUSER
  INHERIT
  CREATEDB
  NOCREATEROLE
  NOREPLICATION
  PASSWORD = "Xamarin";


-- Table: public.evenements

-- DROP TABLE public.evenements;

CREATE TABLE public.evenements
(
    id integer NOT NULL DEFAULT nextval('evenements_id_seq'::regclass),
    "Nom" character varying(50) COLLATE pg_catalog."default" NOT NULL,
    date date NOT NULL,
    responsable character varying COLLATE pg_catalog."default" NOT NULL,
    "Description" text COLLATE pg_catalog."default",
    CONSTRAINT "PK_evenement" PRIMARY KEY (id),
    CONSTRAINT "FK_evenement_user" FOREIGN KEY (responsable)
        REFERENCES public.users (login) MATCH SIMPLE
        ON UPDATE CASCADE
        ON DELETE CASCADE
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.evenements
    OWNER to postgres;

GRANT INSERT, SELECT, UPDATE, DELETE, TRUNCATE ON TABLE public.evenements TO "XamarinAccount" WITH GRANT OPTION;

GRANT ALL ON TABLE public.evenements TO postgres;

-- Table: public.maps

-- DROP TABLE public.maps;

CREATE TABLE public.maps
(
    id integer NOT NULL DEFAULT nextval('map_id_seq'::regclass),
    titre character varying(200) COLLATE pg_catalog."default" NOT NULL,
    longitude double precision NOT NULL,
    latitude double precision NOT NULL,
    description text COLLATE pg_catalog."default",
    CONSTRAINT map_pkey PRIMARY KEY (id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.maps
    OWNER to postgres;

GRANT INSERT, SELECT, UPDATE, DELETE, TRUNCATE ON TABLE public.maps TO "XamarinAccount" WITH GRANT OPTION;

GRANT ALL ON TABLE public.maps TO postgres;

-- Table: public.users

-- DROP TABLE public.users;

CREATE TABLE public.users
(
    login character varying(200) COLLATE pg_catalog."default" NOT NULL,
    password character varying(200) COLLATE pg_catalog."default" NOT NULL,
    nom character varying(50) COLLATE pg_catalog."default",
    prenom character varying(50) COLLATE pg_catalog."default",
    email character varying(200) COLLATE pg_catalog."default" NOT NULL,
    birthdate date,
    emailuniversitaire character varying COLLATE pg_catalog."default",
    CONSTRAINT "PK_Users" PRIMARY KEY (login)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.users
    OWNER to postgres;

GRANT INSERT, SELECT, UPDATE, DELETE, TRUNCATE ON TABLE public.users TO "XamarinAccount" WITH GRANT OPTION;

GRANT ALL ON TABLE public.users TO postgres;

