# Extreme Chess: Software Design Document
### Team Members: Robert Anderson, Hanna Cunningham, Gabriel Davis, Julian Plaisance, Kyle Sarre

# Table of Contents
### 1 Introduction
##### 1.1 Purpose
##### 1.2 Intended Audience
##### 1.3 Scope
##### 1.4 Design Summary
##### 1.5 Overview 
### 2 Conceptual System Architecture
##### 2.1 Overview
##### 2.2 Upgrading
##### 2.3 Energy
##### 2.4 Piece Movement
##### 2.5 Graveyard
##### 2.6 Move History
##### 2.7 The Game Board
##### 2.8 Pieces
##### 2.9 Turn Phases
### 3 Sub-systems Architecture
##### 3.1 Overview
##### 3.2 Model
##### 3.3 View
##### 3.4 Controllers
### 4 Development View
### 5 Physical View
### 6 Database View
### 7 Work-Assignment View
### 8 Element Catalog
### 9 User Interfaces


# 1 Introduction
## 1.1 Purpose
The purpose of this document is to describe the system design, the rationale behind it, and the organization of the information. The overall goal of the SDD is to describe the system architecture.

## 1.2 Intended Audience
Our intended audience consists of:
•	Developer(s) - individuals who are responsible for designing the software itself.
•	Project Manager(s) - individuals who are overseeing the development of the software, establishing deadlines, and managing risks.
•	Tester(s) - individuals who verify that specifications outlined in this document are followed in the software design.
•	Documentation Writer(s) - individuals who need to outline what a feature does, its purpose, and how it will fit into the current system

## 1.3 Scope
Our intended audience consists of:

* Developer(s) - individuals who are responsible for designing the software itself.
* Project Manager(s) - individuals who are overseeing the development of the software, establishing deadlines, and managing risks.
* Tester(s) - individuals who verify that specifications outlined in this document are followed in the software design.
* Documentation Writer(s) - individuals who need to outline what a feature does, its purpose, and how it will fit into the current system

## 1.4 Design Summary
Users should be able to use the software easily and understand the new abilities of the game quickly. This documents outlines the design for “Extreme Chess” as a whole. Based off of the original game of Chess our product will offer a similar yet new experience to the game.

## 1.5 Overview 
 The Software Design Document is divided into 9 sections with subsections. The sections of the Software Design Document are:

1. Introduction: This section gives a brief introduction and summary to the project. 

2. Conceptual System Architecture: This section introduces the main system, subsystems, and their relation in the application. 

3. Subsystems Architecture: This section describes the design of each subsystem. 

4. Development View: This section provides the layout for the organization of the project.

5. Physical View: 

6. Database View: This section goes over the databases and data which will be used within the project. 

7. Work Assignment View: This section presents each task in the application and which developers have been tasked with completing it. 

8. Element Catalog: This section is a reference for all symbols used within the document. 

9. User Interface: This section represents and describes important aspects in the design of the graphical user interface.

 
# 2 Conceptual System Architecture
## 2.1 Overview
Extreme Chess is a spin on the game of Chess. As a game application, Extreme Chess must be designed
around two critical objectives. Firstly, it must reflect our vision for Extreme Chess. Our vision is threefold.
We want our take on chess to have diverse strategies, to be unpredictable, and to have high replayability.
Hence, we came up with the concept of upgrading pieces. Users can pick a collection of upgrades and use them to strengthen the functionality of their pieces at a cost. Secondly, and arguably the most important for a game, it must be entertaining. The significance of this costraint cannot be understated. The user interface must be responsive, logical, and intuitive in its design. Any slowdowns or confusion in communication between the user and the system will make maneuvering the system a chore and immediately damage the system's capacity to be fun. 
We have added numerous features for our user interface for ease of use. The user interface provides a move history log that displays the last 10 moves taken by the players, a forfeit button that allows a user to give up before a game has concluded, a list of the upgrades they have selected so that the user can quickly select what they wish to use, and a game settings menu that allows the user to change a few settings in the game.    On another note, Ultimate Chess's core upgrade mechanic must be finely balanced. Should one upgrade crowd out all the others, the game will fail to represent it's original intent -- diversification of strategy, unpredictability and high replayability. Thus, the upgrade feature must be highly flexible as this particular part of the system is highly susceptible to change. Furthermore, because chess is a game that can be broken into discrete parts, we feel that the game can be divided up into discrete states as well through the use of a state machine.

