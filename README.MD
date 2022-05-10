## About:

Project Highrise has Steam workshop support for custom rooms in our towers,
but using them will disable achievements. 

After seeing a game-mod called `ProjectHighrise-TDEnhancementPack`
I knew it was possible to create more than just custom rooms, and I owe many thanks to the author for sharing his code!

I have never modded a game that doesn't support loading mod dlls, that is why this project uses BepInEx.
Using the Harmony hooking libary we are able to enable achievements when using mods! 

Thanks to: 
* `BepInEx` (https://github.com/BepInEx/BepInEx)
* `Harmony` (https://github.com/pardeike/Harmony)
* `ProjectHighrise-TDEnhancementPack` (https://github.com/alextd/ProjectHighrise-TDEnhancementPack)

## Installation:

* Get the compiled release, unzip into Project Highrise directory.

	OR: manually install `BepInEx` (https://github.com/BepInEx/BepInEx) to Project Highrise directory. 
    
* Extract ProjectHighriseAchievementMod.dll to `BepInEx/plugins` directory.

* Verify that running the game creates `BepInEx/LogOutput.log` which contains a line

   `"[Message:ProjectHighriseAchievementMod] Mod is active!"`


## Development:

* I use VSCode on linux for development, scripts will need to be altered for Windows.

* Edit `SteamDir.user`  to point to steam libary location. (for Project Highrise installation path)
    
* Publicize `Assembly-CSharp.dll` so we can access the methods, and place in ./deps/lib/

	(using https://github.com/CabbageCrow/AssemblyPublicizer)

* DLL will compile to `BepInEx/plugins` in Project Highrise directory!
