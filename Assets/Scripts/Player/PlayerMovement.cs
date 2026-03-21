using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public InputCHECKERFUCK pInput;
    private Rigidbody2D rb;
    [SerializeField] public float moveSpeed;
    [SerializeField] public float jumpForce;
    private float MoveDirection;

    private void Start()
    {
        pInput = GetComponent<InputCHECKERFUCK>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void InputToMovement()
    {
        //              THIS IS ALL THE X AXIS MOVEMENT
        MoveDirection = pInput.inputAxis;
        if (MoveDirection == 1 || MoveDirection == -1)
            rb.linearVelocity = new Vector2(MoveDirection * moveSpeed, rb.linearVelocity.y);
        //              THIS IS ALL THE X AXIS MOVEMENT

        if (pInput.jumpPressed == true)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

    }

    private void FixedUpdate()
    {
        InputToMovement();
    }

}
