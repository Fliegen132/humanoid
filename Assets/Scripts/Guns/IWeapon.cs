using System.Collections;
using UnityEngine;

public interface IWeapon
{
   public Sprite gunSprite { get; set; }
   public bool canAim { get; set; }
   public bool gunIsHold { get; set; }
   public void Attack();

   public void Initialize();

   public void SetInfo(string name, Sprite sprite, bool CanShoot, bool gunIsHold);
   
}
