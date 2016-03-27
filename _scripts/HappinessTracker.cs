using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HappinessTracker : MonoBehaviour {
    public int happiness;
    public Text happyScore;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        happyScore.text = happiness.ToString();
    
	}
}
