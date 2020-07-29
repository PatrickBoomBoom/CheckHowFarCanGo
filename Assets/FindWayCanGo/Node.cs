using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour
{
    public int x;
    public int y;
    public int cost = 1;
    private Text m_text;

    public int rest;

    private void Awake()
    {
        int theCost = 1;
        float x = UnityEngine.Random.Range(0, 10f);
        if (x > 9)
        {
            theCost = 5;
        }
        else if (x > 7)
        {
            theCost = 2;
        }

        m_text = transform.GetComponentInChildren<Text>();
        m_text.resizeTextForBestFit = true;
        //cost = int.Parse(m_text.text);
        m_text.text = theCost.ToString();
        cost = theCost;
    }

    public void SetXY(int a, int b)
    {
        x = a;
        y = b;
    }

    public void SetColor(Color c)
    {
        transform.GetComponent<Image>().color = c;
    }
}
