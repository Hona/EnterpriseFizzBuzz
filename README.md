# Enterprise FizzBuzz

> An overkill version of FizzBuzz, prefect for your enterprise codebase.

This repository aims to demonstrate the enterprise way of implementing the classic problem of FizzBuzz.

The design here is DDD (Domain Driven Design), with the infrastructure layer missing, because currently the solution is stateless.

The layers are as follows:

* Presentation Layer: an ASP.NET Core 5 Web API
* Application Layer: MediatR providing a way between the Presentation Layer and the Core Layer
* Core Layer: Class library with the models, and services

The project also has unit testing.