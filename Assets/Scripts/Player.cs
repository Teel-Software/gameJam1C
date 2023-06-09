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
    void Update() {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
