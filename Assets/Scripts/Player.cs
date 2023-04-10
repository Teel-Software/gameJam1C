using UnityEngine;

public class Player : MonoBehaviour
{
    public readonly TankType type = TankType.Player;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;

    private void OnEnable() {
        
    }

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");
        
        if ((x != 0 ^ y != 0) || 
            (x == 0 && y == 0))
            movement = new Vector2(x, y).normalized;

            

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
