using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {
    
    public GameObject cameraHolder;
   
    public GameObject wayPoint;
    

    public float delay;
    bool one_click = false;
    bool timer_running;
    public float time_for_double_click;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
       
            //new Vector3(wayPoint.transform.position.x,player.transform.position.y,wayPoint.transform.position.z)
            
            //cameraHolder.GetComponent<CameraHolder>().transform.position = Vector3.MoveTowards(cameraHolder.transform.position, new Vector3(player.transform.position.x, cameraHolder.transform.position.y, player.transform.position.z), 15.0f * Time.deltaTime);
        
        if (Input.GetMouseButtonDown(0))
        {
            if (!one_click)
            { // first click no previous clicks
                one_click = true;

                time_for_double_click = Time.time; // save the current time
                                                   // do one click things;
            }
            else
            {

                one_click = false; // found a double click, now reset
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "Ground")
                    {

                        wayPoint.transform.position = hit.point;
                        //Instantiate( wayPoint, hit.point, Quaternion.LookRotation( hit.normal ) ); 
                        

                    }
                    
                }
            }
        }
        if (one_click)
        {
            // if the time now is delay seconds more than when the first click started. 
            if ((Time.time - time_for_double_click) > delay)
            {

                //basically if thats true its been too long and we want to reset so the next click is simply a single click and not a double click.

                one_click = false;

            }
        }
    }
    public void OnMouseDown()
    {
        //wayPoint.GetComponent<Collider>().enabled = true;
    }

    public void OnMouseDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Ground")
            {

                wayPoint.transform.position = hit.point;
                //Instantiate( wayPoint, hit.point, Quaternion.LookRotation( hit.normal ) ); 
                

            }

            //RaycastHit ray = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
            //
            //		print (ray);
            //		Vector3 fwd = transform.TransformDirection(Vector3.forward);
            //		if (Physics.Raycast (transform.position, Input.mousePosition, 1000)) {
            //			print ("ray hits");
            //			Instantiate(wayPoint,ray.point,wayPoint.transform.rotation);
            //			//playerMove = true;
            //		}
        }
    }
    public void PlayerRespawn()
    {
        //cameraHolder.GetComponent<CameraHolder>().transform.position = new Vector3(player.transform.position.x, cameraHolder.transform.position.y, player.transform.position.z);
    }
    public void OnMouseUp()
    {
        //Destroy(GameObject.FindWithTag("Clone"));
        
    }

}
