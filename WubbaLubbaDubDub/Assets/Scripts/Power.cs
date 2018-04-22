using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Power : MonoBehaviour {

    public float currentPower = 0.1f;
    public Image powerSlider;
    public Text powerLabel;
    public int countDown = 3;
    public float fillTimer;
    public GameObject gameOverPanel;
    public bool isEnding;
    public Image tankSlider;
    public float currentTankFill;
    
	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        isEnding = false;
        fillTimer = 0f;
        gameOverPanel.SetActive(false);
        powerSlider.fillAmount = currentPower;
        powerLabel.text = ((int)(currentPower * 100)).ToString();
    }

    private void Update()
    {
        if (isEnding)
        {
            if(fillTimer / countDown < 1) fillTimer += Time.deltaTime;
            tankSlider.fillAmount = Mathf.Lerp(0f, 1f, fillTimer / countDown);
        }
        else
        {
            if(fillTimer / countDown > 0) fillTimer -= Time.deltaTime;
            tankSlider.fillAmount = Mathf.Lerp(0f, 1f, fillTimer / countDown);
        }

        if(tankSlider.fillAmount == 1)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0.1f;
        }
    }

    // Update is called once per frame
    public void UpdatePower (float increment)
    {
        if (currentPower + increment > 0)
        {
            isEnding = false;
        }

        if(currentPower + increment > 1)
        {
            currentPower = 1;
        }
        else if(currentPower + increment < 0)
        {
            isEnding = true;
            currentPower = 0f;
        }
        else
        {
            currentPower += increment;
        }

        powerSlider.fillAmount = currentPower;
        powerLabel.text = ((int)(currentPower * 100)).ToString();
	}
}
