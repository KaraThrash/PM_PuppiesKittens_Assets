using UnityEngine;
using System.Collections;

public class Faucet : MonoBehaviour {
    public GameObject water;
    //public GameObject spout;
    public bool on;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
       // if (on == true) {
            Instantiate(water, transform.position, transform.rotation);
        //}
	}
    //public void OnMouseDown()
    //{
    //    if (on == false)
    //    { on = true; }
    //    else { on = false; }
    //}

}
