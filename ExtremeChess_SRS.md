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

* FIDE handbook: https://www.fide.com/fide/handbook.html
* Unity manual: https://docs.unity3d.com/Manual/index.html
* Unity Scripting API: https://docs.unity3d.com/ScriptReference/index.html
# 2.0 Overall Description
## 2.1 Product Perspective
"Extreme Chess" is a game app developed in Unity. It will allow users to play the game of Extreme Chess in a fun and convenient environment by utilizing the collection of key functions intended for this system.
## 2.2 Key Functions
The following key functions to be included in this system are:

* the ability for two players to play against one another at a game of Extreme chess:
	* players can move a piece
	* players can select upgrades for the game
	* players can use upgrades to enhance the functionality of their pieces
* allowing the user to adjust the volume of the game
* allowing the user to save and load a game
* allowing a user to forfeit a game whenever they choose
* a gui layer to help interface the end user with the system (helps wrap the system features into a more cohesive, easy to understand package)

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
## 3.1 User Interfaces
List of user interface components: main menu, control menu, options box, save box, load box, game menu, game over box.
## 3.2 Software Interfaces
* Unity - our system relies heavily on the Unity game engine version 5.4.2a. Unity provides core functionality to our project common in most game-based systems:
	* 2D rendering engine
	* sound
	* scripting
	* animation
	* memory management
	* scene manager
	* AI
  By taking advantage of the scripting api provided by Unity, we can utilize these low level tools to aid in the development of our own system (rather than building the system from scratch). 

# 4.0 System Features
## 4.1 Main Menu Screen
* The Main Menu shall be immediately rendered upon game startup
* The Main Menu shall consist of the title of the game, centered across the top of the screen, and the following clickable options: New Game, Load Game, Rules, Options, and Quit.
  * New Game: Upon selecting this option, the system will begin the process of creating a new game, as detailed in section 4.2.
  * Load Game: Upon selecting this option, the system will display a list of previously saved games, allowing the player to continue a previous game.
  * Rules: Upon selecting this option, the system will display a screen detailing the basic rules of chess, and the rules regarding the modifications of this program's chess variant.
  * Options: Upon selecting this option, the system will display a list of game options the user can modify. The user will be able to modify graphics settings, the default level of ability energy at game start, and the energy gain rate per turn.
  * Exit: Upon selecting this option, the application will terminate.
  
## 4.1.2.1 User Input/System Response (Quitting the game)
User|System
---|---
User clicks the quit button| The system terminates

## 4.1.2.2 User Input/System Response (New Game)
User clicks the New Game button | The system 

## 4.1.3 Nonfunctional Requirements

## 4.2 Creating a New Game
* Upon selecting “New Game,” the application will prompt Player 1 to enter their display name. Player 1 is the player associated with the white pieces (from here on referred to as “White”). The name entered will be displayed on the move history log on the gameplay screen above the player’s moves. After the name is entered, Player 2 will be prompted for the same process. Player 2 represents the player associated with the black pieces (from here on referred to as “Black”).

* After confirming the player names, the game will display the ability selection screen. This screen will display a list of all available special abilities, including their names, a description of their effects, and their energy costs. The game first prompts White to choose their ability setup.

* The player will select exactly five of these abilities. The abilities’ entries will be highlighted upon selection. By selecting an already-highlighted ability, the ability will be deselected and the highlight will be removed. When the player has selected five abilities, a button will appear allowing them to confirm their choices. The process will be displayed again for Black.

* When both players have completed their selections, the game screen will be displayed. The application shall render 64 colored squares in an 8 x 8 grid, in the layout of a chessboard as described by the conventions of the FIDE (Fédération Internationale des Échecs, or World Chess Federation) handbook, section E.01 – The Laws of Chess. The board grid will be aligned left-of-center of the screen. Icons representing each player’s ability selections will be displayed above or below the board, dependent on each player’s side of the board and the current active turn.

* Aligned to the right of the screen shall be a table representing the movement history. The table will be partitioned into two halves, with the left half displaying the player name and piece color of White on the top row, and the right half displaying the same for Black.

