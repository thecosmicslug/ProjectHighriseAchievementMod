
Installation:

	Get the compiled release, unzip into Project Highrise directory.
    OR: manually install BepInEx (https://github.com/BepInEx/BepInEx) to Project Highrise directory. 
    
    Extract ProjectHighriseAchievementMod.dll to BepInEx/plugins directory.

    Verify that running the game creates BepInEx/LogOutput.log which contains a line "[Message:ProjectHighriseAchievementMod] Mod is active!"


Development:

    Edit SteamDir.user  to point to steam libary location. (for Project Highrise installation path)
    
    Publicize Assembly-CSharp.dll so we can access the methods, and place in ./deps/lib/
	(https://github.com/CabbageCrow/AssemblyPublicizer)
    Assembly-CSharp_publicized.dll is only needed for compilation, we don't have to distribute it.. it would be against copyright anyway.

    DLL will compile to BepInEx/plugins in Project Highrise directory!

