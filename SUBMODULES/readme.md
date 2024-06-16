## Development Directions ##

Note that Visual Studio 2022 has a constraint that it only lists Repos that contain Visual Studio 
*solution file (*.sln)-based* repositories, and does not recognise *folder-based* solutions.

This in effect means that changes within `BASE.Documentation` -- which is a *folder-based* set of *.md files -- will not be made apparent
in visual studio.

One can hope this be resolved in a later version of Visual Studio -- but there is no certainty of this. 