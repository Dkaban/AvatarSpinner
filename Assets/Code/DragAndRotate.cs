using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndRotate : MonoBehaviour
{
    private void Update()
    {
        if (Input.touchCount == 1)
        {
            var screenTouch = Input.GetTouch(0);

            if (screenTouch.phase == TouchPhase.Moved)
            {
                transform.Rotate(0f, -screenTouch.deltaPosition.x * 0.5f, 0f);
            }
        }
    }
}
