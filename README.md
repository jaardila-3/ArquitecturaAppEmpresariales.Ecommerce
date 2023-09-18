# ArquitecturaAppEmpresariales.Ecommerce
curso de arquitectura de aplicaciones empresariales con net 6


# NOTAS:

Arquitectura de aplicaciones empresariales Udemy

## Crear directorios y proyectos:
1. DOMAIN.ENTITY: Categories
2. INFRASTRUCTURE.INTERFACE: ICategoriesRepository
3. INFRASTRUCTURE.REPOSITORY: CategoriesRepository
4. DOMAIN.INTERFACE: ICategoriesDomain
5. DOMAIN.CORE: CategoriesDomain
6. APPLICATION.DTO: CategoriesDto
7. APPLICATION.INTERFACE: ICategoriesApplication
8. APPLICATION.MAIN: CategoriesApplication
9. SERVICES.WEBAPI: CategoriesController

## Patrones usados
- UnitOfWork
- MappingsProfile
- InjectionExtensions

## comparación arquitectura ONION con N-CAPAS
- DOMAIN: DOMAIN
- INFRAESTRUCTURE: DATA
- APPLICATION: BUSINESS
- SERVICES: UI
- TRANSVERSAL: COMMON
