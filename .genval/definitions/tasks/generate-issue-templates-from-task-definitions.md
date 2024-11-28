# Generate Issue Templates from Task Definitions

### Processing Instructions
I want you to look at each markdown file found in  the `.genval/definitions/tasks` directory. 
Each file will be used to generate a Github Issue Template in YAML which we'll name like this:
`.github/ISSUE_TEMPLATE/{task-code}.yaml` where `{task-code}` is a unique code of the task definition markdown file you are processing (without the .md extension). 

Use your best judgement about how to create a Github Issue Form user input elements that is user friendly and helpful for items described in the 
`### User Input` section of the task definition file. This is where you can break up the description into individual input elements.
Be sure to set default values, if you think there should be default values.
Use the `value` attribute to set a default value, not `default`.

For the `### Processing Instructions` section you can just create a single textarea input box with the instructions formatted as markdown.
Be sure to use textarea (not markdown) as the element type, because we need the value to come through when the user submits the issue.
Markdown element types don't actually come through to the issue body when you create an issue, so we have to use the textarea element type.

Title: Use the following pattern when generating the title:
`{task-title}` where `{task-title}` is the a title for the type of task you are working with.

If the definition file includes `### Scope Patterns` you should include those as they are written, in a textarea. 
It's important to include the opening and closing tripple asterisk along with the `text Scope Patterns` part in the template. 
This is important because Genval will look for these opening and closing patterns to find the Scope Patterns patterns to use.
Make sure to use a textarea element for the Scope Patterns and format the contents as markdown with the opening and closing asterisks.

Note: When adding Markdown you are required to specify a `value` attribute, but you can not specify a `label` attribute. So any markdown text should be set in the `value` attribute. 
Also `default` is not a valid attribute for input types, you can only use `value` to specify a default value, you can NOT use `default`.

### Scope Patterns
This should be presented as a textarea with this literal value:

```text Scope Patterns
.genval/definitions/tasks/*.md
.github/ISSUE_TEMPLATE/*
```

It's important to include the opening and closing tripple asterisk along with the `text Scope Patterns` part in the textarea.

Do not add a "Code of Conduct" or any sort of "Opt In" or "Confirmation" elements, we don't to bother users with additional imagined requirements, just stick to what's defined in the task definition.
