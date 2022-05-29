using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController playerController;
    public float moveSpeed = 3f;
    public float rotationSpeed = 120f;

    public Animator animator;
    public GameObject olive;
    public GameObject olivePos;
    public Text fiverText;

    float power = 600;
    private bool fiverMode;
    public int killCount;
    
    void Start()
    {
        fiverMode = false;
        killCount = 0;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        playerController = this;
        
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Walk", true);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveSpeed = 4.5f;
            }
            else
            {
                moveSpeed = 3f;
            }
        }
        else
        {
            animator.SetBool("Walk", false);
        }
        
        float horizontal = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, horizontal, 0);

        float vertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(0, 0, vertical);
        
        if (killCount >= 30 && !fiverMode)
        {
            killCount = 0;
            fiverMode = true;
            fiverText.gameObject.SetActive(true);
            Invoke("OffFiverMode", 5f);
        }

        if (Input.GetButtonDown("Fire1")) {
            if (fiverMode)
            {
                for (var i = 0; i < 10; i++)
                {
                    attack();
                }
            }
            else
            {
                attack();
            }
        }
    }

    void OffFiverMode()
    {
        fiverMode = false;
        fiverText.gameObject.SetActive(false);
    }

    void attack()
    {
        GameObject myOlive = Instantiate(olive, olivePos.transform.position, olivePos.transform.rotation);
        myOlive.GetComponent<Rigidbody>().AddForce(olivePos.transform.forward * power);
    }
}