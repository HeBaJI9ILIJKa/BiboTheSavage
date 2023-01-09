using UnityEngine;

public class Stone : FallingObjects
{
    [SerializeField]
    private int DamageToPlayer = 3;
    private new void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.getInstance().PlayerDamage(DamageToPlayer);

            Notices.GetInstance().ShowNoticeHeart(-DamageToPlayer);
        }
        base.OnCollisionEnter2D(collision);
    }
}
