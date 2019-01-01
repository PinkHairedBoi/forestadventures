using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsController : MonoBehaviour
{
    public Sprite[] starTypes;
    public void SetStars(int number)
    {
        for (int i = 0; i < 3; i++)
        {
            transform.GetChild(i).GetComponent<Image>().sprite = starTypes[i < number ? 1 : 0];
        }
    }
}
