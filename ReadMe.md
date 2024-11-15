# Route Finder Application

## Overview
The Route Finder application is a .NET console application that computes train routes between towns based on input data. It allows users to calculate distances, find routes with specific constraints, and determine the shortest paths.

The application uses an adjacency list representation of the graph and implements traversal algorithms to solve the given problem efficiently.

---

## Features
The application supports the following functionalities:
1. **Calculate the total distance** of a given route.
2. **Check if a route exists** between two towns.
3. **Count the number of trips** between two towns with a maximum or exact number of stops.
4. **Calculate the shortest route** between two towns.
5. **Count the number of trips** between two towns within a maximum distance.

---

## Design Decisions

### 1. Modular Architecture
The application separates responsibilities into distinct components:

- **Graph Representation**: Handles the data structure for the graph.
- **Route Calculations**: Contains the logic for solving the problem.
- **Graph Factory**: Handles graph creation from input data, including validation.

This design adheres to the **Single Responsibility Principle**, ensuring each class has a clear and focused purpose.

### 2. Efficient Graph Representation
The graph is implemented as an **adjacency list**, which offers:
- **Space Efficiency**: Only stores existing connections.
- **Fast Traversals**: Allows efficient lookups of neighboring nodes.

### 3. Use of Recursion for Traversals
Recursive methods are used for:
- Exploring all possible routes under constraints (e.g., stops, distances).
- Simplifying the implementation of graph traversals, making the logic easier to follow.

### Dependencies

- .NET 6.0 or later
- Visual Studio