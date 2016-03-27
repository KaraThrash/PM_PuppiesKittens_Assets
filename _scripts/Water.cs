using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour {
    public GameObject puddle;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag != "Water")
        {
            Instantiate(puddle, transform.position, puddle.transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
