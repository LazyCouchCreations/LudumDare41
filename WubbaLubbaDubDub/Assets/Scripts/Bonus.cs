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
        if (bonus == sprites.Length)
        {
            bonus = sprites.Length - 1;
        }
        myImage.sprite = sprites[bonus];
	}
}
