# Incident Tracker Mini App

A full-stack web application to create, view, search, and manage production incidents.

---

## Tech Stack

### Backend
- ASP.NET Core Web API
- Entity Framework Core
- SQLite

### Frontend
- React (Vite)
- Axios
- React Router

---

## Features

- Create incidents
- View incidents in paginated table
- Server-side pagination, filtering, and sorting
- Search incidents
- Filter by status, service, and severity
- View incident details
- Update incident status, owner, and summary
- Seed database with sample data

---

## API Overview

### Base URL
http://localhost:5035/api

---

### Endpoints

| Method | Endpoint | Description |
|--------|---------|------------|
| POST   | /api/incidents | Create incident |
| GET    | /api/incidents | Get incidents with pagination, filtering |
| GET    | /api/incidents/{id} | Get incident by ID |
| PATCH  | /api/incidents/{id} | Update incident |

---

## Setup Instructions

### Prerequisites

- .NET SDK (8 or above)
- Node.js (LTS)
- Git

---

### Backend Setup

```bash
cd backend/IncidentTracker.Api
dotnet restore
dotnet ef database update
dotnet run
```

Backend runs at:
http://localhost:5035

Swagger UI:
http://localhost:5035/swagger

---

### Frontend Setup

```bash
cd frontend
npm install
npm run dev
```

Frontend runs at:
http://localhost:5173

---

## Design Decisions & Tradeoffs
### 1. Layered Architecture

Used Controller → Service → Repository pattern to separate concerns.

### 2. DTO Usage

Used DTOs instead of exposing database entities.

### 3. Server-side Pagination

Pagination and filtering handled on backend.

### 4. SQLite Database

Used SQLite for simplicity.

---

## Improvements

Authentication & Authorization (JWT)

Better UI using Material UI or Tailwind

Unit and integration tests

Docker support

Logging and monitoring

---

## Project Structure

backend/ → ASP.NET Core API

frontend/ → React application

---

## Author

Amitram Achunala
