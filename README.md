# MedsPlanner (Public)

Blazor PWA App for managing and monitoring medications. This project is currently in development and the CSS has only been completed for display on a Mobile phone. The idea is that this can behave like a traditional Mobile App because of the PWA integration. On your phone you will be able to open the following URL in a browser and then will have the option to install on Android devices, or add to the home screen on IOS.

**Demo:** https://medsplanner.co.uk/

The project is created around Azures new 'Static Web Apps' solution. As part of this solution you have a static app, in this case its Blazor WASM, a Function App and a GitHub CI/CD Pipeline for deployments. The Function App has been configured as an API which the Blazor WASM app can consume to query an Azure Storage Table for the data to display. The Azure Table behaves like a NoSQL database and is suitable due to the type of data that's being stored in this solution.

![image](https://user-images.githubusercontent.com/28670731/189530813-2282402a-24f0-4b38-9418-e0ea702e64c1.png)

The Mobile interface has the option to see additional detail using the toggle button in the NavBar. This uses events to enable the toggle change to trigger a change in other blazor components (Still fine tuning this functionality)

![image](https://user-images.githubusercontent.com/28670731/189530561-a21ba72c-899f-4056-a2f4-1dd893e68da0.png)

GitIgnore is used to ensure sensitive information in the local.settings.json file is not published to the Git Repository. You will need to add the required information of the Storage Account and Azure Table to the this file for local development. Once deployed, these values will also need be added to the Application Settings for the Azure Static Web App.

![image](https://user-images.githubusercontent.com/28670731/189531484-e5f24a3d-a557-48dc-9f3d-a9f425d45f7f.png)

![image](https://user-images.githubusercontent.com/28670731/189531801-c2a779b5-4d73-48d7-affa-18c76496e99c.png)


## TODO

Refactor for better use of Blazor Components + lots of other stuff
