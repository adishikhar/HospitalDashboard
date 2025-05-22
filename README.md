# Hospital Resource Allocation Dashboard

This is a desktop application for managing hospital resources like beds, doctors, and equipment. The app is built with WPF (.NET Core) and follows the MVVM pattern. The backend is a REST API built using ASP.NET Core and uses MongoDB (Atlas) for storage. Real-time updates are handled via SignalR.

---

## Features

- Add and track hospital resources
- Real-time updates across clients using SignalR
- RESTful API between WPF frontend and .NET backend
- Data stored in MongoDB Atlas (cloud NoSQL DB)

---

## Tech Stack

- C# (.NET 6)
- WPF (MVVM)
- ASP.NET Core Web API
- MongoDB Atlas
- SignalR

---

## Getting Started

### Run the Backend

1. Go to the backend folder:

```bash
cd HospitalDashboard.API
```

2. Run the API:

```bash
dotnet run
```

### Run the WPF App

1. Open a second terminal and navigate to the client:

```bash
cd HospitalDashboard.Client
```

2. Run the app:

```bash
dotnet run
```
Make sure MongoDB Atlas is configured in appsettings.json.

![image](https://github.com/user-attachments/assets/a898f825-ab66-42eb-bbc9-d8f0550398ff)

### Notes

1.The backend uses MongoDB Atlas — make sure your IP is whitelisted.
2.SignalR enables real-time sync between multiple instances of the app.


    
