# Refactor

### User Input
A single markdown text box to capture the description from the user about what they want Genval to do with the content they scope in the Scope Patterns section.
In addition to the markdown textbox which describes the task they want to perform, we also need to capture in another markdown text box the Scope Patterns, use this as a default:
```text Scope Patterns
*
!.*
```
Those expressions mean: include everything, except anything that starts with a period "." like hidden files and folders.
It's important to include the opening and closing tripple asterisk along with the `text Scope Patterns` part in the template. 
This is important because Genval will look for these opening and closing patterns to find the Scope Patterns patterns to use.

Finally we need to capture the Source Branch the user wants to create a branch from while Genval works on this request.
You should provide a single text box to capture this. You can default the value to `main`. 
Let the user know they need to set it an actual value of their branch name from the repository they are working in. 
