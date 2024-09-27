# itch.io

### Introduction

FlatRedBall Web games can be uploaded to itch.io. This guide provides a walkthrough for uploading your game.

{% hint style="info" %}
You must first publish your game through Visual Studio before uploading it to itch.io. For more information, see the [Distribution](./#distributing-flatredball-web-games) page.
{% endhint %}

### Uploading a Build

Once you have published your build through Visual Studio, you should have a folder similar to the following image:

<figure><img src="../../.gitbook/assets/image (155).png" alt=""><figcaption><p>Example published web project</p></figcaption></figure>

Open the wwwroot and create a .zip file with the contents.

<figure><img src="../../.gitbook/assets/image (160).png" alt=""><figcaption><p>Compress the contents of your wwwroot</p></figcaption></figure>

Next, log in to your itch.io account and select the option to **Upload new project.**

<figure><img src="../../.gitbook/assets/image (156).png" alt=""><figcaption><p>Select the Upload new project option</p></figcaption></figure>

Fill in your project's information, but be sure to set **Kind of project** to **HTML**.

<figure><img src="../../.gitbook/assets/image (157).png" alt=""><figcaption><p>Select the HTML option</p></figcaption></figure>

Click the Upload Files option and select your .zip file that you created earlier.

<figure><img src="../../.gitbook/assets/image (158).png" alt=""><figcaption><p>Click the Upload files button to upload a .zip file</p></figcaption></figure>

Check the **This file will be played in the browser** option.

<figure><img src="../../.gitbook/assets/image (159).png" alt=""><figcaption><p>Check the option to indicate that this game is played in the browser</p></figcaption></figure>

You can specify the resolution for your project. Typically you should have your project run at a multiple of your native resolution so that pixels draw correctly. If your game uses a smaller resolution for a pixel aesthetic, you may want to set the resolution at two or three times the native size.

For example, consider a game which is set to a resolution of 398x224:

<figure><img src="../../.gitbook/assets/image (2).png" alt=""><figcaption><p>Resolution set to 398x224 in the FRB Editor</p></figcaption></figure>

You can set the game to render at 300% scale by setting the size to 1194x672:

<figure><img src="../../.gitbook/assets/image (1) (1).png" alt=""><figcaption><p>Setting game resolution in itch.io</p></figcaption></figure>
