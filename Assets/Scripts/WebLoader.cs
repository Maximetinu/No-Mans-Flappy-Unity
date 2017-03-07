using UnityEngine;
using System.Runtime.InteropServices;

public class WebLoader : MonoBehaviour
{

    public static bool game_loaded = false;

    [DllImport("__Internal")]
    private static extern void GameLoaded();

    void Start()
    {
        if (!game_loaded)
        {

            game_loaded = true;
            GameLoaded();
        }
    }
}


