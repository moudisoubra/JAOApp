using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSlasher : MonoBehaviour
{

    public LayerMask enemyLayer;
    public Transform attackPoint;
    public Bandit banditScript;
    public bool attackbool;
    public bool dead;
    public float attackRange = 0.5f;
    public float health;
    public float attack;
    public float upForce;
    public float sideForce;
    public float attackTimer;
    public float attackDuration;
    public int points;
    public GameObject endButton;
    public GameObject spawners;
    public Text pointsText;

    private void Start()
    {
        banditScript = GetComponent<Bandit>();
    }
    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime;
        pointsText.text = points.ToString("0");
        //if (Input.GetMouseButtonDown(0) && !dead)
        //{
        //    banditScript.Attack();
        //}

        if (health <= 0)
        {
            dead = true;
            endButton.SetActive(true);
            spawners.SetActive(false);
        }
    }

    public void AttackEnemy()
    {
        if (attackPoint)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

            foreach (Collider2D enemy in hitEnemies)
            {
                var enemyO = enemy.GetComponent<ZombieScript>();
                enemyO.rb.constraints = RigidbodyConstraints2D.None;
                enemyO.health -= attack;
                enemyO.gotHit = true;
                StartCoroutine(KnockBack(attackDuration, enemyO));
                
                enemyO.rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
                Debug.Log("Hit Enemy: " + enemy.name);
            }
        }
    }
    public IEnumerator KnockBack(float knockDuration, ZombieScript enemy)
    {
        float timer = 0;
        while (knockDuration > timer)
        {
            Debug.Log("KnockingBack");
            enemy.rb.constraints = RigidbodyConstraints2D.None;
            timer += Time.deltaTime;
            enemy.rb.AddForce(new Vector2(sideForce * enemy.direction, upForce), ForceMode2D.Impulse);
        }
        yield return 0;
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint)
        {
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }
}
