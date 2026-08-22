---
name: frb-docs-writing
description: How to write FlatRedBall Docs pages, plain and short. Triggers: FlatRedBallDocs repo, tutorials/*.md, glue-reference/*.md, writing or editing GitBook docs pages.
---

# FRB Docs Writing

Style rules for writing or editing pages in the FlatRedBallDocs repo (a GitBook site). Screenshot conventions already live in `contributing/writing-documentation.md`. Read that first. This skill does not repeat it.

## Voice

- Short sentences. Small words. No jargon.
- Present tense, not future. `contributing/writing-documentation.md` already says this ("Do: This button creates a new Sprite" / "Don't: This button will create a new Sprite"). Many older pages still say "will" anyway. Don't copy that habit into new writing.
- Talk to the reader as "you." Slightly conversational, not academic.
- No em dashes. Use a period or a comma instead.
- Cut a sentence if it just restates what the code sample already shows.

## Structure (tutorial pages)

Most tutorial pages under `tutorials/` follow the same shape. Copy it for new pages:

`### Introduction` then `### Main Concepts` (bullet list of what the page covers) then one `###` section per concept, each with a code block followed by one or two plain sentences explaining it, then `### Conclusion` (one line).

See `tutorials/platformer-plugin/wall-sliding-and-jumping.md` for a clean example of this shape.

## Code blocks

Use `csharp` fences. Some older pages use bare fences. Don't copy that. Show the real, current code from the sample project it's teaching, not a simplified stand-in. Readers copy it as-is.
