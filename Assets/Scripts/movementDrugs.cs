using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementDrugs : MonoBehaviour
{
    private Rigidbody2D rb;
    public float thrust = 2f;
    public Animator playerAnimator;
    public bool move;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!CustomGameManager.Instance.isPaused)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            Vector3 movement = new Vector3(moveHorizontal, 0, 0);

            if (move)
            {
                rb.velocity = movement * thrust;
                playerAnimator.SetBool("isWalking", true);
            }
            else
                rb.velocity = Vector2.zero;

            if (rb.velocity == Vector2.zero)
            {
                playerAnimator.SetBool("isWalking", false);
            }
        }
    }
}
