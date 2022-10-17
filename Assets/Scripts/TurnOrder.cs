using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// When a battle starts, they are placed into a TurnOrder which sorts them by their speed.
/// This order never moves. Characters can be removed from this TurnOrder when they are defeated.
/// </summary>
[System.Serializable]
public class TurnOrder
{
    [SerializeField]
    private List<GameObject> turnOrder;

    public TurnOrder()
    {
        this.turnOrder = new List<GameObject>();
    }

    public void Add(GameObject o)
    {
        turnOrder.Add(o);
    }

    public void AddList(List<GameObject> o)
    {
        turnOrder.AddRange(o);
    }

    public void SortBySpeed()
    {
        turnOrder.Sort(delegate (GameObject x, GameObject y)
        {
            return y.GetComponent<Character>().Speed.CompareTo(x.GetComponent<Character>().Speed);
        });
    }

    public List<GameObject> GetAllUnits()
    {
        return turnOrder;
    }

    public void RemoveFromTurnOrder(GameObject go)
    {
        turnOrder.Remove(go);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>The character that is moving AFTER the shuffle has happened</returns>
    public GameObject DoNext()
    {
        if (turnOrder.Count <= 0)
        {
            Debug.LogError("No more items in turnorder");
            return null;
        }
        GameObject temp = turnOrder[0];
        turnOrder.RemoveAt(0);
        turnOrder.Insert(turnOrder.Count, temp);
        return turnOrder[0];
    }

    /// <summary>
    /// Gets the character that is currently moving.
    /// </summary>
    /// <returns></returns>
    public GameObject GetMoving()
    {
        if (turnOrder.Count <= 0)
        {
            Debug.LogError("No more items in turnorder");
            return null;
        }
        return turnOrder[0];
    }

    /// <summary>
    /// Starting from the beginning of the TurnOrder, find the next character that the player controls.
    /// </summary>
    /// <returns></returns>
    public GameObject GetFirstMovingPlayer()
    {
        if (turnOrder.Count <= 0)
        {
            Debug.LogError("No more items in turnorder");
            return null;
        }
        for (int i = 0; i < turnOrder.Count; i++)
        {
            if (turnOrder[i].GetComponent<Character>().IsPlayer)
            {
                return turnOrder[i];
            }
        }
        return null;
    }
}
