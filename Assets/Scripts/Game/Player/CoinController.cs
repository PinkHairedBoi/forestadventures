using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private int _coinnumber;
    private int _amount;
    public TMP_Text text;

    public void Add()
    {
        _amount++;
        UpdateGraphics();
    }

    public int Get()
    {
        return _amount;
    }

    public int GetStars()
    {
        float percent = (float)_amount / (float)_coinnumber;
        return Mathf.FloorToInt(percent / 0.33f);
    }

    private void UpdateGraphics()
    {
        text.text = _amount + "/" + _coinnumber;
    }

    void Start()
    {
        _coinnumber = FindObjectsOfType<Coin>().Length;
        UpdateGraphics();
    }
}
