using UnityEngine;

public class Drumstick2 : FallingObjects
{
    [SerializeField] private int heal = 3, scoreDecreaseValue = 1;
    private new void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = Player.getInstance();
            player.PlayerHeal(heal);
            Score.ScoreDecrease(scoreDecreaseValue);

            Notices.GetInstance().ShowNoticeHeart(heal, -50);
            Notices.GetInstance().ShowNoticeBone(-scoreDecreaseValue, 50);
        }
        base.OnCollisionEnter2D(collision);
    }
}
