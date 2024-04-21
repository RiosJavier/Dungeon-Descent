using UnityEngine;
using System.Collections;

public class cameraMove : MonoBehaviour
{
    public static float speed;

    private void Start()
    {
        speed = 2f;
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}