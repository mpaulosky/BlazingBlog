# Contributing to This Project

Thank you for taking the time to consider contributing to our project.

The following is a set of guidelines for contributing to the project. These are mostly guidelines, not rules, and can be
changed in the future. Please submit your suggestions with a pull-request to this document.

- [Contributing to this Project](#contributing-to-issue-tracker)
    - [Code of Conduct](#code-of-conduct)
        - [What should I know before I get started](#what-should-i-know-before-i-get-started)
            - [Project Folder Structure](#project-folder-structure)
            - [Design Decisions](#design-decisions)
            - [How can I contribute](#how-can-i-contribute)
            - [Create an Issue](#create-an-issue)
            - [Respond to an Issue](#respond-to-an-issue)
            - [Write code](#write-code)
            - [Write documentation](#write-documentation)

## Code of Conduct

We have adopted a code of conduct from the Contributor Covenant. Contributors to this project are expected to adhere to
this code. Please report unwanted behavior to [Matthew Paulosky](mailto:matthew.paulosky@outlook.com)

## What should I know before I get started

This project is a practice project to build a Blazor application supported by API, library and sql projects.

### Project Folder Structure

This project is designed to be built and run primarily with Visual Studio 2022 or JetBrains Rider. The folders are
configured so that they will support editing and working in other editors and on non-Windows operating systems. We
encourage you to develop with these other environments, because we would like to be able to support developers who use
those tools as well. The folders are configured as follows:

- /docs                               -- User Documentation
  - README.md                                   -- Project overvies
  - CODE_OF_CONDUCT.md                          -- Code of Conduct
  - CONTRIBUTING.md                             -- Contributing to the project
  - LICENSE                                     -- License for the project
  - CHANGELOG.md                                -- Changelog for the project
  - Images                                      -- Images used in documentation

- /src
  - BlazingBlog.Web.Server                      -- Blazor Server
  - BlazingBlog.Web.Client                      -- Blazor WASM
  - BlazingBlog.Application                     -- Class Library
  - BlazingBlog.Infrastructure                  -- Class Library
  - BlazingBlog.Domain                          -- Class Library
  - BlazingBlog.Postgres.Migration              -- Class Library

- /tests                              -- Unit and Integration tests
  - BlazingBlog.Web.Server.Tests.Unit           -- Unit tests
  - BlazingBlog.Web.Client.Tests.Unit           -- Unit tests
  - BlazingBlog.Application.Tests.Unit          -- Unit tests
  - BlazingBlog.Infrastructure.Tests.Unit       -- Unit tests
  - BlazingBlog.Domain.Tests.Unit               -- Unit tests
  - BlazingBlog.Postgres.Migration.Tests.Unit   -- Unit tests

All official versions of the project are built and delivered with GitHub Actions and linked in the main README.md
and [releases tab in GitHub](https://github.com/mpaulosky/BlazorApp/releases).

### Design Decisions

Design for this project is ultimately decided by the project team
lead, [Matthew Paulosky](mailto:matthew.paulosky@outlook.com). The following project tenets are adhered to when making
decisions:

1. Use Blazor for the UI.
2. Use PostgresSQL for data storage.
3. Use Auth0 for authentication.
4. Use EF Core to access the data.

### How can I contribute

We are always looking for help on this project. There are several ways that you can help:
This means one of several types of contributions:

1. [Create an Issue](#create-an-issue)
2. [Respond to an Issue](#respond-to-an-issue)
3. [Write code](#write-code)
4. [Write documentation](#write-documentation)

### Create an Issue

Create a [New Issue Here](https://github.com/mpaulosky/BlazorApp/issues).

1. If you are reporting a `Bug` that you have found. Be sure to add the `Bug` label so that we can triage and track it.
2. If you are reporting an `Enhancement` that you think would improve the project. Be sure to add the `Enhancement`
   label so we can track it.

### Respond to an Issue

[Fork the Repository to your GitHub account](https://github.com/mpaulosky/BlazorApp/fork).

1. Create a new Branch from the develop branch with a reference to the existing Issue number.
2. Work on the issue.
3. Create Unit, Integration tests for any code that require them. We use [xUnit](https://www.nuget.org/packages/xunit/)
   to test our code and [bUnit](https://www.nuget.org/packages/bunit/) to test our blazor components.
4. When you are done Create a Pull Request from your branch to the develop branch.
5. Submit the Pull Request.

Any code that is written to support a blazor component or new functionality are required to be accompanied with unit
tests at the time the pull request is submitted. Pull requests without unit tests will be delayed and asked for unit
tests to prove their functionality.

### Write code

All code should have an assigned issue that matches it. This way we can prevent contributors from working on the same
feature at the same time.

Code for components' features should also include some definition in the `/documents` folder so that our users can
identify and understand which feature is supported.

### Write documentation

The documentation for the project is always needed. We are always looking for help to add content to the `/documents`
section of the repository with proper links back through to the main `/README.md`.