# Azure Function Interactive Pilot Quiz
A project-based assessment with selected multiple-choice questions

## Getting Started
For debugging the project, you will need the following:
1.   .NET Core 3.x or above
2.  Azure account (optional, but if deploying to Azure then required)
3. Azure Function Core Tools (required for local debugging the Azure functions from the command line i.e. you are not using Visual Studio or VS Code)
    - https://docs.microsoft.com/en-us/azure/azure-functions/functions-run-local?tabs=windows%2Ccsharp%2Cbash#install-the-azure-functions-core-tools
5. If using VS Code, install the Azure Functions Extension (optional)
    - https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-azurefunctions

A PDF of the quiz contents is located in the assets folder of the root directory of this project repo.
```
~\assets\Quiz 1Pilot.pdf
```

## How to Run This Project
---
To run the code paired with the assessment you will need:
- your favorite code editor or IDE (Visual Studio recommended or VS Code)
- access to the quiz contents
- an API Development Environment such as Postman

**If using Visual Studio 2019 or above simply open the solution file in the root directory**

```bash
$ Azurefunction.sln
```
**If running from the command line follow the steps below:**


## Step 1: Clone or download this repository
From your shell or command line:

    git clone https://github.com/Kev8144/AzureFunction.git

## Step 2: Build and Test
-  navigate to the directory of your cloned project and run the project from the command line:

```bash
$ cd src/
$ dotnet run --project \src\FunctionAppQuizPilot\FunctionAppQuizPilot.csproj
```
-  To build the project, in the root directory:
```bash
$ dotnet build
```
-  To test the project, in the root directory:
```bash
$ dotnet test
```

## Step 3: Run the project
-  navigate to the directory of your cloned project and run the project from the command line.

```bash
$ cd \src\FunctionAppQuizPilot
$ func start
```


