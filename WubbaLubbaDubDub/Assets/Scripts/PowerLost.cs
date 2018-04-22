using UnityEngine.UI;
using UnityEngine;

public class PowerLost : MonoBehaviour {

    public Image powerSlider;
    public RectTransform rectTransform;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        rectTransform.rect.Set(powerSlider.rectTransform.rect.x, powerSlider.rectTransform.rect.y, powerSlider.rectTransform.rect.width, powerSlider.rectTransform.rect.height);
	}
}
