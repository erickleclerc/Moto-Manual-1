<h1 align="center"> Moto Manual </h1>

<p align="center">
  <img alt="Preview" width="660" alt="preview" src="https://github.com/erickleclerc/Moto-Manual-1/blob/main/Assets/Videos/ReadMEGif.gif">
<p align="center">

## Summary
Rev up your virtual engines with my PCVR motorcycle training simulator! Designed to replicate real-world riding scenarios, this immersive experience allows learners to master motorcycle handling, traffic navigation, and road safety without the fear of real-world damage. Feel the thrill of the open road and gain confidence as you progress towards becoming a skilled motorcyclist in a risk-free environment.

An entirely individually conceived project without the use of prior made packages.

## Project Aim / Goal 
Moto Manual aims to teach a prospective riders the intricacies of a two-wheeled vehicle by familiarizing them with the controls and abilities of wrist controlled speeding. Upon completion of a walkthrough identifying the key components of a motorcycle, the rider will be able to practice throttling, braking, and shifting while traffic is in play. As a training simulator designed to be used in-tandem with motorcycle education classes, the rider may practice over and over until they are comfortable taking their skills and muscle memory into the real world.

The goal of this project was to build an entire experience from scratch to expose myself to as many aspects of VR game building as possible. The main objective was to prioritize forming the experience to a functional stage over polishing its design. By attempting to solve nearly all problems within the Unity game engine and using C# scripting, a new level of comfort navigating the engine has been achieved. 

## Features
> Here is a brief of the implemented training features:

* Main Menu
  - [x] Preview of the rideable motorycle
  - [x] Entering the game
  - [x] Selecting to begin or exit using Raycasting

* Game Flow
  - [x] A linear game flow leading into a freedom of choice gameplay
  - [x] Mini lessons:
      - [x] Riding at city speeds
      - [x] Riding at a higher gear
      - [x] Riding at night while avoiding obstacles    

* Animations
  - [x] Gloves and Oculus Controllers animated using the Animation Controller
  - [x] Highlighting animations using C# scripting

* Inputs
  - [x] Customizable Input Actions with bindings set for PC keyboard and Oculus controllers

* Interactions
  - [x] Donning a helmet
  - [x] Placing a key in the igntion
  - [x] Kill Switch
  - [x] Push Start
  - [x] Front & Back Brake
  - [x] Throttle
  - [x] Clutch
  - [x] Shifting
  - [x] Turn Signals
  - [x] Headlight
  - [x] Horn
  - [x] Haptic feedback

 * Locomotion
    - [x] Turning using the user's head tilt while throttling
    - [x] Auto readjusting the player upright
    - [x] Understanding positioning with side mirrors

* A.I. Agents
  - [x] Various vehicles that must be avoided to prevent crashing
 
* Collisions
  - [x] Restarting lesson when colliding with vehicles and buildings
 
* UI
  - [x] Updateable UI based on player progress
  - [x] Controls & shifting references 
  - [x] Speedometer
  - [x] Gear level
  - [x] Hands on the handle bar indicator
  - [x] Crash indicator

 * Audio
    - [x] A.I. generated audio instructions
    - [x] Throttling, Push Starting, and Horn
    - [x] Main menu music 

## Controls
PC Controls:
* **A,S,D**: Throttle, Front Brake, Back Brake
* **Y,T**: Kill Switch, Push Start
*  **C,↑,↓**: Clutch, Shift Up, Shift Down
*  **H,K,L**: Horn, Turn Signals, Headlight
*  **R,M**: Restart Scene, Main Menu

Oculus Controls + USB Pedals:

<p align="center">
  <img alt="Preview" width="500" alt="preview" src="https://github.com/erickleclerc/Moto-Manual-1/blob/main/Github%20Resources/Controllers%20Diagram.jpg">
<p align="center">

<p align="center">
  <img alt="Preview" width="300" alt="preview" src="https://github.com/erickleclerc/Moto-Manual-1/blob/main/Github%20Resources/USB%20Pedal.png">
