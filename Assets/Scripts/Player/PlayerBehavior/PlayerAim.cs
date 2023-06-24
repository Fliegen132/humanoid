using System;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
   public bool aim;
   public Animator anim;
   public AnimationList animationList;
   public ResetAll resetAll;
   public PlayerMovement playerMovement;
   public GameObject vc1;
   public GameObject vc2;

   public void Start()
   {
       playerMovement = GetComponent<PlayerMovement>();
   }

   public void Initialize(int _aim, AnimationList _animationList, ResetAll _resetAll)
   {
       animationList = _animationList;
       resetAll = _resetAll;
       if (_aim == 1)
       {
           aim = true;
       }
       else
       {
           aim = false;
       }
   }
   public void AimCheckBTN()
   {
       if(playerMovement.run == true) return;
       aim = !aim;
       animationList.offAll(anim);
       anim.SetBool("Aim", aim);
       resetAll.ResetAllGuns();
       CheckAim();
   }

   public void CheckAim()
   {
       if (aim == true)
       {
           vc1.SetActive(false);
           vc2.SetActive(true);
       }
       else
       {
           vc1.SetActive(true);
           vc2.SetActive(false);
       }
   }


}
