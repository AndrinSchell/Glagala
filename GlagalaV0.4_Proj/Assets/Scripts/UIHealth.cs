using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIHealth : MonoBehaviour
{

    public Slider healthBar;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    public void setHealth(float val)
    {
        healthBar.value = val;
        text.text = $"{healthBar.value}/{healthBar.maxValue}";
    }

    public void setMax(float val)
    {
        healthBar.maxValue = val;
    }
}
