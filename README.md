# Caching in ASP.NET Core Course

## About
In-Memory Cache: Uygulama sunucusunun RAM'inde saklanır
Distributed Cache: Ayrı bir cache sunucusunda (örn. Redis) saklanır

In this course there are three projects
**RedisIn-Memory.APP** => In this part we test out the AbsoluteExpiration and SlidingExpiration using the In-Memory Cache using the Microsoft Caching library.
**IDistributedCacheRedisApp.Web** => We connect to the redis server and add some simple/complex types to the Db.
**RedisExchangeAPI.Web** => Using the StackExhange.Redis library, we fully use the redis tools for creating and managing  redis data types and test out the data in the redis server.

This course consists of 2 main sections:

## Section 1
Learn about **In-Memory Cache** and **Redis (Distributed Cache)** architectures 

## Section 2
Learn how to implement and use **In-Memory Cache** and **Redis (Distributed Cache)** in ASP.NET Core projects

## Technologies Used

- .NET 8 (Visual Studio)
- Another Redis Desktop Manager
- Docker => Docker is used to start a redis server instance, other ways can be selected to connect to a redis server
- Postman

## Course Contents

### Fundamentals
- What is Caching?
- Types of Caching
- What is In-memory Caching?
- What is Distributed Caching?
- What are On-Demand and PrePopulation Caching?
- Cache lifetime (Absolute time and Sliding time)

### Redis Fundamentals
- What is Redis?
- How to set up Redis Server with Docker Container?

### Redis Data Types
- Introduction to Redis Data Types
- Redis String Data Type
- Redis List Data Type
- Redis Set Data Type
- Redis Sorted Set Data Type
- Redis Hash Data Type

### Implementation
- How to use In-Memory Cache in ASP.NET Core projects?
- How to use Distributed Cache in ASP.NET Core projects?
- How to cache Complex Types?

