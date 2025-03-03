using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class InputManager : MonoBehaviour
{
    public UnityEvent<Vector3> OnMove = new UnityEvent<Vector3>();
    [SerializeField] private CinemachineCamera freeLookCamera;

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
            input += transform.forward;
        if (Input.GetKey(KeyCode.S))
            input -= transform.forward;
        if (Input.GetKey(KeyCode.A))
            input -= transform.right;
        if (Input.GetKey(KeyCode.D))
            input += transform.right;
        if (Input.GetKeyDown(KeyCode.Space))
            input += Vector3.up;

        OnMove?.Invoke(input);
    }
}
