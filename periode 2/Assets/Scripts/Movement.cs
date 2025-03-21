using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector3 camRot;
    public Vector3 rotateDir;
    public Vector3 moveDir;
    public float speed; //Speed of player
    public float camSpeed; //Rotation speed of camera
    public Transform cam; //Rotates camera on x without moving the parent gameobject

    // Update is called once per frame
    void Update()
    {
        //Moving
        moveDir.x = Input.GetAxis("Horizontal");
        moveDir.z = Input.GetAxis("Vertical");
        transform.Translate(moveDir * Time.deltaTime * speed);

        //Rotate
        rotateDir.y = Input.GetAxis("Mouse X");
        camRot.x = Input.GetAxis("Mouse Y");
        transform.Rotate(rotateDir * Time.deltaTime * camSpeed);
        cam.Rotate(-camRot * Time.deltaTime * camSpeed);
    }
}
