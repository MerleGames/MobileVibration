using UnityEngine;

// VibrateDevice.cs | Public class that we access from any given script

// VibrateDevice.Vibrate();         // Will Call our Vibrate function using the default value
// VibrateDevice.Vibrate(1000);     // Will Call our Vibrate function a value we have passed, e.g. ( 1000 ms = 1 second )

public static class VibrateDevice
{
    // If we are running on Unity Android and not on Unity Editor

#if UNITY_ANDROID && !UNITY_EDITOR

    public static AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    public static AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
    public static AndroidJavaObject vibrateDevice = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrateDevice");

#else

    public static AndroidJavaClass unityPlayer;
    public static AndroidJavaObject currentActivity;
    public static AndroidJavaObject vibrateDevice;

#endif

    // Vibrate function ( default time 250 milliseconds ( ¼ of a second ))

    public static void Vibrate(long milliseconds = 250)
    {
        // If we are running on an Android device

        if (IsAndroid())
        {
            // vibrateDevice.Call ( Find the vibrate function, and pass it our milliseconds )

            vibrateDevice.Call("vibrate", milliseconds);
        }

        // Else, if we are not running on a Android Device, use Handheld.Vibrate ( ½ a second )

        else
        {
            Handheld.Vibrate();
        }
    }

    // Cancel

    public static void Cancel()
    {
        if (IsAndroid())
        {
            vibrateDevice.Call("cancel");
        }
    }

    // Are we running on Adroid or not

    public static bool IsAndroid()
    {

#if UNITY_ANDROID && !UNITY_EDITOR

        return true;

#else

        return false;

#endif

    }
}
