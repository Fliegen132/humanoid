using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    public Transform cam;
    
    public Animator anim;
    public DynamicJoystick joystick;
    public CharacterController controller;
    public PlayerAim playerAim;
    public bool Move;
    public float smoothTime = 0.1f;
    private float smoothVelocity;
    public bool run;
    private Vector3 directionVector;
    //Jump
    public Vector3 velocityY;
    public float gravity = -20f;
    public float jumpSpeed = 15f;
    public int clickForJump;
    private void Start()
    {
        playerAim = GetComponent<PlayerAim>();
    }

    public void Initialize(bool _move) => Move = _move;

    public void CheckRun(bool _run)
    {
        if(playerAim.aim == true)
            return;
        run = _run;

    }
    //это и есть кнопка бега
    public void JumpBtn()
    {
        clickForJump++;
        StartCoroutine(afterJumpBtn());
    }

    IEnumerator afterJumpBtn()
    {
        yield return new WaitForSeconds(0.5f);
        clickForJump = 0;
        
    }

    private void FixedUpdate() => Movement();
    
    private void Update()
    {
        Run();

    }

    private void Movement()
    {
        if (Move == false) return;
        directionVector = new Vector3(joystick.Horizontal, 0.0f, joystick.Vertical).normalized;

        anim.SetFloat("speed", Vector3.ClampMagnitude(directionVector, 1).magnitude);
        if (directionVector.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(directionVector.x, directionVector.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        Jump();
       
    }
    
    public void Run()
    {
        if (run && directionVector.magnitude >= 0.1f)
        {
            anim.SetBool("run", true);
            speed = 5f;
        }
        else
        {
            anim.SetBool("run", false);
            speed = 1.5f;
        }
    }

    public bool isJump;
    private void Jump()
    {
        if(playerAim.aim == true) return;
        if (controller.isGrounded && clickForJump >= 2 && directionVector.magnitude <= 0)
        {
            isJump = true;
            clickForJump = 0;
            anim.SetBool("Jump", true);
            StartCoroutine(endJump());
        }
        else if(directionVector.magnitude >= 0.1f && controller.isGrounded && clickForJump >= 2)
        {
            isJump = true;

            clickForJump = 0;
            anim.SetBool("moveJump", true);

            anim.SetBool("run", false);

            StartCoroutine(endMoveJump());
        }

        velocityY.y += gravity * Time.deltaTime;
        controller.Move(velocityY * Time.deltaTime);
    }

    IEnumerator endJump()
    {
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("Jump", false);
        anim.SetBool("moveJump", false);
        isJump = false;

    }
    IEnumerator endMoveJump()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("moveJump", false);
        isJump = false;
    }
}