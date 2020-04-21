# Just one more turn

An strategy Civilization-like game.

# Guidelines

## Commit Message

Each commit messages consists of a header and a body.
The header should follow the Angular convention: a type, a scope and a subject:

```
<type>(<scope>): <subject>

<body>
```

The header is mandatory and the scope of the header is optional.

Any line of the commit message cannot be longer than 100 characters! This allows the message to be easier to read on GitHub as well as in various git tools.

### Sample
```
feat(map): create map

- Creates the game map
```

### Type

Must be one of the following:
- build: Changes that affect the build system or external dependenciers
- docs: Documentation
- feat: A new feature
- fix: A bug fix
- perf: A code change made to improve performance
- refactor: A code change that neither fixes a bug nor adds a feature. Often is related to changes made in order to organize or decoupling the code following SOLID principles.
- style: Changes that do not affect the meaning of the code (white-space, formatting, missing semi-colons, etc)
- test: Adding missing tests or correcting existing tests

### Scope

The scope should be the name of the section where the change was made. A couple of samples:
- hex: Changes made to the Hex module
- input: Changes on the Input module
- interact: Changes on the interaction of the player
- AI: Changes on Artificial Intelligence
- city: Changes on the City module
- unit: Changes on game units module
- civ: Changes on civlizations module

### Subject

The subject contains a succinct description of the change:

use the imperative, present tense: "change" not "changed" nor "changes" don't capitalize the first letter no dot (.) at the end

### Body
Just as in the subject, use the imperative, present tense: "change" not "changed" nor "changes". The body should include the motivation for the change and contrast this with previous behavior.
