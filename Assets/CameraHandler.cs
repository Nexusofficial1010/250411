using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    private GameObject playerCube;
    private Camera playerCamera;
    public int mouseSpeed = 2500;
    public bool isFirstPerson = false;
    public bool isTryingCameraLock = false;
    private float maxm = 70f;
    public float xrot;
    public float yrot;

    void Start()
    {
        playerCamera = Camera.main;

    }

    private void UpdateCameraType()
    {
        if (isFirstPerson || isTryingCameraLock)
        {

        }
        else
        {

        }
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;
        xrot -= mouseY;
        yrot += mouseX;

        xrot = Mathf.Clamp(xrot, -maxm, maxm);
        playerCamera.transform.rotation = Quaternion.Euler(xrot, yrot, 0);
        playerCube.transform.rotation = Quaternion.Euler(0, yrot, 0);
    }
}
