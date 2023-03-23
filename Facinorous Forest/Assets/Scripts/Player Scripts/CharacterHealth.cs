using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{

    public float playerHP;

    // Start is called before the first frame update
    void Start()
    {
        playerHP = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHP <= 0f)
        {
            Destroy(this);
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            playerHP -= 1f;
            Debug.Log("you have " + playerHP + " HP left!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy Projectile")
        {
            playerHP -= 1f;
            Debug.Log("you have " + playerHP + " HP left!");
        }
    }
}
