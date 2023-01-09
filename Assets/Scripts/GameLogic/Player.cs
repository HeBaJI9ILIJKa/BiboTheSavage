using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    private Animator animator;
    private new Rigidbody2D rigidbody2D;
    private Transform _transform;

    [SerializeField]
    private int healthpoint = 5, maxHealthpoint = 5;

    [SerializeField]
    private Text hpText;
    
    private bool playerDamaged, playerRunning;
    private Vector2 movementVector, scaleRight, scaleLeft;

    private static Player instance;

    public static Player getInstance()
    {
        return instance;
    }

    void Start()
    {
        instance = this;
        animator = this.GetComponent<Animator>();
        rigidbody2D = this.GetComponent<Rigidbody2D>();
        _transform = this.transform;
        scaleRight = new Vector3(1.5f, 1.5f, 0);
        scaleLeft = new Vector3(-1.5f, 1.5f, 0);
        movementVector = new Vector2(0, 0);
    }

    private void FixedUpdate()
    {
        MovementLogic();
    }

    private void MovementLogic()
    {
        if (playerDamaged) return;

        if (Input.touchCount <= 0)
        {
            if (playerRunning)
            {
                movementVector.x = 0;
                rigidbody2D.velocity = movementVector;
                TurnOffRunAnimation();
            }
            else return;
        }
        else
        {   
            if (Camera.main.ScreenToWorldPoint(Input.GetTouch(Input.touchCount - 1).position).x >= 0)
            {
                movementVector.x = 1;
                _transform.localScale = scaleRight;
            }
            else
            {
                movementVector.x = -1;
                _transform.localScale = scaleLeft;
            }
            rigidbody2D.velocity = movementVector * GameParameters.playerSpeed;
            TurnOnRunAnimation();
            //rigidbody2D.AddForce(_movementVector * GameParameters.playerSpeed, ForceMode2D.Impulse);
        } 
    }
    private void TurnOffRunAnimation()
    {
        if (playerRunning)
        {
            animator.SetBool("Run", false);
            playerRunning = false;
        }
    }
    private void TurnOnRunAnimation()
    {
        if (!playerRunning)
        {
            animator.SetBool("Run", true);
            playerRunning = true;
        }
    }
    private void Healthpoint—hange(int points)
    {
        healthpoint += points;
        hpText.text = healthpoint.ToString();
    }

    private void PlayerNotDamaged()
    {
        playerDamaged = false;
        animator.SetBool("Damaged", false);
        if (healthpoint <= 0)
        {
            //GameController.getInstance().GameOver();
            EventManager.SendGameOver();
        }
    }

    public void PlayerDamage(int Damage)
    {
        playerDamaged = true;
        animator.SetBool("Damaged", true);
        Healthpoint—hange(-Damage);

        if (hpText.color == Color.black)
            hpText.color = new Color32(100, 0, 0, 255);
    }

    public void PlayerHeal(int Heal)
    {
        if (healthpoint == maxHealthpoint) return;
        
        if (healthpoint + Heal > maxHealthpoint)
            Heal = maxHealthpoint - healthpoint;
       
        Healthpoint—hange(Heal);

        if (healthpoint == maxHealthpoint)
            hpText.color = Color.black;
    }

    public void PlayerIncreaseMaxHP(int amount = 1)
    {
        maxHealthpoint += amount;
    }
    public void PlayerDecreaseMaxHP(int amount = 1)
    {
        maxHealthpoint -= amount;
    }

   
}
