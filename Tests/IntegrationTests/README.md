# Integration Tests

Este proyecto contiene los tests de integración para la API de ProyectoClima.

## Estructura

- **CustomWebApplicationFactory.cs**: Factory personalizado que configura la aplicación para tests de integración, utilizando mocks para los repositorios externos.
- **WeatherForecastControllerTests.cs**: Tests de integración para el controlador de pronóstico del clima.
- **PokedexControllerTests.cs**: Tests de integración para el controlador de Pokédex.

## Cobertura de Tests

### WeatherForecastController

- ✅ Obtención exitosa del clima de una ciudad
- ✅ Manejo de nombres de ciudad vacíos o con solo espacios en blanco
- ✅ Manejo de ciudades no encontradas (404)
- ✅ Manejo de errores del servicio externo (503)
- ✅ Manejo de errores con códigos de estado personalizados
- ✅ Manejo de excepciones inesperadas (500)
- ✅ Tests parametrizados para múltiples ciudades

### PokedexController

- ✅ Obtención exitosa de información de Pokémon por nombre
- ✅ Obtención exitosa de información de Pokémon por ID
- ✅ Tests parametrizados para múltiples Pokémon
- ✅ Manejo de Pokémon no existentes
- ✅ Manejo de errores de solicitud HTTP
- ✅ Tests con diferentes IDs de Pokémon
- ✅ Manejo de nombres vacíos

## Cómo ejecutar los tests

```bash
dotnet test Tests/IntegrationTests/IntegrationTests.csproj
```

O desde la raíz del proyecto:

```bash
dotnet test
```

Para ejecutar solo los tests de integración:

```bash
dotnet test --filter "FullyQualifiedName~IntegrationTests"
```

## Tecnologías Utilizadas

- **xUnit**: Framework de testing
- **Microsoft.AspNetCore.Mvc.Testing**: Para crear una aplicación web en memoria
- **Moq**: Para crear mocks de los repositorios
- **WebApplicationFactory<Program>**: Para levantar la API en memoria durante los tests

## Notas

Los tests utilizan mocks para los repositorios de clima y Pokédex, por lo que no dependen de servicios externos (OpenWeatherMap API y PokéAPI). Esto hace que los tests sean:

- ⚡ Más rápidos
- 🔒 Más confiables (no dependen de servicios externos)
- 🎯 Más predecibles (datos controlados)
- 💰 Sin costos de API
