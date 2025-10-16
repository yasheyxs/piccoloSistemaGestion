Sistema de Gestión – Piccolo Burgers

Aplicación de escritorio (WinForms) para administrar las operaciones de un restaurante. Incluye control de usuarios, productos, materia prima, clientes, proveedores, compras y ventas, además de reportes en PDF y Excel.

📦 Tecnologías y dependencias
Lenguaje: C# (.NET Framework 4.7.2)
Entorno de desarrollo: Visual Studio 2019 o superior
Base de datos: SQL Server LocalDB

Paquetes NuGet principales:
ClosedXML / ClosedXML.Report
DocumentFormat.OpenXml
iTextSharp / itextsharp.xmlworker
FontAwesome.Sharp
BouncyCastle.Cryptography

🖥️ Requisitos de sistema
Componente	Versión/Detalle
Sistema operativo	Windows
.NET Framework	4.7.2
Visual Studio	2019 o superior (con soporte WinForms y restauración de NuGet)
SQL Server	LocalDB o instancia compatible

📁 Estructura del proyecto
capaEntidad/      → Clases de dominio (Producto, Cliente, Venta, etc.)
capaDatos/        → Acceso a datos y consultas SQL
capaNegocio/      → Lógica de negocio y validaciones
piccoloSistemaGestion/ → Interfaz gráfica (WinForms)
PICCOLO_DB.bak    → Respaldo de la base de datos
piccoloSistemaGestion.sln → Solución principal

⚙️ Configuración inicial
Clonar o descargar este repositorio.
Restaurar la base de datos.
Verificar que la instancia sea (localdb)\piccoloDB o ajustar el nombre en App.config.
Abrir la solución piccoloSistemaGestion.sln con Visual Studio.
Restaurar paquetes NuGet desde el IDE (menú Restore NuGet Packages).
Compilar la solución para generar los binarios.

🚀 Ejecución
Establecer piccoloSistemaGestion como proyecto de inicio.
Ejecutar la aplicación (F5 o botón Start).
Al iniciarse, se mostrará el formulario de login:
Usuario: 1
Contraseña: 123

📚 Funcionalidades principales
Gestión de usuarios, roles y permisos.
Administración de categorías, productos y materia prima.
Módulos de clientes y proveedores.
Registro de compras y ventas.
Reportes de ventas y compras en PDF y Excel.
Personalización básica de datos del negocio.

🔄 Mejoras y contribuciones
El proyecto está funcional pero abierto a mejoras. Se recomienda:
Añadir validaciones y manejo de excepciones más robustos.
Permitir configuración externa de la cadena de conexión.
Integrar pruebas unitarias y automatizadas.
Documentar nuevos módulos o personalizaciones.
Las contribuciones se pueden enviar mediante fork y pull request respetando la estructura por capas.
