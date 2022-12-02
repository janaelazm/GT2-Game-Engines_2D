using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    private Rigidbody2D rb2;
    private Animator animator;
    private Transform playerTransform;
    private Vector2 movementInput;
    [SerializeField] private float movementSpeed;
    private float saveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        saveSpeed = movementSpeed;
        rb2 = GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }

    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        // flip player sprites when moving left or right
        if (movementInput.x < 0 )
        {
            playerTransform.localScale = new Vector2(-Mathf.Abs(playerTransform.localScale.x), playerTransform.localScale.y);
        }
        else if(movementInput.x > 0)
        {
            playerTransform.localScale = new Vector2(Mathf.Abs(playerTransform.localScale.x), playerTransform.localScale.y);
        }
        else
        {
            playerTransform.localScale = new Vector2(playerTransform.localScale.x, playerTransform.localScale.y);
        }

        animator.SetFloat("speed", movementInput.magnitude);
    }

    private void FixedUpdate()
    {
        rb2.velocity = movementInput * (movementSpeed * Time.deltaTime);
        
    }

    public void DisableMovement()
    {
        movementSpeed = 0;
    }

    public void EnableMovement()
    {
        movementSpeed = saveSpeed;
    }
}
