# Ultimate Chess: Software Design Document
### Team Members: Robert Anderson, Hanna Cunningham, Gabriel Davis,Julian Plaisance, Kyle Sarre

# Table of Contents
## 2. Conceptual System Architecture ...............(page num)
### 2.1 Overview....................................(page num)
### 2.2 Upgrading...................................(page num)
### 2.3 Energy......................................(page num)

# 1 Introduction
## 1.1 Purpose
## 1.2 Intended Audience
optional
## 1.3 Scope
## 1.4 Design Summary
optional
## 1.5 Overview 
 optional
# 2. Conceptual System Architecture
## 2.1 Overview
Extreme Chess is a spin on the game of Chess. As a game application, Extreme Chess must be designed
around two critical objectives. Firstly, it must reflect our vision for Extreme Chess. Our vision is threefold.
We want our take on chess to have diverse strategies, to be unpredictable, and to have high replayability.
Hence, we came up with the concept of upgrading pieces. Users can pick a collection of upgrades and use them to strengthen the functionality of their pieces at a cost. Secondly, and arguably the most important for a game, it must be entertaining. The significance of this costraint cannot be understated. The user interface must be responsive, logical, and intuitive in its design. Any slowdowns or confusion in communication between the user and the system will make maneuvering the system a chore and immediately damage the system's capacity to be fun. 
We have added numerous features for our user interface for ease of use. The user interface provides a move history log that displays the last 10 moves taken by the players, a forfeit button that allows a user to give up before a game has concluded, a list of the upgrades they have selected so that the user can quickly select what they wish to use, and a game settings menu that allows the user to change a few settings in the game.    On another note, Ultimate Chess's core upgrade mechanic must be finely balanced. Should one upgrade crowd out all the others, the game will fail to represent it's original intent -- diversification of strategy, unpredictability and high replayability. Thus, the upgrade feature must be highly flexible as this particular part of the system is highly susceptible to change. Furthermore, because chess is a game that can be broken into discrete parts, we feel that the game can be divided up into discrete states as well through the use of a state machine.

##2.2  Upgrading
	At the beginning of the game, the system will prompt each player to select five upgrades out of a collection provided by the system. Once each player has selected their five upgrades, they will press a button at the bottom of the prompt and the system will set each player's upgrades. At this point the game would begin.
Once a player has selected a piece, every upgrade on their list of upgrades that can be used with the selected piece will be selectable. A player can deselect their upgrade as long as they haven't confirmed a move yet. Each upgrade has a cost. Once they have confirmed a move with an upgrade selected however, the system will deduct the cost of the upgrade from their resource (Energy) and the turn ends.
##2.3 Energy
	Energy is a player resource used in upgrading pieces. It has a maximum value of 100 and accumulates in increments of 20 at the beginning of the player's turn. When a player makes a move with an upgraded piece, the system will deduct the cost of the piece from Energy.
##2.4 Piece Movement
##2.5 Graveyard
##2.6 Move History
##2.7 The Game Board
##2.8 Pieces
##2.9 Turn Phases
# 3 Sub-systems Architecture
Include rational for each
# 4 Development View
# 5 Physical View
# 6 Database View
# 7 Work-Assignment View
# 8 Element Catalog
# 9 User Interfaces
