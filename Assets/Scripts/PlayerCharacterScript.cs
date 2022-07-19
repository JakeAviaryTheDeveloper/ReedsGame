using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCharacterScript : MonoBehaviour
{
    public float Speed;
    public Animator MyAnimator;
    public int Cash;
    public Text cashUI;
    public float PanicAmount;
    public Slider panicUI;
    public float Health;
    public Slider HealthUI;
    public int Bats;
    public Text BatsUI;
    public GameObject BatPrefab;
    public float detectRange;

    // oh my god uwuwuwuwuwu
    
    // Start is called before the first frame update
    void Start()
    {
        Cash = 0;
        UpdateCashUI();
        PanicAmount = 0.0f;
        updatePanicUI();
        Health = 1.0f;
        UpdateHealthUI();
        Bats = 0;
        UpdateBatsUI();
    }

    // Update is called once per frame
    void Update()
    {

        //check if we are near an enemy and create panic if we are
        var enemyCheck = Physics2D.OverlapCircle(transform.position, detectRange, (1 << 8));
        if (enemyCheck != null)
        {
            PanicAmount += 0.1f;
        }

        // Handle attacking with the bat.

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Bats > 0)
            {
                GameObject newBat = Instantiate<GameObject>(BatPrefab);
                newBat.transform.position = transform.position;
                BatScript newbatscript = newBat.GetComponent<BatScript>();
                newbatscript.Swing = true;
                newbatscript.myParent = gameObject;
                newBat.GetComponent<BatScript>().Swing = true;
                Bats -= 1;
                UpdateBatsUI();
           }
        }


        bool IsMoving = false;
        Vector2 movement = Vector2.zero;
        //this code handles movementto the right.
        if (Input.GetKey(KeyCode.D))
        {
            movement = movement + (new Vector2(Speed * Time.deltaTime, 0.0f));
            IsMoving = true;
        }
         
        if (Input.GetKey(KeyCode.A))
        {
            movement = movement - (new Vector2(Speed * Time.deltaTime, 0.0f));
            IsMoving = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            movement = movement - (new Vector2(0.0f, Speed * Time.deltaTime));
            IsMoving = true;
        }

        if (Input.GetKey(KeyCode.W))
        {
            movement = movement + (new Vector2(0.0f, Speed * Time.deltaTime));
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
        if (PanicAmount >= 1.0f) {
            SceneManager.LoadScene("Game Over");
        }
    }

    public void UpdateHealthUI()
    {
        HealthUI.value = Health;
        if (Health <= 0.0f) {
            SceneManager.LoadScene("Game Over");
        }
    }
    public void UpdateBatsUI()
    {
        BatsUI.text = Bats.ToString();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.tag == "money")
        {
           
                Destroy(collision.gameObject);
            Cash += 25;
            UpdateCashUI();
        }

        if (collision.gameObject.tag == "Enemy")
        {
            PanicAmount += 0.05f;
            updatePanicUI();
        }

        if (collision.gameObject.tag == "hazard")
        {
            Health -= 0.1f;
            UpdateHealthUI();
        }

        if (collision.tag == "bat")
        {
            Bats += 1;
            UpdateBatsUI();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "HealthPickup")
        {
            Health += 0.1f;
            
            if (Health > 1.0f)
            {
                Health = 1.0f;

                
            }
            UpdateHealthUI();
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
    }
}

    
          



