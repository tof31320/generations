using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class MouseController : MonoBehaviour {

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

        if (!clicked && Input.GetMouseButtonDown(0))
        {
            clicked = true;
            startPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        }else if (clicked && Input.GetMouseButtonUp(0))
        {
            // Release            
            clicked = false;
            //cameraController.view = mouseWorldPosition;
        }

        //cameraController.useDampView = clicked;

        if (clicked)
        {
            // Follow mouse                      
            cameraController.transform.position = Vector3.Lerp(cameraController.transform.position, cameraController.transform.position + (startPosition - mouseWorldPosition), cameraController.damp);
            cameraController.view = cameraController.transform.position;
        }
	}
}
