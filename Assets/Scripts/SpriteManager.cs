using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    private PlayerController playerController;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        playerController = transform.parent.transform.parent.GetComponent<PlayerController>();
        rb = transform.parent.transform.parent.GetComponent<Rigidbody2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    { 
       /* float moveVal = playerController.GetGamepad().leftStick.ReadValue().x;
        bool flip = true;
        if (moveVal.Equals(0))
        {
            flip = rb.velocity.x < 0.01;
        }
        else 
        {
            flip = moveVal < 0;
        }

        foreach (SpriteRenderer sr in transform.parent.transform.parent.GetComponentsInChildren<SpriteRenderer>())
        {
            sr.flipX = flip;
        }*/
    }
}
