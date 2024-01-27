using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchEffect : MonoBehaviour
{
    public Camera camera;
    public RaycastHit hit;
    public RaycastHit hit1;
    // public NavMeshAgent agent;
    public GameObject prefab;
    public string groundTag = "Ground";
    public string destTag = "Ground";
    public string ColliderTag = "Collider";
    public bool ButtonDown = false;
    public float TimePress = 1;
    public float TimePressTemp;
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
        if (Input.GetMouseButtonDown(0))
        {
            
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.CompareTag(groundTag))
                {

                    Instantiate(prefab, hit.point, Quaternion.identity);
                    
                }
                
            }
        }
        
    }
}
