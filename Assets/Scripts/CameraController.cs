using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Vector2 margin = new Vector2(10f, 10f);

    public float scrollSpeed = 1f;

    public float damp = 1f;

    //private Vector3 direction = Vector3.zero;
    public Vector3 view = new Vector3(0f, 0f, -10f);
    public bool useBorders = true;
    public bool useDampView = true;

    private float zoomSize = 0f;

    void Start()
    {
        zoomSize = GetComponent<Camera>().orthographicSize;
    }

	public void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        // Direction
        if (useBorders && Input.mousePosition.x < margin.x)
        {
            // Left
            view += new Vector3(-scrollSpeed, 0f, 0f);
        }
        else if (useBorders && Input.mousePosition.x > Screen.width - margin.x)
        {
            view += new Vector3(scrollSpeed, 0f, 0f);
        }
        if (useBorders && Input.mousePosition.y < margin.y)
        {
            view += new Vector3(0f, -scrollSpeed, 0f);
        }
        else if (useBorders && Input.mousePosition.y > Screen.height - margin.y)
        {
            view += new Vector3(0f, scrollSpeed, 0f);
        }

        // Zoom
        if (Input.GetKeyDown(KeyCode.Z) && zoomSize < 10f)
        {
            zoomSize += 1f;
           
        }else if (Input.GetKeyDown(KeyCode.A) && zoomSize > 1f)
        {
            zoomSize -= 1f;
        }

        if (useDampView) {
            transform.position = Vector3.Lerp(transform.position, view, damp);
        }

        GetComponent<Camera>().orthographicSize = Mathf.Lerp(GetComponent<Camera>().orthographicSize, zoomSize, damp);
    }
}
