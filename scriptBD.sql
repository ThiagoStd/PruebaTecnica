USE master;
GO

-- Verificar si el login 'administrativo' ya existe
IF NOT EXISTS (SELECT 1 FROM sys.server_principals WHERE name = 'administrativo')
BEGIN
    -- Crear el login 'administrativo' 
    CREATE LOGIN administrativo WITH PASSWORD = 'S4nT%99'; 
END;
GO

-- Verificar si la base de datos 'prueba' ya existe
IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE name = 'PruebaTecnica')
BEGIN
    -- Crear la base de datos 'prueba' si no existe
    CREATE DATABASE PruebaTecnica;
	
END;
GO

USE PruebaTecnica;
BEGIN
	-- Dar permisos al login 'administrativo'
	CREATE USER administrativo FOR LOGIN administrativo;
	ALTER ROLE db_datareader ADD MEMBER administrativo;
	ALTER ROLE db_datawriter ADD MEMBER administrativo;
END
GO

-- Verificar si la tabla existe
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'usuarios')
BEGIN
    -- Crear la tabla si no existecomercios
    CREATE TABLE usuarios
    (
       [id_Usuario] INT IDENTITY(1,1) NOT NULL ,
	   [usuario_identificacion] VARCHAR(200),
	   [usuario_nombre] VARCHAR(200),
	   [usuario_clave] VARCHAR(200),
	   [usuario_email] VARCHAR(200),
	   CONSTRAINT PK_usuarios PRIMARY KEY (id_usuario)
    );
END;
GO

-- Verificar si la tabla existe
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'comercios')
BEGIN
    -- Crear la tabla si no existe
    CREATE TABLE comercios
    (
       [id_comercio] INT IDENTITY(1,1) NOT NULL,
	   [comercio_codigo] INT UNIQUE,
	   [comercio_nombre] VARCHAR(200),
	   [comercio_nit] VARCHAR(200),
	   [comercio_clave] VARCHAR(200),
	   [comercio_direccion] VARCHAR(200),
	    CONSTRAINT PK_Comercios PRIMARY KEY (id_Comercio)
    );
END;
GO

-- Verificar si la tabla existe
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'estados')
BEGIN
    -- Crear la tabla si no existe
    CREATE TABLE estados
    (
       [id_estado] INT IDENTITY(1,1)  ,
	   [estado_codigo]  SMALLINT UNIQUE  ,
	   [estado_nombre] VARCHAR (30)  , 
	   CONSTRAINT PK_Estados PRIMARY KEY (id_estado)
    );

	-- Se insertan los estados establecidos
	INSERT INTO estados (estado_codigo,estado_nombre)
	VALUES (1,'Aprobada'),(1000,'Rechazada'),(999,'Pendiente'),(1001,'Rechazada SR')
END;
GO

-- Verificar si la tabla existe
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'medios_pago')
BEGIN
    -- Crear la tabla si no existe
    CREATE TABLE medios_pago
    (
       [id_pago] INT IDENTITY(1,1)  ,
	   [pago_codigo]  SMALLINT UNIQUE  ,
	   [pago_nombre] VARCHAR (30) UNIQUE  ,
	   CONSTRAINT PK_mediospago PRIMARY KEY (id_pago)
    );

	-- Se insertan los Medios de pago establecidos
	INSERT INTO medios_pago (pago_codigo,pago_nombre)
	VALUES (0,'Sin definir'),(32,'Tarjeta de Crédito'),(29,'PSE'),(41,'Gana'),(42,'Caja')
END;
GO

-- Verificar si la tabla existe
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'transacciones')
BEGIN
    -- Crear la tabla si no existe
    CREATE TABLE transacciones
    (
       [id_trans] INT IDENTITY(1,1)  ,
	   [trans_codigo] INT UNIQUE  ,
	   [trans_medio_pago] INT   ,
	   [trans_estado] INT   ,
	   [trans_comercio] INT   ,
	   [trans_usuario] INT   ,
	   [trans_total] DECIMAL(10,2)  ,
	   [trans_fecha] VARCHAR (100)  ,
	   [trans_concepto] VARCHAR (100)   ,
	   CONSTRAINT PK_transacciones PRIMARY KEY (id_trans),
	   CONSTRAINT FK_mediopago FOREIGN KEY (trans_medio_pago) REFERENCES medios_pago(id_Pago),
	   CONSTRAINT FK_estado FOREIGN KEY (trans_estado) REFERENCES estados(id_estado),
	   CONSTRAINT FK_comercio FOREIGN KEY (trans_comercio) REFERENCES comercios(id_comercio),
	   CONSTRAINT FK_usuario FOREIGN KEY (trans_usuario) REFERENCES usuarios(id_usuario)
    );

END;