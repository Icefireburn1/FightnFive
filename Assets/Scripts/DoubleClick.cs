using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleClick : MonoBehaviour
{
    private float firstLeftClickTime;
    private float timeBetweenLeftClick = 0.5f;
    private bool isTimeCheckAllowed = true;
    private int leftClickNum = 0;
    public event EventHandler doubleClicked;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            leftClickNum += 1;
        }
        if(leftClickNum == 1 && isTimeCheckAllowed)
        {
            firstLeftClickTime = Time.time;
            StartCoroutine(DetectDoubleLeftClick());
        }
    }

    private IEnumerator DetectDoubleLeftClick()
    {
        isTimeCheckAllowed = false;
        while (Time.time < firstLeftClickTime + timeBetweenLeftClick)
        {
            if (leftClickNum == 2)
            {
                Debug.Log("Double click");
                doubleClicked.Invoke(true, new EventArgs());
                break;
            }
            yield return new WaitForEndOfFrame();
        }
        leftClickNum = 0;
        isTimeCheckAllowed = true;
    }
}
