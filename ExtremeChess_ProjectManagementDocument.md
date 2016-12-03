# Project Management Document

## Extreme Chess
Spin-off of chess in Unity

## Index
##### Vision
##### Configuration Management Plan
##### Process Model
##### Deliverables
##### Potential Risks
##### Team Composition
##### Team Member Contributions
* Kyle Sarre
* Robert Anderson
* Gabriel Davis
* Julian Plaisance
* Hanna Cunningham

##### Project Schedule
##### Meetings Summary

## Vision
The core concept of our game is to create a complete game of chess, but in addition, each player has a set of “special abilities” at their disposal they can periodically use to their advantage. Special abilities will be connected to a system of energy that builds up over time and spent to use an ability. Most moves in the game will follow standard chess rules.

We’re choosing this project because Chess is a rigid game that requires years of dedication and study before one can even begin to create any truly new and effective strategies, and the project seeks to add a new strategic dimension of unpredictability, which will act to “level the playing field,” in a way. More unpredictability places more importance on adaptability and improvisation, instead of endless memorization of positions and strategies. Asymmetric design means that no two games will be the same

## Configuration Management Plan
todo

## Process Model
todo

## Deliverables
todo

## Potential Risks
todo

## Team Composition
**Team members**:</br>
Kyle Sarre,</br>
Robert Anderson,</br>
Gabriel Davis,</br>
Julian Plaisance,</br>
Hanna Cunningham.</br>
**Tasks**:
Game Logic:</br>
	Kyle Sarre, primary logic programmer & designer, secondary logic documenter</br>
	Robert Anderson, secondary logic programmer & designer, primary logic documenter</br>
	Gabriel Davis, secondary logic programmer & designer & documenter</br>
Worked on putting together the logic of the classic game chess into our program and built several power-ups.</br>
User Interface:</br>
	Julian Plaisance, primary UI programming, secondary UI design & documentation</br>
	Hanna Cunningham, secondary UI programming, primary UI design & documentation</br>
Worked on putting together menu & menu systems to allow the player to have maximal control through the game with the maximum amount of knowledge while being as minimal as possible given time constraints</br>
**Team Style**:
We split our five members into 2 teams, 3 in the main game logic and 2 into UI, with the idea that keeping both teams small will increase team cohesion and keep the teams egoless so that when everyone meets together we will be in practice for an egoless structure</br>
	Game Logic:</br>
	semi-egoless with a chief programmer in Kyle who led the main game code and logic with Kyle and Gabriel assisting</br>
	UI:</br>
	egoless pair programming, with Julian as the code lead and Hanna as the design and documentation lead.</br>

## Team Member Contributions
### Kyle Sarre
add your contribution here
### Robert Anderson</br>
Code-wise, I contributed primarily towards the ability implementation. The ability system was mostly complete, though towards the end we ran into trouble connecting it to the UI. I also assisted Kyle with main game logic, primarily through talking through algorithms and design choices on paper, along with some pair programming. I participated in each major design document. I wrote the vision for the PMD, several functional requirements for the SRS, the logical view and work assignment view for the SDD, and several check/checkmate test cases for the STD.</br>
### Gabriel Davis
add your contribution here
### Julian Plaisance
add your contribution here
### Hanna Cunningham
add your contribution here

## Project Schedule
todo

## Meeting Summary
**Date**: 09-21-16</br>
**Purpose**: Setting up source control for team members, setting up Unity and updating to the latest version for team members, discussion of game ideas</br>
**Members in attendance**: Robert Anderson, Kyle Sarre, Hanna Cunningham, Julian Plaisance, Gabriel Davis</br>
**Goals met**: Source control, Unity set up for all group members, discussed ideas that would distinguish our game from others.</br>

**Date**: 09-30-16</br>
**Purpose**: Assignment of documentation responsibilities, discussions on documentation requirements, elaboration on game ideas, final decisions on development tools.</br>
**Members in attendance**: Robert Anderson, Kyle Sarre, Hanna Cunningham, Julian Plaisance, Gabriel Davis</br>
**Goals met**: designated roles for documentation, discussed the requirements of each document, debated on game ideas, finalized development toolkit.</br>

**Date**: 10/4/2016</br>
**Purpose**: Brief requirements analysis, class diagramming.</br>
**Members in attendance**: Robert Anderson, Kyle Sarre</br>
**Goals met**: finished brief requirements analysis, rough draft class diagram for iteration 1 of the project.</br>

