using System;
using System.Data;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputSystem_Actions inputControl;
    private Rigidbody2D rb;
    private PhysicsCheck physcisCheck;
    private PlayerAnimation playerAnimation;
    public Vector2 inputDirection;
    [Header("运动参数")]
    public float speed = 20f;
    public float jumpForce = 16f;

    public bool isHurt;
    public float hurtForce=10f;
    public bool isDead;
    public bool isAttack;


    private void Awake()
    {
        inputControl = new InputSystem_Actions();
        rb = GetComponent<Rigidbody2D>();
        inputControl.Gameplay.Player_1_Jump.started += Jump;
        inputControl.Gameplay.Player_1_Attack.started += PlayAttack;
        physcisCheck = GetComponent<PhysicsCheck>();
        playerAnimation = GetComponent<PlayerAnimation>();
    }
    private void OnEnable()
    {
        inputControl.Enable();
    }
    private void OnDisable()
    {
        inputControl.Disable();
    }

    private void Update()
    {
        inputDirection = inputControl.Gameplay.Player_1_Move.ReadValue<Vector2>();

    }
    private void FixedUpdate()
    {
        if (!isHurt)
        {
            Move();
        }
    }
    public void Move()
    {
        rb.linearVelocity = new Vector2(inputDirection.x * speed * Time.deltaTime, rb.linearVelocity.y);
        int faceDir = (int)transform.localScale.x;
        if (inputDirection.x < 0)
        {
            faceDir = -1;
        }
        if (inputDirection.x > 0)
        {
            faceDir = 1;
        }
        transform.localScale = new Vector3(faceDir, 1, 1);
    }
    private void Jump(InputAction.CallbackContext context)
    {
        if (physcisCheck.isGround)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log(other.name);
    }
    public void GetHurt(Transform attacker)//受伤后被弹开
    {
        isHurt = true;
        rb.linearVelocity = Vector2.zero;
        Vector2 dir = new Vector2((transform.position.x-attacker.position.x),0).normalized;
        rb.AddForce(dir * hurtForce,ForceMode2D.Impulse);
    }
    public void PlayerDead()
    {
        isDead = true;
        inputControl.Gameplay.Disable();
    }
    public void PlayAttack(InputAction.CallbackContext context)
    {
        playerAnimation.PlayAttack();
        isAttack = true;
    }
}
