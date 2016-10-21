# Table of Contents

# 1 Introduction
## 1.1 Purpose
We intend for the following document to elaborate upon and specify the complete set of all functional/non-functional requirements and constraints of V.1.0 of our project "Extreme Chess." 
The primary purpose of this document is to simplify the job of the programmers who will be implementing the system features specified in this SRS. In order to satisfy this primary purpose,
this SRS should clearly and accurately define the set of all parameters(functional/non-functional requirements, constraints) that parameterize the design of this software and its features. Additionally,
we intend to clarify the requirements of the system through alternative representations of the material, such as use-case examples, charts, and illustrations.
## 1.2 Document Conventions
pending	
## 1.3 Intended Audience and Reading Suggestions
Our intended audience consists of:

* Developer(s) - individuals who are responsible for designing the software itself.
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

* General chess information: https://en.wikipedia.org/wiki/Rules_of_chess
* FIDE handbook: https://www.fide.com/fide/handbook.html
# 2 Overall Description
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
expect a software that simulates a consistent reimagining of classic chess, one in which they can navigate  and control with relatively little hassle. Thus,
all of the features to be included in this iteration of our system will be dedicated to serving the end user(s).
## 2.4 Operating  Environment
As of the most current version, The system shall operate on desktop and laptop computers, on the windows 7 platform and above. The entire system is to be designed and built using the Unity game engine.
## 2.5 Design and Implementation Constraints
* language requirement - Our system utilizes the Unity game engine to avoid the hassles of low level problems (memory management, rendering to screen, sound, etc.); however, this decision limits the developers of this project to the languages supported by the Unity API: C#, and JavaScript. To conform with Unity requirements, Our team has elected to use C# for the implementation of this project.
* hardware requirements - This system is designed under the assumption that the user is running our software with a PC running windows 7 or higher. Hence, we expect users to meet the bare minimum requirements necessary to run their operating system on their machine according to Microsoft's corresponding hardware specifications. 
## 2.6 User Documentation
The software will include a tutorial for general game-playing and maneuvering of the system, which will be accessible from the main menu. 
## 2.7 Assumptions and Dependencies
The following is a list of assumptions to be made during development:

* Correctness of Unity Libraries - We assume during the development of the system that the C# libraries covered in the Unity handbook function as stated.
* Users are running the software in its intended environment - We assume that the user will attempt to run the program in the environment for which it was designed, namely on a PC running Windows 7 or higher.

# 3 External Interfaces
## 3.1 User Interfaces
__Title Screen__ – features the name “Extreme Chess” along with buttons for New Game, Load Game, Rules, Options, and Quit.

__New Game Screen__ - accessed when selecting New Game on the Title Screen; prompts the user to input a name for player 1 and player 2.

__Main Game Screen__ – the screen in which the game of Extreme Chess is played. The screen displays a timer, a graveyard for captured pieces, the game board, a log of previous moves, a list of selected power-ups, the amount of energy possessed by the current player, a gear icon button, and a forfeit flag button. On the Main Game Screen, a player may choose to select and move their pieces, use power-ups, or select one of the available buttons.

__Game Dialog Screen__ – accessed by clicking the gear icon in the lower right corner of the Main Game Screen; displays buttons for Options, Save, Rules, Quit, and Resume.

__Forfeit Dialog Boxes 1 and 2__ – Forfeit Dialog Box 1 appears when clicking on the forfeit flag in the Main Game Screen and it asks if the current player wishes to forfeit, offering a Yes or No option. If Yes is selected, Forfeit Dialog Box 2 will appear to ask the player if they are sure of their decision to forfeit. If they select Yes again, then the Game Over Screen is displayed. If the player selects No on either screen, the player is returned to the current game on the Main Game Screen.

__Save/Load Screen__ – appears when clicking Load Game in the Title Screen, or Save in the Game Dialog Menu; displays up to ten saved game files in a list format. A game can be selected from the list and loaded by clicking the Load button on this screen. If a game is already in session, buttons for Save and Continue as well as Save and Quit will be displayed. Save and Continue allows for an instance of the current game to be saved, then the player is returned to the active game. If Save and Quit is selected, the current game will be saved and the player will be redirected to the Title Screen.

__Rules__ – accessed by clicking Rules on the Title Screen or in the Game Dialog Screen; displays the basic rules of chess and the functions of all power-ups in the game. 

__Title Screen Options__ – accessed by clicking the Options button on the Title Screen; allows the user to choose a set amount of energy with which to start a new game, energy gain per turn, and game options such as screen brightness and music volume.

__In Game Options__ – accessed by clicking the Options button on the Game Dialog Screen; allows the user to adjust screen brightness and music volume in game.

__Quit Dialog Box__ – accessed when clicking the Quit button in the Game Dialog Screen; asks the player if they would like to leave the game without saving with a Yes or No option. If the player responds Yes, then the current game is exited and the Title Screen is displayed. If No is selected, the game returns to its current state.

