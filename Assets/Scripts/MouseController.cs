using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class MouseController : MonoBehaviour {

    public int mouseDragButton = 1;

    public CameraController cameraController;

    private bool clicked = false;
    private Vector3 startPosition = Vector3.zero;

	// Use this for initialization
	void Start () {
        cameraController = GetComponent<CameraController>();
    }
	
	// Update is called once per frame
	void Update () {

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (!clicked && Input.GetMouseButtonDown(mouseDragButton))
        {
            clicked = true;
            startPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        }else if (clicked && Input.GetMouseButtonUp(mouseDragButton))
        {
            // Release            
            clicked = false;
            //cameraController.view = mouseWorldPosition;
        }

        // Zoom
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            cameraController.ZoomOut();
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            cameraController.ZoomIn();
        }

        if (clicked)
        {
            // Follow mouse                      
            cameraController.transform.position = Vector3.Lerp(cameraController.transform.position, cameraController.transform.position + (startPosition - mouseWorldPosition), cameraController.damp);
            cameraController.view = cameraController.transform.position;
        }
	}
}
