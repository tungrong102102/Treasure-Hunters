using UnityEngine;
using System.Collections.Generic;
public class BoxController : MonoBehaviour, IDamagebleAndKnockBack
{
    public int maxHealth;
    private int currentHealth;
    private Animator animator;
    [SerializeField]
    private GameObject DeathGO;
    public bool setDeath;
    [SerializeField]
    private Transform DeathPos;
    public List<GameObject> Coins;
    private void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (setDeath)
        {
            setDeath = false;
            animator.SetTrigger("Death");
        }
    }

    public void OnHit(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            animator.SetTrigger("Death");
        }
    }
    public void InstanceCoin()
    {
        Destroy(gameObject);
        Instantiate(DeathGO, DeathPos.position, transform.rotation);
        for (int i = 0; i < 5; i++)
        {
            int index = Random.Range(0, Coins.Count - 1);
            GameObject temp = Instantiate(Coins[index], transform.position, transform.rotation);
            Vector2 tempAddForce = new Vector2(Random.Range(-3, 3), Random.Range(-3, 2));
            temp.GetComponent<Rigidbody2D>().AddForce(tempAddForce, ForceMode2D.Impulse);
        }
    }

    public void KnockBack(Vector2 pos, float knockbackForce)
    {
        throw new System.NotImplementedException();
    }
}
