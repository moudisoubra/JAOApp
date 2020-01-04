using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;

    public float direction;
    public PlayerSlasher player;
    public Animator animator;
    public Rigidbody2D rb;
    public bool start = false;
    public bool dead = false;
    public bool isdead = false;
    public bool walking = false;
    public bool gotHit = false;
    public bool attack = false;
    public Transform attackPoint;
    public float attackRange;
    public float attackDistance;
    public float attackDamage;
    public float attackTimer;
    public float attackTimerDuration;
    public LayerMask playerLayer;

    public float health;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerSlasher>();
        GetComponent<SpriteRenderer>().enabled = true;
        animator.SetTrigger("Spawn");
    }

    // Update is called once per frame
    void Update()
    {

        float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up)
        {
            Vector3 perp = Vector3.Cross(fwd, targetDir);
            float dir = Vector3.Dot(perp, up);

            if (dir > 0f)
            {
                return -1f;
            }
            else if (dir < 0f)
            {
                return 1f;
            }
            else
            {
                return 0f;
            }
        }
        Vector3 heading = player.transform.position - transform.position;
        direction = AngleDir(transform.forward, heading, transform.up);


        transform.localScale = new Vector3(direction, transform.localScale.y, transform.localScale.z);

        if (isdead)
        {
            Destroy(this.gameObject, 5);
        }

        if (health <= 0 && !isdead)
        {
            Die();
        }

        if (walking && !isdead)
        {
            animator.SetInteger("AnimState", 1);
        }
        else if(!isdead)
        {
            animator.SetInteger("AnimState", 0);
        }

        if (gotHit && !isdead)
        {
            attackTimer = 0;
            animator.SetTrigger("Hurt");
            gotHit = false;
        }

        if (attack && !isdead)
        {
            animator.SetTrigger("Attack");
            attack = false;
        }

        if (dead)
        {
            isdead = true;
            walking = false;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            GetComponent<BoxCollider2D>().enabled = false;
            animator.SetTrigger("Death");
            transform.position = new Vector3(transform.position.x, -0.64f, transform.position.z);
            attackPoint.gameObject.SetActive(false);
            player.points += 10;
            
            dead = false;
        }
        else
        {
            transform.position = new Vector3(transform.position.x, -0.631f, 0);
        }

        if (player && start && !isdead)
        {
            ChasePlayer();
        }
    }

    public void Die()
    {
        dead = true;
    }
    public void StartGame()
    {
        start = true;
    }
    public void ChasePlayer()
    {
        //Debug.Log(Vector2.Distance(transform.position, player.transform.position));

        if (Vector2.Distance(transform.position, player.transform.position) > attackDistance)
        {
            walking = true;
            transform.position += (transform.right * -direction) * speed * Time.deltaTime;
        }
        else
        {
            walking = false;
            Attack();
        }
    }

    public void Attack()
    {
        attackTimer += Time.deltaTime;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (attackTimer > attackTimerDuration && !enemy.GetComponent<PlayerSlasher>().dead)
            {
                attack = true;
                Debug.Log("Hit Player: " + enemy.name);
                attackTimer = 0;
            }
        }
    }

    public void HurtPlayer()
    {
        player.health -= attackDamage;
        player.GetComponent<Bandit>().Hurt();
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint)
        {
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }
}
