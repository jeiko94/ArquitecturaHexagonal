Paso 8: Análisis de la Arquitectura Aplicada

8.1. Dominio

Entidades: Tarea

Repositorios (Interfaces): IRepositorioTareas

8.2. Aplicación

Servicios: ServicioTareas implementa IServicioTareas.

Interfaces (Puertos de Entrada): IServicioTareas.

8.3. Infraestructura

Adaptador de Persistencia: RepositorioTareasEnMemoria implementa IRepositorioTareas

8.4. Interfaz de Usuario

Consola: Interactúa con IServicioTareas

8.5. Flujo de Dependencias

La UI depende de Aplicación (IServicioTareas)

Aplicación depende de Dominio (Tarea, IRepositorioTareas)

Infraestructura implementa Dominio (IRepositorioTareas)

Las dependencias apuntan hacia el Dominio

Paso 9: Aplicación de los Principios SOLID

9.1. Responsabilidad Única (SRP)

Cada clase tiene una única responsabilidad:

ServicioTareas: Maneja casos de uso relacionados con tareas.

RepositorioTareasEnMemoria: Gestiona la persistencia en memoria.

9.2. Abierto/Cerrado (OCP)

Podemos extender la funcionalidad agregando nuevos tipos de repositorios (por ejemplo, repositorio en base de datos) sin modificar el código existente.

9.3. Inversión de Dependencias (DIP)

ServicioTareas depende de la abstracción IRepositorioTareas, no de una implementación concreta.

9.4. Segregación de Interfaces (ISP)

Las interfaces son específicas y enfocadas (IRepositorioTareas, IServicioTareas).

9.5. Sustitución de Liskov (LSP)

RepositorioTareasEnMemoria puede sustituir a IRepositorioTareas sin alterar el comportamiento esperado.

Paso 10: Posibles Extensiones

10.1. Agregar Validaciones

Validar que la descripción de la tarea no sea nula o vacía.

Manejar excepciones al convertir el ID de la tarea.

10.2. Implementar Repositorio en Base de Datos

Crear una nueva implementación de IRepositorioTareas que utilice Entity Framework Core o cualquier ORM para persistir datos en una base de datos.

10.3. Crear una API REST

En lugar de una interfaz de consola, implementar una API REST utilizando ASP.NET Core.

Conclusiones

Al completar este ejercicio, hemos:

Implementado la Arquitectura Hexagonal paso a paso, creando una aplicación funcional.

Separado claramente las responsabilidades entre las diferentes capas.

Aplicado principios SOLID, mejorando la calidad y mantenibilidad del código.

Almacenado datos en memoria, lo que facilita el enfoque en la arquitectura sin distraerse con detalles de infraestructura.
