using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
        return temp;
    }

    public GameObject GetMoving()
    {
        if (turnOrder.Count <= 0)
        {
            Debug.LogError("No more items in turnorder");
            return null;
        }
        return turnOrder[0];
    }

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
