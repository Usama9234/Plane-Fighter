using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCount : MonoBehaviour
{
    public Text coinCountText;
    int count = 0;
    private void Update()
    {
        coinCountText.text = count.ToString();
    }

    public void addCount()
    {
        count++;
    }
}
