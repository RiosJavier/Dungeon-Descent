using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderBorder : MonoBehaviour
{
    public List<GameObject> prefabList;
    public static int roomCount;

    void Start(){
        Debug.Log("room count set to 0");
        roomCount = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.tag);

        if (collision.tag == "Loader")
        {
            //Load in next room area.
            Instantiate(prefabList[Random.Range(0, prefabList.Count)], new Vector3(transform.position.x+39,0,0), Quaternion.identity);
            Debug.Log("next room loaded!");
            roomCount++;
        }
    }
}
