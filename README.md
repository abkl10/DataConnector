# 🔌 ClicDataConnector

Un connecteur REST modulaire développé en **.NET 8 + EF Core + MySQL**

> 💡 Ce projet illustre la construction d’un **connecteur back-end multcouches**, en architecture propre (**Clean Architecture**) prêt pour intégration dans une plateforme **SaaS de Business Intelligence**.

---


## Objectif du projet

Ce connecteur simule :
- L’appel à une **API distante externe** (`jsonplaceholder.typicode.com`)  
- La **transformation des données** (via DTOs → Entity)
- La **sauvegarde en base de données** MySQL avec EF Core
- L’exposition **d’API REST** pour intégrer les utilisateurs depuis une plateforme externe


---


## Architecture technique

### Structure

    ```bash
    ClicDataConnector/
    ├── ClicDataConnector.API/          # API REST .NET 8
    ├── ClicDataConnector.Core/         # Entités, DTOs, Interfaces métier
    ├── ClicDataConnector.Infrastructure/ # Repositories, EF Core, DbContext, Migrations
    └── README.md
    ```

## Layers

| Couche         | Rôle                                                                 |
|----------------|----------------------------------------------------------------------|
| **API**        | Expose les endpoints REST (`/api/connectors/users`)                 |
| **Core**       | Contient la logique métier : entités, interfaces, abstractions      |
| **Infrastructure** | Implémente les repositories + EF Core + Migrations               |
| **DTOs**       | Modules de transformation issus d’APIs externes                      |

---

## Stack technique

| Technologie             | Rôle                                    |
|-------------------------|------------------------------------------|
| **ASP.NET 8 Web API**   | API REST                                 |
| **EF Core + Pomelo**    | ORM avec MySQL                           |
| **HttpClient**          | Appels à l'API externe                   |
| **Swagger**             | Documentation API                        |
| **MySQL**               | Base de données                          |
| **GitHub**              | Versioning & présentation du projet      |

---

## Fonctionnalités

- ✅ Connexion à une API externe (jsonplaceholder)
- ✅ Récupération de `Users`
- ✅ Transformation des données via `DTO` ⇒ `Entity`
- ✅ Enregistrement en base **MySQL**
- ✅ Endpoint `GET` pour afficher les données stockées
- ✅ Documentation Swagger

---

## Endpoints REST API

| Méthode | Endpoint                         | Description                                                        |
|---------|----------------------------------|--------------------------------------------------------------------|
| `POST`  | `/api/connectors/users/pull`     | Récupère les utilisateurs depuis l’API externe et sauvegarde en base |
| `GET`   | `/api/connectors/users`          | Récupère les utilisateurs stockés en base (MySQL)                  |

---

## Exemple d’appel `POST /pull`

```http
POST http://localhost:5000/api/connectors/users/pull
````

Reçoit 10 users depuis :

https://jsonplaceholder.typicode.com/users
Insère dans ta base MySQL via EF Core