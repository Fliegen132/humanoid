using System;
using UnityEngine;

public class TimeDelay : MonoBehaviour
{
    [SerializeField]public float currentTime;
    [SerializeField]public float shootDelayTime;

    [Header("---------")]
    [SerializeField]public float currentTimeLower;
    [SerializeField]public float timeLower;

    public bool canAttack;
    public bool lowerAttack;


    private void Start()
    {
        canAttack = true;
        lowerAttack = true;
    }

    private void Update()
    {
        if(!canAttack)
            currentTime += Time.deltaTime;
        if(!lowerAttack)
            currentTimeLower += Time.deltaTime;
        
        if (currentTime >= shootDelayTime)
        {
            canAttack = true;
            currentTime = 0;
        }

        if (currentTimeLower >= timeLower)
        {
            lowerAttack = true;
            currentTimeLower = 0;
        }

    }
}
