using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Byron : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float modelAngularSpeed = 25f;

    float curSpeed = 0f;

    public Transform model;
    public Animator animator;
    CharacterController controller;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        animator.SetBool("IsRun", Input.GetKey(KeyCode.LeftShift));
        if (Input.GetKey(KeyCode.LeftShift))
        {
            curSpeed = runSpeed;
        }
        else
        {
            curSpeed = walkSpeed;
        }
        var input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized;
        if (input.magnitude != 0f)
        {
            var direction = transform.InverseTransformDirection(input);
            var angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            var rotateAngle = Quaternion.Euler(Vector3.up * angle);
            model.localRotation = Quaternion.Lerp(model.localRotation, rotateAngle, modelAngularSpeed * Time.deltaTime);
        }
        controller.Move(input * curSpeed * Time.deltaTime);
        var velocity = controller.velocity.magnitude;
        animator.SetFloat("Velocity", velocity);
    }
}
