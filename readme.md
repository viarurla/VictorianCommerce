# VictorianCommerce

VictorianCommerce is an ASP.NET Core web API for processing orders for a fictional eCommerce site, designed as part of a technical interview step. The application allows users to submit orders with basic information such as the customer's ID and the products ordered.

## Technologies Used

The application is built using .NET 7, with MSSQL used as the database via a Docker container. Swagger was used to document the API.

## Getting Started

To get started with the application, clone the repository and run it in your preferred development environment. The API can be accessed through Swagger UI or any other HTTP client.

## API Endpoints

The API has two endpoints:

- GET /Purchases returns a list of all orders submitted.
- POST /Purchases submits a new order.
For more information about the request and response data for each endpoint, please refer to the Swagger documentation.

## Future Improvements

This application is intended to serve as a technical interview step, and as such, there are many improvements that can be made to it. These include adding authentication and authorization, implementing data validation and error handling, and adding more functionality to the API.

## Contact

If you have any questions or feedback regarding VictorianCommerce, please contact the developer viarurla.