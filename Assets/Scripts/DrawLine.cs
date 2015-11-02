using UnityEngine;
using System;
using System.Collections.Generic;

public class DrawLine : MonoBehaviour
{
    public Line line = null;

    public Sprite sprLineStart = null;

    public Sprite sprLineEnd = null;

    public GameObject dotGameObject;
    public float dotSpriteSize = 1f;

    // 0 : UP, 1 : LEFT, 2 : DOWN, 3 : RIGHT
    public Sprite[] sprCrossLine;

    public Sprite sprLineStyle = null;    
    
    private GameObject CreateDot(Vector3 pos, Sprite sprite)
    {
        GameObject dot = Instantiate(dotGameObject, pos, Quaternion.identity) as GameObject;

        //dot.GetComponent<SpriteRenderer>().sprite = sprite;
        dot.transform.rotation = transform.
        dot.transform.parent = transform;

        return dot;
    }

    public void Draw()
    {
        // Start 
        if (sprLineStart != null) {
            CreateDot(line.start, sprLineStart);
        }

        // Interpolation
        float lineSize = line.Size();
        int nbDotsToDraw = (int) (lineSize / dotSpriteSize);
        for (int i = 0; i < nbDotsToDraw; i++)
        {
            Vector3 positionInLine = Vector3.Lerp(line.start, line.end, ((float) i) / ((float) nbDotsToDraw));
            Debug.Log("POS(" + i + ") => " + positionInLine);
            CreateDot(positionInLine, sprLineStyle);
        }

        // End  
        if (sprLineEnd != null) {
            CreateDot(line.end, sprLineEnd);
        }
    }

    void Start()
    {
        line = GetComponent<Line>();

        Draw();
    }
}

