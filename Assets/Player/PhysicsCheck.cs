using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    private Collider2D coll;
    [Header("检测情况")]
    public bool manual;
    public bool isGround;
    public bool touchRightWall;
    public bool touchLeftWall;
    [Header("检测参数")]
    public float checkRaduis=0.5f;
    public Vector2 bottomOffset;
    public Vector2 leftOffset;
    public Vector2 rightOffset;

    public LayerMask groundLayer;
    private void Awake()
    {
        coll= GetComponent <CapsuleCollider2D>();
        if (!manual)
        {
            rightOffset = new Vector2(coll.bounds.size.x/2+coll.offset.x,coll.bounds.size.y/2);
            leftOffset = new Vector2(-(coll.bounds.size.x/2 + coll.offset.x), coll.bounds.size.y / 2);
        }
        //左右撞墙检测点的自动对正
    }

    public void Update()
    {
        Check();
    }
    public void Check()
    {
        isGround = Physics2D.OverlapCircle((Vector2)transform.position+ bottomOffset, checkRaduis,groundLayer);
        touchLeftWall = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, checkRaduis, groundLayer);
        touchRightWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, checkRaduis, groundLayer);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset, checkRaduis);
        Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset, checkRaduis);
        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, checkRaduis);
    }

}
