# MobileVibration
Unity | Mobile Vibration Class for Android Platform

Public class that we can access from any other script to 'vibrate' your Android Device.

Usage :

// Will Call our Vibrate function using the default value

VibrateDevice.Vibrate();

// Will Call our Vibrate function with a value we have passed, e.g. ( 1000 ms = 1 second )

VibrateDevice.Vibrate(1000);

Alternatively, if we are not on Android platform, we call

Handheld.Vibrate();

// Which vibrates for a default ½ a second
