# A random board game idea I got
I wanted to have a mix of multiple """ancestral""" games :
  - No RNG like chess
  - A 2D grid where position matters
  - A way to play just like mahjong, combining multiple ways of scoring points

# The game itself

Starting from white, each player takes turn placing circles on a square grid.
You score points if you create specific shapes with your placed tiles

![An example where white scores one point doing the first pattern shape](https://i.imgur.com/dGuUFE3.png)

*An example where white scores one point doing the first pattern shape*

You can easily tweak settings in the Statics file :
- The grid width
- How much times players can play
- Patterns overlap
- Patterns and how many points they do score

## Patterns overlap

A tile by default can be used in one and only one pattern/shape
This means there is a recursion function to score points, trying to compute the maximum points depending on avaible shapes (basically looking for the maximum score in every branches to maximize your score)
When a lot of tiles are placed, this become an issue as it gets exponentially slower due to the recursion (Issue #2)

A different way to count points exists, where every tiles can be used in every pattern, which runs way faster (has no recursion), but is quite hard for a human to count points

## Notes!

The project is old and outdated. Used to work fine, but is now an old .NET version and used WPF. I'm not fully on Linux and I can't really rerun/upgrade the project especailly for the front part....

Best would be to rewrite it, which I've started doing in a webapp so it's hosted online, but I stumbled again on the pattern overlap issue. This is definitely a P=NP issue and I guess for now, only the version where a tile can be part of multiple pattern works. I suppose there's a way to have shortcuts in counting points, but that won't be a 100% accurate.

An another way to "fix" it is to probably let the user count and place the shapes at the end, just like if you'd play it IRL and calculate your score without any computer calculation.
