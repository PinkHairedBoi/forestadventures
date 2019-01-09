using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartController : MonoBehaviour
{
	private int _heartamount;
	private int _amount;

	public void Add(int i)
	{
		_amount += i;
		UpdateGraphics();
	}

	public int Get()
	{
		return _amount;
	}

	private void UpdateGraphics()
	{
		for(int i = 0; i < _heartamount; i++)
		{
			transform.GetChild(i).GetComponent<Image>().color = new Color(1, 1, 1, i < _amount ? 1f : 0.4f);
		}
	}

	void Start()
	{
		_heartamount = transform.childCount;
		_amount = _heartamount;
		UpdateGraphics();
	}
}
