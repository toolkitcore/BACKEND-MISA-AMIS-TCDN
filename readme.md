## Introduction

MISA AMIS is a web application for managing assets of an organization. It is developed by [MISA Technology](https://www.misa.com.vn/).

In this project, we use the following technologies:

**ASP.NET Core 6.0:** Used for the backend API

**Dapper:** Used for mapping objects to database tables

**MySQL:** Used for the database

## Features

- CRUD built facilities for employees
- Add, edit, delete and update employees (with duplicate check)
- Get the max employee code
- Get the entire list of employee
- Search for employees by code, name and phone number
- Delete multiple employees
- Export employee list to excel

## API Reference

#### Get new employee code

```http
  GET /api/v2/employees/new-employee-code
```

#### Filter employees

```http
  GET /api/v2/employees/filter
```

| Parameter    | Type     | Description               |
| :----------- | :------- | :------------------------ |
| `keyword`    | `string` | **Required**. Keyword     |
| `pageNumber` | `int`    | **Required**. Page number |
| `pageSize`   | `int`    | **Required**. Page size   |

#### Get all employees

```http
  GET /api/v2/employees
```

#### Get details of an employee

```http
  GET /api/v2/employees/${id}
```

| Parameter | Type     | Description               |
| :-------- | :------- | :------------------------ |
| `id`      | `string` | **Required**. Employee id |

#### Create an employee

```http
  POST /api/v2/employees
```

| Parameter           | Type       | Description                 |
| :------------------ | :--------- | :-------------------------- |
| `employeeCode`      | `string`   | **Required**. Employee code |
| `employeeName`      | `string`   | **Required**. Employee name |
| `departmentId`      | `string`   | **Required**. Department id |
| `departmentName`    | `string`   | Department name             |
| `dateOfBirth`       | `datetime` | Date of birth               |
| `gender`            | `int`      | Gender                      |
| `phoneNumber`       | `string`   | Phone number                |
| `telephoneNumber`   | `string`   | Telephone number            |
| `email`             | `string`   | Email                       |
| `jobTitle`          | `string`   | Job title                   |
| `employeeAddress`   | `string`   | Address                     |
| `identityNumber`    | `string`   | Identity number             |
| `identityDate`      | `datetime` | Identity date               |
| `identityPlace`     | `string`   | Identity place              |
| `bankAccountNumber` | `string`   | Bank account number         |
| `bankName`          | `string`   | Bank name                   |
| `bankBranch`        | `string`   | Bank branch                 |
| `isSupplier`        | `boolean`  | Is supplier                 |
| `isCustomer`        | `boolean`  | Is customer                 |
| `createdBy`         | `string`   | Created by                  |
| `createdDate`       | `datetime` | Created date                |
| `modifiedBy`        | `string`   | Modified by                 |
| `modifiedDate`      | `datetime` | Modified date               |

#### Update an employee

```http
  PUT /api/v2/employees/${employeeId}
```

| Parameter           | Type       | Description                 |
| :------------------ | :--------- | :-------------------------- |
| `employeeId`        | `guid`     | **Required**. Employee id   |
| `employeeCode`      | `string`   | **Required**. Employee code |
| `employeeName`      | `string`   | **Required**. Employee name |
| `departmentId`      | `string`   | **Required**. Department id |
| `departmentName`    | `string`   | Department name             |
| `dateOfBirth`       | `datetime` | Date of birth               |
| `gender`            | `int`      | Gender                      |
| `phoneNumber`       | `string`   | Phone number                |
| `telephoneNumber`   | `string`   | Telephone number            |
| `email`             | `string`   | Email                       |
| `jobTitle`          | `string`   | Job title                   |
| `employeeAddress`   | `string`   | Address                     |
| `identityNumber`    | `string`   | Identity number             |
| `identityDate`      | `datetime` | Identity date               |
| `identityPlace`     | `string`   | Identity place              |
| `bankAccountNumber` | `string`   | Bank account number         |
| `bankName`          | `string`   | Bank name                   |
| `bankBranch`        | `string`   | Bank branch                 |
| `isSupplier`        | `boolean`  | Is supplier                 |
| `isCustomer`        | `boolean`  | Is customer                 |
| `createdBy`         | `string`   | Created by                  |
| `createdDate`       | `datetime` | Created date                |
| `modifiedBy`        | `string`   | Modified by                 |
| `modifiedDate`      | `datetime` | Modified date               |

#### Delete an employee

```http
  DELETE /api/v2/employees/${id}
```

| Parameter | Type     | Description               |
| :-------- | :------- | :------------------------ |
| `id`      | `string` | **Required**. Employee id |

#### Delete multiple employees

```http
  POST /api/v2/employees/delete-multiple
```

| Parameter | Type    | Description                |
| :-------- | :------ | :------------------------- |
| `ids`     | `array` | **Required**. Employee ids |

#### Export employees

```http
  GET /api/v2/employees/export
```

#### Get all departments

```http
  GET /api/v2/departments
```

## Screenshots

![App Screenshot](https://via.placeholder.com/468x300?text=App+Screenshot+Here)

## Run Locally

Clone the project

```bash
  git clone https://github.com/vietanhdang/MISA.WEB08.AMIS.git
```

Go to the project directory

```bash
  cd MISA.WEB08.AMIS
```

Change the connection string in appsettings.json

```bash
  "ConnectionStrings": {
    "MySqlConnectionString": "Server=(your server name);Port=(your port name);Database=(your database name);Uid=(your username);Pwd=(your password);"
  }
```

Install dependencies

```bash
  dotnet restore
```

Start the server

```bash
  dotnet run
```

## Authors

- [@anhdv](https://www.facebook.com/anhdv47/)
