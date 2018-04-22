using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {

    public int playerScore = 0;
    public Text textBox;
    public Image bonusImage;

	// Use this for initialization
	void Start () {
        textBox = GetComponent<Text>();
        UpdateScore(0);
	}

    public void UpdateScore(int increase)
    {
        int bonus = bonusImage.GetComponent<Bonus>().bonus + 1;
        playerScore += increase * bonus;
        textBox.text = playerScore.ToString();
    }
}
