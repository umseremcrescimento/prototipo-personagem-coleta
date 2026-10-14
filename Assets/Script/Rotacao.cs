using UnityEngine;

public class Rotacao : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        transform.Rotate(new Vector3(15, 0, 45) * Time.deltaTime);
    }
}