* At game setup, the application shall render icons representing the game pieces on the game board, with the black chess pieces starting at the top of the board, and the white pieces on the bottom. The pieces’ initial starting positions shall conform to the standards set out in the FIDE handbook.

* The first turn of the game loop then begins, starting with White.

## 4.2.2 User Input/System Response
User1| User2                                           |System                                                                  
--- | --- | ---
User selects "New Game"|| System prompts User1 to enter their display name
User enters their display name|| System prompts User2 to enter their display name
||User2 enters their display name| System displays the upgrade selection screen
User1 selects five upgrades||
User1 confirms their selection||System updates the upgrade list of user1
||User 2 selects five upgrades|System updates the upgrade list of user2
||User2 confirms their selection|
|||System begins the game

## 4.3.0 Taking Turns (Main Game Loop)

## 4.3.1 Functional Requirements

Item| SR-3: Taking turns
---|---
Priority| High
Summary| The system should allow users to take turns continuously until a user is unable to make a valid move 
Rational| Chess is a turn-based game that requires players to make a move on their turn. Hence, if a player can't make a move on their turn, the game is over.  
Requirements| The game must be separated into turns, where the system alternates between the two players. When the game begins, the first player's turn is always first. Each player must move a piece on their turn. For a player to move a piece, they must select a piece that matches their color. When a piece is selected, all cells that the piece can potentially move to will be highlighted green. If the cell a piece can potentially move to is occupied by a piece of the opposite color, the cell of the opposing piece will be highlighted red. Optionally, a player may choose to upgrade 1 piece 1 time before deciding on a move. If the player wishes, the player can undo an upgrade and then upgrade another piece as long as they haven't made a move for their turn. The player should be able to deselect a piece and select another piece. If a player has a piece selected and  they select one of the cells the piece can move to, all selections made by the player for this turn are final and the piece moves to the specified cell. Once a move occurs, the player's turn ends and the next player's turn begins. If a player's move renders the opposing player unable to move and the opposing player's king is not in check, the game should end in a draw. If a player's move renders the opposing player unable to move and the opposing player's king is in check, the game should end with the opposing player as the loser.  Players should be able forfeit or bring up the control menu during their turn. 
References| Activating an upgrade, forfeiting, control menu, State Diagram 

* The game loop shall be separated into turns, alternating between each player. During each player’s turn, the active player has several options: Move a piece, activate an ability, or access options.

* Move a piece:
  * To move a piece, the player shall click on a piece belonging to their color. When this is done, any available valid moves for that piece will have their destination squares highlighted green. Clicking on a valid destination square moves the piece to that square, checks to see if victory conditions are met, then ends the turn. If an opponent’s piece is on a valid square of capture/movement, moving the piece onto that square will capture the piece, removing it from the game. A piece’s valid moves/captures shall correspond to the Laws of Chess as laid out in the FIDE Handbook, unless altered by a previously activated ability. If an activated ability would allow the opponent’s King to be immediately captured, that move is disallowed.

* Activate an ability:
  * To activate an ability, the player shall click on the icon representing that ability on their ability display bar. This shall bring up a text box containing a description of the ability’s effects, the ability’s energy cost, and two buttons to activate or cancel the ability’s use. If the player lacks the required energy to activate the ability, the button that confirms the ability’s activation will be grayed out and unselectable. If the player activates the ability, the energy cost will be deducted from their energy display, and the valid moves of the pieces will be altered accordingly.

* Access options:
  * This brings up an options menu which allows the player to offer a draw, which, if accepted, ends the game in a draw, accept a draw offer, if offered on the previous turn, save the game state, allowing the game to be stopped and resumed at a later date, and quit the game, returning to the main menu.

* At end of turn:
  * Upon the end of a turn, the move the player made during the turn is recorded in the movement history table, numbered by the turn number, and displayed conforming to standard algebraic notation as dictated by the FIDE handbook. The next turn then begins for the player of the opposite color.

