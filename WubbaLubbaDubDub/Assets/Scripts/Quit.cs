using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour {

    public void QuitGame()
    {
#if DEBUG
        UnityEditor.EditorApplication.isPlaying = false;
#endif

        Application.Quit();              
    }
}
