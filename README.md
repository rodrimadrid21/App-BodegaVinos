# Bodega Vinos API

API para gestionar vinos en un inventario (ASP.NET Core).

# Endpoints de la API

Registro de un nuevo vino:
- URL: `/api/Wine`
- Método HTTP: `POST`
- Descripción: Registra un nuevo vino en el inventario.
- Respuesta: (200 OK)

Consultar vino por nombre:
- URL: `/api/Wine/{name}`
- Método HTTP: `GET`
- Descripción: Devuelve información sobre un vino por su nombre.
- Respuesta: (200 OK)

Actualizar el stock de un vino:
- URL: `/api/Wine/{id}`
- Método HTTP: `PUT`
- Descripción: Actualiza el stock de un vino.
- Respuesta: (200 OK)

Registrar un nuevo usuario:
- URL: `/api/User`
- Método HTTP: `POST`
- Descripción: Registra un nuevo usuario.
- Respuesta: (200 OK)

