using UnityEngine;
using System.Collections;

public class Clickable : MonoBehaviour {
    public bool held;
    public float delay;
    bool one_click = false;
    bool timer_running;
    public float time_for_double_click;
    public GameObject mouseCursor;
    // Use this for initialization
    void Start () {
	held = false;
        mouseCursor = GameObject.Find("MouseControl");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0))
        { held = false; }
        if (held == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Ground")
                {

                    transform.position = Vector3.MoveTowards(transform.position,hit.point, Time.deltaTime);
                    //Instantiate( wayPoint, hit.point, Quaternion.LookRotation( hit.normal ) ); 


                }

            }

            //mouseCursor.GetComponent<Mouse>().wayPoint = this.gameObject;
            //transform.position = Input.mousePosition; 
        }
	}
    public void OnMouseDown()
    {
        if (one_click)
        {
            if (Input.GetMouseButtonDown(0))
            { held = true; }
            if ((Time.time - time_for_double_click) > delay)
            {

                one_click = false;

            }
            //else { held = true; }
        }
        if (!one_click)
        {
            one_click = true;

            time_for_double_click = Time.time;
                                              
        }
        else
        {
            one_click = false; // found a double click, now reset
        }
        
    }
}
