readme sf4combotrainer v13jan14


### FAQ ###

Q: How do I get SF4 to run in windowed mode?
A: When you are inside street fighter press alt+enter to toggle windowed mode if the window is to big change the resolution inside streetfighter

Q: How do I create combos, How do I know how many frames to wait?
A: You can either read up on frame data or you can just try it out. Start with something simple like for example linking balrogs cr.LP to cr.MP. Add the cr.LP then the waitframe and the cr.MP. If the second hit doesn't come out increase the amount of wait frames. You'll see it linking at exactly 16 frames wait time in between but it'll get blocked once you wait 17 or more since it's a 1frame link. Some combos can get complicated, especially long one. Break them apart and try to make them step by step. Also you can watch the video of PR_Balrog explaining it all real good at http://www.twitch.tv/pr_balrog/b/493266282

Q: It doesn't work, I get a strange error message "SF4 not advancing frames" after I pressed play
A: The combo trainer program heavily relies on street fighters internal frame counter. The combo trainer won't work if this frame counter a) cannot be found or b) isn't doing anything. Reasons for a) are that you are running an old unpatched version of sf4 or you didn't check the steam-version-check box accordingly. or the graphic setting for stagequality is set to low. or sf4 isn't running at all. reasons for b) are that sf4 isn't inside a match but the menu instead. or the game is paused. or the game is lagging so hard that it didn't render 1 frame in 3 seconds. 

Q: The program won't start?
A: http://msdn.microsoft.com/library/5a4x27ek(v=vs.110).aspx

Q: The program seems to work but it doesn't seem to send the correct inputs.
A: Set your streetfighter keyboard 1 settings as follows or edit sf4keyboard.cfg. arrow keys for directions, NUM4 - 6 lp mp hp, NUM1 - 3 lk mk hk

Q: The program works inconsistently, drops links, isn't frame perfect.
A: The program is infact a bit cpu heavy when playing a combo because it has to watch street fighters frame counter and intercept with a precision of less than 16ms. If you can't run street fighter with a steady 60fps this tool is probably not going to work for you. But even on an average machine windows background processes may slow down sf4 occasionally and it may drop a combo but it should work 95% of the time. If you have these kind of problems you might lower street fighter resolution and graphic settings except for the stage quality.

Q: I can't hear a difference between the sounds of joystick or button inputs
A: There are different sounds for buttons and directional inputs but they sound very similar because I recorded them from my own stick with a camera. You can however replace the wav files inside the sounds folder with whatever you want. wait.wav is a generic beep that you could use for everything if you want.

Q: I can't press stop. It won't stop.
A: You probably looped a combo that has very little waiframes inside it and now the program is heavily firing commands and you can't intercept with stop anymore. Unfortunately this is a situation where you have to kill off the program with alt-f4 or the task manager. Next time make sure you add like wait 40 frames to the end of the combo if you plan to loop it.

Q: It's really annoying to move stuff around in the timeline
A: This version isn't final there are people working on making this program easier to use

Q: Can I help coding?
A: https://github.com/Necrophagos/SF4ComboTrainer

Q: I found a bug and it's not answered in this read me file
A: phecronagos@gmail.com


### SPECIAL THANKS ###

https://github.com/cbcoolbox
https://github.com/Ceaseless
https://github.com/leemi
https://github.com/GreenZebra
for the awesome coding contributions!

reddit r/SF4
eventhubs
pr_balrog
gootecks & mike ross
for exposure

http://strategywiki.org/wiki/User:Blendmaster
for button images