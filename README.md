# microservices-dot-net-core

Building a Scalable eCommerce Platform with Microservices using .NET Core

## Introduction

In the fast-paced world of online business, creating an eCommerce platform that can grow seamlessly and withstand challenges is crucial. Companies must prioritize the development of a digital storefront that can handle increased demand and bounce back from any disruptions in the market.This Comprehensive Guide dive deep into a cutting eCommerce Solution Using Microservice

## Technology Used

**Backend:** Asp.Net Core ,C#

**DataBase:** SQL Server

## Getting Started

- In order to run the project a small amount of prerequisites and additional steps have to be fulfilled.

### Prerequisites

- Visual Studio IDE installed

### Running

- Clone the Project from Github Repository

- Open `Microservice.sln` file using Visual Studio IDE

### Starting

- Right Click on `Solution Microservice` File and Go to Properties.

- Select `Multiple Startup Projects` Option and Select Action `Start` for All the Projects.

- Now Click on `Apply` and start the Project

## Roadmap

- Creating A New Project of Asp.net Core

- Creating Microservice In Asp.net Core

- Adding Database Connection

- Creating API Gateway Using Ocelot

# Screenshots

### Api Gateway

![ApiGateway Screenshot1](Screenshot/ApiGateway_s1.png)

![ApiGateway Screenshot2](Screenshot/ApiGateway_s2.png)

![ApiGateway Screenshot3](Screenshot/ApiGateway_s3.png)

![ApiGateway Screenshot4](Screenshot/ApiGateway_s4.png)

![ApiGateway Screenshot5](Screenshot/ApiGateway_s5.png)

### Product Service

![Product1 Screenshot](Screenshot/ProductService_s1.png)

![Product1 Screenshot](Screenshot/ProductService_s2.png)

![Product1 Screenshot](Screenshot/ProductService_s3.png)

### Account Service

![AccountS1 Screenshot](Screenshot/AccountService_s1.png)

![AccountS1 Screenshot](Screenshot/AccountService_s2.png)

### Checkout Service

![Checkouts1 Screenshot](Screenshot/CheckoutService_s1.png)

![Checkouts2 Screenshot](Screenshot/CheckoutService_s2.png)

![Checkouts3 Screenshot](Screenshot/CheckoutService_s3.png)

![Checkouts3 Screenshot](Screenshot/CheckoutService_s4.png)

![Checkouts3 Screenshot](Screenshot/CheckoutService_s5.png)

![Checkouts3 Screenshot](Screenshot/CheckoutService_s6.png)

### Tracking Service

![TrackS1 Screenshot](Screenshot/TrackService_s1.png)

![TrackS1 Screenshot](Screenshot/TrackService_s2.png)

![TrackS1 Screenshot](Screenshot/TrackService_s3.png)

### Project Starting

![MultipleStartupProject](Screenshot/MultipleStartupProject.png)

# Contents

## Product Service

- Description and responsibilities.
- Table schema for storing product information.

## Account Service

- Description and responsibilities
- Table Schema for storing User information

## Checkout Service

- Description and responsibilities
- Table Schema for storing Order and OrderItem information

## Tracking Service

- Description and responsibilities
- Table Schema for Storing OrderTrack information

## ApiGateway

- Routes To All the Service Using Ocelot

### Setting Up the enviourment

- .Net Core and any other Required Tools

### Model Classes

- Product Class

![product class](Screenshot/ProductClasss.png)

- User Class
  ![User class](Screenshot/UserClass.png)

- OrderClass
  ![Order class](Screenshot/Orderclass.png)

- OrderTrack Class
  ![OrderTrack class](Screenshot/OrderTrackingClass.png)

- OrderStatus Class
  ![OrderStatus class](Screenshot/OrderStatusClass.png)
