using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderBorder : MonoBehaviour
{
    public GameObject prefab1;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Loader")
        {
            //Load in next room area.
            Instantiate(prefab1, new Vector3(transform.position.x+50,0,0), Quaternion.identity);
            Debug.Log("next room loaded!");
        }
    }
}
