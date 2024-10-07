# Contributing Code (Pull Requests)

### Introduction

Pull requests are a very important way to contribute to the growth and maintenance of FlatRedBall. This document discusses how to create pull requests which will maximize their benefit to the community and minimize effort needed to accept the PR by other maintainers.

### Selecting a Feature or Bug

If you're not sure what to work on, the best place to start is the Discord channel. FlatRedBall maintainers are usually available to discuss proposed changes. Alternatively, issues are regularly added to the Github repository, and some have the `Up For Grabs` label: [https://github.com/vchelaru/FlatRedBall/labels/Up%20For%20Grabs](https://github.com/vchelaru/FlatRedBall/labels/Up%20For%20Grabs)

Even if you do decide to work on an issue which has previously been defined as an issue, it's best to discuss the change in Discord to prevent duplicate work and to make sure priorities and approaches align with the other maintainers.

### Github Issues

Most work should be tied to an issue on Github unless the change is very minor. Examples of changes which do not require issues include:

* Fixing typos to variables inside a method
* Adding XML documentation (see below)
* Fixing typos to UI elements in the FlatRedBall Editor
* Minor styling fixes to UI elements in the FlatRedBall Editor

If your proposed change is not covered in an existing issue, you can make an issue on Github with the proposal. Since FlatRedBall is open source, you are free to do anything in your own Fork; however, we recommend waiting for a response to the issue either in Github or on Discord before doing too much work on your issue unless you are highly confident that it will be accepted.

See below for suggestions on creating new issues.

### Forks and Branches

If you have not been given write access to the main repository, then you should fork the FlatRedBall repository to work on the change you are making. If you have been given write access, then you should create a new branch for the feature.

The branch name should match the issue number in Github and should include at least a minor suggestion of the feature being worked on. For example, consider the following issue:

{% embed url="https://github.com/vchelaru/FlatRedBall/issues/1533" %}

The branch for this issue was titled `1533-warnings`.

### Testing your Changes

All changes should be tested prior to merging a pull request. The type of tests needed depend on the nature of your changes.

* If you are making a game, use of your code in your game may be sufficient testing depending on the size and complexity of the game.
* If you do not have a game for testing the changes, you should open, generate, and run the auto test project to verify that the change does not introduce problems. You may also be asked to add additional tests to the auto test.
* If your change is particularly valuable, existing FlatRedBall maintainers may offer to test your branch on an existing project. You should create a pull request to make this process easier.

### General Guidelines

When selecting what to work on and creating pull requests, the following guidelines can increase the changes of your PR being accepted.

#### Discuss Features with Maintainers

Do not work on new features unless you have discusses this change with long-term maintainers of the FlatRedBall engine. Unfortunately most open source contributors do not stick with projects for very long. Any new feature will usually fall on the long-term maintainers, so the discussion of this new feature should be agreed upon by both the initial author as well as those who will keep the feature running for years in the future.

#### Refactors Must be Paired with Feature Work

Refactoring code for the sake of "clean code" will often be scrutinized and may be rejected, especially if the change is large (changes which span dozens of files). Large refactors suggest that the change was made by following a guideline without contextual consideration.

The FlatRedBall code base includes many cases where code is referencing obsolete methods or classes. These violations persist because changing them is not a simple find-and-replace job. Sometimes the violation is necessary and must be marked as such. Other times the violation can be fixed, but the context surrounding the code is complex.

The best way to prove that your change is done with the understanding of context is to perform the refactor while having worked on a feature in the same code. Feature work requires contextual understanding which can help with refactoring.

In sort, **you should understand the context of the code that is being changed. If you do not know exactly why the code is written a certain way, do not touch it!**

#### Perform Tests

Indicate how you have tested your code if you are performing refactors. This can include explaining the steps you have taken when running the code, the projects that you have used to test the code, and confirming that you have run the automated test project.

#### Keep Refactors Small

Small refactors are much easier to review by maintainers. If you submit a large refactor (spanning over a dozen files) it is likely to get rejected.

Of course, this may seem frustrating if you have found an issue that persists across the entire code base which can be solved in an automated manner. Unfortunately this is the nature of large code bases which have nuances and require context to maintain (see the point above). If such widespread issues are found, the existing maintainers should agree that this is a problem. Furthermore, if fixing these widespread issues are deemed a priority, then a feature or fix should be identified to be paired with the refactor. This exercise can help you get the context necessary to make the change.

If you are not willing to do the work needed to understand the context for the change, do not make the change.

#### Avoid Automated Refactoring Tools

While these may seem harmless, automated refactoring tools should be avoided.

These tools have been shown to produce changes in the past which change the behavior of the app, including introducing bugs

These tools often produce very large changes which can be difficult to debug. Practically speaking these tools are useful if you are making a very large change to a code base. As mentioned above these changes are discouraged and will likely be rejected. These changes are usually made without understanding the context.
