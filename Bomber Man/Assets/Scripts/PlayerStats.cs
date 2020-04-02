using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 3;
    public int health = 2;  

    private bool vunerable = true;

    public GameObject dustPile;
    private Slider hpBar;
    private Animator animator;

    private void Start()
    {
        animator = transform.GetComponent<Animator>();
        hpBar = FindObjectOfType<Slider>();
        hpBar.maxValue = health;
        hpBar.value = health;
    }

    public void TakeDamage(int damage)
    {
        if (vunerable)
        {
            health -= damage;
            hpBar.value = health;
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.Hurt);
            StartCoroutine(PlayeHurtAnimation(0.5f));
            if (health <= 0)
            {
                StartCoroutine(Die());            
            }
            StartCoroutine(BecomeInvunerable(2));
        }
    }

    private IEnumerator PlayeHurtAnimation(float time)
    {
        animator.SetBool("Hurt", true);
        yield return new WaitForSeconds(time);
        animator.SetBool("Hurt", false);
    }

    private IEnumerator BecomeInvunerable(float time)
    {
        vunerable = false;
        for (int i = 0; i <= 10; i++)
        {
            transform.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(time / 20);
            transform.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(time / 20);
        }
        vunerable = true;
    }

    private IEnumerator Die()
    {
        animator.SetBool("Dead", true);
        transform.GetComponent<PlayerController>().enabled = false;
        yield return new WaitForSeconds(1);
        Instantiate(dustPile, transform.position, Quaternion.identity);
        GameMaster.Instance.LoseGame();
        Destroy(gameObject);
    }

    public void IncreaseHealth(int increase)
    {
        health += increase;
        if (health > maxHealth)
            health = maxHealth;
        if (health > hpBar.maxValue)
            hpBar.maxValue = health;
        hpBar.value = health;
    }
}
