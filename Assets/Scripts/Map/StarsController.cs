using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsController : MonoBehaviour
{
	int _amount;
    public Sprite[] starTypes;
    public void Set(int number)
    {
		_amount = number;
        for (int i = 0; i < 3; i++)
        {
            transform.GetChild(i).GetComponent<Image>().sprite = starTypes[i < number ? 1 : 0];
        }
    }

	public int Get()
	{
		return _amount;
	}
}
