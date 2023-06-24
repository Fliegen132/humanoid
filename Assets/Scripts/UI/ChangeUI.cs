using UnityEngine;
using UnityEngine.UI;

public class ChangeUI : MonoBehaviour
{
    public Image changeWeaponBTN;

    public Image attackBTN;
    public Image attackHoldBTN;
    [Header("Aim Btn")] public GameObject AimBTN;
    public GameObject AttackBTN;
    public GameObject AttackHolderBTN;

    public PlayerAim _PlayerAim;
    public void ChangeWeaponBTNUI(Sprite _sprite)
    {
        changeWeaponBTN.sprite = _sprite;
        attackBTN.sprite = _sprite;
        attackHoldBTN.sprite = _sprite;
    }

    public void ChangeAttackBtn(bool gunIsHold)
    {
        if (gunIsHold == true)
        {
            AttackHolderBTN.SetActive(true);
            AttackBTN.SetActive(false);
        }
        else
        {
            AttackHolderBTN.SetActive(false);
            AttackBTN.SetActive(true);
        }
    }

    public void AimBtnUI(bool aim)
    {
        if (aim == true)
        {
            AimBTN.SetActive(true);
        }
        
        else
        {
            AimBTN.SetActive(false);
            _PlayerAim.aim = false;
            _PlayerAim.anim.SetBool("Aim", false);
        }
    }
}