__Game Over Screen__ – accessed when a game is forfeited, checkmate is reached, or a stalemate occurs. The screen displays the names of the players as well as who won and who lost, unless a stalemate was reached: then it displays that there was no winner. A confirm button appears which redirects the player back to the Title Screen. 

## 3.2 Hardware Interfaces
The software in question is compatible only with PC and requires access to a monitor, keyboard, and mouse. The monitor displays the user interface, allowing the user to view the game and make decisions based on the current position of chess pieces. The keyboard is used to enter the names of players upon starting a new game in order to make saved games easier to track and allow a name to be displayed on the turn of the current player. The mouse is the primary hardware component by which a user may navigate the screen, clicking to select various buttons as well as chess pieces and their intended destinations on the board. 
## 3.3 Software Interfaces
The Windows Operating System is necessary in order to compile and interpret the code to run Extreme Chess. 
## 3.4 Communications Interfaces
Extreme Chess does not communicate with any external entities.


# 4 System Features
## 4.1 Main Menu Screen
* The Main Menu shall be immediately rendered upon game startup
* The Main Menu shall consist of the title of the game, centered across the top of the screen, and the following clickable options: New Game, Load Game, Rules, Options, and Quit.
  * New Game: Upon selecting this option, the system will begin the process of creating a new game, as detailed in section 4.2.
  * Load Game: Upon selecting this option, the system will display a list of previously saved games, allowing the player to continue a previous game.
  * Rules: Upon selecting this option, the system will display a screen detailing the basic rules of chess, and the rules regarding the modifications of this program's chess variant.
  * Options: Upon selecting this option, the system will display a list of game options the user can modify. The user will be able to modify graphics settings, the default level of ability energy at game start, and the energy gain rate per turn.
  * Exit: Upon selecting this option, the application will terminate.

## 4.2 Creating a New Game
* Upon selecting “New Game,” the application will prompt Player 1 to enter their display name. Player 1 is the player associated with the white pieces (from here on referred to as “White”). The name entered will be displayed on the move history log on the gameplay screen above the player’s moves. After the name is entered, Player 2 will be prompted for the same process. Player 2 represents the player associated with the black pieces (from here on referred to as “Black”).

* After confirming the player names, the game will display the ability selection screen. This screen will display a list of all available special abilities, including their names, a description of their effects, and their energy costs. The game first prompts Player 1 to choose their ability setup.

* The player will select exactly five of these abilities. The abilities’ entries will be highlighted upon selection. By selecting an already-highlighted ability, the ability will be deselected and the highlight will be removed. When the player has selected five abilities, a button will appear allowing them to confirm their choices. The process will be displayed again for Player 2.

* When both players have completed their selections, the game screen will be displayed. The application shall render 64 colored squares in an 8 x 8 grid, in the layout of a chessboard as described by the conventions of the FIDE (Fédération Internationale des Échecs, or World Chess Federation) handbook, section E.01 – The Laws of Chess. The board grid will be aligned left-of-center of the screen. Icons representing each player’s ability selections will be displayed above or below the board, dependent on each player’s side of the board and the current active turn.

* Aligned to the right of the screen shall be a table representing the movement history. The table will be partitioned into two halves, with the left half displaying the player name and piece color of White on the top row, and the right half displaying the same for Black.

* At game setup, the application shall render icons representing the game pieces on the game board, with the black chess pieces starting at the top of the board, and the white pieces on the bottom. The pieces’ initial starting positions shall conform to the standards set out in the FIDE handbook.

* The first turn of the game loop then begins, starting with White.

## 4.3 Main Game Loop
* The game loop shall be separated into turns, alternating between each player. During each player’s turn, the active player has several options: Move a piece, activate an ability, or access options.

* Move a piece:
  * To move a piece, the player shall click on a piece belonging to their color. When this is done, any available valid moves for that piece will have their destination squares highlighted green. Clicking on a valid destination square moves the piece to that square, checks to see if victory conditions are met, then ends the turn. If an opponent’s piece is on a valid square of capture/movement, moving the piece onto that square will capture the piece, removing it from the game. A piece’s valid moves/captures shall correspond to the Laws of Chess as laid out in the FIDE Handbook, unless altered by a previously activated ability. If an activated ability would allow the opponent’s King to be immediately captured, that move is disallowed.

* Activate an ability:
  * To activate an ability, the player shall click on the icon representing that ability on their ability display bar. This shall bring up a text box containing a description of the ability’s effects, the ability’s energy cost, and two buttons to activate or cancel the ability’s use. If the player lacks the required energy to activate the ability, the button that confirms the ability’s activation will be grayed out and not selectable. If the player activates the ability, the energy cost will be deducted from their energy display, and the valid moves of the pieces will be altered accordingly.

* Access options:
  * This brings up an options menu which allows the player to offer a draw, which, if accepted, ends the game in a draw, accept a draw offer, if offered on the previous turn, save the game state, allowing the game to be stopped and resumed at a later date, and quit the game, returning to the main menu.

