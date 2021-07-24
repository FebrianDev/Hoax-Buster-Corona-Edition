using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Singleton
    private static PlayerMovement _player;
    public static PlayerMovement Instance
    {
        get
        {
            if (_player == null)
            {
                _player = FindObjectOfType<PlayerMovement>();
            }

            return _player;
        }
    }
    #endregion

    //SerializeField Private Components
    #region Components
    [Header("Components")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    #endregion
    [SerializeField] private Animator MainCharAnimator;
    //SerializedField Private Property

    #region Property
    [Header("Property")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField]private Joystick joystick;
    #endregion

    //Private Property
    private Vector2 movement;

    private void Update()
    {
       InputAnimation();
        
        print(movement.sqrMagnitude);
    }

    //Fungsi untuk melakukan movement pada player
    public void Movement()
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

    public void InputJoystick()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    public void InputAnimation()
    {
        MainCharAnimator.SetFloat("Horizontal", movement.x);
        MainCharAnimator.SetFloat("Vertical", movement.y);
        MainCharAnimator.SetFloat("Speed", movement.sqrMagnitude);
    }
}