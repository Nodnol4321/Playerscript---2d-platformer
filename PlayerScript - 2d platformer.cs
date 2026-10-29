using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
   [SerializeField] private float speed;
    private Rigidbody2D body;

    private int JumpCount = 0;
    public int maxJumps = 1;

    public LayerMask ground;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private bool get_ground()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 1f, ground);
    }

    private void Update()
    {
        body.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.linearVelocityY);

        if (Input.GetKeyDown(KeyCode.Space) && JumpCount < maxJumps)
        {
            body.linearVelocity = new Vector2(body.linearVelocityX, speed);
            JumpCount++;
        }
        Debug.DrawRay(transform.position, Vector2.down * 1, Color.green);
        if (get_ground()){
            JumpCount = 0;
        }

    }
}
