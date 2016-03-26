using UnityEngine;
using System.Collections;

public class Clickable : MonoBehaviour {
    public bool held;
    public bool petting;
    public int wetOpinion;
    public int hotOpinion;
    public GameObject mouseCursor;
    public GameObject happinessTracker;
    public int wetStat;
    public int hotStat;
    public int wetLimit;
    public int hotLimit;
    public int happyStat;
    public int currentHappiness;
    private Rigidbody rb;
    // Use this for initialization
    void Start () {
	held = false;
        rb = GetComponent<Rigidbody>();
        happinessTracker = GameObject.Find("HappinessTracker");
        mouseCursor = GameObject.Find("MouseControl");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0))
        { held = false;
            rb.useGravity = true;
        }
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
            if (Input.GetMouseButtonDown(0))
            { held = true;
            rb.useGravity = false;
        }

        if (Input.GetMouseButtonDown(1))
        {
            held = false;
            petting = true;
            
        }
        
    }
    public void OnTriggerEnter(Collider col)
    { if (col.gameObject.tag == "Wet")
            { wetStat += col.gameObject.GetComponent<Zone>().wet;
            if (wetStat >= wetLimit)
            { happyStat -= wetOpinion; }
        }
    
    if (col.gameObject.tag == "Hot")
            { hotStat += col.gameObject.GetComponent<Zone>().hot;
            if (hotStat >= hotLimit)
            { happyStat-= hotOpinion; }
        }
        
        
        ChangeHappiness((happyStat - currentHappiness));
        currentHappiness = happyStat;
                }
    public void ChangeHappiness(int happy)
    {
        happinessTracker.GetComponent<HappinessTracker>().happiness += happy;
    }
}
