using UnityEngine;

public class Attack : MonoBehaviour
{
    public int damage;
    public float attackRange;
    public float attackRate;
    public void OnTriggerStay2D(Collider2D other)
    {

        other.GetComponent<Character>()?.TakeDamage(this);//"?"保证对方有TakeDamage再执行
    
    }
}
