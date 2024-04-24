using Game.Constants;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

/*
 * This script is attached to a text object within a canvas
 * Constants are being pulled from Game.Constant NameSpace
 */
public class DebugConsole : MonoBehaviour
{
    private TMP_Text _text;

#pragma warning disable 0162  // disable unreachable code for debug
    void Start()
    {
        _text = gameObject.GetComponent<TMP_Text>();

        AddDebugInfoToText(SceneManager.GetActiveScene());
        //on scene load update text again
        SceneManager.sceneLoaded += OnSceneLoad;
    }
#pragma warning restore 0162

    private void AddDebugInfoToText(Scene scene)
    {
        //.text is the text object associated with the tmp ui field
        _text.text = "Scene Name: " + scene.name;
    }

    private void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        AddDebugInfoToText(scene);
    }
}
