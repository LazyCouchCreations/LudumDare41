using UnityEngine.UI;
using UnityEngine;

public class music : MonoBehaviour {

    public AudioSource themeMusic;
    public Slider me;

	// Use this for initialization
	void Start () {
        me = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        themeMusic.volume = me.value;
    }
}
