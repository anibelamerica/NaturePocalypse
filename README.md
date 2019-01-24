# NaturePocalypse

### Description
NaturePocalypse is an Ada Developer's Academy C10 capstone project. Capstone projects are completed within one month requiring the development of an application using at least 3 technologies new to the Adie.

This AR app is created using Apple's ARKit and Unity in order to populate the scene through iPhone or iPad camera lens. The goal is to create a mixed reality experience where the viewer can see natural elements in their surroundings.

Scenes are populated via ARKit's plane detection: randomized "ground" objects are instantiated with a minimum spacing on horizontal surfaces. The same can be said for "wall" objects. With Permissions given for media saving, snapshots can be taken and saved to the camera roll.

#### __In-app description__

>Nature-pocalypse is an AR app that tips the scale in nature’s favor. Look through the camera into a fictional reality of what would happen if we stepped back and gave the earth room to breathe. In this alternate universe, will the view you see be one of overgrowth? Or might it actually be one of balance?

### Setup

__Technologies used__
- [Unity, version 2018.3.1f1 Personal](https://store.unity.com/)
- [ARKit plugin](https://bitbucket.org/Unity-Technologies/unity-arkit-plugin) via bitbucket (it is deprecated in the Asset store)
- [Xcode 10.1](https://developer.apple.com/xcode/)
- [Visual Studio Community](https://visualstudio.microsoft.com/vs/community/) for C# scripts

For importing .blend models, [Blender](https://www.blender.org/) version 2.79b was used. Version 2.8 in beta at this time though due to asset license restriction, some may find it useful to download this version as it can handle .gltf files.

__Installfest__

You will need to install Unity3D and XCode:

  For Unity3D, go the [Unity store](https://store.unity.com/) and download Unity. This app was created using Unity Personal.

  Installing XCode requires an Apple ID and developer account. You _DO NOT_ need to pay for the service. _However_, development of this app required multiple deployments from XCode (as this was a learning experience) that quickly exceeded the bundle identifier limit.  Downloading/updating Xcode is straightforward but can take a long time.

  ARKit is deprecated from the Unity Asset store. You can download the package from [Bitbucket](https://bitbucket.org/Unity-Technologies/unity-arkit-plugin). This package comes with example scenes and ARKit scripts. There are likely better ways but I found it worked best for the duration of this capstone, to unzip the file and drop the entire plugin into the Asset folder. Modifications for the UnityARHitTestExample.cs were made for the development of this app. See modified script UnityARHitTestExampleModified.txt and _after_ importing the plugin, open UnityARHitTestExample.cs copy pasta this code over the original.

__Hardware Limitations__

ARKit needs a minimum iOS version of 11.3 to function.

__Asset Limitations__

Art, Audio, Font, Materials, Icons, 3D models, and additional plugins are not included in this repository in order to keep with redistribution requirements. Sources and relevant links are listed below. Feel free to substitute assets.

1. <b>Logo</b>
  - Ada C10 Duck by Dionisia

2. <b>Icons</b>
  - Simple Vector Icons by Unruly Games from Unity Asset Store
  - Pine, Palm, and Prickly Pear Icons made by [Freepik from www.flaticon.com](www.flaticon.com)

3. <b>Font</b>
  - Taviraj font designed by Cadson Demak from [Google Fonts](https://fonts.google.com/)

4. <b>Forest 3D models</b>
  - Grass, Iris, and Thistle by [Viz-People from Viz-People Blog](https://www.blog.viz-people.com/blog/free-3d-model-grass/)
  - Various forest vegetation by Fredrik Larsson from the Unity Asset Store.
  - Pine Trees by Laxer from the Unity Ansset Store
  - Climbing Ivy by DEXSOFT-Games, 3DModels-textures from the Unity Asset Store

5. <b>Desert 3D models</b>
  - Various desert plants by Lemuria from the Unity Asset Store
  - Cactuses by Useful3D from the Unity Asset Store
  - Additional cacti by Dmitriy Dryzhak from the Unity Asset Store

6. <b>Tropics/Coast</b>
  - Various tropical plants by Creative Minds from the Unity Asset Store
  - Model 47 - Loggerhead sea turtle and Model 50 - Hatchling Hawksbill sea turtle by Digital Life 3D from Sketchfab, [CC Attribution -NonCommercial](https://creativecommons.org/licenses/by-nc/4.0/)
  - Dancing Crab - Uca Mjoebergi by Bohdan Lvov from Sketchfab, [CC Attribution](https://creativecommons.org/licenses/by/4.0/)
  - Starfish by Ian Christopher from Sketchfab, [CC Attribution](https://creativecommons.org/licenses/by/4.0/)

7. <b>Chaos 3D models</b>
  - Cat by POLYDACTYL from Unity Asset Store
  - Spider by [PRISM BUCKET] from Unity Asset Store

8. <b>Sound Loops</b>
  - Thunderstorm by EPIC SOUNDS AND FX from Unity Asset Store
  - Ocean Beach Waves and Forest Scrub Ambience with Birds by SOUND SPARK LLC from Unity Asset Store
  - Wind Whistle by JOHN LEONARD FRENCH from Unity Asset Store

__Setup__

Fork, clone this repository to your directory. Open Unity, click "Open" and navigate to the cloned directory and open the folder. Import ARKit (drag and drop the folder into Assets).

For the missing assets, you can find many of these or similar items for free on the Unity Asset store or on the web. If you end up acquiring new 3D models with a different coordinate orientation, you may find it useful to make these a child of an empty game object. The empty game object will have Unity's coordinate system and then you can rotate the original model so they can be oriented accordingly in virtual space. Also, for all ground, tree, and wall prefabs make sure to make colliders inactive (or remove component) as these will affect detection and instantiation.

__Scenes__
1. <b>Main Menu</b>

  Restrictions on this scene will be from the sprites used to decorate the Canvas and font. Font will have to be acquired and can then be used directly in text UI components. However, resolution can suffer greatly. Instead, use TextMesh Pro's Font Asset Creator to make a font asset. Then use Text Mesh Pro Text UI for higher-resolution text.

2. <b>Loading Screen</b>

  No restrictions but was hoping to make this fade in and out upon load.

3. <b>Forest, Desert, and Tropics</b>

  HitCubeParent will require a hit transform, various ground, tree, and wall prefabs (you can just choose and put them in all slots). Tree prefabs do not need to be specific and will be reworded in future versions.

  Set your spawn check min range via the slider or typing in a float. This number sets the minimum distance between ground objects to ground objects and wall objects to wall objects.

  In Audio, select an audio clip for audio source that fits the scene's theme

4. <b>Chaos</b>

  This one's just for fun. Make the same modifications as you would for any of the other scenes. I included cats and spiders with a thunderstorm background. Have fun with this one!

__Additional Information__
Creation of this app was documented in the Development_Notes. Refer to it for week by week goals and issues that were encountered.

NaturePocalypse will undergo changes in future versions. Some improvements include:
- Better asset loading between scene changes
- Diversified assets and better assignment in inspector

Some stretch goals include:
- Integrating GPS for country code and potentially querying/developing APIs for additional information based on general region/nearby features/country code, etc.
- Learning model creation and populating the scene with endangered species for that region.
- Exploring other depth-sensing devices and combining this with a grass-on-everything look

__Planning Resources and Notes__
1. [Product Plan](https://gist.github.com/anibelamerica/eefdb4893ea471ef2fc3a347af27d07f)
2. [Modified UnityARHitTestExample](https://github.com/anibelamerica/NaturePocalypse/blob/master/UnityARHitTestExampleModified.txt)
3. [Development Notes](https://github.com/anibelamerica/NaturePocalypse/blob/master/Development_Notes.md) - tutorials and ramping up process listed here
4.  [The World Without Us](http://worldwithoutus.com/index2.html) by Alan Weisman - for a novel way to visualize future versions of the app
4.  Team Unity Support Group: Since this was a nature app, Be-leaf me when I sea that you ROCK!
