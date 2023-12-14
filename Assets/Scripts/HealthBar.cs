using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Enemy enemy;
    public Image bar;
    public float fill;

    // Start is called before the first frame update
    void Start()
    {
        fill = 1f; // 100% precents
        bar.fillAmount = fill;
    }

    // Update is called once per frame
    void Update()
    {
        bar.fillAmount = ((float)enemy.CurrentHealth/2);
    }
}
