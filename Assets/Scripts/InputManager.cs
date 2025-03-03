using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    [SerializeField] private CinemachineCamera freeLookCamera;
    public UnityEvent<Vector3> OnMove = new UnityEvent<Vector3>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = freeLookCamera.transform.forward;
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        Vector3 input = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
            input += Vector3.forward;
        if (Input.GetKey(KeyCode.S))
            input += Vector3.back;
        if (Input.GetKey(KeyCode.A))
            input += Vector3.left;
        if (Input.GetKey(KeyCode.D))
            input += Vector3.right;
        if (Input.GetKeyDown(KeyCode.Space))
            input += Vector3.up;

        OnMove?.Invoke(input);
    }
}
