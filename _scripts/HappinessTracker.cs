using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HappinessTracker : MonoBehaviour {

    public int happiness;
    public Text happyScore;
    public int happyTarget;
    public bool displayScore;
    public GameObject winText;
    public GameObject loseText;
    // Use this for initialization
    void Start () {
        winText.active = false;
        loseText.active = false;
        StartCoroutine(KeepScore(1.0f));
    }
	
	// Update is called once per frame
	void Update () {
        if (displayScore == true)
        {
            happyScore.text = (happyTarget - happiness).ToString();
            if (happiness >= happyTarget)
            {
                StartCoroutine(YouWin(1.0f));
            }
        }
       
	}
    IEnumerator YouWin(float waitTime)
    {
        winText.active = true;
        yield return new WaitForSeconds(1.0f);
        
        displayScore = true;
    }
    IEnumerator KeepScore(float waitTime)
    {
        yield return new WaitForSeconds(1.0f);
        
        happiness = 0;
        displayScore = true;
    }
}
