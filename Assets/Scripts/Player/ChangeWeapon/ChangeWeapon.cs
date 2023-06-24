using UnityEngine;
using UnityEngine.Serialization;

public class ChangeWeapon : MonoBehaviour
{
    private WeaponsArray weaponsArray;
    private ChangeUI changeUi;

    private Attack attack;
    private AnimationList animationList;
    private Animator animator;
    public ResetAll resetAll;
    public void Initialize(WeaponsArray _weaponsArray, ChangeUI _changeUI, Attack _attack, AnimationList _animationList,
        Animator _animator, ResetAll _resetAll)
    {
        weaponsArray = _weaponsArray;
        changeUi = _changeUI;
        attack = _attack;
        animationList = _animationList;
        animator = _animator;
        resetAll = _resetAll;
    }

    public void Change()
    {
        if (weaponsArray.CountWeapon >= weaponsArray.Weapons.Count)
        {
            weaponsArray.CountWeapon = 0;
        }
        for (int i = 0; i < weaponsArray.Weapons.Count; i++)
        {
            weaponsArray.Weapons[i].gameObject.SetActive(false);
        }
        weaponsArray.Weapons[weaponsArray.CountWeapon].gameObject.SetActive(true);
        //изменение UI
        changeUi.ChangeWeaponBTNUI(weaponsArray.Weapons[weaponsArray.CountWeapon].GetComponent<IWeapon>().gunSprite);
        changeUi.AimBtnUI(weaponsArray.Weapons[weaponsArray.CountWeapon].GetComponent<IWeapon>().canAim);
        changeUi.ChangeAttackBtn(weaponsArray.Weapons[weaponsArray.CountWeapon].GetComponent<IWeapon>().gunIsHold);
        //----------
        attack.InitializeWeapon(weaponsArray.Weapons[weaponsArray.CountWeapon].GetComponent<IWeapon>());
        attack.isHold = false;
        weaponsArray.Weapons[weaponsArray.CountWeapon].GetComponent<IWeapon>().Initialize();
        
        PlayerAim playerAim = FindObjectOfType<PlayerAim>();
        playerAim.aim = false;
        playerAim.CheckAim();
        weaponsArray.CountWeapon++;
        animationList.offAll(animator);
        resetAll.ResetAllGuns();


    }
    
}
