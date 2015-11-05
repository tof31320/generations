using UnityEngine;
using System;
using System.Collections.Generic;

public interface TreeLayoutElement
{
    void Layout(Node parent);

    float GetLayoutWidth();

    float GetLayoutHeight();

    Transform GetTransform();
}
