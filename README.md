# r9-isbn-ci-dotnet

[![Build Status](https://dev.azure.com/paul0287/CSD-CI-2020-03/_apis/build/status/paul-r9.CSD-CI-2020-03?branchName=master)](https://dev.azure.com/paul0287/CSD-CI-2020-03/_build/latest?definitionId=6&branchName=master)

[Azure DevOps Project page](https://dev.azure.com/paul0287/CSD-CI-2020-03)

- Some tests against ISBN10 in place to verify azure devops build

- BookInfoProvider
  - Defines the Provider interface
  - Has the data object BookInfoProvider
  - Has an in-memory test double, ISBNService, that ISBNFinder can be tested against
  
- ISBN
  - ISBNFinder - the System Under test
  
- ISBN.tests
  - xUnit tests for the ISBNFinder class
