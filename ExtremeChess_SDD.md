# Extreme Chess: Software Design Document
### Team Members: Robert Anderson, Hanna Cunningham, Gabriel Davis, Julian Plaisance, Kyle Sarre

# Table of Contents
### 1 Introduction
Gabe needs to add subsections
### 2 Conceptual System Architecture
#### 2.1 Overview
#### 2.2 Upgrading
#### 2.3 Energy
#### 2.4 Piece Movement
#### 2.5 Graveyard
#### 2.6 Move History
#### 2.7 The Game Board
#### 2.8 Pieces
#### 2.9 Turn Phases
### 3 Sub-systems Architecture
add sections for subsystems
### 4 Logical View
### 5 Development View
### 6 Physical View
### 7 Database View
### 8 Work-Assignment View
### 9 Element Catalog
### 10 User Interfaces


# 1 Introduction
## 1.1 Purpose
## 1.2 Intended Audience
optional
## 1.3 Scope
## 1.4 Design Summary
optional
## 1.5 Overview 
 optional
# 2 Conceptual System Architecture
## 2.1 Overview
Extreme Chess is a spin on the game of Chess. As a game application, Extreme Chess must be designed
around two critical objectives. Firstly, it must reflect our vision for Extreme Chess. Our vision is threefold.
We want our take on chess to have diverse strategies, to be unpredictable, and to have high replayability.
Hence, we came up with the concept of upgrading pieces. Users can pick a collection of upgrades and use them to strengthen the functionality of their pieces at a cost. Secondly, and arguably the most important for a game, it must be entertaining. The significance of this costraint cannot be understated. The user interface must be responsive, logical, and intuitive in its design. Any slowdowns or confusion in communication between the user and the system will make maneuvering the system a chore and immediately damage the system's capacity to be fun. 
We have added numerous features for our user interface for ease of use. The user interface provides a move history log that displays the last 10 moves taken by the players, a forfeit button that allows a user to give up before a game has concluded, a list of the upgrades they have selected so that the user can quickly select what they wish to use, and a game settings menu that allows the user to change a few settings in the game.    On another note, Ultimate Chess's core upgrade mechanic must be finely balanced. Should one upgrade crowd out all the others, the game will fail to represent it's original intent -- diversification of strategy, unpredictability and high replayability. Thus, the upgrade feature must be highly flexible as this particular part of the system is highly susceptible to change. Furthermore, because chess is a game that can be broken into discrete parts, we feel that the game can be divided up into discrete states as well through the use of a state machine.

##2.1 Turn Cycle
The turn cycle is outlined as follows: begin turn --> can select --> can move --> is moving --> has moved --> turn end --> begin turn.
##2.1 Piece Movement
When a user specifies a piece to move, the system will highlight all cells that the piece can visit given
the rules of the piece. If the user selects one of these highlighted cells, the system will move the piece
from its starting position to the destination position specified by the user. If an opposing piece resides in the destination position, the system captures the piece and moves it to the graveyard.
##2.1.2 Check
The system will prune all moves for a given piece that would result in the king being threatened by the opposing player's pieces. Additionally, if a player is in check and selects a piece, the system will try to find moves for that piece that will save the king. If no such moves exist, the player will not be able to move the piece.
##2.1.3 Check Mate and Draw
If a player is put into check and has no moves left for any piece, the player is in check mate, and the system ends the game and decides a winner. If a player is not in check but has no moves left for any piece, the system ends the game with a draw and no winner is decided.
##2.1.4 Promotion
If a player manages to move their pawn to one of the cells on the other end of the board, the player can replace their pawn with a piece of their choice.
##2.2  Upgrading
At the beginning of the game, the system will prompt each player to select five upgrades out of a collection provided by the system. Once each player has selected their five upgrades, they will press a button at the bottom of the prompt and the system will set each player's upgrades. At this point the game would begin.
##2.3 Energy
Energy is a player resource used in upgrading pieces. It has a maximum value of 100 and accumulates in increments of 20 at the beginning of the player's turn. When a player makes a move with an upgraded piece, the system will deduct the cost of the piece from Energy.
Once a player has selected a piece, every upgrade on their list of upgrades that can be used with the selected piece will be selectable. A player can deselect their upgrade as long as they haven't confirmed a move yet. Each upgrade has a cost. Once they have confirmed a move with an upgrade selected however, the system will deduct the cost of the upgrade from their resource (Energy) and the turn ends.
##2.4 Graveyard
The system has two graveyards: one for the white player and one for the black player. When a piece is captured
on the board due to a move, the system moves the captured piece from the board to the capturing player's graveyard.
##2.5 Move History
When a player finalizes a move (by selecting a piece, an optional upgrade, and then selecting a visitable cell for that piece), the system records both the source cell and destination cell of the move, as well as any captures, and records that data to the move history log.
##2.6 Forfeiting
During gameplay, a user can opt to forfeit the game. The system then decides the winner early.
##2.7 Highlighting
The system uses a highlighter to highlight elements on the board. The system always highlights board cells underneath the cursor blue to indicate the cursor's position on the board clearly. If their is a piece underneath the cursor, the piece is highlighted yellow. If a piece is selected, the system retains the yellow highlight on the piece and highlights all of the piece's visitable cells green. If there is an opposing piece on a visitable cell, that cell will be highlighted red instead.
# 3 Sub-systems Architecture
##3.1 Overview
Due to our system's dependence on the Unity game engine, our system conforms to the model and structure of Unity. Unity is an Entity-Component driven system, and so all of the scripts that comprise our system are components of some entity in the Unity engine. Hence, we can think of our written scripts as being components of our system. For our system, we decided to go with a MVC architectural approach.
Our system is comprised of a game controller, which is composed of three specific game controllers: the board controller, the player controller, and the UI controller. The game controller is responsible for controlling messaging between these three sub-controllers and for managing game states. The board controller is responsible for application logic regarding changes to the board, its graveyards, and its pieces. The player controller is responsible for application logic regarding changes to the players and the actions players can make in the game. The UI controller is responsible for updating UI elements throughout the game.
Additionally, our system is comprised of a model. The model is representative of the entire domain of our system. Components of this model include the board, the pieces, the players, all game states, a move history log, upgrades, and graveyards. 
Finally, the view of the system is handled entirely by the Unity API. All controllers in our system may communicate with the Unity API to update the view of our system.
3.2 
    
Include rational for each
# 4 Logical View
![](https://github.com/kylesarre/Temp-ChessProject/blob/master/SRSdiagrams/LogicalView.png)
# 5 Development View
# 6 Physical View
# 7 Database View
# 8 Work-Assignment View
# 9 Element Catalog
# 10 User Interfaces
