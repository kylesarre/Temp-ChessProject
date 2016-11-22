##1. User Interface

###1.1 Startup and Main Menu

Test Case #: 1.1.1| Test Case Name: Main Menu
---|---
System: Extreme Chess | Subsystem: UI
Designed by: Hanna Cunningham | Design Date: 11/21/16
Executed by: | Execution Date:
Short Description: The main menu must load at startup.

Step|Action|Expected System Response|Pass/Fail|Comment
---|---|---|---|---
1| Select and run game icon/executable | display main menu | | 
Post-conditions: The items in the main menu can be selected.

Test Case #: 1.1.2| Test Case Name: New Game
---|---
System: UI | Subsystem: 
Designed by: Hanna Cunningham | Design Date: 11/21/16
Executed by: | Execution Date:
Short Description: Create a new game from the main menu.

Step|Action|Expected System Response|Pass/Fail|Comment
---|---|---|---|---
1| Click New Game in Main Menu| Prompts for Player 1’s name| | 
2| Enter name for Player 1 and click OK |Prompts for Player 2’s name| | 	
3| Enter name for Player 2 and click OK |Loads the game board with all pieces in their default locations| | 
Post-conditions: The game board will now be in a playable state.

###1.2 Help Menu

Test Case #: 1.2.1| Test Case Name: Help Menu
---|---
System: UI | Subsystem: 
Designed by: Hanna Cunningham | Design Date: 11/21/16
Executed by: | Execution Date:
Short Description: Provides players with the knowledge to understand the game system and its powerups, allowing people new to chess to grasp the basic principles of the game. 

Step|Action|Expected System Response|Pass/Fail|Comment
---|---|---|---|---
1| Click Help in either the Main Menu or Game Dialog Menu| Load Help Menu| |
2a|Click How to Play| Loads screen with description on how chess works| |
2b| Click Back button| Returns to Help Menu| |
3a| Click Chess Pieces| Loads screen that displays pieces| |
3b| Select a Piece| Shows description of the piece| |
3c| Click Back button| Returns to Piece Selection| | 
3d| Click Back button| Returns to Help Menu| | 
4a| Click Powerups| Loads screen that displays powerups| |
4b| Select a Powerup| Shows description of the powerup| |
4c| Click Back button| Returns to Powerup Selection| | 
4d| Click Back button| Returns to Help Menu| |
5a| Click Special Moves and Restrictions| Loads screen with description on the special moves of chess and the rules to which the game does not conform| |
5b| Click Back button| Returns to Help Menu| |
6a| Click Glossary| Loads screen with glossary of chess terms sorted alphabetically| |
6b| Click Back button| Returns to Help Menu| |
7| Click Resume| Returns player to previous menu, either Main Menu or the Game Dialog Menu| |

####1.3 Quit
1.3.1 Quit from Main Menu
...

###1.4 Main Game

Test Case #: 1.4.1| Test Case Name: Settings Button
---|---
System: UI| Subsystem: In game menu
Designed by: Julian Dane Plaisance| Design Date: 11/19/16
Executed by: | Execution Date:
Short Description:
Black-Box Testing case for the in game menu Settings Button

Step|Action|Expected System Response|Pass/Fail|Comment
---|---|---|---|---
1| Click inside the button boundaries | Brings up the Game dialogue menu | p/f | 
2| Click at the button boundaries | Brings up the Game dialogue menu| p/f | 	
3| Click near but outside the button boundaries | Nothing | p/f |  
Post-conditions:
None

Test Case #: 1.4.2| Test Case Name: Forfeit Button
---|---
System: UI| Subsystem: In game menu
Designed by: Julian Dane Plaisance| Design Date: 11/19/16
Executed by: | Execution Date:
Short Description:
Black-Box Testing case for the in game menu Forfeit Button

Step|Action|Expected System Response|Pass/Fail|Comment
---|---|---|---|---
1| Click inside the button boundaries | Brings up the forfeit dialogue box | p/f | 
2| Click at the button boundaries | Brings up the forfeit dialogue | p/f | 	
3| Click near but outside the button boundaries | Nothing | p/f |  
Post-conditions:
None

Test Case #: 1.4.3| Test Case Name: Energy amount
---|---
System: UI| Subsystem: In game menu
Designed by: Julian Dane Plaisance| Design Date: 11/19/16
Executed by: | Execution Date:
Short Description:
Black-Box Testing case for the in game menu Energy UI representation

