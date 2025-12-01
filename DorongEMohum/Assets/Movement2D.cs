using UnityEngine;


public class Movement2D : MonoBehaviour
{
    private float moveSpeed = 5.0f;
    private Vector3 moveDirection;
    private Rigidbody2D rigid2d;

    public GameObject pPreviousSkill = null;
    public GameObject pNextSkill = null;
    public int skillType = -1;

    private float rotateSpeed = 0.0f;

    private void Awake()
    {
        rigid2d = GetComponent<Rigidbody2D>();
    }

    public void Setup(Vector3 direction)
    {
        moveDirection = direction;
    }

    public void SetRotation(float speed)
    {
        rotateSpeed = speed;
    }

    private void Update()
    {
        //transform.position += moveDirection * moveSpeed * Time.deltaTime;

        rigid2d.velocity = moveDirection * moveSpeed;
        transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * rotateSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed = 0.0f;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        moveSpeed = 5.0f;
    }
}