# Complete Developer Network WebApp

CDN - Complete Developer Network is building a directory of freelancers to provide a comprehensive list of contacts for job opportunities. This repository contains the RESTful API for managing freelancer's user information.

## Features
- Create: Register a new User
- Delete: Delete an existing User
- Update: Update User details
- Get: Retrieve User details

## Prerequisites

- Docker
- Docker Compose

## Getting Started

Follow the steps below to set up and run the application locally using Docker.

### Clone the Repository

```bash
git clone https://github.com/ChanKahHee/CompleteDeveloperNetworkWebApp.git
cd CompleteDeveloperNetworkWebApp
```

### Update the Connection String

Update the `ConnectionStrings` and `database.environment` properties in the `docker-compose.yml` file with the correct database credentials:

```yml
database:
  environment: 
    MYSQL_ROOT_PASSWORD: my-secret-pw
    MYSQL_USER: root
    MYSQL_PASSWORD: my-secret-pw
    MYSQL_DATABASE: CompleteDeveloperNetwork
api:
  environment:
    - "ConnectionStrings:Connection=server=database;port=3306;database=CompleteDeveloperNetwork;user=root;password=my-secret-pw;"
```

### Build and Run the Application

Run the following command to build and run the Docker containers:

```bash
docker-compose up --build
```

The ASP.NET Core application will be accessible at `http://localhost:8080`

## API Endpoints

The endpoint can be tested using `http://localhost:8080/swagger/index.html`

## Clean Up

To stop and remove the Docker containers, run the following command:

```bash
docker-compose down
```
