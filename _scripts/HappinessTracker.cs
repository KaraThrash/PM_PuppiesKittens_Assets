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
    public bool losing;
    // Use this for initialization
    void Start () {
        losing = false;
        winText.active = false;
        loseText.active = false;
        StartCoroutine(KeepScore(1.0f));
    }
	
	// Update is called once per frame
	void Update () {
        if (displayScore == true)
        {
            happyScore.text = ((happyTarget + 1) - happiness).ToString();
            if (happiness >= happyTarget)
            {
                losing = true;
                StartCoroutine(YouWin(3.0f));
            }
            if (happiness <= ((happyTarget + 1)*-2))
            {
                losing = true;
                StartCoroutine(YouLose(3.0f));
            }
        }
       
	}
    IEnumerator YouWin(float waitTime)
    {
        winText.active = true;
        yield return new WaitForSeconds(3.0f);

        Application.LoadLevel("WinScreen");
    }
    IEnumerator YouLose(float waitTime)
    {
        loseText.active = true;
        yield return new WaitForSeconds(3.0f);

        Application.LoadLevel("LoseScreen");
    }
    IEnumerator KeepScore(float waitTime)
    {
        yield return new WaitForSeconds(2.0f);
        
        happiness = 0;
        displayScore = true;
        yield return new WaitForSeconds(22.0f);
        if (losing == false)
        {
            StartCoroutine(YouLose(1.0f));
        }
    }
}
