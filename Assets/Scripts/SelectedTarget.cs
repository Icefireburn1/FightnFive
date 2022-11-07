using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The target that is selected during battle
/// </summary
public class SelectedTarget : MonoBehaviour
{
    public Transform selectedTarget;

    public Ability.EligibleTarget eligibleTarget;

    private void Awake()
    {
        eligibleTarget = Ability.EligibleTarget.OneEnemy;
    }
}
