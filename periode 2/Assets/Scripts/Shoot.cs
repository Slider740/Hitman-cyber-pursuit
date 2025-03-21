using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public RaycastHit hit; //saves data from raycast
    public float shootDistance; //max distance raycast can shoot

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, shootDistance))
            {
                print("hit");

                if (hit.collider.CompareTag("Enemy"))
                {
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
