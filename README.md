# Taskeroni 📝🍝

Welcome to **Taskeroni**, the task management system that’s as fun as a bowl of macaroni! Built with .NET 6 and React, Taskeroni makes it easy to add, edit, delete, and manage your tasks, all in one place. Because let’s face it, organizing tasks should be as satisfying as that last bite of pasta! 🍲

---

## Features

- **Create, Edit, and Delete Tasks**: Easily manage tasks with CRUD operations.
- **Task Status Tracking**: Mark tasks as pending, completed, or overdue.
- **Simple REST API**: Powered by ASP.NET and Docker, so you can run it anywhere.
- **Responsive Frontend**: Built with React for smooth user experience.

---

## Tech Stack

- **Backend**: .NET 6, ASP.NET, Entity Framework Core
- **Frontend**: React, TypeScript
- **Database**: PostgreSQL (or In-Memory for testing)
- **Containerization**: Docker

---

## Getting Started

### Prerequisites

Make sure you have the following installed:

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Node.js and npm](https://nodejs.org/) (for the frontend)
- [Docker](https://www.docker.com/) (optional, for running with PostgreSQL)

---

## API usage

Backend API Endpoints
GET /api/todotasks - Retrieve all tasks
POST /api/todotasks - Create a new task
GET /api/todotasks/{id} - Retrieve a task by ID
PUT /api/todotasks/{id} - Update a task by ID
DELETE /api/todotasks/{id} - Delete a task by ID
GET /api/todotasks/pending - Retrieve all pending tasks
GET /api/todotasks/completed - Retrieve all completed tasks
GET /api/todotasks/overdue - Retrieve all overdue tasks

Frontend
Access the frontend UI at http://localhost:3000.
View, create, edit, and delete tasks using a simple and intuitive interface.

---

### Setup Instructions

1. **Clone the repository**:
   ```bash
   git clone https://github.com/gdobrilov/Taskeroni.git
   cd Taskeroni

2. **Ensure Docker is running** on your machine.

3. **Start the containers** with the following command:
   ```bash
   docker-compose up --build

4. **This setup will:

  Launch the backend API on http://localhost:5001 (or the configured port in docker-compose.yml).
  Use PostgreSQL as the database for storing tasks.

5. **TTo stop the containers, run:
  ```bash
  docker-compose down
