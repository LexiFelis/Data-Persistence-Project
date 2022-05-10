# Data-Persistence-Project

Exercise Brief:

You are now ready to begin the challenge of implementing data persistence in this application. The key features you need to achieve are:

   - Saving data between scenes: a piece of data set in one scene will be stored and used in another scene.
   - Saving data between sessions: a piece of data set during runtime will be saved and used the next time the application is run. 
    
    Although there are many ways you could implement these features in an application, here is how we suggest you implement them in this particular challenge:
Player name (saving data between scenes)

   - Create a new Start Menu scene for the game with a text entry field prompting the user to enter their name, and a Start button.
   - When the user clicks the Start button, the Main game scene will be loaded and their name will be displayed next to the score. 

High score (saving data between sessions):

   - As the user plays, the current high score will be displayed on the screen alongside the player name who created the score.
   - If the high score is beaten, the new score and player name will be displayed instead.
   - The highest score will be saved between sessions, so that if the player closes and reopens the application, the high score and player name will be retained.

If you’re feeling ambitious, you could add additional data persistence features as well. For example:

    Create a separate High Score scene that displays the high score.
    Display multiple high scores instead of just one.
    Create a Settings scene that allows users to configure gameplay, and use that information between sessions. 