Step|Action|Expected System Response|Pass/Fail|Comment
---|---|---|---|---
1| White and then Black end turn | Energy goes up by amount specified by game logic team | p/f |
Post-conditions:
None

Test Case #: 1.4.4| Test Case Name: Graveyard Display
---|---
System: UI| Subsystem: In game menu
Designed by: Julian Dane Plaisance| Design Date: 11/19/16
Executed by: | Execution Date:
Short Description:
Black-Box Testing case for the in game menu Graveyard Display

Step|Action|Expected System Response|Pass/Fail|Comment
---|---|---|---|---
1| White captures a Black piece | Black piece captured appears in black graveyard | p/f | 
2| Black captures a White piece | White piece captured appears in white graveyard | p/f | 	
3| If a pawn of either colour gets to the opposite side of the board | pawn is added to graveyard and piece chosen to replace pawn is removed from the graveyard | p/f |  
Post-conditions:
None

Test Case #: 1.4.5| Test Case Name: Previous moves display
---|---
System: UI| Subsystem: In game menu
Designed by: Julian Dane Plaisance| Design Date: 11/19/16
Executed by: | Execution Date:
Short Description:
Black-Box Testing case for the in game menu Previous moves display

Step|Action|Expected System Response|Pass/Fail|Comment
---|---|---|---|---
1| Either player make their move | updates showing what piece moved from, to, and what it captured | p/f | 
Post-conditions:
None

Test Case #: 1.4.6| Test Case Name: Player’s turn
---|---
System: UI| Subsystem: In game menu
Designed by: Julian Dane Plaisance| Design Date: 11/19/16
Executed by: | Execution Date:
Short Description:
Black-Box Testing case for the in game text displaying whose turn it is.

Step|Action|Expected System Response|Pass/Fail|Comment
---|---|---|---|---
1| Game starts | Display’s “$White-player turn” | p/f | 
2| White moves | Display’s “$Black-player turn” | p/f | 	
3| Black moves | Display’s “$White-player turn” | p/f | 
Post-conditions:
None

###1.5 Game Dialog Screen
#####1.5.1 Resume
#####1.5.2 Options
#####1.5.3 Help
#####1.5.4 Quit

###1.6 Options

Test Case #: 1.6.1.1| Test Case Name: Brightness Test #1
---|---
System: UI |Subsystem: Options
Designed by: Hanna Cunningham | Design Date: 11/21/16
Executed by: | Execution Date:
Short Description: 

Step|Action|Expected System Response|Pass/Fail|Comment
---|---|---|---|---
1| Click Options in the Game Dialog Screen| Displays Options Menu| | 
2| Move slider labeled Brightness to the left| Game screen darkens| | 
3| Click Resume | Returns to Game Dialog Screen| | 
Post-conditions: Game remains at this brightness unless adjusted

Test Case #: 1.6.1.2| Test Case Name: Brightness Test #2
---|---
System: UI |Subsystem: Options
Designed by: Hanna Cunningham | Design Date: 11/21/16
Executed by: | Execution Date:
Short Description: 

Step|Action|Expected System Response|Pass/Fail|Comment
---|---|---|---|---
1| Click Options in the Game Dialog Screen| Displays Options Menu| | 
2| Move slider labeled Brightness to the right| Game screen gets lighter| | 
3| Click Resume | Returns to Game Dialog Screen| | 
Post-conditions: Game remains at this brightness unless adjusted

Test Case #: 1.6.2.1| Test Case Name: Volume Test #1
---|---
System: UI |Subsystem: Options
Designed by: Hanna Cunningham | Design Date: 11/21/16
Executed by: | Execution Date:
Short Description: 

Step|Action|Expected System Response|Pass/Fail|Comment
---|---|---|---|---
1| Click Options in the Game Dialog Screen| Displays Options Menu| | 
2| Move slider labeled Volume to the left| Music volume gets quieter| | 
3| Click Resume | Returns to Game Dialog Screen| | 
Post-conditions: Game remains at this volume level unless adjusted

Test Case #: 1.6.2.2| Test Case Name: Volume Test #2
---|---
System: UI |Subsystem: Options
Designed by: Hanna Cunningham | Design Date: 11/21/16
Executed by: | Execution Date:
Short Description: 

Step|Action|Expected System Response|Pass/Fail|Comment
---|---|---|---|---
1| Click Options in the Game Dialog Screen| Displays Options Menu| | 
2| Move slider labeled Volume to the right| Music volume gets louder| | 
3| Click Resume | Returns to Game Dialog Screen| | 
Post-conditions: Game remains at this volume level unless adjusted

