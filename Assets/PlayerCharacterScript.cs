using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacterScript : MonoBehaviour
{
    public float Speed;
    public Animator MyAnimator;
    public int Cash;
    public Text cashUI;
    public float PanicAmount;
    public Slider panicUI;


    // Start is called before the first frame update
    void Start()
    {
        Cash = 0;
        UpdateCashUI();
        PanicAmount = 0.0f;
        updatePanicUI();
    }

    // Update is called once per frame
    void Update()
    {
        bool IsMoving = false;
        Vector2 movement = Vector2.zero;
        //this code handles movementto the right.
        if (Input.GetKey(KeyCode.D))
        {
            movement = movement + (new Vector2(Speed, 0.0f));
            IsMoving = true;
        }
         
        if (Input.GetKey(KeyCode.A))
        {
            movement = movement - (new Vector2(Speed, 0.0f));
            IsMoving = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            movement = movement - (new Vector2(0.0f, Speed));
            IsMoving = true;
        }

        if (Input.GetKey(KeyCode.W))
        {
            movement = movement + (new Vector2(0.0f, Speed));
            IsMoving = true;
        }

        GetComponent<Rigidbody2D>().AddForce(movement);
           

        //This section handles animation.
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
        {
            IsMoving = true;
            MyAnimator.SetTrigger("WalkSide");
            if (Input.GetKeyDown(KeyCode.A))
                transform.localScale = new Vector3(-1.0f * Mathf.Abs( transform.localScale.x), transform.localScale.y,
                    transform.localScale.z);
            else
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y,
                transform.localScale.z);
            {
            
            
            }
            
                
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            MyAnimator.SetTrigger("WalkDown");
        }
         
        if (Input.GetKeyDown(KeyCode.W))
        {
            MyAnimator.SetTrigger("WalkUp");
        }
    
        
        
        
        {

        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp
            (KeyCode.D))
        {
            if(!IsMoving)
            {
                MyAnimator.SetTrigger("Idle");
            }
        }

       
    }
    public void UpdateCashUI()
    {
        cashUI.text = "Money: $" + Cash;
    }

    public void updatePanicUI()
    {
        panicUI.value = PanicAmount;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.tag == "money")
        {
           
                Destroy(collision.gameObject);
            Cash += 25;
            UpdateCashUI();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            PanicAmount += 0.05f;
            updatePanicUI();
        }
    }
}

    
          



