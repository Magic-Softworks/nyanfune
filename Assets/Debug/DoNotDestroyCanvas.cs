using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using Game.Constants;
#pragma warning disable 0162  // disable unreachable code for debug

/*
 * This script is attached to the MainMenu, which is the first loaded scene
 * any subsequent scenes will not destroy the text debug canvas this is attached to 
 */
public class DoNotDestroyCanvas : MonoBehaviour
{
    /*
     * If Debug = true continue, else if not Destroy Canvas
     */
    void Awake()
    {
        if (GameConstants.Debug)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
#pragma warning restore 0162
