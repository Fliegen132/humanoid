using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationList : MonoBehaviour
{
   public string[] animations;

   public void offAll(Animator anim)
   {
      for (int i = 0; i < animations.Length; i++)
      {
         anim.SetBool(animations[i], false);
      }
   }
}
