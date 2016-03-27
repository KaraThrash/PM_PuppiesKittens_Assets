using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour {
    public GameObject puddle;
    public bool isPuddle;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnCollisionEnter(Collision col)
    {if (isPuddle == false)
        {
            if (col.gameObject.name == "Puddle(Clone)")
            {
                col.transform.localScale = new Vector3(col.transform.localScale.x + 0.01f, col.transform.localScale.y, col.transform.localScale.z + 0.01f);
                Destroy(this.gameObject); }

            if (col.gameObject.tag != "Water")
            {
                Instantiate(puddle, transform.position, puddle.transform.rotation);
                Destroy(this.gameObject);
            }
        }
        
    }
}
