using UnityEngine;

public class Drumstick1 : FallingObjects
{
    [SerializeField] private int heal = 1;
    private new void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.getInstance().PlayerHeal(heal);
            Notices.GetInstance().ShowNoticeHeart(heal);
        }
        base.OnCollisionEnter2D(collision);
    }
}

