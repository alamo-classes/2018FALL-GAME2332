using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwordsman : MonoBehaviour
{
    public float speed = 2f;
    public float detectRange = 30;
    public float swordAttackRange = 5f;
    public bool moveCloser;
    public bool inSwordRange;
    Transform player;
    Rigidbody2D m_rigidBody;
    Direction direction;
    Sword sword;
    int addCounter = 0;
    Animator swordsmanAnim;

    void Awake ( )
    {
        direction = GetComponent<Direction>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        m_rigidBody = GetComponent<Rigidbody2D>();
        sword = GetComponentInChildren<Sword>();
        swordsmanAnim = GetComponent<Animator>();
    }

    void FixedUpdate ( )
    {
        float detectDistance = (player.transform.position - transform.position).sqrMagnitude;
        DetermineAction(detectDistance);

        if (moveCloser)
        {
            m_rigidBody.MovePosition(Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime));
        }
        if (inSwordRange && !sword.isAttacking && !sword.onCooldown)
        {
            if (detectDistance > 1f)
                m_rigidBody.MovePosition(Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime));
            sword.Attack();
            sword.onCooldown = true;
        }
    }

    public void DetermineAction ( float detectDistance )
    {
        if (detectDistance <= detectRange && detectDistance >= 1)
        {
            moveCloser = true;
            AudioManager.inCombat = true;
            swordsmanAnim.SetBool("isMoving", true);
            SetDirection();
        }
        else
        {
            moveCloser = false;
            swordsmanAnim.SetBool("isMoving", false);
            swordsmanAnim.SetInteger("vertical", 0);
            swordsmanAnim.SetInteger("horizontal", 0);
        }
        if (detectDistance <= swordAttackRange)
        {
            inSwordRange = true;
            //moveCloser = false;
            //swordsmanAnim.SetBool("isMoving", false);
        }
        else
        {
            inSwordRange = false;
        }

        if ((moveCloser || inSwordRange) && addCounter < 1)
        {
            PlayerController.enemiesInRange++;
            addCounter++;
        }

        if (!moveCloser && !inSwordRange && addCounter > 0)
        {
            PlayerController.enemiesInRange--;
            addCounter--;
        }
    }

    private void SetDirection ( )
    {
        if (player.position.y > transform.position.y)
        {
            direction.SetFacing(Direction.Facing.Up);
            swordsmanAnim.SetInteger("vertical", 1);
            swordsmanAnim.SetInteger("horizontal", 0);
        }
        else
        {
            direction.SetFacing(Direction.Facing.Down);
            swordsmanAnim.SetInteger("vertical", -1);
            swordsmanAnim.SetInteger("horizontal", 0);
        }

        if (Mathf.Abs(player.position.y - transform.position.y) < Mathf.Abs(player.position.x - transform.position.x))
        {
            if (player.position.x > transform.position.x)
            {
                direction.SetFacing(Direction.Facing.Right);
                swordsmanAnim.SetInteger("horizontal", 1);
                swordsmanAnim.SetInteger("vertical", 0);
            }
            else
            {
                direction.SetFacing(Direction.Facing.Left);
                swordsmanAnim.SetInteger("horizontal", -1);
                swordsmanAnim.SetInteger("vertical", 0);
            }
        }
    }

    void OnDestroy ( )
    {
        PlayerController.enemiesInRange--;
    }
}
