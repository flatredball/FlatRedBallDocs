## Introduction

The LoadAsynchronously property tells Glue to load all content in Global Content Files asynchronously. In other words, the first screen (StartUp Screen) will load even if Global Content Files hasn't yet finished loading its content.

![](/media/2017-06-img_593ad221664fe.png)

By default LoadAsynchronously is false, which means all content must finish loading before the first screen is displayed.

## Content required by Screen

LoadAsynchronously is safe to use even if the first screen depends on content in **Global Content Files**. If any code asks the GlobalContent object for a file, but the file has not yet loaded, the primary thread will be stopped until the content is loaded. Therefore, the content will either already be loaded (since it may have been loaded asynchronously prior to the request for the content) or the primary thread may pause until that particular content is finished loaded. If the primary thread is paused, it will be resumed once the requested content has been loaded, rather than waiting for all files in GlobalContent.
