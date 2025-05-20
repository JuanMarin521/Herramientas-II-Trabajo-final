-- Crear la base de datos
CREATE DATABASE Herramientas;
GO

-- Usar la base de datos
USE Herramientas;
GO

-- Tabla: Clientes
CREATE TABLE Clientes (
    ClienteID INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(50),
    Apellido NVARCHAR(50),
    Telefono NVARCHAR(20),
    TipoMembresia NVARCHAR(20) -- Básico, VIP, Premium
);

-- Tabla: Instructores
CREATE TABLE Instructores (
    InstructorID INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(50),
    Especialidad NVARCHAR(50),
    Disponibilidad BIT -- 1 = disponible, 0 = no disponible
);

-- Tabla: Clases
CREATE TABLE Clases (
    ClaseID INT PRIMARY KEY IDENTITY,
    NombreClase NVARCHAR(50),
    TipoClase NVARCHAR(50),
    Horario DATETIME,
    CupoMaximo INT
);

-- Tabla: Reservas
CREATE TABLE Reservas (
    ReservaID INT PRIMARY KEY IDENTITY,
    ClienteID INT FOREIGN KEY REFERENCES Clientes(ClienteID),
    ClaseID INT FOREIGN KEY REFERENCES Clases(ClaseID),
    FechaReserva DATETIME,
    Estado NVARCHAR(20) -- Activa, Cancelada
);

-- Tabla: Asistencias
CREATE TABLE Asistencias (
    AsistenciaID INT PRIMARY KEY IDENTITY,
    ClienteID INT FOREIGN KEY REFERENCES Clientes(ClienteID),
    ClaseID INT FOREIGN KEY REFERENCES Clases(ClaseID),
    FechaAsistencia DATETIME
);
