using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticClass 
{
    public static string CrossSceneInformation = "Flighter Interceptor";

    public static Vector3 playerCoords = new Vector3(-90.79f, 3.81f, -41.88f);

    public static Quaternion playerOrientation = Quaternion.LookRotation(Vector3.forward, Vector3.up);

    public static bool exploreMode = true;

    public static bool leverMode = false;

    public static bool lucesMode = false;
}
