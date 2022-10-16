using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedTarget : MonoBehaviour
{
    public Transform selectedTarget;

    public Ability.EligibleTarget eligibleTarget;

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<SpriteRenderer>().enabled = false;
    }

    private void Awake()
    {
        eligibleTarget = Ability.EligibleTarget.OneEnemy;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
