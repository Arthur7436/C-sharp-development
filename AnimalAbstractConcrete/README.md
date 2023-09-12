# Animal Abstract Project

## Overview

The Animal Abstract Project is a C# exercise that demonstrates the power and flexibility of abstract classes in an object-oriented design context. The project establishes a foundational hierarchy of animals in a theoretical zoo management system.

## Features

- **Abstract Base Class**: A foundational `Animal` class that contains common properties and methods all animals share.
- **Derived Class**: `Lion` class that inherits from the `Animal` class and provides a specific implementation.
- **Polymorphism**: Demonstrates the ability to treat different animal objects in a unified manner based on the abstract class definition.
- **Enforced Implementation**: Ensures consistent behavior across all animal types by requiring certain methods to be implemented by all derived classes.

## Components

1. **Animal (Abstract Class)**: Provides a blueprint for all animals. Contains:
    - An abstract `Speak()` method.
    - An abstract `Name` property.
    - A concrete `Eat()` method.

2. **Lion (Concrete Class)**: Represents a lion in the zoo. Implements the abstract methods and properties from `Animal`.

## Usage

1. Clone the repository: