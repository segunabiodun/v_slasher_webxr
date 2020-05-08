using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Logger : MonoBehaviour
{
    [Conditional("ENABLE_LOGS")]
    public static void Debug(string logMsg)
    {

        UnityEngine.Debug.Log(logMsg);

    }
}