##2. Main Game

###2.1 Check/Checkmate

Test Case #: 2.1.1| Test Case Name: Check Declaration
---|---
System: Main Gameplay| Subsystem: Check/Checkmate
Designed by: Kyle Sarre| Design Date: 11/20/2016
Executed by: | Execution Date:
Short Description:
A test to determine that a king being threatened by an opposing piece (an opposing piece can capture the king in the following turn) results in the system identifying check. Suppose we have the black king at D4, and the white queen at E6, and it is the white player's turn.

Step|Action|Expected System Response|Pass/Fail|Comment
---|---|---|---|---
1| Attempt to move white queen to E5 | System moves white queen to E5; declares player black is in check | P/F |
Post-conditions:
The white queen should be at E5 and threatening to capture the black king at D4. When the white player attempts to move, their moves should be limited to preventing the queen from threatening the king.

Test Case #: 2.1.2| Test Case Name: Stalemate Declaration
---|---
System: Main Gameplay | Subsystem: Check/Checkmate
Designed by: Kyle Sarre| Design Date: 11/20/2016
Executed by: | Execution Date:
Short Description:
Test if, whenever a player is NOT in check and they no longer have any valid moves, the system declares a stalemate.
Suppose we have a black king at C1, a white king at B3 and a white queen at D4, and it is white's turn.

Step|Action|Expected System Response|Pass/Fail|Comment
---|---|---|---|---
1| Attempt to move the white queen to D3 | System Moves white queen to D3 and reports that a stalemate has occurred. | P/F | 
Post-conditions:
The game ends; both players lose.

Test Case #: 2.1.3| Test Case Name: Two Piece Check
---|---
System: Main Gameplay| Subsystem: Check/Checkmate
Designed by: Kyle Sarre| Design Date:
Executed by: | Execution Date:
Short Description:
System should require the player to move their king when a check by two pieces occurs. For this test,
suppose we have a black bishop at C3, a black rook at D4, and a white king at E5, a white queen at g3, and it is currently black's turn.

Step|Action|Expected System Response|Pass/Fail|Comment
---|---|---|---|---
1| Attempt to move black rook to E4| System moves black rook to E4| | 
2| Attempt to move queen to bishop at C3| System fails to move queen to C3| | 	
3| Attempt to move king to E4| System moves king to E4 and captures black rook| | 
Post-conditions:
White is no longer in check, the black rook is no longer in play, and the king is now located at E4.

Test Case #: 2.1.4| Test Case Name: Check/Checkmate: Fool's Mate
---|---
System: Main Game | Subsystem: Check/Checkmate
Designed by: Robert Anderson | Design Date: 11/21/2016
Executed by: | Execution Date:
Short Description:
A simple test case for the checkmate system. Plays out the fastest checkmate possible in a game of chess.

Step|Action|Expected System Response|Pass/Fail|Comment
---|---|---|---|---
1| Upon game start, move White's c-file pawn to c3. | Game executes 1. c3 | | 
2| Move Black's e-file pawn to e5. | Game executes 1. ... e5 | | 	
3| Move White's g-file pawn to g4. | Game executes 2. g4 | | 
4| Move Black's queen to h4. | Game executes 2. ... Qh4#, declares checkmate. | | 
Post-conditions:
None

Test Case #: 2.1.5| Test Case Name: Check/Checkmate - Piece Interposition
---|---
System: Main Gameplay | Subsystem: Piece Movement
Designed by: Robert Anderson | Design Date: 11/20/2016
Executed by: | Execution Date:
Short Description:
Test case for piece interposition - The method of escaping check by moving a friendly piece to block the path of the opposing piece laying check

Step|Action|Expected System Response|Pass/Fail|Comment
---|---|---|---|---
1| At game start, move White's e-file pawn to e4 | Game executes 1. e4 | | 
2| Move Black's d-file pawn to d5 | Game executes 1. ... d5 | | 	
3| Capture Black's d5 pawn with White's e4 pawn | Game executes 2. exd5 | | 
4| Capture White's d5 pawn with Black's queen | Game executes 2. ... Qxd5 | | 
5| Move one of White's remaining pawns forward one square (essentially, pass turn to black) | Game executes the move | | 
6| Move Black's queen to e5, creating check on the white king| Game executes 3. ... Qe5+, declares check | | 
7| Move White's kingside bishop to e2, interposing it between the White king and the Black queen. | Game executes 4. Be2, removes the check | | 
Post-conditions: White's bishop at e2 should not be able to move from its position until either the Black queen or the White king move away from the e-file, or another piece interposes between the Black king and White bishop.

