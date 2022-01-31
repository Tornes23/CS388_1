using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class DebugLog
{
    static Text debug_text;

    public static void DrawDebugText(string db_text)
    {
        if (debug_text == null)
        {
            debug_text = GameObject.Find("DebugLog").GetComponent<Text>();
        }
        debug_text.text = db_text;
    }
}
