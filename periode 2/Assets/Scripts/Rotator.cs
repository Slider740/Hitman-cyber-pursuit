using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Vector3 rotateDir;
    public float mouseX;
    public float mouseY;
    public float rotatespeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotateDir * Time.deltaTime);

        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        transform.Rotate(Vector3.up, mouseX * Time.deltaTime * rotatespeed);
        transform.Rotate(Vector3.left, mouseY * Time.deltaTime * rotatespeed);
    }
}
