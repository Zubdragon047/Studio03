using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    public float rotationSpeed = 85f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.Euler(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
