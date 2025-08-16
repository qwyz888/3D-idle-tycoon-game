using UnityEngine;

namespace _Scripts.Infrastracture.CameraCOntroller
{
    public class CameraController : MonoBehaviour
    {
        [Header("Zoom Settings")]
        public float zoomSpeed = 10f;
        public float minZoom = 5f;
        public float maxZoom = 30f;

        [Header("Pan Settings")]
        public float panSpeed = 0.5f;
        public Vector2 panLimitX = new Vector2(-20f, 20f);
        public Vector2 panLimitZ = new Vector2(-20f, 20f);

        private Camera cam;
        private Vector3 lastMousePos;

        void Start()
        {
            cam = Camera.main;
        }

        void Update()
        {
            HandleZoom();
            HandlePan();
        }

        private void HandleZoom()
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if (scroll != 0f)
            {
                float newSize = cam.orthographic ?
                    Mathf.Clamp(cam.orthographicSize - scroll * zoomSpeed, minZoom, maxZoom) :
                    Mathf.Clamp(cam.fieldOfView - scroll * zoomSpeed, minZoom, maxZoom);

                if (cam.orthographic)
                    cam.orthographicSize = newSize;
                else
                    cam.fieldOfView = newSize;
            }
        }

        private void HandlePan()
        {
            if (Input.GetMouseButtonDown(0))
            {
                lastMousePos = Input.mousePosition;
            }

            if (Input.GetMouseButton(0))
            {
                Vector3 delta = Input.mousePosition - lastMousePos;
                lastMousePos = Input.mousePosition;

                Vector3 move = new Vector3(-delta.x * panSpeed * Time.deltaTime, 0, -delta.y * panSpeed * Time.deltaTime);
                transform.position += move;


                transform.position = new Vector3(
                    Mathf.Clamp(transform.position.x, panLimitX.x, panLimitX.y),
                    transform.position.y,
                    Mathf.Clamp(transform.position.z, panLimitZ.x, panLimitZ.y)
                );
            }
        }
    }
}
