
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

