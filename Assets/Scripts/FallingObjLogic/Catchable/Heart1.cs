using UnityEngine;

public class Heart1 : FallingObjects
{
    [SerializeField]
    private int heal = 500;
    private new void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = Player.getInstance();
            player.PlayerIncreaseMaxHP(1);
            player.PlayerHeal(heal);

            Notices.GetInstance().ShowNoticeHeart(heal, -50);
            Notices.GetInstance().ShowNoticeHeart(1, 50);
        }
        base.OnCollisionEnter2D(collision);
    }
}
