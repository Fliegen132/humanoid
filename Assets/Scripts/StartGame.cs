using UnityEngine;

public class StartGame : MonoBehaviour
{
    public PlayerMovement _PlayerMovement;
    private DropGun[] _DropGuns;
    public PlayerAim _playerAim;
    public Fist fist;
    public Attack attack;
    public AnimationList _animationList;
    public WeaponsArray _weaponsArray;
    public Transform _inventory;
    public ChangeUI _changeUI;
    public ChangeWeapon _changeWeapon;

    public Animator _animator;
    public ResetAll _resetAll;
    //для сохранения
    public int AimSave;
    private void Start()
    {
        Application.targetFrameRate = 300;
        fist.Initialize();
        attack.InitializeWeapon(fist);
        _PlayerMovement.Initialize(true);
        _playerAim.Initialize(AimSave, _animationList, _resetAll);
        _changeWeapon.Initialize(_weaponsArray, _changeUI, attack, _animationList, _animator, _resetAll);

        _changeUI.AimBTN.SetActive(AimSave == 1);
        _weaponsArray.Weapons[0] = fist.gameObject;
        //Инициализация оружия на земле
        _DropGuns = FindObjectsOfType<DropGun>();

        foreach (var t in _DropGuns)
        {
            t.Initialize(_weaponsArray, _inventory, _changeUI, attack);
        }
        //-----------------
        
    }

}
