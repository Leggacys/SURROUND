using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Move : MonoBehaviour
{
    public Animator panelAnim;
    public Image[] hearts;
    public Sprite fullhart;
    public Sprite emptyheart;
    private Animator anim;
    private Rigidbody2D ry;
    private  Vector2 moveAmount;
    public float speed;
    public VirtualJoystick Joystick;
    public int  health;
    private transitionsPanel transitions;
    // Start is called before the first frame update
    void Start()
    {
      
        anim = GetComponent<Animator>();
        ry = GetComponent<Rigidbody2D>();
        transitions = FindObjectOfType<transitionsPanel>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        miscare();    
    }

    private void miscare()
    {
        Vector2 moveInput =Vector2.zero;
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
         moveAmount = moveInput.normalized * speed;
         if(Joystick.Directions!=Vector3.zero)
        {
            Vector3 v3 = Vector3.zero;
            v3 = Joystick.Directions;
            moveAmount.x = v3.x;
            moveAmount.y = v3.z;
            moveAmount *=Time.deltaTime * speed;
        }

    }
    private void FixedUpdate()
    {
        ry.position = ry.position + moveAmount;
       
    }

    private void Run()
    {
        if(moveAmount!=Vector2.zero)
        {
            anim.SetBool("ismove", false);
        }
        else
        {
            anim.SetBool("ismove", true);
        }
    }
    public void TakeDamage(int damageamount)
    {
        health -= damageamount;
        UpdateHeal(health);
        panelAnim.SetTrigger("Screen");
        if (health <= 0)
        {
            transitions.loadScreen("LOSE");
            Destroy(gameObject);
        }
    }
    void UpdateHeal(int currenthealt)
    {
        for(int i=0;i<hearts.Length;i++)
        {
            if (i < currenthealt)
            {
                hearts[i].sprite = fullhart;
            }
            else
            {
                hearts[i].sprite = emptyheart;
            }
        }
    }

      public void Heal(int healamount)
    {
         if(health+healamount>5)
        {
            health = 5;
        }
         else
        {
            health += healamount;
        }

        UpdateHeal(health);
    }
    

}
