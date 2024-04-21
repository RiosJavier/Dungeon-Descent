using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderBorder : MonoBehaviour
{
    public List<GameObject> prefabList;
    public GameObject shopkeeperRoom;
    public static int roomCount;
    public static int shopkeeperCount;

    void Start(){
        Debug.Log("room count set to 0");
        roomCount = 9;
        shopkeeperCount = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.tag);
        
        if (collision.tag == "Loader")
        {
            collision.tag = "already touched";
            roomCount++;

            if (roomCount % 10 == 0) 
            {
                //load the shopkeeper every ten rooms instead
                Instantiate(shopkeeperRoom, new Vector3(transform.position.x + 39, 0, 0), Quaternion.identity);
                shopkeeperCount++;
                Debug.Log("Shopkeeper Loaded!!!!!");
            }
            else
            {
                //Load in next room area at random.
                Instantiate(prefabList[Random.Range(0, prefabList.Count)], new Vector3(transform.position.x+39,0,0), Quaternion.identity);
                Debug.Log("next room loaded!");
            }
        }

        if(collision.tag == "Freezer")
        {
            collision.tag = "already touched";
            roomCount++;

            cameraMove.speed = 0f;
        }
    }
}
