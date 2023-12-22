using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLives : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    private Rigidbody2D playerBody;

    private void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(playerBody.transform.position.y < -18)
        {
            RestartLevel();
        }
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Trap"))
        {
            Die();
        } else
        {
            Debug.Log("Not collided with trap");
        }
    }

    private void Die()
    {
        playerBody.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        Debug.Log("Player Dead");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
