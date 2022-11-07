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

    /// <summary>
    /// Add a single object to the turnorder
    /// </summary>
    /// <param name="o"></param>
    public void Add(GameObject o)
    {
        turnOrder.Add(o);
    }

    /// <summary>
    /// Adds an already existing list to the turnorder
    /// </summary>
    /// <param name="o"></param>
    public void AddList(List<GameObject> o)
    {
        turnOrder.AddRange(o);
    }

    /// <summary>
    /// Sort the characters by speed. Fastest move first.
    /// </summary>
    public void SortBySpeed()
    {
        turnOrder.Sort(delegate (GameObject x, GameObject y)
        {
            return y.GetComponent<Character>().Speed.CompareTo(x.GetComponent<Character>().Speed);
        });
    }

    /// <summary>
    /// Get the list of units in turnorder
    /// </summary>
    /// <returns></returns>
    public List<GameObject> GetAllUnits()
    {
        return turnOrder;
    }

    /// <summary>
    /// Remove an item from turn order using a direct reference
    /// </summary>
    /// <param name="go"></param>
    public void RemoveFromTurnOrder(GameObject go)
    {
        turnOrder.Remove(go);
    }

    /// <summary>
    /// Moves the character at the beginning of the TurnOrder to the end.
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

    /// <summary>
    /// Number of items in turnOrder.
    /// </summary>
    /// <returns>Number of items in turnOrder</returns>
    public int Size()
    {
        return turnOrder.Count;
    }
}
