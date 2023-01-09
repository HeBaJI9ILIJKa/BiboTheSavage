using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjects : MonoBehaviour
{
    [Range(1, 100)]
    public int spawnWeight = 50;

    [SerializeField]
    public FallingObjectsTypes type;

    public int poolNumber;

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player"))
        {
            //Destroy(this.gameObject);
            EventManager.SendObjectFell(this);
        }
    }

    public void SetActive(bool value)
    {
        this.gameObject.SetActive(value);
    }
}

