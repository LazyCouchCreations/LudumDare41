using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour {

    public void Reset()
    {
        Debug.Log("loading scene...");
        SceneManager.LoadScene(0);        
    }
}
