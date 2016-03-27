using UnityEngine;
using System.Collections;

public class Clickable : MonoBehaviour {
    public bool held;
    public bool petting;
    public GameObject wayPoint;
    public int wetOpinion;
    public int hotOpinion;
    public int heightOpinion;
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
    public AudioClip meow;
    public AudioClip meow2;
    public AudioClip meowHappy;
    public AudioClip meowSad;
    public AudioClip meowBump;
    public AudioSource audio;
    // Use this for initialization
    void Start () {
        audio = GetComponent<AudioSource>();
        held = false;
        rb = GetComponent<Rigidbody>();
        happinessTracker = GameObject.Find("HappinessTracker");
        mouseCursor = GameObject.Find("MouseControl");
        wayPoint = GameObject.Find("WayPoint");
        happinessTracker.GetComponent<HappinessTracker>().happyTarget += Random.Range(0, 4);
        currentHappiness = happyStat;
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
            audio.clip = meow2;
            audio.Play();
            rb.AddForce((wayPoint.transform.position- transform.position) *throwForce* 100);
            rb.useGravity = true;
        }
        
    }
    
    public void OnMouseDown()
    {
        audio.clip = meow;
        audio.Play();
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
        // { wetStat += col.gameObject.GetComponent<Zone>().wet;
        // if (wetStat >= wetLimit)
        { happyStat += (wetOpinion * col.gameObject.GetComponent<Zone>().wet);
    }
        if (col.gameObject.tag == "Height")

        // wetStat -= col2.gameObject.GetComponent<Zone>().wet;
        // if (wetStat <= wetLimit)
        {
            happyStat += (heightOpinion * col.gameObject.GetComponent<Zone>().height);
        }
        if (col.gameObject.tag == "Hot")
        // { hotStat += col.gameObject.GetComponent<Zone>().hot;
        // if (hotStat >= hotLimit)
        {
            happyStat += (hotOpinion * col.gameObject.GetComponent<Zone>().hot);
        }
        
        
        ChangeHappiness((happyStat - currentHappiness));
        if (currentHappiness > happyStat)
        {
            audio.clip = meowHappy;
            audio.Play();
        }
        if (currentHappiness < happyStat)
        {
            audio.clip = meowSad;
            audio.Play();
        }
        currentHappiness = happyStat;
                }
    public void OnTriggerExit(Collider col2)
    {
        if (col2.gameObject.tag == "Wet")

        // wetStat -= col2.gameObject.GetComponent<Zone>().wet;
        // if (wetStat <= wetLimit)
        {
            happyStat -= (wetOpinion * col2.gameObject.GetComponent<Zone>().wet);
        }
        if (col2.gameObject.tag == "Height")

        // wetStat -= col2.gameObject.GetComponent<Zone>().wet;
        // if (wetStat <= wetLimit)
        {
            happyStat -= (heightOpinion * col2.gameObject.GetComponent<Zone>().height);
        }
        if (col2.gameObject.tag == "Hot")
        
           // hotStat -= col2.gameObject.GetComponent<Zone>().hot;
           // if (hotStat <= hotLimit)
            { happyStat -= (hotOpinion * col2.gameObject.GetComponent<Zone>().hot); 
        }

        if (currentHappiness > happyStat)
        {
            audio.clip = meowHappy;
            audio.Play();
        }
        if (currentHappiness < happyStat)
        {
            audio.clip = meowSad;
            audio.Play();
        }
        ChangeHappiness((happyStat - currentHappiness));
        currentHappiness = happyStat;
    }
    public void ChangeHappiness(int happy)
    {
        happinessTracker.GetComponent<HappinessTracker>().happiness += happy;
    }
}
