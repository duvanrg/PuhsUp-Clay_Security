# Clay Security Backend - Desafío de Integración

La Empresa Clay Security tiene como objetivo desarrollar un backend que permita la integración de diversas aplicaciones creadas por una empresa consultora de software. Con el fin de facilitar el proceso de desarrollo, Clay Security proporciona el Diagrama Entidad-Relación (DER) de la base de datos elaborada por la empresa consultora.

## Requerimientos Funcionales

### 1) Implementación de Control de Acceso con JWT
Se requiere la implementación de un robusto sistema de Control de Acceso utilizando JSON Web Tokens (JWT) para garantizar la autenticación y autorización seguras en el backend.

### 2) Prevención de Peticiones Automatizadas
Se debe incorporar medidas de seguridad para prevenir peticiones automatizadas y garantizar la integridad de los datos y el rendimiento del sistema.

### 3) Implementación de Arquitectura DTO
Es necesario seguir una arquitectura Data Transfer Object (DTO) para asegurar la eficiencia en la transferencia de datos entre el frontend y el backend, evitando la sobreexposición de información innecesaria.

### 4) Implementación de Patrón Singleton con Unidades de Trabajo
Se debe aplicar el patrón Singleton para garantizar la existencia de una única instancia de las Unidades de Trabajo, facilitando la gestión de la conexión a la base de datos y mejorando el rendimiento.

### 5) Implementación de Paginación
Se requiere la implementación de un sistema de paginación eficiente para manejar grandes conjuntos de datos y mejorar la experiencia del usuario.

### 6) Generación de CRUD
Se debe desarrollar un conjunto completo de operaciones CRUD (Crear, Leer, Actualizar, Eliminar) para todas las entidades especificadas en el DER proporcionado.

## Instrucciones de Ejecución

1. Clona el repositorio en tu máquina local.
   ```bash
   git clone https://github.com/tuusuario/clay-security-backend.git
   ```
2. Restaurar las dependencias con
   ```bash
   Dotnet restore
   ```
1. Iniciar el proyecto en el equipo.
   ```bash
   Dotnet run -p API/
   ```
