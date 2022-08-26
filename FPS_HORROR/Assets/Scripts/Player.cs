using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Camera camera;
    public float x_sensi;
    public float y_sensi;

    // Update is called once per frame
    void Update()
    {
        ViewpointChange();  
    }

    private void ViewpointChange()
    {
        float x_Rotation = Input.GetAxis("Mouse X");
        float y_Rotation = Input.GetAxis("Mouse Y");

        x_Rotation = x_Rotation * x_sensi;
        y_Rotation = y_Rotation * y_sensi;

        this.transform.Rotate(0, x_Rotation, 0);
        camera.transform.Rotate(-y_Rotation, 0, 0);
    }

}


//https://syun625.com/pc/unityfpscamera/2/