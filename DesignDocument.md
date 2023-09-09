
# Game Loop
Player can move forward and back, and turn left and right. Objective is to hit boxes with a lower number than the player. This will increase the players number by that amount.


# Game Rules
- You can only consume a number smaller than yourself.
- Your value only goes up if the consumed number matches your number
- If you consume a number smaller that doesn't match, it goes on to your tail
    - Numbers on your tail merge together when you consume a number
    - If largest number on the tail equals the head, it is consume and the player value goes up
- Every number consume adds to the consume score counter

# Features to add
- Powerups to double / half player values
- Multiplayer support
- Tail should flow behind player
- Player should get bigger as they progress
