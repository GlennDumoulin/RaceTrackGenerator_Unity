# Race Track Generator

## Introduction

This research project aims to create a **dynamic** race track generator in *Unity* using **Perlin Noise** for terrain generation and **random point generation** for track creation. The final track will be generated using **Bezier curves** and will have a road mesh applied for a more realistic look. The Bezier curve and road mesh implementation will be done using a tool from the *Unity Asset Store* called **Bezier Path Creator** made by *Sebastian Lague*.

Additionally, the use of **custom editors** in *Unity* allows for **easy customization** of the generated tracks, giving the user greater control over the final outcome of the race track. This feature allows for an even more **dynamic and unique experience for the user**.

## Results

Now before I go into to much detail about this reasearch, I would like to show you what I've achieved by now.

//Insert GIF(s) here

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

//Add some images

### Generating random points

Anyways moving on. I'm gonna be honest I have struggled with this part a lot even though it sounds very straight forward.

//Continue text here...

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
 