<p align="center">

<p align="center">
  <img alt="Preview" width="300" alt="preview" src="https://github.com/erickleclerc/Moto-Manual-1/blob/main/Github%20Resources/Pedal%20Construction.png">
<p align="center">
Three pedals were programmed to the PC keyboard bindings, combined with scrap wood to mimic a shifter lever and a brake pedal.  

## Process 
Playtests
<p align="center">
  <img alt="Preview" width="500" alt="preview" src="https://github.com/erickleclerc/Moto-Manual-1/blob/main/Github%20Resources/Bruno%20In%20Action%20Playtest.png">
<p align="center">

[![](https://github.com/erickleclerc/Moto-Manual-1/blob/main/Github%20Resources/Playtest%20Thumbnail.png)](https://vimeo.com/842711348?share=copy)


## Journey
The project's developement came in two stages:

**The Planning Stage**

https://github.com/erickleclerc/Moto-Manual-1/blob/main/Github%20Resources/Moto%20Manual%20-%20Project%20Plan.pdf

**The Development Stage** <br>
Much of keeping the project on track was due to a reliance on Miro and JIRA for loogging progress along the way, highlighting what needed to be prioritized or rescheduled. This provided a learning opportunity to understand unfamiliar tools outside of Unity.

<p align="center">
  <img alt="Preview" width="800" alt="preview" src="https://github.com/erickleclerc/Moto-Manual-1/blob/main/Github%20Resources/backlog.jpg">
<p align="center">

<p align="center">
  <img alt="Preview" width="800" alt="preview" src="https://github.com/erickleclerc/Moto-Manual-1/blob/main/Github%20Resources/Calendar.jpg">
<p align="center">

<p align="center">
  <img alt="Preview" width="800" alt="preview" src="https://github.com/erickleclerc/Moto-Manual-1/blob/main/Github%20Resources/jira%201.png">
<p align="center">

<p align="center">
  <img alt="Preview" width="800" alt="preview" src="https://github.com/erickleclerc/Moto-Manual-1/blob/main/Github%20Resources/jira%202.png">
<p align="center">

*** Please click on the images to view them in greater detail ***

## Case Study Video 
> Example Video

[![](http://i3.ytimg.com/vi/G7rzMntNpz4/hqdefault.jpg)](https://vimeo.com/852572254?share=copy)

## Optimization
Even though the experience is meant for PC VR, a goal to optimize for standalone would benefit reaching a larger VR audience. 

According to Meta Quest Optimization Guideline, a Medium Simulation intensity for the Quest 2 recommends 200-300 draw calls. The triangle count should be 750k-1.0m. Finally, a comfortable fps for standalone games if over 70fps.

Moto Manual was able to achieve the following: 

<p align="center">
  <img alt="Preview" width="300" alt="preview" src="https://github.com/erickleclerc/Moto-Manual-1/blob/main/Github%20Resources/Statistics.png">
<p align="center">


The vast majority of the tris come from a complex motorcycle model along with the render textures that could be swapped for a simpler yet still effective model.

## Roadmap / Beyond
* Lessons:
  - Highway traffic
  - Turning + Shoulder checks
  - Riding the clutch
  - Push Steering
  - Reading road signs

* Additions:
  - Multiple motorcycle models
  - Pedestrians
  - More environments
  - A.I. instructor
 
* Refinements
  - Implement wheel colliders
  - Bluetooth controls for standalone devices
  - Motorcycle and A.I. agents at scriptable objets

## Essential Tools
The GameManager Script
<p align="center">
  <img alt="Preview" width="300" alt="preview" src="https://github.com/erickleclerc/Moto-Manual-1/blob/main/Github%20Resources/Game%20Manager%20SC.png">
<p align="center">

The Motorcycle Controller Script
<p align="center">
  <img alt="Preview" width="300" alt="preview" src="https://github.com/erickleclerc/Moto-Manual-1/blob/main/Github%20Resources/Moto%20Controller%20SC.png">
<p align="center">



