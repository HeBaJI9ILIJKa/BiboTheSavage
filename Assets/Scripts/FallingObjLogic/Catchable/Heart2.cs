using UnityEngine;

public class Heart2 : FallingObjects
{
    [SerializeField] private int heal = 1;
    private new void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = Player.getInstance();
            player.PlayerIncreaseMaxHP(heal);
            player.PlayerHeal(heal);

            Notices.GetInstance().ShowNoticeHeart(heal, -50);
            Notices.GetInstance().ShowNoticeHeart(1, 50);
        }
        base.OnCollisionEnter2D(collision);
    }
}
