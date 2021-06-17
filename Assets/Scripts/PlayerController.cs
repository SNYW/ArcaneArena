using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerControls playerControls;
    private Rigidbody2D rb;
    private Collider2D col;
    public int playerIndex;
    public Player player;
    public bool aiming;
    public bool charging;
    public Vector2 aimAngle;
    private Gamepad gamepad;

    public float moveSpeed;
    public float maxMoveSpeed;
    public float jumpForce;
    public float maxJumpSpeed;
    private Vector2 moveInput;

    public LayerMask ground;

    void Awake()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        player = GetComponent<Player>();
        aiming = false;
        charging = false;
        gamepad = Gamepad.all.ToArray()[playerIndex];
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    void Update()
    {
        Move();
        if (gamepad.buttonSouth.wasPressedThisFrame)
        {
            Jump();
        }
        else if (gamepad.leftTrigger.wasPressedThisFrame)
        {
            if(player.shotPower < player.maxShotPower)
            {
                StartCharging();
            }
            else
            {
                charging = false;
            }
        }
        else if (gamepad.leftTrigger.wasReleasedThisFrame)
        {
            StopCharging();
        }
        else if (gamepad.rightTrigger.wasPressedThisFrame)
        {
            StartAim();
        }
        else if (gamepad.rightTrigger.wasReleasedThisFrame)
        {
            StopAim();
        }

        if(gamepad.rightShoulder.wasPressedThisFrame)
        {
            if(!aiming && !charging)
            {
                player.ActivateShield();
            }
        }
        else if(gamepad.rightShoulder.wasReleasedThisFrame)
        {
            player.DeactivateShield();
        }

        if (charging)
        {
            player.IncrementShotPower();
        }
        if (aiming)
        {
            SetStickRotation();
            player.SetAimIndicatorPosition();
        }
    }

    private void StartCharging()
    {
        if (IsGrounded() && !aiming)
        {
            rb.velocity = Vector2.zero;
            charging = true;
        }
    }

    private void StopCharging()
    {
        charging = false;
        player.StopCharging();
        player.HideShotEffect();
    }

    private void StartAim()
    {
        if(player.shotPrefab != null && !charging)
        {
            player.aimIndicator.SetActive(true);
            rb.gravityScale = 0.1f;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / 5);
            aiming = true;
            player.StartAiming();
        }
    }

    private void StopAim()
    {
        if (!charging)
        {

            player.aimIndicator.SetActive(false);
            rb.gravityScale = 1;
            player.FireShot(aimAngle);
            aiming = false;
        }
    }

    private void Jump()
    {
        if (IsGrounded())
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, 0, maxJumpSpeed)); ;
        }
    }

    public bool IsGrounded()
    {
        Vector2 topLeftPoint = transform.position;
        topLeftPoint.x -= col.bounds.extents.x;
        topLeftPoint.y += col.bounds.extents.y;

        Vector2 bottomRightPoint = transform.position;
        bottomRightPoint.x += col.bounds.extents.x;
        bottomRightPoint.y -= col.bounds.extents.y+0.1f;
        return Physics2D.OverlapArea(topLeftPoint, bottomRightPoint, ground);
    }

    private void Move()
    {
        if (!charging)
        {
            moveInput = gamepad.leftStick.ReadValue();
            if (aiming) moveInput /= 10;
            Vector3 currentPosition = transform.position;
            rb.AddForce(new Vector2(moveInput.x * moveSpeed * Time.deltaTime,LeftStickYValue()));
            transform.position = currentPosition;
        }

        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxMoveSpeed, maxMoveSpeed), rb.velocity.y);
    }

    public Gamepad GetGamepad()
    {
        return gamepad;
    }

    public void SetAimAngle(Vector2 a)
    {
        aimAngle = a;
    }

    private void SetStickRotation()
    {
        var posOffset = gamepad.leftStick.ReadValue();

        if (!posOffset.Equals(new Vector2(0, 0)))
        {
            var dir = (Vector2)transform.position + posOffset - (Vector2)transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion rot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angle);
            SetAimAngle(dir);

            player.SetAimInidicatorRotation(rot);
        }
    }

    private float LeftStickYValue()
    {
        if(gamepad.leftStick.ReadValue().y < 0 && !aiming)
        {
            return gamepad.leftStick.ReadValue().y * moveSpeed * Time.deltaTime;
        }
        else
        {
            return 0;
        }
    }

}
