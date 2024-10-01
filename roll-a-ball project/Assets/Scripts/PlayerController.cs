using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb; 
    private int count;
    private float moveX;
    private float moveY;

    public float speed = 0; 
    public TextMeshProUGUI cText;
    public GameObject winTextObject;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody>(); 
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove (InputValue movementValue)
   {
        Vector2 movementVector = movementValue.Get<Vector2>(); 
        moveX = movementVector.x; 
        moveY = movementVector.y; 
   }

   void SetCountText()
   {
        cText.text = "Count: " + count.ToString();
        if(count >= 8) {
            winTextObject.SetActive(true);
        }
   }

    private void FixedUpdate() 
    {
        Vector3 movement = new Vector3 (moveX, 0.0f, moveY);
        rb.AddForce(movement * speed); 
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("PickUp")){
            other.gameObject.SetActive(false);
            ++count;
            SetCountText();
        }
    }

}
