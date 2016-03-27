using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
    public GameObject catHot;
    public GameObject catCold;
    public int rndSpawn;
	// Use this for initialization
	void Start () {
        rndSpawn = Random.Range(0, 5);
        if (rndSpawn == 1)
        {
            Instantiate(catCold, transform.position, transform.rotation); }
        else { Instantiate(catHot, transform.position, transform.rotation); }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
