using System.Collections;
using UnityEngine;

public class Uzi : MonoBehaviour, IWeapon
{
    public Sprite gunSprite { get; set; }
    public bool canAim { get; set; }
    public bool gunIsHold { get; set; }

    public Animator Anim;
    
    private TimeDelay timer;
    public ParticleSystem muzzleFlash;

    private PlayerAim playerAim;
    public GameObject shootGameObjectSound;
    public void Initialize()
    {
        Anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        playerAim = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerAim>();
        timer = GetComponent<TimeDelay>();
    }
    public void SetInfo(string _name, Sprite _sprite, bool _canShoot, bool _gunIsHold)
    {
        Debug.Log(_name);
        gunSprite = _sprite;
        canAim = _canShoot;
        gunIsHold = _gunIsHold;
    }

    public void Attack()
    {
        if(playerAim.aim == false)
            ShootAimOut();
        else
            InstBullet();
    }

    private void ShootAimOut()
    {
        Anim.SetBool("Shoot", true);
        if (timer.canAttack == true)
        {
            if(timer.lowerAttack == false)
                InstBullet();
            else
                StartCoroutine(InstBulletDownHand());

            timer.canAttack = false;
        }
        timer.currentTimeLower = 0;

        timer.lowerAttack = false;
    }

    private void Update()
    {
        if (timer.lowerAttack == true)
        {
            Anim.SetBool("Shoot", false);
        }
        else if(timer.lowerAttack == true && playerAim.aim == false)
        {
            Anim.SetBool("Shoot", true);
        }
    }
    
    private void InstBullet()
    {
        if(!timer.canAttack) return;
        Instantiate(shootGameObjectSound, transform);
        muzzleFlash.Play();
        timer.canAttack = false;

    }

    private IEnumerator InstBulletDownHand()
    {
        yield return new WaitForSeconds(0.2f);
        Instantiate(shootGameObjectSound, transform);

        muzzleFlash.Play();
    }
    
    
}
