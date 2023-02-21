using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Transform bar;

    public void setSize(float size)
    {
        bar.localScale = new Vector2(size, 1f);
    }
}
