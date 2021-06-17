using UnityEngine;

public class Ball : MonoBehaviour
{
    public float startScale;
    public float maxScale;
    public int ownedPlayerIndex;
    public LayerMask playerMask;

    public Player ballHolder;
    private Collider2D col;
    public Rigidbody2D rb;

    private void Start()
    {
        transform.localScale = new Vector3(startScale, startScale, startScale);
        ballHolder = null;
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (ballHolder != null)
        {
            transform.position = ballHolder.transform.position;
        }

        Collider2D hit = Physics2D.OverlapCircle(transform.position, col.bounds.extents.x, playerMask);
        //If we hit a player that isn't the one that shot us, deal damage

    }

    public void Throw()
    {
        //set
        ballHolder = null;
        Invoke("ResetBall", 0.2f);
    }

}
