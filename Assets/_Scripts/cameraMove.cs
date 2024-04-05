using UnityEngine;
using System.Collections;

public class cameraMove : MonoBehaviour
{
    public float speed;
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}