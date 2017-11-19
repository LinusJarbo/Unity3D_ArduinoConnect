# Unity3D_ArduinoConnect

This is a Unity-to-Arduino serial communication solution that works both in editor and on Mac desktop builds.
If you put this code in projects earlier than unity 2017.1.2f1, Mac builds will not work with serial, but editor might?

Mac OS version (not tested on windows)
Connect to Arduino on usb over serial.

0. Arduino .ino code included in unity project. Build to your Arduino through Arduino IDE. Tested on Arudino UNO and Arduino Nano. 

Features:
1. Auto-connects to arduino
2. Serial communication works both in editor and on mac desktop builds.
3. Project polls three analog pins for their values, one analog pin at a time.

Things to observe:
1. The serial communication from unity to arduino is single character.
2. The respons from arduino is a string with the calling single character, followed by a numeric value.
