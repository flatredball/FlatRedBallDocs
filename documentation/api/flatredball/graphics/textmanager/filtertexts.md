## Introduction

The FilterTexts property controls whether Texts are rendered. The TextManager can set this value and it will override the value set in [the GraphicsOption's TextureFilter property](/frb/docs/index.php?title=FlatRedBall.Graphics.GraphicsOptions.TextureFilter.md "FlatRedBall.Graphics.GraphicsOptions.TextureFilter").

## Default Value

The default for TextManager.FilterTexts is false, while the default value for [the GraphicsOption's TextureFilter](/frb/docs/index.php?title=FlatRedBall.Graphics.GraphicsOptions.TextureFilter.md "FlatRedBall.Graphics.GraphicsOptions.TextureFilter") is on (technically it's an enumeration, but for simplicity we'll say that filtering does occur). The reason for this is because Text which is drawn to-the-pixel does not need to be filtered. Filtering text that is drawn to-the-pixel will make it look fuzzier than normal.

However, you may want to turn FilterTexts to true if you plan on drawing Texts at larger-than-pixel-perfect to reduce their pixellated look.