## 2.1 Turn Cycle
The turn cycle is outlined as follows: begin turn --> can select --> can move --> is moving --> has moved --> turn end --> begin turn.
## 2.1.1 Piece Movement
When a user specifies a piece to move, the system will highlight all cells that the piece can visit given
the rules of the piece. If the user selects one of these highlighted cells, the system will move the piece
from its starting position to the destination position specified by the user. If an opposing piece resides in the destination position, the system captures the piece and moves it to the graveyard.
## 2.1.2 Check
The system will prune all moves for a given piece that would result in the king being threatened by the opposing player's pieces. Additionally, if a player is in check and selects a piece, the system will try to find moves for that piece that will save the king. If no such moves exist, the player will not be able to move the piece.
## 2.1.3 Check Mate and Draw
If a player is put into check and has no moves left for any piece, the player is in check mate, and the system ends the game and decides a winner. If a player is not in check but has no moves left for any piece, the system ends the game with a draw and no winner is decided.
## 2.1.4 Promotion
If a player manages to move their pawn to one of the cells on the other end of the board, the player can replace their pawn with a piece of their choice.
## 2.2  Upgrading
At the beginning of the game, the system will prompt each player to select five upgrades out of a collection provided by the system. Once each player has selected their five upgrades, they will press a button at the bottom of the prompt and the system will set each player's upgrades. At this point the game would begin.
## 2.3 Energy
Energy is a player resource used in upgrading pieces. It has a maximum value of 100 and accumulates in increments of 20 at the beginning of the player's turn. When a player makes a move with an upgraded piece, the system will deduct the cost of the piece from Energy.
Once a player has selected a piece, every upgrade on their list of upgrades that can be used with the selected piece will be selectable. A player can deselect their upgrade as long as they haven't confirmed a move yet. Each upgrade has a cost. Once they have confirmed a move with an upgrade selected however, the system will deduct the cost of the upgrade from their resource (Energy) and the turn ends.
## 2.4 Graveyard
The system has two graveyards: one for the white player and one for the black player. When a piece is captured
on the board due to a move, the system moves the captured piece from the board to the capturing player's graveyard.
## 2.5 Move History
When a player finalizes a move (by selecting a piece, an optional upgrade, and then selecting a visitable cell for that piece), the system records both the source cell and destination cell of the move, as well as any captures, and records that data to the move history log.
## 2.6 Forfeiting
During gameplay, a user can opt to forfeit the game. The system then decides the winner early.
## 2.7 Highlighting
The system uses a highlighter to highlight elements on the board. The system always highlights board cells underneath the cursor blue to indicate the cursor's position on the board clearly. If their is a piece underneath the cursor, the piece is highlighted yellow. If a piece is selected, the system retains the yellow highlight on the piece and highlights all of the piece's visitable cells green. If there is an opposing piece on a visitable cell, that cell will be highlighted red instead.
# 3 Sub-systems Architecture
## 3.1 Overview
Due to our system's dependence on the Unity game engine, our system conforms to the model and structure of Unity. Unity is an Entity-Component driven system, and so all of the scripts that comprise our system are components of some entity in the Unity engine. Hence, we can think of our written scripts as being components of our system. For our system, we decided to go with a MVC architectural approach.
Our system is comprised of a game controller, which is composed of three specific game controllers: the board controller, the player controller, and the UI controller. The game controller is responsible for controlling messaging between these three sub-controllers and for managing game states. The board controller is responsible for application logic regarding changes to the board, its graveyards, and its pieces. The player controller is responsible for application logic regarding changes to the players and the actions players can make in the game. The UI controller is responsible for updating UI elements throughout the game.
Additionally, our system is comprised of a model. The model is representative of the entire domain of our system. Components of this model include the board, the pieces, the players, all game states, a move history log, upgrades, and graveyards. 
Finally, the view of the system is handled entirely by the Unity API. All controllers in our system may communicate with the Unity API to update the view of our system.

