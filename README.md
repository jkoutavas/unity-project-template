# unity-project-template

_Last updated March 23rd, 2022_

A Unity project template for Heynow Games.

This is a work in progress which lays out what'll become the template for Unity projects I do going forward. Here's what it has:

1. Latest Unity 2022 beta sample project at `{clone-root}/Project` using Lurking-Ninja's approach for laying out the project: "I keep a `_<projectname>` folder, where my stuff lives, outside of this the plugins and assets can go haywire if they want. I don't care." (Ref: [This Unity Forum Post](https://forum.unity.com/threads/mature-project-folder-structure.654694/))
2. A "GameEngine" directory at `{clone-root}/GameEngine/src` separated completely from the Unity Project. This allows independent development and testing of the game's logic. The Unity project integrates with it via a debugable .dll Plugin.
3. Using [cs-util-com/cscore](https://github.com/cs-util-com/cscore)'s Redux-like [Immutable Datastore](https://github.com/cs-util-com/cscore#immutable-datastore) to handle model, store, actions, and reducers.
4. xUnit.net based unit testing at `{clone-root}/GameEngine/test` for the GameEngine (using [Getting Started with xUnit.net](https://xunit.net/docs/getting-started/netfx/cmdline) as a setup guide.
5. A dotnet console app at `{clone-root}/Console` for interaction with the GameEngine, again, separate from Unity. Allowing for an independent "front end" to the GameEngine which validates the GameEngine as purely a backend without Unity dependencies. The Console is using the [Command Line Parser](https://www.nuget.org/packages/CommandLineParser/) nuget package to provide a REPL to interact with the GameEngine.
6. An example `omnisharp.json` file (`example.omnisharp.json`) which can be placed at `~/.omnisharp/omnisharp.json` or in your project's tree for a consistent coding style.

Have a look at the merged PR descriptions for some further details about these features.


(this needs refinement) To put the GameEngine's .dll into the Unity project (at `{clone-root}/Project`):

```
cd {clone-root}/GameEngine/src
dotnet publish -c Debug -o ../../Project/Assets/_Project/Plugins
```
