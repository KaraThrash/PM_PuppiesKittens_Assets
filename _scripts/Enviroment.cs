using UnityEngine;
using System.Collections;

public class Enviroment : MonoBehaviour {
    public bool held;
    public GameObject roomCenter;
    private Vector3 startPosition;
	// Use this for initialization
	void Start () {
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        if (held == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, roomCenter.transform.position, (0.3f * Time.deltaTime));
            //transform.LookAt(Input.mousePosition);
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //RaycastHit hit;
            //if (Physics.Raycast(ray, out hit))
            //{
            //    //transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
            //    //transform.position = Vector3.MoveTowards(transform.position, new Vector3(hit.point.x, transform.position.y, hit.point.z), Time.deltaTime * 0.3f);
            //    Vector3 targetDir = new Vector3(hit.point.x, transform.position.y, hit.point.z) - transform.position;
            //    float step = 1 * Time.deltaTime;
            //    Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, -step, 0.0F);

            //    transform.rotation = Quaternion.LookRotation(newDir);

            //}
        }
        //else { transform.position = Vector3.MoveTowards(transform.position, startPosition, (0.3f *Time.deltaTime)); }
        if (Input.GetMouseButtonUp(0))
        {
            held = false;
            
        }
    }
    public void OnMouseDown()
    {
        held = true;


        //if (held == false)
        //{ held = true; }
        //else { held = false; }
    }
}
