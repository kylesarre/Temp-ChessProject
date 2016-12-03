# Extreme Chess Project Management Document

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
__GitHub:__<br>
For all of the documents and code in this project, we used GitHub as our configuration management tool. It worked well for our team, as it allowed us to create branches to test features separately and then merge them at a later date.<br> 
__GroupMe:__<br>
To stay connected with one another on a real-time basis, we used GroupMe to communicate. It allowed each of us to quickly send messages to the group and each other while archiving important comments for future reference.<br>

## Process Model
__Agile Method: Extreme Programming__ <br>
We chose to use the agile programming method because we started this project with only a vague idea of what we wanted to implement. Using the agile approach allowed us to constantly make changes to our requirements as we added features that we realized we wanted to implement while removing features that would be both more difficult and less important to include in the first release of the software. By using this method, we were able to change the direction of our development quickly to reflect our more updated visions of the game. 

## Deliverables
Extreme Chess Executable <br>

Documentation:
* [Software Requirements Specification](https://github.com/kylesarre/Temp-ChessProject/blob/master/ExtremeChess_SRS.md)
* [Software Design Document](https://github.com/kylesarre/Temp-ChessProject/blob/master/ExtremeChess_SDD.md)
* [Software Testing Documnet](https://github.com/kylesarre/Temp-ChessProject/blob/master/ExtremeChess_STD.md)

## Potential Risks
__Human Risk:__ Lack of experience with the software used to make the game. Not knowing how to use the tools can lead to a higher chance of problems occuring. <br>
__Time Risk:__ Semester due date - Must manage scope of project and keep on task with deadlines. <br>
__Resources Risk:__ Potentially encountering problems with Microsoft Visual Studios. <br>
__Liability Issues:__ None

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
### Kyle Sarre</br>
Contributions:
* Documentation – I wrote sections 1,2 of the SRS and assisted Robert in writing section 4. I Wrote section 2 of the SDD and provided Robert with a diagram of the technical overview of the system. I wrote numerous test cases related to game logic (non ui related). Additionally, I maintained a log of group meetings throughout the semester.
* Game design – I Provided feedback on design decisions made by the group and offered my own designs. Some of my designs that made it into the final product include the 2d aesthetic of the game, a few of the power ups, interfacing (user to game board), and object highlighting. 
* Software Architectural Design – I came up with the core architecture of the system (the MVC design).
* Art – I created art for the board and the pieces. I also created art for the UI elements of the game but, due to time constraints, I couldn’t finish.
* Feature Implementation – I implemented piece highlighting, piece selection, piece movement (partially unimplemented), piece capturing, check and checkmate (couldn’t function without correct piece movement), and all of their underlying subsystems.
* Technical consultation – I assisted members of the group with using Unity, GitHub, and C# programming.
</br>

### Robert Anderson</br>
Code-wise, I contributed primarily towards the ability implementation. The ability system was mostly complete, though towards the end we ran into trouble connecting it to the UI. I also assisted Kyle with main game logic, primarily through talking through algorithms and design choices on paper, along with some pair programming. I participated in each major design document. I wrote the vision for the PMD, several functional requirements for the SRS, the logical view and work assignment view for the SDD, and several check/checkmate test cases for the STD.</br>

### Gabriel Davis</br>
My exact contribution was assisting with the logic of the program and design as well as documentation for the project and assisting Kyle with game coding. I worked on the SRS, SDD, STD, PMD and code along with the rest of the group because we all did it together and split the work into parts. I missed a group meeting on 11/1/16 because I was out of town and again on the Thanksgiving weekend from 11/26/16 to 11/27/16 because I was out of town for the holidays.</br>

### Julian Plaisance
add your contribution here

### Hanna Cunningham
For this project, I contributed a fair amount to the documentation, created the project schedule, and organized the majority of the group meetings.  I designed the User Interface for the game and worked on a few menus, including the Main Menu, Credits, Help, and Options, while also designing and adding some of the custom buttons in the game. Some of the powerups created late in the implementation phase were thought up by me, though they were not the first to be added, and thus are not included in the game’s initial release. 

## Project Schedule
+![CPM](https://github.com/kylesarre/Temp-ChessProject/blob/master/SRSdiagrams/Extreme%20Chess%20Critical%20Path%20Diagram%20-%20New%20Page%20(3).png)

Task Description| Task | Task Precedence | Length (days) | ES | LS | Slack
---|---|---|---|---|---|---|
Main menu/scenes | A | - | 1 | 0 | 0 | 0
Quit application | B | A | 1 | 1 | 54 | 53
Create game board/grid | C | A | 1 | 1 | 1 | 0
Powerup selection menu| D | A | 2 | 1 | 44 | 43
Generate pieces | E | C | 3 | 2 | 2 | 0
Highlight cells on hover | F | E | 2 | 5 | 6 | 1
Select piece | G | E | 3 | 5 | 5 | 0
Highlight piece cell on select | H | F, G | 1 | 8 | 9 | 1
Deselect piece | I | G | 2 | 8 | 8 | 0
Add movement vectors| J | H, I | 4 | 10 | 10 | 0
Highlight possible moves | K | J | 2 | 14 | 15 | 1
Move piece to applicable cell | L | J | 3 | 14 | 14 | 0
Assign players to colored pieces| M | K, L | 1 | 17 | 17 | 0
Previous turns window | N | L | 5 | 17 | 50 | 33
Player can only select own pieces | O | M | 2 | 18 | 18 | 0
Add turn logic/switching | P | O | 2 | 20 | 20 | 0
Piece capture | Q | P | 1 | 22 | 23 | 1
Cannot move on top of same color piece | R | P | 2 | 22 | 22 | 0
Energy adds up every turn | S | P | 1 | 22 | 49 | 27
Player name header switches every turn | T | P | 1 | 22 | 54 | 32
Graveyard/captured pieces window | U | Q | 5 | 23 | 50 | 27
Add check/checkmate logic | V | Q, R | 14 | 24 | 24 | 0
Energy assigned to player/energy UI | W | S | 1 | 23 | 50 | 27
End game on checkmate/forfeit | X | V | 1 | 38 | 38 | 0
Add powerup vectors to piece library | Y | X | 7 | 39 | 39 | 0
Allow selection of powerups | Z | D, Y | 5 | 46 | 46 | 0
Subtract energy when powerup is used | AA | W, Z | 2 | 51 | 51 | 0
Check piece powerup window | AB | AA | 2 | 53 | 53 | 0

![Gantt Chart](https://github.com/kylesarre/Temp-ChessProject/blob/master/SRSdiagrams/Extreme%20Chess%20Gantt%20Chart.png?raw=true)

__Estimation Method: PERT__
Considering the team had no experience in Unity prior to this semester, we were unable to use an algorithmic estimation method for our project, being entirely unsure of the KLOC to which our project might grow. Though not experts by any means, we were forced to discuss how long we believed features would take to implement, based on the experience that a few of our members gained working in Unity during the WICS Game Jam early in the semester. The most likely results we garnered are shown in the above diagrams. 

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
**Members in Attendance**: Kyle Sarre, Juilian Plaisance</br>
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

