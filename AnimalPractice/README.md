
# Simple Zoo System

A basic C# project to understand interfaces and constructors by simulating animals in a zoo.

## Overview

This project introduces a basic system where animals can perform certain actions like "Speak" or "Eat". The main goals of this project are:

1. Understand the use and implementation of interfaces.
2. Familiarize oneself with constructors and their role in class initialization.

## Components

### IAnimal Interface

- Defined as the main contract that all animal classes should adhere to.
- Contains two method signatures:
  - `Speak()`: Represents the sound the animal makes.
  - `Eat()`: Simulates the animal eating and returns a message indicating so.

### Dog Class

- Implements the `IAnimal` interface.
- Constructor initializes the dog's name.
- `Speak()` method returns "Woof!".
- `Eat()` method returns "[Dog's Name] is eating.".

### Cat Class

- Implements the `IAnimal` interface.
- Constructor initializes the cat's name.
- `Speak()` method returns "Meow!".
- `Eat()` method returns "[Cat's Name] is eating.".

## Usage

After creating instances of the `Dog` and `Cat` classes, you can call their `Speak()` and `Eat()` methods to simulate their actions.

```csharp
Dog dog = new Dog("Buddy");
Console.WriteLine(dog.Speak()); // Outputs: Woof!
Console.WriteLine(dog.Eat());   // Outputs: Buddy is eating.

Cat cat = new Cat("Whiskers");
Console.WriteLine(cat.Speak()); // Outputs: Meow!
Console.WriteLine(cat.Eat());   // Outputs: Whiskers is eating.