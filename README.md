# Bridgeway

.Net NuGet Package

[![Nuget](https://img.shields.io/nuget/v/Bridgeway?logo=nuget&style=default)](https://www.nuget.org/packages/Bridgeway)
![Nuget](https://img.shields.io/nuget/dt/Bridgeway?color=blue&label=Downloads)

# Introduction
Bridgeway is an open-source NuGet package written using c#, with the main purpose of simplifying the interaction between web-services within a distributed architecture or even with third party services. By "simplifying" I mean:
* Not concerning ourselves with how a request is built, whether its parameters are encoded as `application/json` payload or as `application/x-www-form-urlencoded`;
* Not concerning ourselves with how data is extracted from the response payload;
* Decoupling concerns about how a request has been authorized from how it has been sent.

## Interested in how this thing works?

Go check acceptance tests [here](https://github.com/fatlummaliqi/Bridgeway/tree/main/test/Bridgeway.Test.Acceptance). I've written these tests using the [JSON Placeholder API](https://jsonplaceholder.typicode.com/) as a real-world scenario.