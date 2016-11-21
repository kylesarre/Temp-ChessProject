
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

Test Case #: UI-BBT-G.1| Test Case Name: InGameMenu – Settings Button
---|---
System: UI| Subsystem:
Designed by: Julian Dane Plaisance| Design Date: 11/19/16
Executed by: | Execution Date:
Short Description:
Black-Box Testing case for the InGame Menu Settings Button

Step|Action|Expected System Response|Pass/Fail|Comment
---|---|---|---|---
1| Click inside the button boundaries | Brings up the Game dialogue menu | p/f | 
2| Click at the button boundaries | Brings up the Game dialogue menu| p/f | 	
3| Click near but outside the button boundaries | Nothing | p/f |  
Post-conditions:
None

Test Case #: UI-BBT-G.2| Test Case Name: InGameMenu – Forfeit Button
---|---
System: UI| Subsystem:
Designed by: Julian Dane Plaisance| Design Date: 11/19/16
Executed by: | Execution Date:
Short Description:
Black-Box Testing case for the InGame Menu Forfeit Button

Step|Action|Expected System Response|Pass/Fail|Comment
---|---|---|---|---
1| Click inside the button boundaries | Brings up the forfeit dialogue box | p/f | 
2| Click at the button boundaries | Brings up the forfeit dialogue | p/f | 	
3| Click near but outside the button boundaries | Nothing | p/f |  
Post-conditions:
None

Test Case #: UI-BBT-G.3| Test Case Name: InGameMenu – Energy amount
---|---
System: UI| Subsystem:
Designed by: Julian Dane Plaisance| Design Date: 11/19/16
Executed by: | Execution Date:
Short Description:
Black-Box Testing case for the InGame Menu Energy UI representation

Step|Action|Expected System Response|Pass/Fail|Comment
---|---|---|---|---
1| White then Black move | Energy goes up by amount specified by game logic team | p/f |
Post-conditions:
None

Test Case #: UI-BBT-G.4| Test Case Name: InGameMenu – Graveyard Display
---|---
System: UI| Subsystem:
Designed by: Julian Dane Plaisance| Design Date: 11/19/16
Executed by: | Execution Date:
Short Description:
Black-Box Testing case for the InGame Menu Graveyard Display

Step|Action|Expected System Response|Pass/Fail|Comment
---|---|---|---|---
1| White captures a Black piece | Black piece captured appears in black graveyard | p/f | 
2| Black captures a White piece | White piece captured appears in white graveyard | p/f | 	
3| If a pawn of either colour gets to the opposite side of the board | pawn is added to graveyard and piece chosen to replace pawn is removed from the graveyard | p/f |  
Post-conditions:
None

Test Case #: UI-BBT-G.5| Test Case Name: InGameMenu – Previous moves display
---|---
System: UI| Subsystem:
Designed by: Julian Dane Plaisance| Design Date: 11/19/16
Executed by: | Execution Date:
Short Description:
Black-Box Testing case for the InGame Menu Previous moves display

Step|Action|Expected System Response|Pass/Fail|Comment
---|---|---|---|---
1| Either player make their move | updates showing what piece moved from, to, and what it captured | p/f | 
Post-conditions:
None

Test Case #: UI-BBT-G.6| Test Case Name: InGameMenu – Player’s turn
---|---
System: UI| Subsystem:
Designed by: Julian Dane Plaisance| Design Date: 11/19/16
Executed by: | Execution Date:
Short Description:
Black-Box Testing case for the InGame Text displaying whose turn it is.

Step|Action|Expected System Response|Pass/Fail|Comment
---|---|---|---|---
1| Game starts | Display’s “$White-player turn” | p/f | 
2| White moves | Display’s “$Black-player turn” | p/f | 	
3| Black moves | Display’s “$White-player turn” | p/f |  
Post-conditions:
None

Test Case #: | Test Case Name: Check/Checkmate: Fool's Mate
---|---
System: | Subsystem:
Designed by: | Design Date:
Executed by: | Execution Date:
Short Description:
A simple test case for the checkmate system. Plays out the fastest checkmate possible in a game of chess.

Step|Action|Expected System Response|Pass/Fail|Comment
---|---|---|---|---
1| Upon game start, move White's c-file pawn to c3. | Game executes 1. c3 | | 
2| Move Black's e-file pawn to e5. | Game executes 1. ... e5 | | 	
3| Move White's g-file pawn to g4. | Game executes 2. g4 | | 
4| Move Black's queen to h4. | Game executes 2. ... Qh4#, declares checkmate. | | 
5| | | | 
6| | | | 
7| | | | 
Post-conditions:

Test Case #: | Test Case Name: Check/Checkmate - Piece Interposition
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

Test Case #: | Test Case Name: Check/Checkmate: Piece Locking
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