* At end of turn:
  * Upon the end of a turn, the move the player made during the turn is recorded in the movement history table, numbered by the turn number, and displayed conforming to standard algebraic notation as dictated by the FIDE handbook. The next turn then begins for the player of the opposite color.

* End-of-game conditions:
  * At the end of each turn, the game will check if victory conditions have been met. If victory (or draw) conditions are met, the game will end, and display the text, “Game Over - <playerName> wins!” or, in the event of a draw, “Game Over – Draw!” The victory condition is to force Checkmate.
  * Checkmate occurs when a player places their opponent in Check, and the opponent has no valid moves that would result in that player no longer being in Check. Check is achieved when, following a move, the opponent’s king is in a square in which a friendly piece can make a valid capture. Check and checkmate are considered at the end of a turn, and only based on standard Chess moves. A piece with its valid moves altered by an ability cannot immediately force check with those altered moves (that is, capture the opponent’s King without a chance for the opponent to respond), though a piece with altered moves can use said moves to achieve a position which then results in check or checkmate under standard rules.
  * A draw occurs under several circumstances: First, if a player whose turn is active is not in check, but has no valid moves that would not result in that player being in check, the game is a draw. Second, if the same pattern of either two or three moves repeats three times in a row, the game is drawn. Third, a game is drawn after 75 moves without a victory (a checkmate on the 75th move overrules this). Finally, a game is drawn if each player agrees to it on their turns.

# 5 Other Nonfunctional Requirements

# 6 Other Requirements

# Appendix A: Glossary
__Chess:__ a strategy board game played between two players in which each player takes turns maneuvering 16 chess pieces around a chess board, capturing their opponent’s pieces, and ultimately attempting to put the other player into checkmate. Each player is assigned a unique color at the start of the game that corresponds to their game pieces-black or white-and the player who controls the white pieces always makes the first move.

__Piece:__ one of seven unique types of game pieces used in chess; each possessing a different movement pattern and rules specific to itself.

__Board:__ the field of play for the chess; consists of an 8 by 8 grid of squares in which the player may maneuver their pieces-in normal chess, only one piece may occupy one grid square at a time.

__Capture:__ occurs when one piece lands on top of an opponent’s piece, resulting in the removal of the opponent’s piece from the board.

__Pawn:__ the most numerous piece in a chess game; each player begins with 8 pawns positioned in front of the pieces along their back line. Under most conditions, pawns can only move forward a single space each turn or capture a piece diagonally in front of it. On the first move of the pawn, however, it may move two spaces forward. If you choose to move your pawn two spaces on its first move, then your opponent moves the pawn directly across from yours in the same way, your pawn may move diagonally forward one space and capture their pawn. This is the only scenario in the game in which one piece may capture another without landing directly on it. If a pawn is not captured and makes its way to the end of the board, all the way to the back line of the opponent’s side, it may be upgraded. When upgraded, the player controlling the pawn may choose to turn it into another piece of their choosing, namely a rook, knight, bishop, or queen. 

__Rook:__ a piece that may move any number of squares in a straight line-forward, backward, left, or right-as long as its path is not blocked by a piece of the same color.

__Knight:__ a piece that always moves in an ‘L’ shape; it may move two spaces in a straight line-forward, backward, left, or right-then it must move one square at a right angle to its initial movement direction. The knight is the only piece that may jump over other pieces, friend or foe.

__Bishop:__ a piece that may move any number of squares diagonally; of the player’s bishops, one begins on a white space, while the other appears on a dark space. Under normal conditions, a bishop will never move to a square with a different color than the one on which it started.

__Queen:__ often considered the most powerful chess piece, the queen may move any number of squares in any of the cardinal directions, meaning it can choose to move like a rook or a bishop on any given turn.

__King:__ the piece to be protected; the point of the game of chess is to defend the king and ensure the opponent does not capture the piece. One must move their pieces around to prevent the king from being cornered, as the king can move in any of the cardinal directions, like the queen, but it can only move a single space in any direction per turn.

__Check:__ the condition where a king is in danger. If an opponent moves one of their pieces into a position by which it may capture the king on the next turn, the threatened king is considered ‘in check.’ The player with the threatened king then has three options: move the king to a position in which it is not threatened, capture the piece that threatens the king, or move another one of their pieces to obstruct the piece that is threatening the king. 

__Checkmate:__ signals the end of the game; occurs when a king is threatened and the player controlling that king can make no possible moves to get the king out of check

__Castling:__ a special move in standard chess-the only one that allows two pieces to be moved at the same time. If the back line of a player’s side is clear of game pieces between one of their rooks and their king, neither of those pieces have moved in the game yet, and the king is not in check, a player may move their king over one space towards the rook, move the rook next to the king, and then swap the position of the two pieces.

__Power-Ups:__ special bonuses purchased with Energy in Extreme Chess; allows the normal rules of chess to be bent for more a more Extreme gameplay experience.

__Energy:__ currency acquired during the gameplay of Extreme Chess at the rate per turn determined at game start; used to purchase power-ups. 


# Appendix B: Analysis Models

# Appendix C: To Be Determined List


