# BoardGameIdea
 A random board game idea I got
 I wanted to have a mix of multiple ancestral games :
  - No RNG like chess
  - A 2D grid where position matters
  - A way to do like mahjong, combining multiple ways of scoring points

# The game itself

Starting from white, each player takes turn placing a circles on a square grid.
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
This produces a recursion function to score points, trying to compute the maximum points depending on avaible shapes
When a lot of tiles are placed, this become an issue as it gets exponentially slower (Issue #2)

A different way to count points exists, where every tiles can be used in every pattern, which runs way faster (has no recursion), but is quite hard for a human to count points
