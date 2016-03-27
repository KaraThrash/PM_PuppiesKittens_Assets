using UnityEngine;
using System.Collections;

public class DieInTime : MonoBehaviour {
    public float dieTime;
	// Use this for initialization
	void Start () {
        StartCoroutine(DieNow(dieTime));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    IEnumerator DieNow(float waitTime)
    {
        yield return new WaitForSeconds(dieTime);
        Destroy(this.gameObject);
    }
}
