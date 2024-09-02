using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0;
    private Rigidbody rb;
    private float movementX;
    private float movementY; 
    private int count;
    
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    
    void Start()
    {   
        rb = GetComponent <Rigidbody>();
        SetCountText();
        count = 0;
        winTextObject.SetActive(false);
         
    }


    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x; 
        movementY = movementVector.y;
    }
    void SetCountText() 
    {
        countText.text =  "Count: " + count.ToString();
        if (count >= 14)
        {
            winTextObject.SetActive(true);
        }
    }

    private void FixedUpdate() 
    {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("PickUp")) 
        {
            other.gameObject.SetActive(false);  
            count = count + 1;
            SetCountText();
        }
    }
   

}