![](https://github.com/kylesarre/Temp-ChessProject/blob/master/SRSdiagrams/LogicalView.png)
## 3.2 Model
The Model for this program includes all of the data the program stores about the game: things such as playerName, playerColor, pieceLocation, and so on. This information is nested in scripts and handled by the Unity Game Engine. 
## 3.3 View
The system's View consists of everything the player can see on the screen: basically all of the user interface. More details on the user interface can be found in section 9.
## 3.4 Controllers
The operations and communications between the subsystems of the program are handled by the controllers. They can access and modify data in the Model as well as talk to the user interface to update the visual displayed on the screen.
### 3.4.1 Game Controller
The Game Controller(GC) coordinates connections between controllers and handles the GameState
Possible game states are: ...
Connections:
- board communicates with GC to tell UC to update graveyard
- player communicates with GC to tell UC to update energy #
- board communicates with GC to tell UC to update piece location on board
- board communicates with GC to update previous moves list

### 3.4.2 UI Controller (UC)
The User Controller uses button clicks to navigate to different screens as well as...
uses information received from GC to:
- update graveyard graphic to include captured piece
- update the player's energy
- update piece location
- highlight select cells/pieces on the board
- ensure player name at top corresponds to current player

### 3.4.3 Player Controller (PC)
The Player Controller is used at the start of the game to store the players' names and colors. During the game, when the GC tells it that a turn has passed for each player, it increases the players' energy by a set amount. Also, if a powerup is used, the player's energy is decremented by the amount dictated by the specific powerup.
### 3.4.4 Board Controller (BC)
The Board Controller keeps track of all the piece locations and how/where they are allowed to move every turn. It also tracks for check and checkmate. If a piece is selected on the user interface, the information is sent to the GC which tells the Board Controller to update the location of the piece on its side. The Board Controller also keeps track of previous moves and sends them to the GC to display on the user interface.
# 4 Development View
![](https://github.com/kylesarre/Temp-ChessProject/blob/master/SRSdiagrams/developmentview.PNG)
# 5 Physical View
On a physical level, the software will be solely confined to the PC on which the software is installed. This section is reserved in case there is a decision to incorporate other physical entities later on in the project.
# 6 Database View
There are no plans for the system to include any major database elements. This section is reserved in case there is a decision to implement a database later on in development.

# 7 Work-Assignment View
 * The user interface design will be assigned to Hanna Cunningham and Julian Plaisance. They will be responsible for ensuring that all UI elements are functional, and that all visual transitions and effects work as desired.
 * The game logic will be assigned to Robert Anderson, Kyle Sarre, and Gabriel Davis. They will be responsible for ensuring that the game logic, including the chess moves, ability activations, and win-condition logic all function properly.
 
# 8 Element Catalog
# 9 User Interfaces
The user interface windows shown here represent prototypes of the final design and will go through changes before the final product is released. As of now, they serve to model the buttons and corresponding functions of the interface.
## 9.1 Title Screen
![](https://github.com/kylesarre/Temp-ChessProject/blob/master/SRSdiagrams/Screenshot%20(3).png)

Selectable Objects:
- New Game Button: prompts for the name of Player1 and Player2 then creates a new game instance
- Help Button: opens the help menu
- Quit Button: closes the application

## 9.2 Main Game Screen
![](https://github.com/kylesarre/Temp-ChessProject/blob/master/SRSdiagrams/Screenshot%20(9).png)

The main game screen serves as the primary window in which the game will operate. It displays the graveyards, the current player's name and energy level, and the previous moves list. The UI Controller will update the graveyard every time a piece is captured. It will also switch the displayed name and energy to match the current player after every turn as well as add the last move to the list of previous moves in the grey box at the bottom of the screen. 

Selectable Objects:
- Pieces(of the same color as the current player): may be clicked to select; power-ups can then be used, or the piece moved
- Cells: highlighted when scrolled over; if a piece is selected at this time, the piece is able to be moved to the cell over which the mouse is hovering, and the mouse is clicked on this square, the piece will move to the location
- Game Dialog Button: brings up the Game Dialog Screen
- Forfeit Button: creates a dialog screen asking if the current player wishes to forfeit. If they select yes, the game ends with victory for the other player and returns to the title screen.

## 9.3 Game Dialog Screen
![](https://github.com/kylesarre/Temp-ChessProject/blob/master/SRSdiagrams/Screenshot%20(4).png)

Selectable Objects:
- Resume: returns player to the current game
- Options: opens the Options Screen
- Help: opens the Help Menu Screen
- Quit: creates a dialog screen asking if the player wishes to quit the game. If they select yes, the game ends without a victor and the title screen is displayed.

## 9.4 Options Screen
![](https://github.com/kylesarre/Temp-ChessProject/blob/master/SRSdiagrams/options.png)

Selectable Objects:
- Volume: the slider controls the volume of the background music in game
- Brightness: the slider controls the brightness of the game display
- Resume: returns player to game

## 9.5 Help Menu Screen
The help menu is intended to aid people that are new to chess or its extreme variant. It uses the Glossary of the Extreme Chess SRS for its definitions.

Selectable Objects:
- Chess Basics: displays the definition of chess with a neat summary of how to play the classic game
- Chess Pieces: displays a list of pieces which can be selected; once selected, the piece's information and move details are displayed
- Extreme Powerups: displays a list of in-game powerups; once selected, the piece the powerup can be used on, as well as its cost and effect are shown
- Back: returns player to game if currently in one


## 9.6 Other Dialog Screens
![](https://github.com/kylesarre/Temp-ChessProject/blob/master/SRSdiagrams/Screenshot%20(6).png)

The remaining user interface screens consists of multiple dialog boxes that ask a yes or no question. Upon answering no, the game will close the dialog screen and return to its last state. For the sake of simplicity and space, only one example is shown above: the forfeit dialog screen.

Dialog Screens:
- Forfeit: asks if current player would like to forfeit; if yes, the game ends with a banner showing the opposing player was the victor and then returns to the title screen
- Quit: asks if the player would like to quit the current game; if yes, the game ends without a victor and returns to the title screen
- Apply Powerup: asks if the player is sure they want to apply the selected powerup to the selected piece; if yes, the powerup  becomes active on that piece
