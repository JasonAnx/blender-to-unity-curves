> **Note** right now only Nurbs path is implemented. Bezier should be similar but atm it is commented out since I haven't had the chance to test it. Contributions are appreciated.
> **Note** This code is pretty messy right now. Any contributions would be appreciated.

# About

This repo contains Scripts to turn Blender's Bezier or Nurbs-Path curve's into Unity's Cinemachine waypoints (smooth path). 
Specifically, it contains a script that can turn Blender's curves data points into a json file. 
It also contains Unity scripts to read said json file and create a cinemachine dolly track inside Unity.

# How To use

  ### 1) Blender
  - in you blender project, go to the 'scripting' tab.
    - go to text > new to create a new script, use whichever name you want
    
         <img src="https://user-images.githubusercontent.com/14960498/191333223-9eaab837-0379-4277-b7a9-5c5c3de551cb.png" width="650" height="200">
          
  - copy blender.py into the script's text panel
  - execute the script. You should now have a json file in your project directory.

  ### 2) Unity
  - Copy both .cs files into your unity project. Wait for compilation.
  - Create an empty object and add the BlenderSplineToDollyTrack script script component to it.
  - in the Component's 'JSon file' input, select your json file you created in blender
  ![image](https://user-images.githubusercontent.com/14960498/191334509-416f2dcf-dc0c-453d-8365-1a030219ea47.png)
  - clic on "build"
  
 that's it!
 
 ![image](https://user-images.githubusercontent.com/14960498/191334752-579b7c6b-018c-4d9d-9763-c5999fc6233e.png)
