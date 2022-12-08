# SendKeyOnSound

This repo contains a [LinqPad7](https://www.linqpad.net/LINQPad7.aspx) script.

The script periodically checks the sound output for an sound event.
If an event gets recognized, the script sends keydown and keyup events to an specific process.
The scripts send multiple key events to the process, because in my specific case it was need to automate some... proccess ;)

If you want to use the script.
Just clone the repo and open the *.linq file with linqpad.
Or download the file direclty and open it.

If you want to use a different key than F5 you can look [here](https://learn.microsoft.com/en-us/windows/win32/inputdev/virtual-key-codes) for the virtual key code and change it.
