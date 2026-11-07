using UnityEngine;
using UnityEngine.InputSystem;

public class Player2Controller : MonoBehaviour
{
    public InputSystem_Actions inputControl;
    private Rigidbody2D rb;
    private PhysicsCheck physcisCheck;
    private Player2Animation player2Animation;
    public Vector2 inputDirection;
    [Header("运动参数")]
    public float speed = 20f;
    public float jumpForce = 16f;
    public float currentSpeed;
    [Header("冲刺参数")]
    public float dashSpeed=100f;
    public float dashTimer;
    public float dashTime=1f;
    public bool isDash;
    public float dashDirection;

    public bool isHurt;
    public float hurtForce = 10f;
    public bool isDead;
    public bool isAttack;
    private void Awake()
    {
        inputControl = new InputSystem_Actions();
        rb = GetComponent<Rigidbody2D>();
        inputControl.Gameplay.Player_2_Jump.started += Jump;
        inputControl.Gameplay.Player_2_Attack.started += PlayAttack;
        inputControl.Gameplay.Player_2_Dush.started += PlayDash;
        physcisCheck = GetComponent<PhysicsCheck>();
        player2Animation = GetComponent<Player2Animation>();

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
        inputDirection = inputControl.Gameplay.Player_2_Move.ReadValue<Vector2>();

    }
    private void FixedUpdate()
    {
        if (isDash)
            Dash();
        else if(!isHurt&&!isDash)
            Move();
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
    public void PlayAttack(InputAction.CallbackContext context)
    {
        player2Animation.PlayAttack();
        isAttack = true;
    }
    public void PlayDash(InputAction.CallbackContext context)
    {
        if (!isDash)
        {
            dashTimer = dashTime;
            dashDirection = transform.localScale.x;
            isDash = true;
        }
    }
    public void Dash()
    {
        rb.linearVelocity = new Vector2(dashDirection * dashSpeed*Time.deltaTime, rb.linearVelocity.y);
        dashTimer -= Time.deltaTime;
        if (dashTimer <= 0)
        {
            isDash = false;
        }

    }

    public void GetHurt(Transform attacker)//受伤后被弹开
    {
        isHurt = true;
        rb.linearVelocity = Vector2.zero;
        Vector2 dir = new Vector2((transform.position.x - attacker.root.position.x), 0).normalized;
        rb.AddForce(dir * hurtForce, ForceMode2D.Impulse);
    }
    public void GetHurtRecover()
    {
        isHurt = false;
    }
    public void PlayerDead()
    {
        isDead = true;
        inputControl.Gameplay.Disable();
    }
}
