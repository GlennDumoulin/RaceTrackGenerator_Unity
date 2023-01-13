# Race Track Generator

## Introduction

This research project aims to create a **dynamic** race track generator in *Unity* using **Perlin Noise** for terrain generation and **random point generation** for track creation. The final track will be generated using **Bezier curves** and will have a road mesh applied for a more realistic look. The Bezier curve and road mesh implementation will be done using a tool from the *Unity Asset Store* called **Bezier Path Creator** made by *Sebastian Lague*.

Additionally, the use of **custom editors** in *Unity* allows for **easy customization** of the generated tracks, giving the user greater control over the final outcome of the race track. This feature allows for an even more **dynamic and unique experience for the user**.

## Results

Now before I go into to much detail about this reasearch, I would like to show you what I've achieved by now.

![TerrainGeneration](/Assets/TerrainGeneration.gif)
![Track01](https://user-images.githubusercontent.com/55405998/212292317-1ae058c7-f2b8-44f3-a744-940d70dfb294.png)

## How I did it

For this project to work I needed the race tracks to be generated on top of the terrain "*well yeah, of course*". So after some *quantum physics* I decided to start with **generating terrain**. After that I would look into **generating random points** on that terrain. Then I would need to **connect these points together** somehow. And finally I would need to **create the actual track**.

Since this is the plan I had in mind, I will follow this order to go into depth about each of the subjects.

### Generating the terrain

To start this section of I would just like to say that I had so much fun *learning*, *exploring* and *playing* with **Perlin Noise**. This was my *first time* working with **Perlin Noise** so I didn't really now how what to expect. I soon discovered that the **build-in Perlin Noise Method** of *Unity* will always result in the same value for a certain point and also that it repeats at integer values "*Which I had to learn the hard way...*".

While I was wandering around the internet in my search to understand what I was going to work with, I seemed to keep bumping into this one person called **Sebastian Lague**. I had seen YouTube videos of him before and I knew he always seemed to explain everything very well for me.

*a couple of websites and a few video's later* So now I'm ready to do this.

During my first attempt I used Perlin Noise on a Terrain gameObject. But eventually I got stuck while trying to implement seeding. It seemed like the Perlin Noise **offset** you add to the **sample point** did not really like the integer values of the seed "*Remember what I said about learning it the hard way*". Yeah I got stuck here for a while before just *taking a deep breath* and starting over using a different method.

*Enter terrain generation using meshes*

With again an empty project in front of me and a new way of attempting terrain generation in mind *and with a tutorial guiding me through* I started over. After some time I started to believe this would be the way to go. I quickly was able to add custimizations for the user such as **seeding**(*working this time*), **nr of octaves used**, **colors based on height values** and **many more options**.

This marks the end of my work on the terrain generation. "*Well the working part at least, time to play a bit with the settings and see what get's generated... Oh look at this!*"

![Terrain01](https://user-images.githubusercontent.com/55405998/212289331-89c43b2c-6052-4d47-bdfc-ea622cdcb900.png)
![Terrain02](https://user-images.githubusercontent.com/55405998/212289345-dffe7c97-9c8d-4d98-a92d-f0ee321fd725.png)
![Terrain03](https://user-images.githubusercontent.com/55405998/212289366-4a59bdb6-f0ea-4247-885e-8bc9fd10f080.png)

### Generating random points

Anyways moving on. I'm gonna be honest I have struggled with this part a lot even though it sounds very straight forward.

The initial idea was to use a random walk algorithm to generate these points but I couldn't wrap my head around the **possible problem** in which the algorithm **wanders out of the map** and starts placing points for the track into nothingness. And just **clamping** the value to the world borders would just **look very weird**.

Then I had the idea to try and **build a navmesh** on top of the generated terrain mesh and let an **agent wander around** the navmesh and place some points. But when I discovered there is **no way of rebuilding the navmesh through code**, I had to abondon this idea as well.

After that I was going to **generate random directions with random distances** and add these onto the previous point. But here again I had the problem of the algorithm leaving the generated terrain.

At last I settled on a way of just **generating random points above the map** and then checking with a **raycast downwards** if the points hits the terrain. From this raycast I also got the **normal** information of the **point on the mesh** that was hit. This would prove very helpfull soon.

*I will definitly have to come back to this part later on because this just is not a very good solution.*

### Connecting the points && Creating the actual track

So now I have my terrain and points onto the terrain mesh generated, it was time to connect the points and create the track itself. At first I was going to look for some assets I could download the make the track out of a **predefined set of blocks**. The problem I had with this is that it would most likely never feel very natural. Plus you are much more constricted to a certain style. So I started looking into my second option, **splines**.

Also quick sidenote: "I decided to put these parts together *for now* since they were actually done by a tool I found in the *Unity Asset Store* called *Bezier Path Creator* while I was refreshing my memory of **bezier curves**."

While I was researching bezier curves I found a tutorial series on YouTube made by "*You guessed it!*" **Sebastian Lague** about a 2D Curve Editor in Unity. So I decided to watch these videos and then I found out he had put this up *for free* in the *Unity Asset Store*. The tool was an expended and enhanced version of the 2D Curve Editor. It had functionality to add a road mesh onto it for example. "*Very helpfull indeed.*"

So I added this tool to my project and started testing it out and looking into how I could use it for my purpose. Since the tool supported **3D paths** and I had discovered you can **change the normals of the points** so that the track would bend and **flow more naturally**, I eventually added my own **Bezier Path Constructor** to the tool which also takes the **normal** information I talked about during the random point generation.

![Track01](https://user-images.githubusercontent.com/55405998/212292317-1ae058c7-f2b8-44f3-a744-940d70dfb294.png)
![Track02](https://user-images.githubusercontent.com/55405998/212292330-4bb85c57-03c1-4441-882e-7d22ab407982.png)

## Conclusion/Future work

This is where I've ended up at this point. I'm not very happy with the current state of the project. But I really liked working with the Perlin Noise and will definitly do more experiments with this. It be in Unity, Unreal Engine or anything else. The track itself seemed to be a wall I kept running into. There is lots to do if I want to continue working on this project and I very well might when I find the time for it.

Some ideas for future work are:

 - For the random point generation I recently remembered the idea of starting out with **all points randomly chosen on a circle**. Then I would **loop x times** through all points and **generate some random offset** for each point to **expand the shape** of the track.
 - Something else that isn't even mentioned yet before is the addition of option for the track style. You can say if the track should loop. But what kind of track do you want? *Fast-paced with long straights* or *more technical turns*?
 - There is much more I could do such as even adding checkpoints to the track so that I can let some machine learning AI cars loose onto the track.

## Sources

### Perlin Noise Algorithm

 - [Perlin noise - Wikipedia](https://en.wikipedia.org/wiki/Perlin_noise)
 - [Perlin Noise in Unity - Brackeys](https://www.youtube.com/watch?v=bG0uEXV6aHQ)
 - [Generating Terrain in Unity - Brackeys](https://www.youtube.com/watch?v=vFvwyu_ZKfU)
 - [Procedural Terrain Generation - Sebastian Lague](https://www.youtube.com/playlist?list=PLFt_AvWsXl0eBW2EiBtl_sxmDtSgZBxB3)
 
 ### Bezier Curves
 
 - [Bezier Path Creator (Tool) - Unity Asset Store](https://assetstore.unity.com/packages/tools/utilities/b-zier-path-creator-136082)
 - [2D Curve Editor - Sebastian Lague](https://www.youtube.com/playlist?list=PLFt_AvWsXl0d8aDaovNztYf6iTChHzrHP)

### Random Walk Algorithm

 - [Random walk - Wikipedia](https://en.wikipedia.org/wiki/Random_walk)
 - [Random walks - Khan Acadamy](https://www.khanacademy.org/computing/computer-programming/programming-natural-simulations/programming-randomness/a/random-walks)
 
