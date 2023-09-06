# E-Commerce Platform Project

Welcome to the e-commerce platform project. This is a step-by-step development of an e-commerce system starting from object-oriented principles, progressing to a simple console-based interaction, and finally to integration with a database.

## Table of Contents
- [Overview](#overview)
- [Project Breakdown](#project-breakdown)
  - [1. OO Models](#1-oo-models)
  - [2. Instance Creation](#2-instance-creation)
  - [3. Console Interaction & In-Memory Data](#3-console-interaction--in-memory-data)
  - [4. File System Storage](#4-file-system-storage)
  - [5. Database Integration & ORM](#5-database-integration--orm)
- [Getting Started](#getting-started)
- [Contribute](#contribute)
- [License](#license)

## Overview

This project is structured to help understand:
- Object-Oriented principles like polymorphism, inheritance, and abstraction.
- Basic console-based user interactions.
- Data storage, retrieval, and database integrations.

## Project Breakdown

### 1. OO Models

Start by defining object-oriented models for our e-commerce platform:

- **Enums**: UserRole, ProductCategory, and OrderStatus.
- **Abstract Class**: User - with properties and basic methods.
- **Classes**: Seller, Buyer, Admin, Product, Order, and Review.
- **Interfaces**: IReviewable and ITransaction.

### 2. Instance Creation

At this phase:

- Instances of Seller, Buyer, and Product are created.
- Polymorphism is tested via the `Dashboard()` method for Seller and Buyer.

### 3. Console Interaction & In-Memory Data

Develop a simple console application to:

- Let users select their role: Seller, Buyer, or Admin.
- Sellers can add product details.
- Buyers view products, add to cart, and 'purchase'.
- Data at this stage is in-memory. Restarting the application will lose all data.

### 4. File System Storage

Enhance the application to:

- Store product info in a text file upon a seller's input.
- Store order info in a different text file upon a buyer's purchase.
- Read these files when the application starts, preserving data across sessions.

### 5. Database Integration & ORM

Now, connect the application to a database:

- **Data Access Layer (DAL)**: Separate classes for database operations.
  - `ProductDataAccess`, `OrderDataAccess`, etc.
- **ORM Frameworks**: Use an ORM like Entity Framework Core.
  - Define database entities: ProductEntity, OrderEntity, and more.
  - Initialize and connect to the database.
  - Update DAL for ORM-driven data operations.

The updated structure will have:
- **Entities** (with ORM)
- **DAL** 
- **Models** 
- **Console Application**

## Getting Started

To begin with the project, start from the OO Models section and proceed step-by-step. If you're picking up from a certain phase, make sure to check the pre-requisites and dependencies.

# E-Commerce Console Application Flow

## Application Initialization
- The application starts and welcomes the user with a greeting message.
- The main menu provides the user with options to choose their role: 'Admin', 'Seller', or 'Buyer', or 'Exit'.

## Role-Based Dashboards

### Admin Dashboard
- View all registered users.
- Approve or remove sellers.
- Review and approve/reject products added by sellers.
- Generate reports, e.g., total sales, user registrations, popular products.

### Seller Dashboard
- Register as a seller by providing necessary details (username, password, email, etc.)
- Add a new product by providing its details: name, price, category, etc.
- View and manage their product listings.
- Update the details of the products they've listed.
- View sales reports for their products.

### Buyer Dashboard
- Register as a buyer by providing necessary details (username, password, email, etc.)
- Browse the product catalog, either viewing all products or filtering by category.
- Search for specific products by name.
- Add products to their shopping cart.
- View their shopping cart, modify quantities, or remove items.
- Proceed to checkout, confirming their order.
- View their past orders and their statuses (e.g., shipped, delivered).
- Review products they've purchased.

## Review System
- After receiving an order, buyers have the option to review the product.
- Sellers can view reviews on their product listings.
- Admins can monitor and, if necessary, moderate reviews.

## Exiting the Application
- At any point, the user can choose to log out and return to the main menu.
- From the main menu, they can safely exit the application.

**Note**: The entire experience is interactive and driven by user input in the console. As users make selections (e.g., choosing a role, selecting 'Buyer', browsing products), the console provides feedback, either moving them forward in the process or providing pertinent information.


## Contribute

If you're collaborating, feel free to make pull requests and ensure you update this README with any structural changes or added functionalities.

## License

[MIT License](LICENSE.md)
