using UnityEngine;

public class Spaceship : MonoBehaviour
{
    //https://www.youtube.com/watch?v=DVHcOS1E5OQ
    [SerializeField] float accelerationFactor, turnFactor, driftFactor, maxSpeed;
    float accelerationInput, steeringInput, rotationAngle, velocityVsUp;
     
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 inputVector = Vector2.zero;
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");
        SetInputVector(inputVector);
    }

    private void FixedUpdate()
    {
        ApplyEngineForce();
        KillOrthogonalVelocity();
        ApplySteering();
    }

    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput = inputVector.x;
        accelerationInput = inputVector.y;
    }

    void ApplyEngineForce()
    {
        // How much "forward" we'r going in term of direction of our velocity
        velocityVsUp = Vector2.Dot(transform.up, rb.velocity);

        // Limit max speed on forward direction
        if (velocityVsUp > maxSpeed && accelerationInput > 0)
            return;

        // Limit so we cannot go faster than 50% of max speed on reverse
        if (velocityVsUp < -maxSpeed * .5f && accelerationInput < 0)
            return;

        // Limit so we cannot go faster in any direction while accelerating
        if (rb.velocity.sqrMagnitude > maxSpeed * maxSpeed && accelerationInput > 0)
            return;

        // Ship stops when player lets go of the accelerator
        if (accelerationInput == 0)
            rb.drag = Mathf.Lerp(rb.drag, 3f, Time.fixedDeltaTime * 3);
        else rb.drag = 0;
         
        Vector2 engineForceVector = transform.up * accelerationInput * accelerationFactor;
        rb.AddForce(engineForceVector, ForceMode2D.Force);
    }

    void ApplySteering()
    {
        // Limit the ability to turn when moving slowly
        float minSpeedBeforeAllowTurningFactor = (rb.velocity.magnitude / 2);
        minSpeedBeforeAllowTurningFactor = Mathf.Clamp01(minSpeedBeforeAllowTurningFactor);

        rotationAngle -= steeringInput * turnFactor * minSpeedBeforeAllowTurningFactor;
        rb.MoveRotation(rotationAngle);
    }

    void KillOrthogonalVelocity()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(rb.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(rb.velocity, transform.right);

        rb.velocity = forwardVelocity + rightVelocity * driftFactor;
    }
}
