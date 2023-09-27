## First, an apology

If you're used to looking at the FlatRedBall wiki you might be wondering why the first section is not "Introduction". The reason for this is because we're not happy with the way the following tutorials have turned out, and we would like to apologize for this.

Normally our tutorials follow a pretty standard format. We introduce something, provide some simple code which can be dropped in your Game class, then finally show a screen shot of what the result of that code is. Only in the rarest (and most complicated) of situations are you required to create a new file to support the logic which is being presented in our tutorials - at least to get it working initially. Of course, eventually you will probably want to move things out of Game later to maintain a clean code base, but that's beside the point. Normally it's a copy/paste in Game and you're done!

But not this time...

The following set of tutorials will be far more complicated requiring **seven new classes** and **two new projects**. And yes, we are very sorry about that. But please read on so we can explain why this is the case, and so we can pass the blame just a little bit.

## What you want

These tutorials enables the following:

-   Ability to load from file to your runtime object. In other words, ability to create tools to edit your objects.
-   Ability to load through content pipeline to your runtime object.
-   Ability to distribute your game to XNA end users.
-   Ability to run your game on the Xbox 360.

If any of the above abilities were not required, then this tutorial would be greatly simplified. But to be able to do everything at the same time requires a process that is very complicated relative to the usual FlatRedBall tutorials.

## Why are things so complicated?

This is where we pass the blame for how complicated the following tutorials will be. In short, XNA is a **fantastic** API, but when it comes to the content pipeline, Microsoft has failed terribly.

The first failure on Microsoft's part is to not include from-file loading for some of their content on the PC, and virtually no from-file loading for any content on the 360. That means that if you want to make a tool, you have to jump through a lot of loops to get from-file working on the PC for through content pipeline-only types (like Models).

Furthermore, the libraries which perform the content pipeline loading are not available to users who have only the end-user runtime version of XNA (or users on the 360). Distributing these libraries is against the licensing agreement for XNA on the PC, and is completely not an option at all on the 360.

These two facts make our solution for content far more mangled than it would be otherwise. The ideal for us is to be able to do everything from file on every system (avoid the content pipeline altogether), or have all pipeline libraries available to all users (avoid having to make multiple projects).

Don't like how complicated Microsoft has made things? Then help our cause by voting on adding from-file loading for all content here:

[https://connect.microsoft.com/feedback/ViewFeedback.aspx?FeedbackID=394594&SiteID=226](https://connect.microsoft.com/feedback/ViewFeedback.aspx?FeedbackID=394594&SiteID=226)

Simply click on the 5 stars on the top left to rate it very important.

## Finally, we create our projects

Despite our complaints about the content pipeline, we think that being able to distribute games on the Xbox 360 is amazing. So, this tutorial will show how to work around the limitations of the content pipeline so you can achieve all of the functionality you need for development while maintaining the ability to distribute your game.

### Create the new projects

We assume that at this point you have a running FlatRedBall XNA project. At this point we will add all of the projects that we need for the rest of this tutorial.

We will be adding files to these projects and I'll be referencing them by their names established in this tutorial, so it might be beneficial to match names in your project.

1.  Right click on your Solution in the Solution Explorer, select "Add" -\> "New Project...". Select "Windows Game Library (3.0)". Name your project something like **"FromFileProject"**.
2.  Repeat the previous step to create a content pipeline project. Right click on your Solution in the Solution Explorer, select "Add" -\> "New Project...". Select "Windows Game Library (3.0)". Name your project something like **"ContentPipelineProject"**.

Next, the projects need to reference each other. Add the following:

| Project                                                            | should include reference to                       |
|--------------------------------------------------------------------|---------------------------------------------------|
| Game project                                                       | FromFileProject, FlatRedBall                      |
| Game Content project (Content project embedded in the Game project | ContentPipelineProject, FlatRedBall.Content       |
| FromFileProject                                                    | FlatRedBall                                       |
| ContentPipelineProject                                             | FromFileProject, FlatRedBall, FlatRedBall.Content |
