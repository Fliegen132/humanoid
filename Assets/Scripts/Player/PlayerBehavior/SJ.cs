using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SJ : MonoBehaviour
{
    public PlayerMovement PlayerMovement;
    public void Jump()
    {
        PlayerMovement.velocityY.y = PlayerMovement.jumpSpeed;
    }

    public Transform rLeg;
    public Transform lLeg;
    public GameObject tracePrefab;
    public void LTrace()
    {
        if (!PlayerMovement.controller.isGrounded) return;
        GameObject go = Instantiate(tracePrefab);
        go.transform.position = lLeg.transform.position;
    }
    public void RTrace()
    {
        if (!PlayerMovement.controller.isGrounded) return;
        GameObject go = Instantiate(tracePrefab);
        go.transform.position = rLeg.transform.position;
    }
}
