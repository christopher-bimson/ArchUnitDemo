# Arch Unit Demo

This is a simple project to demonstrate how you can use ArchUnit to write unit tests for your architecture.

## ArchUnit

While this is a .NET example, ArchUnit is available for both

- [.NET](https://github.com/TNG/ArchUnitNET)
- [JVM](https://www.archunit.org/)

There is [ts-arch](https://github.com/ts-arch/ts-arch) for TypeScript/Node which is inspired by ArchUnit, but not having used it I can't vouch for it.

## Rough Explanation

### BasicTaskList.Api 

Is a simple REST API that manages to-do lists in pretty much the simplest way you can imagine.

It *'works'* in the most bare bones sense - you can run it and make calls via the Swagger UI - but it does all sorts of things you should not do in a real application (in memory persistence, not especially rigorous input validation, probably other things)

### BasicTaskList.Api.ArchitectureTests

Contains a number of unit test scenarios that are intended to enforce the rules of a hexagonal type architecture. You can break the rules, run the tests and you should receive useful feedback on what you did wrong.