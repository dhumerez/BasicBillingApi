# Basic Billing API

This web api project is done in .Net Core 3.1, with C# 8 nullable. Entity Framework Core and SQL Server.
It contains basic behaviour of a Billing system. It includes:

 - Get Clients
 - Get Client Bills
 - Get Client Payments
 - Get Bills
 - Get Bill Payments
 - Post Client Payment
 - Post Bill Payment

# Setup
First run the attached sql file ("**BasicBillingApi.sql**") that will set your DB locally after that to set the tables and some data please restore the new DB with the file "BasicBillingBackUp", it can also be done througt "update-database" in the Package Manager console since a migration is already set on the project, but before running the command a valid DB has to be specified on the connection string. If the process is done througt the migration, the seed process will happen automatically once the project is run for the first time

Check your connection string, it is located on the BasicBilling.API project, inside the appsettings.json file, if you use your local DB no changes should be made.


## Test the project

In order to run the project you can do it from visual studio or througt comand line, in order to run it in comand line you have to go to the BasicBilling.API directory, then you just have to write "**dotnet run**" and a console will be displayed with the available port.

Attached is also a Postman Collection that contains requests for all the available enpoints. Its name is "**BasicBilling.postman_collection**", you can import it to your local postman, change the port number if needed.

# Endpoints


## Get Clients

    /clients

This endpoint will retrieve all the clients on the system.

## Get Client Bills

    /clients/{clientId}/bills

This endpoint will retrieve all the bills per client, it has a bool query param, that allows to filter the bills by state.

Query param options:
 - **paid = true** Returns only Paid bills
 - **paid = false** Returns only Pending bills
 - **paid = null** Returns all bills

## Get Client Payments

    /clients/{clientId}/payments
This endpoint will retrieve all the Payments done by a Client.

## Get Bills

    /bills

This endpoint will retrieve all the Bills on the system.

## Get Bill Payments

    /bills/{billId}/payments

This endpoint will retrieve all the payments done for a specific Bill on DB.

## Post Client Payment

    /clients/{clientId}/payments

This endpoint will Create a payment for a Client given a Date and a Bill Type.
Body:

    { 
	    "Amount": 1,
	    "BillType": "Electricity",
	    "Date": "2021-11-01"
    }


## Post Bill Payment

    bills/{billId}/payments

This endpoint will Create a payment for a Bill given a Bill Id.

Body: 

    { 
	    "Amount": 1
    }
