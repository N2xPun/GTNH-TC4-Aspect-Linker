# GT:NH-TC4 Aspect Linker
This is a tool for helping with Thaumcraft research in the modpack GT:NH.
# How to use?
Select aspects that are "the starts" in the top left box and aspects that are "the ends" in the bottom left box.
Select how far apart the starting and ending aspects are in the spinbox and the sorting type.
The program will calculate "the chain" on changing parameters.
# Why is it made with Godot?
Because, I wanted to.
# How does the sorting work?
 - Unique: Sort aspect chains by the "uniqueness value" (ascending).
 - Complexity: Sort the aspect chains by the "complexity value" (descending).
 - Unique & Simple: Sort the aspect chains by uniqueness (ascending) then complexity (ascending).
 - Entropy: Sort the aspect by its entropy (descending).

## Uniqueness value for a chain
 1. Make an aspect frequency graph from a chain by simply counting how many aspect is in that chain excluding ones that does not exist in the chain.
 2. The uniqueness value is then defined by taking the highest frequency multiplied by the count of aspect in the chain then subtracted by the sum of all frequencies.
 3. This calculation makes it so that the lower the value the more unique the chain is hence the ascending sort.

## Complexity value for a chain
 1. Each aspect has a complexity value (see below).
 2. The complexity value for a chain is simply the sum of all the complexity of each aspect.

## Complexity value for an aspect
 1. Primal aspects have a complexity of 1.
 2. A compound aspect has the complexity of their parents complexity combined.

## Entropy for a chain
 1. Probability is calculated for each aspect in the chain by taking the number of times it appears and then dividing it by the length of the chain.
 2. The probabilities are then used in [the entropy function](https://en.wikipedia.org/wiki/Entropy_(information_theory)) (base 2).
