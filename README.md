# unity-project-template
A Unity project template for Heynow Games

This is a work in progress which lays out what'll become the template for Unity projects I do going forward. Here's what it has:

1. Latest Unit 2022 beta project. Using Lurking-Ninja's approach for laying out the project: "I keep a "_<projectname>" folder, where my stuff lives, outside of this the plugins and assets can go haywire if they want. I don't care." (Ref: [This Unity Forum Post](https://forum.unity.com/threads/mature-project-folder-structure.654694/))
2. A "GameEngine" directory separated completely from the Unity Project. This allows independent development and testing of the game's logic. The Unity project integrates with it via a debugable .dll Plugin.
3. A console app for interaction with the GameEngine, again, separate from Unity. Allowing for an independent "front end" to the GameEngine which validates the GameEngine as purely a backend without Unity dependencies.

