using System;
using UnityEngine;

namespace Game_Mechanics
{
    public class Look : MonoBehaviour
    {
        [SerializeField] private Camera playerCamera;
        [SerializeField] private float minX = -60f;
        [SerializeField] private float maxX = 60f;
        [SerializeField] private float minY = -60f;
        [SerializeField] private float maxY = 60f;
        [SerializeField] private float sensitivity;
        private float rotY = 0f;
        private float rotX = 0f;

        private void Start()
        {
            // Locks the mouse in the middle and keeps it there for turning! (And its invisible)
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            CameraLook();
        }

        private void CameraLook()
        {
            rotY += Input.GetAxis("Mouse X") * sensitivity;
            rotX += Input.GetAxis("Mouse Y") * sensitivity;

            rotY = Mathf.Clamp(rotY, minY, maxY);
            rotX = Mathf.Clamp(rotX, minX, maxX);

            transform.localEulerAngles = new Vector3(0, rotY, 0);
            playerCamera.transform.localEulerAngles = new Vector3(-rotX, rotY, 0);
        }
    }
}