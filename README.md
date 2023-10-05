# Notes App

---
The Notes App is a straightforward application designed for sharing your notes anonymously.

## Build

---
Notes App uses docker to simplify project setup and run.
It contain the PostgreSQL database and the app containers.

### Run the project
To start the app you need to install docker on your machine and configure environment variables.
Steps:
1. Copy the `.env.example` file to the `.env` file, and update variables as you want.
2. Open the project directory and run `docker-compose build` to build containers
3. Run the `docker-compose up to start the application

After these steps you can visit the `localhost` URL to check the App

## Application Layers

---
### NotesApp.Application
This foundational layer encompasses all the essential business logic and entities required for the application to function. Think of it as the heart of the application, where the core functionality resides. It's akin to the combination of the Domain and Application layers in Domain-Driven Design (DDD), responsible for managing the application's key operations and data.

### NotesApp.Persistence
The Persistence layer is responsible for the interaction with the database. It houses the implementations that handle data storage and retrieval, ensuring that your notes are securely stored and can be accessed when needed. This layer bridges the gap between the application's logic and the database, making it possible to save and retrieve data reliably.

### NotesApp.Blazor
The Blazor layer serves as the presentation layer of the application. Here, you'll find the user interface components and logic needed to create and display the web pages. It's the part of the application that users interact with directly. Through the Blazor layer, you can navigate the application's features, create and view notes, and enjoy a user-friendly experience.

In summary, the Notes App is structured into these three crucial layers: Application for business logic and entities, Persistence for database interaction, and Blazor for the user interface. Together, these layers work harmoniously to provide a seamless and anonymous note-sharing experience for users.
