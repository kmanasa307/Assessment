# Alogent Digital Code Assessment

## Application Description

The following application is a system that allows users to post small notes on their boards.
For this exercise, added and removed data needs to only last as long as the web host is online.

The total set of deliverables as outlined would likely take 3 or 4 hours.
Only spend one hour on the assessment and get done what you can.
You will not be judged on the amount of code completed, only on the quality of the code turned in.
A project that doesn't compile or that fails any unit tests will not be accepted.

There is an initial "seed" of data that is stored in a `json` file. 
You can use this file to be your data store or you can store everything in-memory for the purposes of this assignment.
The file is deleted and restored at each run of the application.

This should run without anything other than Visual Studio or IIS.

## Getting Started

* Fork this repository on Github
* Clone your copy of the repository 

```
> git clone https://github.com/<username>/alogent-assessment.git
```

* Install NPM modules

```
> cd Src/Assessment.Client/ClientApp
> npm install
```

## Models

### Board

* Contain a name
* Contain the date is was created
* Contain any number of post-it notes

### Post-It

* Contain a title
* Contain some note information (URL, text, etc.)
* Contain the date it was created

## Target Deliverables 

1. Add a collection of "post-its" to the `Board` class
2. Add the features outlined in the __Features__ section below
  - These features should be developed in the order outlined below
  - Add (or update) the Web API controller(s) and include the minimal UI required to facilitate use of the API
      - The expected API URL path and HTTP method are specified with the features below
3. Unit tests for all server-side code added/modified
    - Code coverage target - `90%`
      - For all logic areas added
      - The current code in the repository is not considered in determining the coverage. Only code and tests you add will be reviewed.

### Features

The following features need to be added to the application to make it useful for users.

1. Create a new board - `POST /boards`
2. Delete an existing board - `DELETE /boards/[board-id]`
3. Add a pin to a board - `POST /boards/[board-id]/post-its/`
4. View pins attached to a board - `GET /boards/[board-id]/post-its/`
5. Delete a pin - `DELETE /boards/[board-id]/post-its/[post-it-id]`
6. Delete a board and all pins - `DELETE /boards/[board-id]`

Complete what you can in the time frame allotted for the assessment - __1 Hour__.
You will not be judged on the amount of code completed, only on its quality and ability to meet the requirements outlined.

## Tech Stack

* Git
* C#
* ASP.NET Core Web API
* Angular 5
* Bootstrap
* NUnit
* Moq

## Recommended Tools

* PowerShell
* VS Code or Visual Studio
 
## Out of scope

- User authenticiation/authorization
- Permanent data storage
- Design of front-end 
    - use the existing layout/design
    - if you have extra time and want to spend it changing the design, you are more than welcome