**Date**: 10-7-16</br>
**Purpose**: Review each section of the SRS and delegate responsibilities for each section.</br>
**Members in Attendance**: </br>
**Goals met**: Didn't meet objective. Realized the group needs time to think about what the SRS covers in terms of our own project
and that we should meet again at a later date.</br>

**Date**: 10-14-16</br>
**Purpose**: Review each section of the SRS and delegate responsibilities for each section.</br>
**Members in Attendance**: Robert Anderson, Kyle Sarre, Gabriel Davis, Julian Plaisance, Hanna Cunningham </br>
**Goals met**: Kyle will handle sections 1,2 (intro and scope), Julian and Hanna will handle section 3 (User, hardware, and software interfaces), Robert and Kyle, if needed, will work on section 4(functional requirements/system features), and Gabe will work on section 5 (other non-functional requirements).</br>

**Date**: 10-17-16</br>
**Purpose**: Check in on group member progress towards completion of the SRS. </br>
**Members in Attendance**: Robert Anderson, Kyle Sarre, Hanna Cunningham, Gabriel Davis </br>
**Goals met**: Section 1 and 2 complete (requires editing). Brainstormed UI ideas for the system, reviewed Robert's take on the major features and their functional requirements.</br>

**Date**: 10-18-16</br>
**Purpose**: discuss the User Interface</br>
**Members in Attendance**: Hanna Cunningham, Julian Plaisance</br>
**Goals met**: mapped out the basic appearance of the UI and took notes for the External Interfaces section of the SRS</br>

**Date**: 10-21-16</br>
**Purpose**: work out conflicts in the SRS and submit the final version to GitHub</br>
**Members in Attendance**: Robert Anderson, Kyle Sarre, Hanna Cunningham, Gabriel Davis, Julian Plaisance</br>
**Goals met**: finished SRS </br>

**Date**: 11-1-16</br>
**Purpose**: Review group's progess on the SDD.</br>
**Members in Attendance**: Robert Anderson, Kyle Sarre, Hanna Cunningham, Julian Plaisance </br>
**Goals met**: Each section was dealt with. However, the developer's perspective/system architecture is incomplete and requires attention.</br>

**Date**: 11/11/16</br>
**Purpose**: Verify the system can be worked on by other team members. Integrate UI with the rest of the system.  </br>
**Members in Attendance**: Kyle Sarre, Juilian, Plaisance</br>
**Goals met**: Realized that the current github configuration was leading to broken prefab and script references in the unity project after pulling, making the project extremely difficult to work on seperately.</br>

**Date**: 11/18/16</br>
**Purpose**: Split up the testing documentation amongst the group.</br>
**Members in Attendance**: Robert Anderson, Hanna Cunningham, Gabriel Davis, Julian Plaisance, Kyle Sarre</br>
**Goals met**: Delegated sections of the testing document based on what parts of the system people had worked on. </br>

**Date**: 11/26/16</br>
**Purpose**: Worked on User Interface implementation</br>
**Members in Attendance**: Hanna Cunningham, Julian Plaisance</br>
**Goals met**: Furthered menu implementation slightly.</br>

**Date**: 11/26/16</br>
**Purpose**: Pair programming to complete the check/checkmate feature of the system</br>
**Members in Attendance**: Robert Anderson, Kyle Sarre</br>
**Goals met**: Finished the underlying system needed to support finding check or checkmate; began implementation of piece upgrades.</br>

**Date**: 11/27/16</br>
**Purpose**: Pair programming to complete the check/checkmate feature of the system.</br>
**Members in Attendance**: Robert Anderson, Kyle Sarre</br>
**Goals met**: System could now recognize check as well as the number of pieces threatening the king. Implemented five of our upgrades. Check mate is not finished.</br>

**Date**: 11/27/16</br>
**Purpose**: Finish the project demo</br>
**Members in Attendance**: Hanna Cunningham, Robert Anderson, Kyle Sarre, Julian Plaisance</br>
**Goals met**: almost finished project demo</br>

**Date**: 11/28/16</br>
**Purpose**: Meet up before class, review presentation, discuss who will talk for what and when</br>
**Members in Attendance**: Hanna Cunningham, Robert Anderson, Kyle Sarre, Julian Plaisance, Gabriel Davis</br>
**Goals met**: Gabriel will introduce our project, Robert will lead the presentation, Julian and Hanna will talk about their UI,
Kyle will talk about the technical details.</br>


