# 0.0 Table of Contents

# 1.0 Introduction
## 1.1 Purpose
We intend for the following document to elaborate upon and specify the complete set of all functional/non-functional requirements and constraints of V.1.0 of our project "Extreme Chess." 
The primary purpose of this document is to simplify the job of the programmers who will be implementing the system features specified in this SRS. In order to satisfy this primary purpose,
this SRS should clearly and accurately define the set of all parameters(functional/non-functional requirements, constraints) that parameterize the design of this software and its features. Additionally,
we intend to clarify the requirements of the system through alternative representations of the material, such as use-case examples, charts, and illustrations.
## 1.2 Document Conventions
pending	
## 1.3 Intended Audience and Reading Suggestions
Our intended audience consists of:

* Developer(s) - indviduals who are responsible for designing the software itself.
* Project Manager(s) - individuals who are overseeing the development of the software, establishing deadlines, and managing risks.
* Tester(s) - individuals who verify that specifications outlined in this document are followed in the software design.
* Documentation Writer(s) - individuals who need to outline what a feature does, its purpose, and how it will fit into the current system
## 1.4 Product Scope
"Extreme Chess" is an extension of the classic game of chess. We want to make chess a more unpredictable and wild experience,
so we have decided to incorporate a new game mechanic that we call "upgrading". Players can upgrade a piece at a cost, which will allow the player to
perform new moves or maneuvers with their pieces. We intend for "Extreme Chess" to expand player choice
and allow for more personalization of gameplay and strategy, while reducing the effectiveness of years of practicing in the original chess ruleset. 
Hence, "Extreme Chess" should be designed with the intent of making chess a more approachable, replayable, and fun experience for novices and experts alike.     	 
## 1.5 References
Standard Chess Rules: https://en.wikipedia.org/wiki/Rules_of_chess
# 2.0 Overall Description
## 2.1 Product Perspective
"Extreme Chess" is a game app developed in Unity. It will allow users to play the game of Extreme Chess in a fun and convenient environment by utilizing the collection of key functions intended for this system.
## 2.2 Key Functions
The following key functions to be included in this system are:

* the ability for two players to play against one another at a game of Extreme chess
* allowing the user to adjust the volume of the game
* allow the user to save and load a game
* allow a user to forfeit a game whenever they choose
* provide convenient gui elements to help inform the player of what is occurring on screen and to give them limited control of the game

## 2.3 User Classes and Characteristics
There is only one user class relevant in this version of the system: the end user(s). The end user(s) will use our system to play the game "Ultimate Chess". They will
expect a software that simulates a consistent reimagining of classic chess, one in which they can navigate  and control with relatively little hastle. Thus,
all of the features to be included in this iteration of our system will be dedicated to serving the end user(s).
## 2.4 Operating  Environment
As of the most current version, The system shall operate on desktop and laptop computers, on the windows 7 platform and above. The entire system is to be designed and built using the Unity game engine.
## 2.5 Design and Implementation Constraints
* language requirement - Our system utilizes the Unity game engine to avoid the hastles of low level problems (memory management, rendering to screen, sound, etc); however, this decision limits the developers of this project to the languages supported by the Unity API: C#, and Javascript. To conform with Unity requirements, Our team has elected to use C# for the implementation of this project.
* hardware requirements - This system is designed under the assumption that the user is running our software with a PC running windows 7 or higher. Hence, we expect users to meet the bare minimum requirements necessary to run their operating system on their machine according to microsoft's corresponding hardware specifications. 
## 2.6 User Documentation
The software will include a tutorial for general gameplaying and maneuvering of the system, which will be accessible from the main menu. 
## 2.7 Assumptions and Dependencies
The following is a list of assumptions to be made during development:

* Correctness of Unity Libraries - We assume during the development of the system that the C# libraries covered in the Unity handbook function as stated.
* Users are running the software in its intended environment - We assume that the user will attempt to run the program in the environment for which it was designed, namely on a PC running Windows 7 or higher.
# 3.0 External Interfaces
## 3.1 User Interface
List of user interface components: main menu, control menu, options box, save box, load box, game menu, game over box.
