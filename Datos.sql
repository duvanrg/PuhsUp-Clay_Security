DROP TABLE IF EXISTS `categoriaper`;
DROP TABLE IF EXISTS `ciudad`;
DROP TABLE IF EXISTS `contactoper`;
DROP TABLE IF EXISTS `contrato`;
DROP TABLE IF EXISTS `departamento`;
DROP TABLE IF EXISTS `dirpersona`;
DROP TABLE IF EXISTS `estado`;
DROP TABLE IF EXISTS `pais`;
DROP TABLE IF EXISTS `persona`;
DROP TABLE IF EXISTS `programacion`;
DROP TABLE IF EXISTS `tipocontacto`;
DROP TABLE IF EXISTS `tipodireccion`;
DROP TABLE IF EXISTS `tipopersona`;
DROP TABLE IF EXISTS `turnos`;
-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 11-12-2023 a las 13:54:28
-- Versión del servidor: 10.4.27-MariaDB
-- Versión de PHP: 8.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `clay_security`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `categoriaper`
--

CREATE TABLE `categoriaper` (
  `Id` int(11) NOT NULL,
  `NombreCat` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ciudad`
--

CREATE TABLE `ciudad` (
  `Id` int(11) NOT NULL,
  `NombreCiu` varchar(50) NOT NULL,
  `DepId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `contactoper`
--

CREATE TABLE `contactoper` (
  `Id` int(11) NOT NULL,
  `Descripcion` varchar(150) NOT NULL,
  `PersonaId` int(11) NOT NULL,
  `TContactoId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `contrato`
--

CREATE TABLE `contrato` (
  `Id` int(11) NOT NULL,
  `ClienteId` int(11) NOT NULL,
  `FechaContrato` date NOT NULL,
  `EmpleadoId` int(11) NOT NULL,
  `FechaFin` date NOT NULL,
  `EstatoId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `departamento`
--

CREATE TABLE `departamento` (
  `Id` int(11) NOT NULL,
  `NombreDep` varchar(50) NOT NULL,
  `PaisId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `dirpersona`
--

CREATE TABLE `dirpersona` (
  `Id` int(11) NOT NULL,
  `Direccion` varchar(80) NOT NULL,
  `PersonaId` int(11) NOT NULL,
  `TDireccionId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `estado`
--

CREATE TABLE `estado` (
  `Id` int(11) NOT NULL,
  `Descripcion` varchar(150) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pais`
--

CREATE TABLE `pais` (
  `Id` int(11) NOT NULL,
  `NombrePais` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `persona`
--

CREATE TABLE `persona` (
  `Id` int(11) NOT NULL,
  `IdPersona` int(11) NOT NULL,
  `Nombre` varchar(50) NOT NULL,
  `DateReg` date NOT NULL,
  `TPersonaId` int(11) NOT NULL,
  `CatId` int(11) NOT NULL,
  `CiudadId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `programacion`
--

CREATE TABLE `programacion` (
  `Id` int(11) NOT NULL,
  `ContratoId` int(11) NOT NULL,
  `TurnoId` int(11) NOT NULL,
  `EmpleadoId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tipocontacto`
--

CREATE TABLE `tipocontacto` (
  `Id` int(11) NOT NULL,
  `Descripcion` varchar(150) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tipodireccion`
--

CREATE TABLE `tipodireccion` (
  `Id` int(11) NOT NULL,
  `Descripcion` varchar(150) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tipopersona`
--

CREATE TABLE `tipopersona` (
  `Id` int(11) NOT NULL,
  `Descripcion` varchar(150) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `turnos`
--

CREATE TABLE `turnos` (
  `Id` int(11) NOT NULL,
  `NombreTurno` varchar(50) NOT NULL,
  `HoraTurnoI` date NOT NULL,
  `HoraTurnoF` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

-- Índices para tablas volcadas
--

--
-- Indices de la tabla `categoriaper`
--
ALTER TABLE `categoriaper`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `ciudad`
--
ALTER TABLE `ciudad`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `DepId` (`DepId`);

--
-- Indices de la tabla `contactoper`
--
ALTER TABLE `contactoper`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `Descripcion` (`Descripcion`),
  ADD KEY `PersonaId` (`PersonaId`),
  ADD KEY `TContactoId` (`TContactoId`);

--
-- Indices de la tabla `contrato`
--
ALTER TABLE `contrato`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `ClienteId` (`ClienteId`),
  ADD KEY `EmpleadoId` (`EmpleadoId`),
  ADD KEY `EstatoId` (`EstatoId`);

--
-- Indices de la tabla `departamento`
--
ALTER TABLE `departamento`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `PaisId` (`PaisId`);

--
-- Indices de la tabla `dirpersona`
--
ALTER TABLE `dirpersona`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `TDireccionId` (`TDireccionId`),
  ADD KEY `PersonaId` (`PersonaId`);

--
-- Indices de la tabla `estado`
--
ALTER TABLE `estado`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `pais`
--
ALTER TABLE `pais`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `persona`
--
ALTER TABLE `persona`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `IdPersona` (`IdPersona`),
  ADD KEY `TPersonaId` (`TPersonaId`,`CatId`,`CiudadId`),
  ADD KEY `CiudadId` (`CiudadId`),
  ADD KEY `CatId` (`CatId`);

--
-- Indices de la tabla `programacion`
--
ALTER TABLE `programacion`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `ContratoId` (`ContratoId`),
  ADD KEY `TurnoId` (`TurnoId`),
  ADD KEY `EmpleadoId` (`EmpleadoId`);

--
-- Indices de la tabla `tipocontacto`
--
ALTER TABLE `tipocontacto`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `tipodireccion`
--
ALTER TABLE `tipodireccion`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `tipopersona`
--
ALTER TABLE `tipopersona`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `turnos`
--
ALTER TABLE `turnos`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `categoriaper`
--
ALTER TABLE `categoriaper`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `ciudad`
--
ALTER TABLE `ciudad`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `contactoper`
--
ALTER TABLE `contactoper`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `contrato`
--
ALTER TABLE `contrato`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `departamento`
--
ALTER TABLE `departamento`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `dirpersona`
--
ALTER TABLE `dirpersona`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `estado`
--
ALTER TABLE `estado`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `pais`
--
ALTER TABLE `pais`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `persona`
--
ALTER TABLE `persona`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `programacion`
--
ALTER TABLE `programacion`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `tipocontacto`
--
ALTER TABLE `tipocontacto`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `tipodireccion`
--
ALTER TABLE `tipodireccion`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `tipopersona`
--
ALTER TABLE `tipopersona`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `turnos`
--
ALTER TABLE `turnos`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `ciudad`
--
ALTER TABLE `ciudad`
  ADD CONSTRAINT `ciudad_ibfk_1` FOREIGN KEY (`DepId`) REFERENCES `departamento` (`Id`);

--
-- Filtros para la tabla `contactoper`
--
ALTER TABLE `contactoper`
  ADD CONSTRAINT `contactoper_ibfk_1` FOREIGN KEY (`PersonaId`) REFERENCES `persona` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `contactoper_ibfk_2` FOREIGN KEY (`TContactoId`) REFERENCES `tipocontacto` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `contrato`
--
ALTER TABLE `contrato`
  ADD CONSTRAINT `contrato_ibfk_1` FOREIGN KEY (`ClienteId`) REFERENCES `persona` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `contrato_ibfk_2` FOREIGN KEY (`EmpleadoId`) REFERENCES `persona` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `contrato_ibfk_3` FOREIGN KEY (`EstatoId`) REFERENCES `estado` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `departamento`
--
ALTER TABLE `departamento`
  ADD CONSTRAINT `departamento_ibfk_2` FOREIGN KEY (`PaisId`) REFERENCES `pais` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `dirpersona`
--
ALTER TABLE `dirpersona`
  ADD CONSTRAINT `dirpersona_ibfk_1` FOREIGN KEY (`PersonaId`) REFERENCES `persona` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `dirpersona_ibfk_2` FOREIGN KEY (`TDireccionId`) REFERENCES `tipodireccion` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `persona`
--
ALTER TABLE `persona`
  ADD CONSTRAINT `persona_ibfk_2` FOREIGN KEY (`CiudadId`) REFERENCES `ciudad` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `persona_ibfk_3` FOREIGN KEY (`TPersonaId`) REFERENCES `tipopersona` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `persona_ibfk_4` FOREIGN KEY (`CatId`) REFERENCES `categoriaper` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `programacion`
--
ALTER TABLE `programacion`
  ADD CONSTRAINT `programacion_ibfk_1` FOREIGN KEY (`EmpleadoId`) REFERENCES `persona` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `programacion_ibfk_2` FOREIGN KEY (`ContratoId`) REFERENCES `contrato` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `programacion_ibfk_3` FOREIGN KEY (`TurnoId`) REFERENCES `turnos` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;


-- 1. **Tabla: `categoriaper`**
   
   INSERT INTO `categoriaper` (`Id`, `NombreCat`) VALUES
   (1, 'Hogar'),
   (2, 'Tecnología'),
   (3, 'Belleza'),
   (4, 'Moda'),
   (5, 'Deportes'),
   (6, 'Alimentos'),
   (7, 'Salud'),
   (8, 'Entretenimiento'),
   (9, 'Automotriz'),
   (10, 'Viajes');
   

-- 2. **Tabla: `ciudad`**
   
   INSERT INTO `ciudad` (`Id`, `NombreCiu`, `DepId`) VALUES
   (1, 'Bucaramanga', 1),
   (2, 'Floridablanca', 1),
   (3, 'Girón', 1),
   (4, 'Piedecuesta', 1),
   (5, 'Barrancabermeja', 2),
   (6, 'San Gil', 3),
   (7, 'Socorro', 3),
   (8, 'Aratoca', 3),
   (9, 'Barichara', 3),
   (10, 'Lebrija', 1);
   

-- 3. **Tabla: `contactoper`**
   
   INSERT INTO `contactoper` (`Id`, `Descripcion`, `PersonaId`, `TContactoId`) VALUES
   (1, 'Teléfono Principal', 1, 1),
   (2, 'Correo Electrónico', 2, 2),
   (3, 'Celular', 3, 1),
   (4, 'WhatsApp', 4, 1),
   (5, 'Redes Sociales', 5, 3),
   (6, 'Teléfono Trabajo', 6, 1),
   (7, 'Fax', 7, 4),
   (8, 'Skype', 8, 3),
   (9, 'Teléfono Emergencia', 9, 1),
   (10, 'Otro', 10, 5);
   

-- 4. **Tabla: `contrato`**
   
   INSERT INTO `contrato` (`Id`, `ClienteId`, `FechaContrato`, `EmpleadoId`, `FechaFin`, `EstatoId`) VALUES
   (1, 1, '2023-01-15', 2, '2023-12-31', 1),
   (2, 3, '2023-02-10', 1, '2023-11-30', 2),
   (3, 2, '2023-03-22', 3, '2023-10-15', 1),
   (4, 4, '2023-04-05', 5, '2023-09-20', 2),
   (5, 6, '2023-05-18', 4, '2023-08-31', 1),
   (6, 5, '2023-06-30', 6, '2023-07-15', 2),
   (7, 8, '2023-07-12', 7, '2023-06-30', 1),
   (8, 7, '2023-08-25', 9, '2023-05-10', 2),
   (9, 10, '2023-09-08', 8, '2023-04-25', 1),
   (10, 9, '2023-10-20', 10, '2023-03-15', 2);
   

-- 5. **Tabla: `departamento`**
   
   INSERT INTO `departamento` (`Id`, `NombreDep`, `PaisId`) VALUES
   (1, 'Santander', 1),
   (2, 'Norte de Santander', 1),
   (3, 'Boyacá', 1),
   (4, 'Cundinamarca', 1),
   (5, 'Antioquia', 1),
   (6, 'Atlántico', 1),
   (7, 'Bolívar', 1),
   (8, 'Caldas', 1),
   (9, 'Caquetá', 1),
   (10, 'Casanare', 1);
   

-- 6. **Tabla: `dirpersona`**
   
   INSERT INTO `dirpersona` (`Id`, `Direccion`, `PersonaId`, `TDireccionId`) VALUES
   (1, 'Carrera 23 #45-67', 1, 1),
   (2, 'Calle 56 #12-34', 2, 2),
   (3, 'Avenida 78 #90-12', 3, 1),
   (4, 'Diagonal 45 #67-89', 4, 3),
   (5, 'Transversal 34 #56-78', 5, 2),
   (6, 'Carrera 12 #34-56', 6, 1),
   (7, 'Calle 90 #23-45', 7, 4),
   (8, 'Avenida 67 #45-23', 8, 3),
   (9, 'Diagonal 34 #56-78', 9, 1),
   (10, 'Transversal 56 #78-90', 10, 2);
   

-- 7. **Tabla: `estado`**
   
   INSERT INTO `estado` (`Id`, `Descripcion`) VALUES
   (1, 'Activo'),
   (2, 'Inactivo'),
   (3, 'Pendiente'),
   (4, 'En Proceso'),
   (5, 'Finalizado'),
   (6, 'Cancelado'),
   (7, 'Suspendido'),
   (8, 'En Revisión'),
   (9, 'Aprobado'),
   (10, 'Rechazado');
   

-- 8. **Tabla: `pais`**
   
   INSERT INTO `pais` (`Id`, `NombrePais`) VALUES
   (1, 'Colombia');
   

-- 9. **Tabla: `persona`**
   
   INSERT INTO `persona` (`Id`, `IdPersona`, `Nombre`, `DateReg`, `TPersonaId`, `CatId`, `CiudadId`) VALUES
   (1, 101, 'Juan Pérez', '2023-01-02', 1, 1, 1),
   (2, 102, 'María Gómez', '2023-02-15', 2, 2, 2),
   (3, 103, 'Carlos

 Rodríguez', '2023-03-20', 1, 3, 3),
   (4, 104, 'Ana Martínez', '2023-04-10', 2, 4, 4),
   (5, 105, 'Luisa Sánchez', '2023-05-25', 1, 5, 5),
   (6, 106, 'David López', '2023-06-15', 2, 6, 6),
   (7, 107, 'Laura Ramírez', '2023-07-30', 1, 7, 7),
   (8, 108, 'Javier García', '2023-08-12', 2, 8, 8),
   (9, 109, 'Marta Castro', '2023-09-22', 1, 9, 9),
   (10, 110, 'Oscar Vargas', '2023-10-05', 2, 10, 10);
   

-- 10. **Tabla: `programacion`**
    
    INSERT INTO `programacion` (`Id`, `ContratoId`, `TurnoId`, `EmpleadoId`) VALUES
    (1, 1, 2, 3),
    (2, 3, 1, 5),
    (3, 2, 3, 1),
    (4, 5, 2, 6),
    (5, 4, 1, 4),
    (6, 6, 3, 10),
    (7, 8, 2, 7),
    (8, 7, 1, 9),
    (9, 10, 3, 8),
    (10, 9, 2, 2);
    

-- 11. **Tabla: `tipocontacto`**
    
    INSERT INTO `tipocontacto` (`Id`, `Descripcion`) VALUES
    (1, 'Teléfono'),
    (2, 'Correo Electrónico'),
    (3, 'Redes Sociales'),
    (4, 'Fax'),
    (5, 'Otro');
    

-- 12. **Tabla: `tipodireccion`**
    
    INSERT INTO `tipodireccion` (`Id`, `Descripcion`) VALUES
    (1, 'Residencial'),
    (2, 'Comercial'),
    (3, 'Vacacional'),
    (4, 'Oficina');
    

-- 13. **Tabla: `tipopersona`**
    
    INSERT INTO `tipopersona` (`Id`, `Descripcion`) VALUES
    (1, 'Natural'),
    (2, 'Jurídica');
    

-- 14. **Tabla: `turnos`**
    
    INSERT INTO `turnos` (`Id`, `NombreTurno`, `HoraTurnoI`, `HoraTurnoF`) VALUES
    (1, 'Mañana', '07:00:00', '15:00:00'),
    (2, 'Tarde', '15:00:00', '23:00:00'),
    (3, 'Noche', '23:00:00', '07:00:00');
    