# Writing Documentation

### Introduction

This page provides information about how to maintain and write new documentation. Following the guidelines in this page helps keep the documentation organized and consistent.

### Screenshots

Screenshots in FlatRedBall are taken with ShareX. If a screenshot does not require additional markings such as arrows or boxes, then any technology can be used to take a screenshot, including regular Windows snipping tool.

However, screenshots often require additional markings. For consistency we recommend using ShareX which can be obtained at [https://getsharex.com/](https://getsharex.com/)

#### Use Rounded Red Rectangles to Draw Attention to Important UI

User ShareX's default rectangles to draw attention to UI elements. The following screenshot could be used to show the user how to navigate back in the selection stack.

<figure><img src="../.gitbook/assets/image (3) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>Red rectangle highlighting UI</p></figcaption></figure>

Optionally, consider using arrows to draw the user's attention if the UI is small or otherwise difficult to find.

<figure><img src="../.gitbook/assets/image (4) (1) (1) (1).png" alt=""><figcaption><p>Arrow used to draw the user's attention to a button</p></figcaption></figure>

#### Use Arrows When Multiple Clicks are Needed

Use arrows and rectangles to the reader through multiple clicks. For example, the following screenshot shows how to set the Movement Speed on a Player in the Variables tab:

<figure><img src="../.gitbook/assets/image (5) (1) (1).png" alt=""><figcaption><p>Arrows used to guide the user through multiple clicks</p></figcaption></figure>

Use curved arrows to guide user through multiple clicks between UI elements which are near to each other. The following screenshot tells the user to click both the ICollidable and IDamageable checkboxes:

<figure><img src="../.gitbook/assets/image (6) (1).png" alt=""><figcaption><p>Curved arrows used to connect UI elements which are near each other</p></figcaption></figure>

#### Keep Screenshot Size Small

Screenshots should be the minimum size possible while providing the necessary information to the user.&#x20;

For example, consider a screenshot which displays a CircleInstance and its Variables tab. The following screenshot is a good size and shows the information clearly.

<figure><img src="../.gitbook/assets/image (3) (1) (1) (1) (1).png" alt=""><figcaption><p>Minimum information shown for CircleInstance and Variables</p></figcaption></figure>

Do not show large windows since it can make text difficult to read and it does not focus the reader's attention on important parts of the image.

<figure><img src="../.gitbook/assets/image (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>This screenshot is too big</p></figcaption></figure>

#### Hide Irrelevant Parts in Screenshots

If a tab is not important for the screenshot, it should be moved or reduced in size. This is especially important for the bottom section of the UI. Keep the output tab either hidden or clear of input.

The following screenshot includes additional output which draws the reader's attention from the important parts of the screenshot, so avoid doing this.

<figure><img src="../.gitbook/assets/image (2) (1) (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>Avoid including output window or other irrelevant parts of the screenshot</p></figcaption></figure>

#### Take Entire-App and Window Screenshots Over a Solid-Colored Background

Screenshots can bleed their backgrounds at the edges or corners. This can be distracting. Take all screenshots over a solid colored background.

For example, a screenshot of the create entity window might be taken over a black background. The following image shows the surrounding background:

<figure><img src="../.gitbook/assets/image (7) (1).png" alt=""><figcaption><p>Location of the Add Entity window over a black background</p></figcaption></figure>

Taking a screenshot over other windows can result in distracting edges showing in the screenshot. For example, consider the following location for a screenshot:

<figure><img src="../.gitbook/assets/image (8) (1).png" alt=""><figcaption><p>Screenshot taken over other windows</p></figcaption></figure>

If we zoom in to the edges, we can see that the background shows on the screenshot as shown in this zoomed in image:

<figure><img src="../.gitbook/assets/image (9) (1).png" alt=""><figcaption><p>Background bleeding through the screenshot</p></figcaption></figure>

#### Take Screenshots of the Entire App When Introducing Concepts

Readers may not be familiar with FlatRedBall, Visual Studio, or other apps, so when beginning a document, include full-app screenshots to help the user orient themselves.

For example the following could be an image introducing where entities are stored in FlatRedBall:

<figure><img src="../.gitbook/assets/image (2) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>Show entire FlatRedBall Editor screenshot to orient the reader</p></figcaption></figure>

Once the reader has been shown full app in a screenshot, additional screenshots can show a subsection. For example, the following screenshot may emphasize the different entity icons.

<figure><img src="../.gitbook/assets/image (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>Entity icons emphasized in a screenshot which does not show the entire app</p></figcaption></figure>

#### Exclude the Cursor From Screenshots

By default ShareX includes the Windows cursor in screenshots. Unless it is important for the screenshot, make sure to move the cursor away from the application so that it doesn't show in the final image. Including the cursor can cause confusion for the reader since they may mistake the cursor in the screenshot for their own cursor.

The following image shows the cursor included in a screenshot.

<figure><img src="../.gitbook/assets/image (2) (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>Screenshot with a cursor - don't do this</p></figcaption></figure>

