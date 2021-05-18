using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public float jumpspeed = 0;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI deathText;
    public GameObject winTextObject;
    public GameObject menuButton;
    
    

    private Rigidbody rb;
    private int count;
    private int deaths;
    private bool istouching = true;

    private float movementX;
    private float movementY;
    
    private Vector3 originalPos;
    

    private AudioSource source;
    private AudioClip jumpSound;
    public AudioClip collectSound;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Start()
    {
        
        rb = GetComponent<Rigidbody>();

        count = 0;

        deaths = 0;

        SetCountText();
        
        setDeathText();

        winTextObject.SetActive(false);
        
        menuButton.SetActive(false);
        
        originalPos = gameObject.transform.position;
    }


    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void Update()
    {
        
        if (istouching == true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                Vector3 jump = new Vector3(0.0f, 6.0f,0.0f);
                rb.AddForce(jump * jumpspeed);
                        
                source.Play();
            }
        }
    }

    private void OnCollisionStay(Collision other)
    {
        istouching = true;

    }

    private void OnCollisionExit(Collision other)
    {
        istouching = false;
    }


    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
        
    }
        


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            
            source.PlayOneShot(collectSound);
        }
        

        
        SetCountText();
        
        if(other.gameObject.CompareTag("End"))
        {
            gameObject.transform.position = originalPos;
            deaths = deaths + 1;
            setDeathText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 12)
        {
            menuButton.SetActive(true);
            winTextObject.SetActive(true);
            GameObject.Find("Player").SendMessage("Finnish");
        }
    }

    public void SetSpawn(Vector3 newPos)
    {
        originalPos = newPos;
    }

    void setDeathText()
    {
        deathText.text = "Deaths: " + deaths.ToString();
    }

   
}
