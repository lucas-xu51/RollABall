using UnityEngine;

public class ball : MonoBehaviour
{
    public Rigidbody sphereRigibody;
    public float ballSpeed = 2f;
    public float jumpForce = 5f;       // 跳跃力度
    public float rayLength = 0.6f;     // Raycast 的长度
    private bool isGrounded = false;   // 检测是否在地面

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("start");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            inputVector += Vector2.up;
        }

        if (Input.GetKey(KeyCode.S))
        {
            inputVector += Vector2.down;
        }

        if (Input.GetKey(KeyCode.D))
        {
            inputVector += Vector2.right;
        }

        if (Input.GetKey(KeyCode.A))
        {
            inputVector += Vector2.left;
        }

        Vector3 inputXYPlane = new Vector3(inputVector.x, 0, inputVector.y);
        sphereRigibody.AddForce(inputXYPlane * ballSpeed);

        isGrounded = Physics.Raycast(transform.position, Vector3.down, rayLength);

        // 跳跃控制
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            sphereRigibody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            
        }

    }

    void OnDrawGizmos()
    {
        Gizmos.color = isGrounded ? Color.green : Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * rayLength);
    }
}
