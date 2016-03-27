using UnityEngine;
using System.Collections;

public class Clickable : MonoBehaviour {
    public bool held;
    public bool petting;
    public GameObject wayPoint;
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
    public float throwForce;
    // Use this for initialization
    void Start () {
	held = false;
        rb = GetComponent<Rigidbody>();
        happinessTracker = GameObject.Find("HappinessTracker");
        mouseCursor = GameObject.Find("MouseControl");
        wayPoint = GameObject.Find("WayPoint");
    }
	
	// Update is called once per frame
	void Update () {
        
        if (held == true)
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                
                if (hit.collider.tag == "Ground")
                {
                    wayPoint.transform.position = hit.point;
                    transform.position = Vector3.MoveTowards(transform.position,hit.point, Time.deltaTime);
                    //Instantiate( wayPoint, hit.point, Quaternion.LookRotation( hit.normal ) ); 


                }
                throwForce = Mathf.Abs(Vector3.Distance(transform.position, wayPoint.transform.position));
            }

            //mouseCursor.GetComponent<Mouse>().wayPoint = this.gameObject;
            //transform.position = Input.mousePosition; 
        }
    }
    public void OnMouseUp()
    {
        
        if (held == true)
        {
            held = false;
            rb.AddForce((wayPoint.transform.position- transform.position) *throwForce* 100);
            rb.useGravity = true;
        }
        
    }
public void OnMouseDrag()
    {
        print("mousedown");
            if (Input.GetMouseButton(0))
            { held = true;
            rb.useGravity = false;
        }
        if (Input.GetKey(KeyCode.Space))
        { transform.Translate(transform.up * Time.deltaTime); }
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
