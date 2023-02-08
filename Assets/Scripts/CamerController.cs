using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class CamerController : MonoBehaviour
{
    public float ZoomSpeed;
    public float speed;
    void Update()
    {
        MoveCamera();
        //get left mouse button and rotate around centre
        if (Input.GetMouseButton(1))
        {
            transform.RotateAround(transform.position, Vector3.up, Input.GetAxis("Mouse X") * 10f);
            //transform.RotateAround(Vector3.zero, Vector3.right, Input.GetAxis("Mouse Y") * 10f);
        }

        //get mouse roller and zoom out       
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && Camera.main.orthographicSize <= 13)
        {
            //transform.Translate(Vector3.forward * 10f);
            Camera.main.orthographicSize -= ZoomSpeed;
        }
        if (Camera.main.orthographicSize > 13)
        {
            Camera.main.orthographicSize = 13f;
        }

        //get mouse roller and zoom in
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && Camera.main.orthographicSize >= 1)
        {
            //transform.Translate(Vector3.back * 10f);
            Camera.main.orthographicSize += ZoomSpeed;
        }
        if (Camera.main.orthographicSize < 1)
        {
            Camera.main.orthographicSize = 1f;
        }
    }

    private void MoveCamera()
    {
        //move camera on x and z axis using arrow keys
        //if (Input.GetKey(KeyCode.UpArrow) && transform.position.z < 16f)
        //{
        //    transform.Translate(Vector3.forward.normalized * Time.deltaTime * 10f, Space.World);
        //}
        //if (Input.GetKey(KeyCode.DownArrow) && transform.position.z > -16f)
        //{
        //    transform.Translate(Vector3.back.normalized * Time.deltaTime * 10f, Space.World);
        //}
        //if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -16f)
        //{
        //    transform.Translate(Vector3.left.normalized * Time.deltaTime * 10f, Space.World);
        //}
        //if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 16f)
        //{
        //    transform.Translate(Vector3.right.normalized * Time.deltaTime * 10f, Space.World);
        //}
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)) * 2;
        Vector3 cameraRight = Vector3.Scale(Camera.main.transform.right, new Vector3(1, 0, 1));
        Vector3 moveDirection = (cameraForward * vertical + cameraRight * horizontal) * speed * Time.deltaTime;
        //Vector3 mvtVector = new Vector3(horizontal * Camera.main.transform.forward.x, 0, vertical * Camera.main.transform.forward.z) * speed * Time.deltaTime;
        transform.position += moveDirection;
    }
}
