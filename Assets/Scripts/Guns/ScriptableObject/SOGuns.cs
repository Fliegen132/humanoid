using UnityEngine;

[CreateAssetMenu(fileName = "NewGun", menuName = "Guns")]
public class SOGuns : ScriptableObject
{
    public string gunName;
    public GameObject gunPrefab;
    public Sprite gunSprite;
    public bool canShoot;
    public bool gunIsHold;
}
