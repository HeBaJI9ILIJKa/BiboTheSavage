using UnityEngine;

public class Bone : FallingObjects
{
    [SerializeField] private int scoreIncreaseValue = 1;
    private new void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Score.ScoreIncrease(scoreIncreaseValue);
            Notices.GetInstance().ShowNoticeBone(scoreIncreaseValue);
        }
        base.OnCollisionEnter2D(collision);
    }
}