* End-of-game conditions:
  * At the end of each turn, the game will check if victory conditions have been met. If victory (or draw) conditions are met, the game will end, and display the text, “Game Over - <playerName> wins!” or, in the event of a draw, “Game Over – Draw!” The victory condition is to force Checkmate.
  * Checkmate occurs when a player places their opponent in Check, and the opponent has no valid moves that would result in that player no longer being in Check. Check is achieved when, following a move, the opponent’s king is in a square in which a friendly piece can make a valid capture. Check and checkmate are considered at the end of a turn, and only based on standard Chess moves. A piece with its valid moves altered by an ability cannot immediately force check with those altered moves (that is, capture the opponent’s King without a chance for the opponent to respond), though a piece with altered moves can use said moves to achieve a position which then results in check or checkmate under standard rules.
  * A draw occurs under several circumstances: First, if a player whose turn is active is not in check, but has no valid moves that would not result in that player being in check, the game is a draw. Second, if the same pattern of either two or three moves repeats three times in a row, the game is drawn. Third, a game is drawn after 75 moves without a victory (a checkmate on the 75th move overrules this). Finally, a game is drawn if each player agrees to it on their turns.

## 4.3.2 User Input/System Response
User                                           |System                                                                  
--- | ---
Player selects a piece | System highlights the cell yellow, highlights all movable cells green, and sets the list of upgrades as active. 
Player selects an upgrade from the list | System updates the functionality of the piece to what is specified by the user's selection.
Player selects a cell to move | System checks if the move is a valid one. If true, the system moves the piece to the specified cell.
|						|System transitions to the next players turn.

# 5.0 Other Nonfunctional Requirements

* The system should be able to carry out a move specified by the player in less than .5 seconds. The system should allow less than 2 seconds to transition from one turn to the next, to give time for any animations that need to be played during this transitionary period.
* The user should be able to quit the game and pull up the options or rules interface in less than .2 seconds. Launching a new game should begin in less than .2 seconds.
* Saving and loading games should take no less than 5 seconds.

# 5.1 Performance Requirements
As stated earlier in the document performance should remain quick and responsive regardless of what type of system the game is being run on(high end PC, mobile etc). It will be an offline game so there are no concerns when it will come to an internet connection messing with the performance of the game.

# 5.2 Safety Requirements
 The system used for the game will be a closed system; that is, all data that is managed by the system will only happen within the system. Nothing outside of the system will be affected; the user’s device will be unaffected by the application aside from taking up storage space. The same safety precautions when using a phone apply when using the mobile version of the app; do not utilize the app when driving and be wary to not get distracted by the app when in dangerous areas. For the desktop version be careful when sitting at the computer for extended periods of time.

# 5.3 Security Requirements
As stated earlier it will be a closed system so a security system will not implemented. It will be an offline player 1 vs player 2 system so no user data is being stored or used so in turn no security measures are needed.

# 5.4 Software Quality Attributes
The system will prioritize usability to give users an optimal experience. Ease-of-use will be promoted with simple design elements to keep the game easy to understand.   To eliminate frustration, the entire system will be thoroughly tested for potential glitches and game breaking abilities. Each feature mentioned will have testability. Developers will test each feature, developers will work together to test features together, and all developers will test the whole system to ensure a final product that works as intended.   . 

# 5.5 Business Rules
Not applicable to the system. It is purely academic with no monetary motivations.


# Appendix A: Glossary

* FIDE: The Fédération Internationale des Échecs, or World Chess Federation. The FIDE is the official governing body of international chess competition.
* White: The player associated with the white pieces, also referred to as "Player 1."
* Black: The player associated with the black pieces, also referred to as "Player 2."

# Appendix B: Analysis Models

## 1B. Turn Taking: State Diagram
![Alt text](https://github.com/kylesarre/Temp-ChessProject/blob/master/StateDiagramForChessRound.PNG "State Diagram:Turn Taking")
Figure 1: Illustrates the process of turn taking as a graph of states linked by conditionals as described in SR-3.

# Appendix C: To Be Determined List

* The nature of the set of abilities at the players' disposal will be subject to change and development to ensure game balance during playtesting.
* The precise layouts of the user interface, i.e. fonts, text sizes, pixel-level alignment of UI elements, etc. will be determined upon implementation.
