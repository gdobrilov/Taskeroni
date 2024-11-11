# Taskeroni 📝🍝

Welcome to **Taskeroni**, the task management system that’s as fun as a bowl of macaroni! Built with .NET 6 and React, Taskeroni makes it easy to add, edit, delete, and manage your tasks, all in one place. Because let’s face it, organizing tasks should be as satisfying as that last bite of pasta! 🍲

---

## Features

- **Create, Edit, and Delete Tasks**: Easily manage tasks with CRUD operations.
- **Task Status Tracking**: Mark tasks as pending, completed, or overdue.
- **Simple REST API**: Powered by ASP.NET and Docker, so you can run it anywhere.
- **Responsive Frontend**: Built with React for smooth user experience.
- **In-memory Database** (for easy testing) or use Docker with PostgreSQL.

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

6. **The frontend will be accessible at http://localhost:3000.

7. **To stop the containers, run:
  ```bash
  docker-compose down
