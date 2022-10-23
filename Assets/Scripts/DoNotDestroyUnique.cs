using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Do not destroy this object on scene load AND make sure we don't make duplicates of this object
/// </summary>
public class DoNotDestroyUnique : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    private void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("Background").Length > 1)
        {
            GameObject.Destroy(transform.gameObject);
        }
    }
}
