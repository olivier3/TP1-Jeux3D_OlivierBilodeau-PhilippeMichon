using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    private int nbPoints = 0;

    public int GetPoints()
    {
        return nbPoints;
    }

    public void AddPoint()
    {
        nbPoints += 100;
    }
}
