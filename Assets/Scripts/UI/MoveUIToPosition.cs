using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUIToPosition : MonoBehaviour
{
    public Transform HPBarPos;

    private RectTransform myRectTransform;

    void Start()
    {
        myRectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        //var screenToWorldPosition = Camera.main.ScreenToWorldPoint(HPBarPos.transform.position);
        //myRectTransform.localPosition += Vector3.right;
        //myRectTransform.localPosition = screenToWorldPosition;
    }
}
