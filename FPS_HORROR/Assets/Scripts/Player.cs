using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Camera camera;
    public float x_sensi;
    public float y_sensi;
    private float moveSpeed = 10f;

    private void Start()
    {
        this.UpdateAsObservable().Where(_ => Input.GetKey(KeyCode.W)).Subscribe(_ => UpMove());
        this.UpdateAsObservable().Where(_ => Input.GetKey(KeyCode.S)).Subscribe(_ => DownMove());
        this.UpdateAsObservable().Where(_ => Input.GetKey(KeyCode.A)).Subscribe(_ => LeftMove());
        this.UpdateAsObservable().Where(_ => Input.GetKey(KeyCode.D)).Subscribe(_ => RightMove());
    }
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

    private void UpMove()
    {
        var dir = Quaternion.Euler(camera.transform.eulerAngles) * Vector3.forward;
        transform.position += new Vector3(dir.x * Time.deltaTime, 0, dir.z * Time.deltaTime)*moveSpeed;
    }

    private void DownMove()
    {
        var dir = Quaternion.Euler(camera.transform.eulerAngles) * Vector3.back;
        transform.position += new Vector3(dir.x * Time.deltaTime, 0, dir.z * Time.deltaTime)*moveSpeed;
    }

    private void LeftMove()
    {
        var dir = Quaternion.Euler(camera.transform.eulerAngles) * Vector3.left;
        transform.position += new Vector3(dir.x * Time.deltaTime, 0, dir.z * Time.deltaTime)*moveSpeed;
    }

    private void RightMove()
    {
        var dir = Quaternion.Euler(camera.transform.eulerAngles) * Vector3.right;
        transform.position += new Vector3(dir.x * Time.deltaTime, 0, dir.z * Time.deltaTime)*moveSpeed;
    }
}


//https://syun625.com/pc/unityfpscamera/2/