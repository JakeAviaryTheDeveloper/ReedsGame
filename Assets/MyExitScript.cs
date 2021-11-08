using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MyExitScript : MonoBehaviour
{

    public string SceneToOpen;
    public int NeedAmount; // Amount of cash needed to open exit door.
    public Text amountNeededUI;

    private void Start()
    {
        amountNeededUI.text = "Needed $" + NeedAmount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.GetComponent<PlayerCharacterScript>().Cash >= NeedAmount)
            {
                SceneManager.LoadScene(SceneToOpen);
            }

           
        }
            
    }
}
