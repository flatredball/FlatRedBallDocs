# UnloadsContentManagerWhenDestroyed

### Introduction

UnloadsContentManagerWhenDestroyed is a property which controls whether a given Screen unloads its ContentManager when the Screen is destroyed. Most Screens should have this value set to 'true' because Screen transitions usually represent when content can be safely unloaded to free up RAM for new content. However, this can be false if the Screen is going to be visited frequently and the cost of holding content in RAM is offset by the savings in load time.

