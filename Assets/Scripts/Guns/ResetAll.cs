using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAll : MonoBehaviour
{
    public void ResetAllGuns()
    {
        TimeDelay[] timeDelays = FindObjectsOfType<TimeDelay>();
       
        for (int i = 0; i < timeDelays.Length; i++)
        {
            timeDelays[i].lowerAttack = true;
        }
    }
}
