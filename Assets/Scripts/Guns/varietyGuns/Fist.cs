using System.Collections;
using UnityEngine;

public class Fist : MonoBehaviour, IWeapon
{
    public Sprite gunSprite { get; set; }
    public bool canAim { get; set; }

    public Animator Anim;

    public SOGuns SOFist;

    
    //название анимаций для системы комбо вомбо
    private string Attack1 = "Attack1";
    private string Attack2 = "Attack2";
    
    private string Stand = "stand";

    public int currentAttack;
    [SerializeField]private bool canAttack = true;
    public bool gunIsHold { get; set; }
    
    public void Initialize()
    {
        SetInfo(SOFist.gunName, SOFist.gunSprite, SOFist.canShoot, SOFist.gunIsHold);
        canAttack = true;
    }

    public void Attack()
    {
        if(canAttack == false)
            return;
        Anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        Anim.SetBool(Stand, true);
        StartCoroutine(returnCanAttack());
        if (currentAttack == 0)
        {
            canAttack = false;
            Anim.SetBool(Attack1, true);
            
            currentAttack++; 
            StartCoroutine(offAnim());

        }
        else if (currentAttack == 1)
        {
            canAttack = false;

            Anim.SetBool(Attack2, true);
            currentAttack--;
            StartCoroutine(offAnim());
        }
        Debug.Log("удар кулаком");
    }
    public IEnumerator offAnim()
    {
        yield return new WaitForSeconds(1f);

        Anim.SetBool(Stand, false);

        Anim.SetBool(Attack2, false);
        
        Anim.SetBool(Attack1, false);
    }

    private IEnumerator returnCanAttack()
    {
        yield return new WaitForSeconds(1f);
        canAttack = true;

    }
    public void SetInfo(string _name, Sprite _sprite, bool _canShoot, bool _gunIsHold)
    {
        Debug.Log(_name);
        gunSprite = _sprite;
        canAim = _canShoot;
    }

    
}
