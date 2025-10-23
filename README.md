## 🧠 Sistema de Gestión – **Piccolo Burgers**

Aplicación de escritorio desarrollada en **C# (.NET Framework 4.7.2)** para la administración integral de un restaurante.
Diseñada con arquitectura por capas y enfoque modular, permite gestionar **usuarios, productos, materia prima, clientes, proveedores, compras y ventas**, además de generar **reportes dinámicos en PDF y Excel**.

Este sistema busca optimizar los procesos operativos de pequeñas y medianas empresas gastronómicas, brindando una interfaz intuitiva y herramientas administrativas completas.

---

### 🧩 **Tecnologías principales**

* **Lenguaje:** C# (.NET Framework 4.7.2)
* **Entorno:** Visual Studio 2019 o superior
* **Base de datos:** SQL Server LocalDB
* **Interfaz:** Windows Forms (WinForms)

**Paquetes y librerías destacadas:**

* `ClosedXML` / `ClosedXML.Report` → Exportación de reportes Excel
* `iTextSharp` / `iTextSharp.xmlworker` → Generación de reportes PDF
* `DocumentFormat.OpenXml` → Manipulación avanzada de documentos
* `FontAwesome.Sharp` → Iconografía moderna para WinForms
* `BouncyCastle.Cryptography` → Seguridad y cifrado de datos

---

### ⚙️ **Requisitos mínimos**

| Componente            | Versión / Detalle                          |
| --------------------- | ------------------------------------------ |
| Sistema operativo     | Windows 10 o superior                      |
| Framework             | .NET Framework 4.7.2                       |
| Entorno de desarrollo | Visual Studio 2019+ (con soporte WinForms) |
| Base de datos         | SQL Server LocalDB o instancia compatible  |

---

### 📁 **Estructura del proyecto**

| Carpeta                     | Descripción                                         |
| --------------------------- | --------------------------------------------------- |
| `capaEntidad/`              | Modelos de dominio (Producto, Cliente, Venta, etc.) |
| `capaDatos/`                | Acceso a datos y consultas SQL                      |
| `capaNegocio/`              | Lógica de negocio y validaciones                    |
| `piccoloSistemaGestion/`    | Interfaz gráfica principal (WinForms)               |
| `PICCOLO_DB.bak`            | Respaldo de la base de datos                        |
| `piccoloSistemaGestion.sln` | Solución principal del proyecto                     |

<img width="434" height="153" alt="image" src="https://github.com/user-attachments/assets/bf41bd65-4ecd-4bc9-a472-e9201444608f" />


---

### 🚀 **Configuración y ejecución**

1. Clonar o descargar el repositorio.
2. Restaurar la base de datos `PICCOLO_DB.bak` en SQL Server.
3. Ajustar la cadena de conexión en `App.config` si es necesario (`(localdb)\piccoloDB`).
4. Abrir la solución `piccoloSistemaGestion.sln` en Visual Studio.
5. Restaurar los paquetes NuGet (`Restore NuGet Packages`).
6. Establecer `piccoloSistemaGestion` como proyecto de inicio.
7. Ejecutar la aplicación (F5).

**Credenciales de prueba:**
Usuario → `1`
Contraseña → `123`

---

### 📊 **Principales funcionalidades**

* Gestión de **usuarios**, **roles** y **permisos**.
* Administración completa de **categorías**, **productos** y **materia prima**.
* Módulos de **clientes** y **proveedores**.
* Registro de **compras**, **ventas** y **movimientos de stock**.
* **Reportes automáticos** en PDF y Excel.
* Personalización de datos comerciales del negocio.
* Interfaz clara, adaptable y de fácil mantenimiento.

---

### 💼 **Objetivo del proyecto**

Este desarrollo fue concebido como una **solución completa para la gestión interna de restaurantes**, demostrando dominio de:

* Arquitectura en capas
* Patrón de separación de responsabilidades
* Conexión a bases de datos relacionales (SQL Server)
* Generación de reportes empresariales
* Uso de librerías externas y buenas prácticas de desarrollo

Ideal para mostrar competencias en **desarrollo de software de escritorio, análisis funcional y manejo de datos empresariales**.

---

## 📸 Screenshots

1. **Pantalla de Login:**
<img width="498" height="205" alt="image" src="https://github.com/user-attachments/assets/bbce1963-3594-49ca-9546-284eefd8478f" />

2. **Gestión de productos / ventas:**
<img width="993" height="675" alt="image" src="https://github.com/user-attachments/assets/dcb0d244-0a6d-48c5-9cab-5801c2810f18" />
<img width="994" height="678" alt="image" src="https://github.com/user-attachments/assets/077fd5ac-143f-4317-b7fe-2f9d20e115a1" />

5. **Generación de Excel:**
<img width="1822" height="722" alt="image" src="https://github.com/user-attachments/assets/d3dec618-2d13-4084-b4cb-740cfca6f48e" />


¿Querés que te genere la **versión Markdown final lista para pegar en GitHub** con formato, emojis y encabezados (README.md)?
Puedo hacerlo directamente adaptado al estilo de portfolio o CV.
