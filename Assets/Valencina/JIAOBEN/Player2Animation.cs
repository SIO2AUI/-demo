using UnityEngine;

public class Player2Animation : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;
    public PhysicsCheck pc;
    public Player2Controller player2Controller;
    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        pc = GetComponent<PhysicsCheck>();
        player2Controller = GetComponent<Player2Controller>();
    }
    void Update()
    {
        SetAnimation();
    }
    public void SetAnimation()
    {
        anim.SetFloat("velocityX", Mathf.Abs(rb.linearVelocity.x));
        anim.SetFloat("velocityY", rb.linearVelocity.y);
        anim.SetBool("isGround", pc.isGround);
        anim.SetBool("isDead", player2Controller.isDead);
    }
    public void PlayHurt()
    {
        anim.SetTrigger("hurt");
    }
    public void PlayAttack()
    {
        anim.SetTrigger("attack");
    }

}