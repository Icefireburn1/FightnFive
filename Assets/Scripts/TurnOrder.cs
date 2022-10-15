using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurnOrder
{
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
        turnOrder = turnOrder.OrderBy(o => o.GetComponent<Character>().Speed).ToList();
    }
}
