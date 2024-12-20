---
name: GenVal Refactoring Request template
about: Create a GenVal refactoring request
title: ''
labels: ''
assignees: ''

---

name: Refactor
description: Submit a refactoring request
title: "Refactor: [Brief Description]"
labels: ["refactor"]
assignees: []
body:
  - type: textarea
    id: refactor_description
    attributes:
      label: Refactor Description
      description: Describe what you want Genval to do with the content you scope in the Scope Patterns section.
      placeholder: Enter your refactoring request here...
    validations:
      required: true

  - type: textarea
    id: scope_patterns
    attributes:
      label: Scope Patterns
      description: Specify the scope patterns for the refactoring task.
      value: |
        ```text Scope Patterns
        *
        !.*
        ```
    validations:
      required: true

  - type: input
    id: source_branch
    attributes:
      label: Source Branch
      description: Specify the branch name from which Genval should create a new branch for this refactoring task.
      value: main
    validations:
      required: true
