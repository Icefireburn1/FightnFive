using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedTarget : MonoBehaviour
{
    public Transform selectedTarget;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null && Input.GetMouseButtonDown(0))
        {
            Debug.Log(hit.transform.gameObject.name + " Position: " + hit.collider.gameObject.transform.position);
            selectedTarget = hit.transform;
            transform.position = new Vector3(selectedTarget.position.x+.022f, selectedTarget.position.y+0.815f);
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
