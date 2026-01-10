# Overview of the solution

## code\Thesaurus

Contains an interface for a thesaurus.

## code\Thesaurus.Core

An implementation of the thesaurus interface, with an emphasis on rudimentary business logic:
* null is never allowed.
* Adding a list of synonyms requires that it must contain at least two words/elements.

## code\InMemoryThesaurus

A full implementation of the thesaurus, including storage.

### Features
* Synonyms can be added to and read from the thesaurus.
* When reading synonyms or the entire list of words, they are sorted in ascending/alphabetical order.
* Searching for synonyms is case-insensitive. If a word is stored e.g. as "Car", you will find synonyms for "car".

### Limitations

* Words are stored in memory and thereby not stored in e.g. a database.
* The caller/user of the thesaurus is expected to handle e.g. prevention of storing duplicate synonyms. Words are stored as they are provided, no filters are applied. Storing mixed-case words might result in duplicate entries.
* An individual word cannot be updated nor deleted.

## tests\InMemoryThesaurus.Tests, tests\Thesaurus.Core.Tests

Tests that aims to serve as a specification for business logic and the in-memory thesaurus implementation.

Run ```dotnet test``` to execute test suite.
