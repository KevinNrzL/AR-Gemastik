using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class DetectionCollider : MonoBehaviour
{

    public Camera camera;
    public RaycastHit hit;
    public RaycastHit hit1;
   // public NavMeshAgent agent;
   // public GameObject prefab;
    public string groundTag = "Ground";
    public string destTag = "Ground";
    public string ColliderTag = "Collider";
    public bool ButtonDown = false;
    public float TimePress = 1;
    public float TimePressTemp;

    public string NameSentuh1 = "0", NameSentuh2 = "0";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        WaitInputCommand();
    }
    private void WaitInputCommand()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.CompareTag(groundTag))
                {
                    
                    ButtonDown = true;
                    TimePressTemp = TimePress;
                    string nama = hit.collider.name;
                    NameSentuh1 = hit.collider.name;
                    Debug.Log("Berhasil Hit Collider & " + nama);
                }
                if (hit.collider.CompareTag(ColliderTag))
                {
                    //agent = hit.collider.GetComponentInParent<NavMeshAgent>();
                    string nama = hit.collider.name;
                    Debug.Log("Berhasil Hit Collider & " + nama);
                }
            }
        }
        if(Input.GetMouseButtonUp(0)) 
        {
            NameSentuh1 = "0";
            Debug.Log("Berhasil Hit Collider & " + NameSentuh1);
        }
        
        if (ButtonDown)
        {
            TimePressTemp -= Time.deltaTime;
            if (TimePressTemp <= 0)
            {
                ButtonDown = false;
            }
            if (Input.GetMouseButtonUp(0))
            {
                Ray ray1 = camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray1, out hit1, Mathf.Infinity))
                {
                    if (hit1.collider.CompareTag(destTag))
                    {
                        Debug.Log("Berhasil Deteksi Destination");
                        ButtonDown = false;
                    }
                }
            }
        }
    }
}
