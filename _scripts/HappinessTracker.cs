using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HappinessTracker : MonoBehaviour {

    public int happiness;
    public Text happyScore;
    public int happyTarget;
    public bool displayScore;
	// Use this for initialization
	void Start () {
        StartCoroutine(KeepScore(1.0f));
    }
	
	// Update is called once per frame
	void Update () {
        if (displayScore == true)
        {
            happyScore.text = happiness.ToString();
        }
	}
    IEnumerator KeepScore(float waitTime)
    {
        yield return new WaitForSeconds(1.0f);
        
        happiness = 0;
        displayScore = true;
    }
}
