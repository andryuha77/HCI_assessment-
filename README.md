# HCI_assessment-
Technical assessment - take home


# Healthcare App

## Healthcare Backend

### Prerequisites

- Visual Studio or Visual Studio Code installed
- .NET 5 SDK installed ([Download .NET 5](https://dotnet.microsoft.com/download/dotnet/5.0))

### Back-End (HealthcareBackendVS)

1. Open the HealthcareBackendVS solution in Visual Studio.
2. Set the Startup project to HealthcareBackendVS.
3. Ensure your SQL Server database is configured using SQL Server Management Studio (SSMS). If not, follow these steps:
   - Open the Package Manager Console.
   - Run the following commands:
     ```bash
     Update-Database
     ```
   - This will apply the database migrations and create the necessary tables.

4. Build and run the project.

The back-end API will be accessible at:
- Base URL: `https://localhost:44379`

---

## Front-end Setup

### Prerequisites

- Node.js and npm installed ([Download Node.js](https://nodejs.org/))

### Steps

1. Open a terminal and navigate to the `healthcare-app` directory:

    ```bash
    cd healthcare-app
    ```

2. Install dependencies:

    ```bash
    npm install
    ```

3. Start the front-end development server:

    ```bash
    npm start
    ```

4. Open your browser and visit [http://localhost:3000](http://localhost:3000) to view the front-end application.

---

### Note:

- Ensure that the backend server is running before accessing the front-end application.
- In case of any issues, refer to the documentation or project-specific instructions for troubleshooting.

  ---
![image](https://github.com/andryuha77/HCI_assessment-/assets/14886116/6ea16981-f781-48ae-bba1-557a9a3d58d4)
