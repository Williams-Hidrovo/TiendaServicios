Proyecto de Microservicios en .NET CORE 3.1

✨ Este proyecto implementa una arquitectura de microservicios utilizando .NET CORE 3.1 con diferentes bases de datos y comunicación asíncrona. Incluye integración con RabbitMQ, pruebas unitarias con mocks, un API Gateway y despliegue mediante Docker.

🌐 Estructura del Proyecto

El proyecto está compuesto por los siguientes microservicios:

🔐 Servicio de Autores

Base de datos: PostgreSQL

Funcionalidad: Gestión de usuarios y autenticación.

📖 Servicio de Libros

Base de datos: SQL Server

Funcionalidad: Gestión de libros (CRUD).

📦 Servicio de Carrito de Compras

Base de datos: MySQL

Funcionalidad: Gestión del carrito de compras y su contenido.

Adicionalmente:

🛠️ API Gateway para la centralización y enrutamiento de solicitudes.

Comunicación asíncrona mediante RabbitMQ.

⚡ Características Principales

1. 🏛️ Bases de Datos

PostgreSQL para Autores.

SQL Server para Libros.

MySQL para Carrito de Compras.

2. 📢 Comunicación Asíncrona

Los microservicios se comunican de forma asíncrona mediante RabbitMQ, asegurando un sistema desacoplado y escalable.

3. 🔧 Pruebas Unitarias

Implementadas con xUnit.

Uso de Mocks para simular dependencias y aislar la lógica de negocio.

4. 🛊️ Despliegue con Docker

Cada microservicio está configurado con su propio Dockerfile, y se utiliza docker-compose para la orquestación de contenedores.

5. 🛣️ API Gateway

Se implementa un API Gateway para gestionar el enrutamiento y la seguridad de las solicitudes hacia los microservicios.
