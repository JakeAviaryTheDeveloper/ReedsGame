using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatScript : MonoBehaviour
{
    // Start is called before the first frame update

    private Quaternion startingRotation;
    public bool Swing;
    private float myTimer;
    public float SwingSpeed;
    public GameObject myParent;

    void Start()
    {
        startingRotation = transform.rotation;
        //Swing = false;
        myTimer = 0.0f;
    }

   void Update()
    {
        if (Swing)
        {
            myTimer += Time.deltaTime;
            transform.position = myParent.transform.position;
            transform.Rotate(new Vector3(0.0f, 0.0f, SwingSpeed));
            if (Quaternion.Angle(startingRotation, transform.rotation) < 5.0f && myTimer > 0.7)
            {
                Destroy(gameObject);
            }

        }
    }
}
