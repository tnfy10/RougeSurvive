using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobController : MonoBehaviour
{
    public static MobController mobController;
    public Transform target;
    NavMeshAgent agent;

    State state;
    
    Animator animator;
    
    enum State
    {
        Idle,
        Run,
        Attack
    }
    
    void Start()
    {
        state = State.Idle;

        agent = GetComponent<NavMeshAgent>();
        
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        mobController = this;
        
        switch (state)
        {
            case State.Idle:
                UpdateIdle();
                break;
            case State.Run:
                UpdateRun();
                break;
            case State.Attack:
                UpdateAttack();
                break;
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if ( collision.collider.tag == "Olive")
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            GameController.gameController.mobCount--;
            PlayerController.playerController.killCount++;
        }
    }
    
    public void UpdateAttack()
    {
        agent.speed = 0;
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance > 2)
        {
            state = State.Run;
            animator.SetTrigger("Run");
        } 
        else if (distance <= 1)
        {
            GameController.gameController.playerDamage();
        }
    }

    public void UpdateRun()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance <= 2)
        {
            state = State.Attack;
            animator.SetTrigger("Attack");
        }

        agent.speed = 3.5f;
        agent.destination = target.transform.position;
    }

    public void UpdateIdle()
    {
        agent.speed = 0;
        target = GameObject.Find("Player").transform;
        if (target != null)
        {
            state = State.Run;
            animator.SetTrigger("Run");
        }
    }
}
