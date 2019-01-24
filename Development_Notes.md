# NaturePocalypse
Ada C10 Capstone Project - Documentation

### Pre-capstone/Planning

**Week 0:**  
Spend this time getting familiar with the proposed tech stack: Unity3D, ARKit plugin, and C#. As recommended, try to get some of the technology connections functioning, i.e. getting the app onto the phone.

1. Getting familiar with Unity interface, Unity Hub, find resources for education
  - [Unity Fundamentals Tutorial](https://app.pluralsight.com/library/courses/unity-2018-fundamentals/table-of-contents)
    - went up to level design
    - very game focused, not all relevant to project but useful for getting some familiarity with Unity navigation
  - [Unity3D Learn](https://unity3d.com/learn)
    - website was down sometimes
  - Udemy
    - They've got a $10/course sale Black Friday weekend, and around New Year's
  - Youtube videos
2. ARKit: using ARKit plugin in an app, building/running from Unity and XCode, getting app on iphone
  - [ARKit with Harry Potter PortKeys](https://medium.freecodecamp.org/how-to-build-an-app-with-arkit-and-unity-featuring-harry-potter-portkeys-7dd478b02735)
    - Make sure you have the AR script tied to the main camera or the camera with settings
    - For iPhone camera usage, add the privacy key and string into info.plist or add it from Build settings --> Player Settings, Configuration
  - Modifying above scene to place 3D grass models on horizontal detected surfaces
    - Issues with accuracy, sometimes get a floating grass sprite in addition to one on the ground


  _Issues:_
  - Disk space management:
    - Unity + Xcode (especially with multiple windows) + visual studio can be very taxing on PC hardware
    - Upgrading from Sierra to Mojave helped, as well as clearing up space
    - Note that assets and xcode projects take up a lot of memory. Consider backups, additional memory, etc.
  - Deletion of previous Unity versions on phone for subsequent app installs via xcode


### Capstone

**Week 1:**  
Continue familiarizing with tech stack this week. Identify questions as this is when class recommences and PMs/accountability teams will be decided.

1. C#: Need some deeper understanding of accessing gameObjects and components in Unity via C# script
  - [Unity C# Scripting Fundamentals](https://app.pluralsight.com/library/courses/unity-2017-c-sharp-scripting-fundamentals/table-of-contents)
  - Google it!
2. Github and Unity
3. Deploying multiple apps
  - In Info.plist, edit the Bundle Identifier key with the value "$(PRODUCT_BUNDLE_IDENTIFIER)"
  - In Build Settings, go to “Product Bundle Identifier”, click the dropdown arrow, update debug and beta build settings to use a different bundle ID
  - May need to change the display name in the General settings
4. Using the simulator on Xcode
  - Incompatible with ARKit (Camera)
5. Button to Render / Tap to Render
  - Created a button via Canvas -> UI -> Button
    - I anchored this button to the bottom-middle of my screen
    - For Canvas settings, I had the following settings in Canvas Scaler (Script) changed:
      - UI Scale Mode: Scale with Screen Size
      - Reference Resolution: x 360, y 640
      - Screen Match Mode: Expand
    - Resource:
      - [Simple Framework for Beautiful Mobile Game UI in Unity](Simple Framework for Beautiful Mobile Game UI in Unity)
  - In the OnClick() section of the Button gameObject, dragged the component with the script to run if that button is clicked (in my case, HitCubeParent had a chooseGrass script) that sets a boolean to true. This boolean lives in another script component attached the the HitCubeParent. The other script component is the UnityARHitTestExample
    - Resources:
      - [ARKit 1.5 & Unity Tutorial - Vertical Plane detection (Place Paintings on the wall)](https://youtu.be/vqtEHOYX2vw)
      - [ARKit 101: Creating Simple Interactions in Augmented Reality for the iPhone & iPad](https://mobile-ar.reality.news/how-to/arkit-101-creating-simple-interactions-augmented-reality-for-iphone-ipad-0182080/)(Referenced the beautiful line-by-line explanation for C# scripting)
  - In HitCubeParent, my UnityARHitTestExample script has a public variable that holds the chooseGrass script component. This way I can access chooseGrass variables (in my case a renderNow boolean) and use it to run conditional blocks of code.
  - See next week for not-bug-free auto-generation of grass prefabs
6. Get vertical features/limit horizontal features
  - WIP


  _Issues:_
  - Accurate sprite placement in the AR world
    - (Basing off the ARKit ARKitScene) Make sure your prefabs are set to the proper coordinates (for me, I set it the same as my hitcubeparent with x:0, y:0, z:-2.98.). Y position is very important as it'll just appear to be floating
    - still have issues with floating sprite placement, potentially placing sprites on a non-ground plane
  - Accurate orientation of non-Unity asset store 3D models (ones you find from 3rd party sites)
    - Some assets are imported with z-axis as "up" and you'll end up with 90 degree rotated (x direction?) sprites
    - Can import the models into image editing software to correct before re-exporting
    - OR in Unity, create an empty object (this will have the correct orientation for Unity application) and make your prefab a child of this object. Edit child orientation to make this correction and you can save the parent as a new, correctly oriented prefab
  - Can't(?) use Simulator SDK in Xcode
    - incompatibility with ARKit due to camera usage
  - Trying to detect horizontal planes is easy with ARAnchorManager but my instantiation and location logic is hit test. Not sure if this is the best place to put it (will probably pull out into a separate script )

**Week 2:**
Work on MVP: woodland scene. Differentiate between horizontal and vertical detected planes. This is important so that we can autopopulate planes with different assets based on orientation. Fit in C# practice when possible.

1. Auto-generation of grass prefabs
  - The method block run from above casts a ray from the main camera and detects hits with colliders (planes at the moment, will probably need to limit this to just planes), gets the coordinate from the collision and instantiates a grass prefab there
  - Will need to limit creation eventually
2. Differentiate between horizontal and vertical planes
  - Ended up using right or up vector from a triangle on a detected plane. Had to calibrate the value comparison in my method but it works fine for the most part.
  - Not sure if there is a better way to do this (AR Anchor Manager sure is nice but I want that hit point so I went with this route)
  - Euler? Quaternions? These were mentioned online as a way to find orientation.
3. Button to Switch Scenes in test app (throw ball)- PUSH TO FRIDAY OR NEXT WEEK
  - Wasn't able to get the app to switch. Possibly the touch input to throw the ball is getting in the way of the button.
4. Desert scene/level/render mode from scratch
  - Do be aware than Game Object order in the hierarchy is important
5. Limited distance between object instantiation
  - Created a new script for this functionality
  - Script for this has a couple of functions:
    - A function to collect the current game objects of type ground or wall respectively
    - A function that takes in a potential spawn point (hit.point) and used an Enumerable.Any method to see if any of the current spawned objects violate a minRange
    - MinRange is set as a public float, represented as a slider in the inspector
      - [Show public variables as Sliders with [Range(min, max)]](https://unity3d.com/learn/tutorials/topics/tips/show-public-variables-sliders-rangemin-max)
  6. Switch up ground objects being instantiated
    - Likely a better way to do this but I ended up making 3 public variables and dragged different prefabs to it
    - To randomize, I made an array and used Random.Range to choose
  7. Create a button to switch/load scenes
    - Started out with the same exact code and process as in 3. but it worked!

_Issues:_
- Disk space juggling struggles are very real
- Committing to Git is a struggle with asset size, will likely need to redo the repo with finalized assets or none at all
- Working through learning C# and Unity libraries can be a struggle but very rewarding when they work
- Art: if I had a designer or design background, I could leverage this to create better assets for the given scenes/themes
- Objects not being created in the minRange of previous scenes

**Week 3**
Work on Desert scene and UI (Loading screen, main menu, about and attribution). Also, plan for presentations

  1. Create Desert scene
    - modify min range between assets for a more barren look
    - sand piles don't look very good so going for a very vegetative desert (think Sonoran Desert)
  2. Provide loading screen between scenes
  3. Add menu screen with buttons for Starting (defaults to forest)
  4. Add About button that goes to a second canvas on the same scene
    - For pop ups, make a not-active second canvas -> panel -> scrollview. Enable second canvas on button click to show up
  5. Decisions on adding more features or polishing what you have for the presentation (went with the later)

_Issues:_
- Disk space saga continues
- Need to convert to Large Git due to asset size
- Learning the difference between a specific object instantiation tied to a game object (via inspector) and when you instantiate it yourself.
- Scene build index and Scene Management's index of scenes are NOT the same. Be careful with the methods you use for this
- No support for hyperlink in text UI? Text mesh pro may have something but is complicated for a non-MVP feature
- Telling yourself that what you have IS good, giving up on non MVP or MVP features in light of deadlines, stopping bug fixes that take too long and is not extremely detrimental to the app, etc.

**Week 4**
Finalizing scenes (density of prefabs, overall look), smoother UI, documentation, version control revisited
