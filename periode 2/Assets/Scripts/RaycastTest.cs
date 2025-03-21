using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour
{
    public RaycastHit hit;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, distance))
        {
            print ("ik raak wat");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
