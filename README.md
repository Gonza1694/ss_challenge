Speed Solutions Challenge

Este proyecto consiste en el desarrollo de una aplicación web para la gestión integral de una estación de servicio. Incluye módulos para productos, precios, control de dispensadores y mangueras, así como visualización detallada de configuraciones y transacciones.

## Tecnologías Utilizadas

- **Capa de Presentación:** React
- **Capa de Lógica de Negocios:** ASP.NET Core API 7
- **Capa de Acceso a Datos:** .Net Core 7 - ORM: Entity Framework Core
- **Base de Datos:** SQL

## Requisitos Previos
- Node.js: [Descargar e Instalar Node.js](https://nodejs.org/)
- .NET SDK: [Descargar e Instalar .NET SDK](https://dotnet.microsoft.com/download)
- SQL Server: [Descargar e Instalar SQL Server](https://www.microsoft.com/sql-server/)

### Clonar el Repositorio

```bash
git clone https://github.com/Gonza1694/ss_challenge.git
```

## Instalacion del Proyecto React
```bash
cd ss_challenge/speedsolutionschallenge.client
```
```bash
yarn install
```

## Instalacion del Proyecto .Net Core
```bash
cd ss_challenge
```
```bash
dotnet restore
```
```bash
dotnet build
```

## Configuración de la Cadena de Conexión
Abre el archivo appsettings.json en el proyecto ```SpeedSolutionsChallenge.Server``` y actualiza la cadena de conexión con los detalles de tu servidor SQL.
```bash
  "ConnectionStrings": {
    "DefaultConnection": "YOUR_CONNECTION_STRING"
  },
```

## Instalacion de la DB
```bash
cd /ss_challenge/SpeedSolutionsChallenge.Data
```
```bash
dotnet ef database update
```
### Alternativa 
Desde la consola Package Manager, seleccionar como proyecto predeterminado `SpeedSolutionsChallenge.Data` y ejecutar el siguiente comando
```bash
update-database
```
## Levantar el Proyecto React
```bash
cd /ss_challenge/speedsolutionschallenge.client
```
```bash
yarn dev
```
## Levantar el Proyecto .Net Core
```bash
cd /ss_challenge/SpeedSolutionsChallenge.Server
```
```bash
dotnet run
```

Si tienes problemas al levantar la API desde la consola lo puedes hacer directamente desde Visual Studio seleccionando ```SpeedSolutionsChallenge.Server``` como startup project.
