using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChooser : MonoBehaviour
{
    public List<Sprite> sprites;
    public GameObject sp;

    // Update is called once per frame
    void Update()
    {
        PlayerStatus.Item i = PlayerStatus.getItem();

        switch (i)
        {
            case PlayerStatus.Item.ROPE:
                sp.GetComponent<SpriteRenderer>().sprite = sprites[(int)i];
                break;
            case PlayerStatus.Item.NONE:
                sp.GetComponent<SpriteRenderer>().sprite = sprites[(int)i];
                break;

        }
    }
}
