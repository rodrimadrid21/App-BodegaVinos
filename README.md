# Bodega Vinos API

API para gestionar vinos en un inventario (ASP.NET Core).

# Endpoints de la API 

## CATA
Crear una nueva cata:
- URL: `/api/Cata/create`
- Método HTTP: `POST`
- Descripción: Crea una nueva cata.
- Respuesta: (200 OK)

Lista de las catas:
- URL: `/api/Cata/all`
- Método HTTP: `POST`
- Descripción: Devuelve una lista de todas las catas.
- Respuesta: (200 OK)

## USER
Registrar un nuevo usuario:
- URL: `/api/User/register`
- Método HTTP: `POST`
- Descripción: Registra un nuevo usuario.
- Respuesta: (200 OK)

Login de usuario:
- URL: `/api/User/login`
- Método HTTP: `POST`
- Descripción: Loguea un usuario.
- Respuesta: (200 OK)
  
## WINE
Registro de un nuevo vino:
- URL: `/api/Wine/register`
- Método HTTP: `POST`
- Descripción: Registra un nuevo vino en el inventario.
- Respuesta: (200 OK)

Lista de todos los vinos:
- URL: `/api/Wine/all`
- Método HTTP: `GET`
- Descripción: Devuelve una lista de todos los vinos.
- Respues: (200 OK)

Consultar vino por variedad:
- URL: `/api/Wine/{variety}`
- Método HTTP: `GET`
- Descripción: Devuelve información sobre un vino por su variedad.
- Respuesta: (200 OK)

Consultar vino por id:
- URL: `/api/Wine/{id}`
- Método HTTP: `GET`
- Descripción: Devuelve información sobre un vino por su id.
- Respuesta: (200 OK)

Actualizar el stock de un vino:
- URL: `/api/Wine/{id}/stock`
- Método HTTP: `PUT`
- Descripción: Actualiza el stock de un vino.
- Respuesta: (200 OK)
