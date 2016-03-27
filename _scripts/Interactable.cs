using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour {
    public bool on;
    public GameObject myObj;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (on == true)
        { myObj.active = true; }
        else { myObj.active = false; }
	}
    public void OnMouseDown()
    {
        if (on == false)
        { on = true; }
        else { on = false; }
    }
}
