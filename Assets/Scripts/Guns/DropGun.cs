using UnityEngine;

public class DropGun : MonoBehaviour
{
    public SOGuns gun;

    private WeaponsArray weaponsArray;
    private Transform Inventory;
    private ChangeUI changeUI;
    public Attack attack;
    public void Initialize(WeaponsArray _WeaponsArray, Transform _Inventory, ChangeUI _changeUI, Attack _attack)
    {
        attack = _attack;
        weaponsArray = _WeaponsArray;
        Inventory = _Inventory;
        changeUI = _changeUI;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            var weaponGO = Instantiate(gun.gunPrefab, Inventory);
            weaponsArray.Weapons.Add(weaponGO);
            for (int i = 0; i < weaponsArray.Weapons.Count; i++)
            {
                weaponsArray.Weapons[i].gameObject.SetActive(false);
            }
            weaponGO.gameObject.SetActive(true);
            weaponGO.GetComponent<IWeapon>().SetInfo(gun.gunName, gun.gunSprite,gun.canShoot, gun.gunIsHold);
            attack.InitializeWeapon(weaponGO.GetComponent<IWeapon>());
            changeUI.ChangeWeaponBTNUI(gun.gunSprite);
            changeUI.AimBtnUI(gun.canShoot);
            changeUI.ChangeAttackBtn(gun.gunIsHold);
            weaponsArray.CountWeapon++;
            weaponGO.GetComponent<IWeapon>().Initialize();
            
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        Quaternion rotation = Quaternion.AngleAxis(1f, Vector3.up);
        transform.rotation *= rotation;
    }
}
