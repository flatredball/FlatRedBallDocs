## Introduction

The Fill method sets the entire ImageData to be the same color. For example, to make the entire ImageData black, use the following call:

    imageDataInstance.Fill(Color.Black);

## Performance

Keep in mind that filling an ImageData is much slower than rendering to a texture. If you are working with large ImageDatas, avoid calling Fill on them frequently for performance reasons.
