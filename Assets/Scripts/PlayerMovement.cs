using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //SerializeField Private Components
    [Header("Components")]
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Animator anim;
    
    //SerializedField Private Property
    [Header("Property")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField]private Joystick joystick;
    
    //Private Property
    private Vector2 movement;

    private void Update()
    {
        InputMovement();
        InputJoystick();
        //InputAnimation();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    //Fungsi untuk melakukan movement pada player
    private void Movement()
    {
        if (rb != null)
        {
            rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
        }
        else
        {
            Debug.LogError("Komponen Rigidbody Belum DiTambahkan Ke Dalam Script");
        }
    }
    
    //Fungsi untuk Input Player
    private void InputMovement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    
    private void InputJoystick()
    {
        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;
    }

    /*private void InputAnimation()
    {
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);
    }*/
}