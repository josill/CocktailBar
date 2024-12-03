# .NET ID Class Generator

A simple bash script for generating DDD-style ID value object classes in .NET projects.

## Overview

This script generates ID value object classes following a consistent pattern for Domain-Driven Design (DDD) projects. Each generated class follows a standard template that includes:
- Copyright header
- MIT license notice
- Proper namespace derived from the path
- Base class inheritance
- Factory methods for creation

## Prerequisites

- Bash shell (Linux, macOS, or WSL on Windows)
- Write permissions in your project directory

## Installation

1. Save the script as `generate-entity-id.sh` in your project root
2. Make it executable:
   ```bash
   chmod +x generate-entity-id.sh
   ```

## Usage

Basic syntax:
```bash
./generate-entity-id.sh -p <path> -c <class-names>
```

Parameters:
- `-p`: Full path where files should be generated (must start with './src/')
- `-c`: Comma-separated list of class names (without 'Id' suffix)

## Examples

1. Generate a single ID class:
   ```bash
   ./generate-entity-id.sh -p "./src/Domain/StockAggregate/ValueObjects/Ids" -c "StockOrder"
   ```

2. Generate multiple ID classes:
   ```bash
   ./generate-entity-id.sh -p "./src/Domain/ProductAggregate/ValueObjects/Ids" -c "Product,Category,Supplier"
   ```

## Output

For the StockOrder example above:

1. Creates directories if they don't exist:
   ```
   ./src/Domain/StockAggregate/ValueObjects/Ids/
   ```

2. Generates file:
   ```
   StockOrderId.cs
   ```

3. File content:
   ```csharp
   // Copyright (c) 2024 Jonathan Sillak. All rights reserved.
   // Licensed under the MIT license.

   namespace Domain.StockAggregate.ValueObjects.Ids;

   using System;
   using CocktailBar.Domain.Common;

   public sealed class StockOrderId : BaseId<StockOrderId>, IBaseId<StockOrderId>
   {
       private StockOrderId(Guid value) : base(value) { }

       public static StockOrderId New() => new StockOrderId(Guid.NewGuid());

       public static StockOrderId From(Guid id) => new StockOrderId(id);
   }
   ```

## Important Notes

1. Path must start with './src/'
2. Namespace is automatically derived from the path after 'src/'
3. 'Id' suffix is automatically added to class names
4. Directory structure will be created if it doesn't exist

## Error Handling

The script will show an error if:
- Required parameters are missing
- Path doesn't start with './src/'
- Directory creation fails
- File generation fails
