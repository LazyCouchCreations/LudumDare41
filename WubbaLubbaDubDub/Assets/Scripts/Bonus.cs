using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bonus : MonoBehaviour {

    public Sprite[] sprites;
    public Image myImage;
    public Image powerSliderImage;
    public int bonus;

    // Use this for initialization
    void Start () {
        myImage.sprite = sprites[0];
        bonus = 0;
	}
	
	// Update is called once per frame
	void Update () {
        bonus = (int)((powerSliderImage.fillAmount * 100f) / 25);
        myImage.sprite = sprites[bonus];
	}
}
