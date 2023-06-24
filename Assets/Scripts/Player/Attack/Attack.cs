using System;
using UnityEngine;

public class Attack : MonoBehaviour
{
   private IWeapon currentWeapon;

   public bool isHold;
   
   public void CheckHold(bool _isHold) => isHold = _isHold;
   public void InitializeWeapon(IWeapon _currentWeapon)
   {
      currentWeapon = _currentWeapon;
   }

   public void AttackBtn()
   {
      currentWeapon.Attack();
   }

   private void Update() 
   {
      if (isHold)
         currentWeapon.Attack();
   }
}