###2.2 Basic Movement

Test Case #: 2.2.1| Test Case Name: Default Piece Movement Behavior (Outside of check, excluding king, not locked in place)
---|---
System: Main Gameplay| Subsystem: Piece Movement
Designed by: Kyle Sarre| Design Date: 11/20/2016
Executed by: | Execution Date:
Short Description:
Test case for normal piece movement outside of check. Pieces should move according to the ruleset defined in the FIDE handbook. All piece movement is generated exactly the same way, except for the pawn. Assume all pieces are at their default positions.

Step|Action|Expected System Response|Pass/Fail|Comment
---|---|---|---|---
1| Attempt to move the white pawn from C2 to C4| System moves the pawn to C4| P/F |
2| Attempt to move the white pawn from C4 to C6| System fails to move the pawn to C6| P/F |
3| Attempt to move the white pawn from D4 to D5| Sysem moves the pawn to C5| P/F |
4| Attempt to move the queen from D1 to A4| System moves the queen to A4| P/F |
5| Attempt to move the queen from A4 to A8| System fails to move the queen to A4 | P/F |
Post-conditions:
The pawn should be at cell C5 and the queen should be at cell A4.

Test Case #: 2.2.2| Test Case Name: King Movement Behavior
---|---
System: Main Gameplay| Subsystem: Piece Movement
Designed by:Kyle Sarre | Design Date: 11/20/2016
Executed by: | Execution Date:
Short Description:
Test if the king cannot make a move that would put itself in check

Step|Action|Expected System Response|Pass/Fail|Comment
---|---|---|---|---
1| Attempt to move black king to D4| Game executes the move| P/F |
2| Attempt to move white rook to C5| Game executes the move| P/F |
3| Attempt to move black king to C5| Game does not execute the move| P/F |
4| Attempt to move black king to E3| Game executes the move| P/F |
Post-conditions:
White rook should remain on C5, black king should end up on E3

Test Case #: 2.2.3| Test Case Name: Capturing a Piece
---|---
System: Main Gameplay| Subsystem: Piece Movement
Designed by: Kyle Sarre | Design Date:11/20/2016
Executed by: | Execution Date:
Short Description:
Test if a piece of a given color captures a piece of the opposite color

Step|Action|Expected System Response|Pass/Fail|Comment
---|---|---|---|---
1| Attempt to move the the black bishop on white to C4| Black bishop should be moved to F4| P/F| 
2| Attempt to move the white bishop on white to F5| White bishop should be moved to F5| P/F| 	
3| Attempt to move the black bishop on white to F5 | Black bishop moves to F5 and the white bishop is captured| P/F|
4| Attempt to move the white rook at A5 to white pawn at F4 | White rook fails to move to F4| P/F|  
Post-conditions:
Black bishop is on cell F5. The white bishop is captured. White rook and pawn remain in their default positions.
The black bishop should reside on the F5 cell and the white bishop should no longer be in play.

Test Case #: 2.2.4| Test Case Name: Piece Locking
---|---
System: Main Gameplay | Subsystem: Piece Movement
Designed by: Robert Anderson | Design Date: 11/20/2016
Executed by: | Execution Date:
Short Description:
Test case for piece locking - in which a piece's moves are restricted due to the threat of check.

Step|Action|Expected System Response|Pass/Fail|Comment
---|---|---|---|---
1| Execute the steps of Test Case: Check/Checkmate - Piece Interposition | Expected responses from previous test case | | 
2| Move Black's Queen to e4. This maintains the pin on White's bishop. | Game executes 4. ... Qe4 | | 	
3| Select White's bishop on e2. | No squares are highlighted. The bishop cannot move. | | 
4| Move White's King to f1. This removes the pin on White's bishop. | Game executes 5. Kf1 | | 
5| Move Black's Queen to c4. This again pins White's bishop. | Game executes 5. ... Qc4 | | 
6| Select White's bishop. | The squares d3 and c4 should be highlighted. These are the bishop's only valid moves, or else the White king would be placed in check. | | 
Post-conditions:
None

Template:

Test Case #: | Test Case Name:
---|---
System: | Subsystem:
Designed by: | Design Date:
Executed by: | Execution Date:
Short Description:

Step|Action|Expected System Response|Pass/Fail|Comment
---|---|---|---|---
1| | | | 
2| | | | 	
3| | | | 
4| | | | 
5| | | | 
6| | | | 
7| | | | 
Post-conditions:
