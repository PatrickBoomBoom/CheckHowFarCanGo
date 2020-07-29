using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parent : MonoBehaviour
{
    public List<List<Node>> Nodes = new List<List<Node>>();

    public int x = 10;
    public int y = 10;
    public int StartRest = 10;

    private List<Node> l = new List<Node>();

    void Start()
    {
        x = Random.Range(1, 19);
        y = Random.Range(1, 19);
        StartRest = Random.Range(6, 15);

        for (int i = 0; i < 20; i++)
        {
            Nodes.Add(new List<Node>());
            for (int y = 0; y < 20; y++)
            {
                Transform x = transform.GetChild(i * 20 + y);
                if (x != null)
                {
                    Node node = x.GetComponent<Node>();
                    if (node != null)
                    {
                        node.SetXY(y, i);
                        Nodes[i].Add(node);
                    }
                }
            }
        }

        Debug.LogError(string.Format("初始点为：({0},{1}),初始行动力为：{2}", x, y, StartRest));
        StartAt(x, y, StartRest);
    }

    void StartAt(int x, int y, int rest)
    {
        if (Nodes.Count > y)
        {
            if (Nodes[y].Count > x)
            {
                var n = Nodes[y][x];
                n.SetColor(Color.red);
                n.rest = rest;
            }
        }
        l.Clear();
        l.Add(Nodes[y][x]);
        GoNextStep();
    }

    List<Node> tmp = new List<Node>();
    void GoNextStep()
    {
        tmp.Clear();

        foreach (var item in l)
        {
            int xx = 0;
            int yy = 0;

            xx = item.x - 1;
            yy = item.y;
            CheckNode(xx, yy, item.rest);

            xx = item.x + 1;
            yy = item.y;
            CheckNode(xx, yy, item.rest);

            xx = item.x;
            yy = item.y + 1;
            CheckNode(xx, yy, item.rest);

            xx = item.x;
            yy = item.y - 1;
            CheckNode(xx, yy, item.rest);
        }

        l.Clear();
        if (tmp.Count > 0)
        {
            l.AddRange(tmp);
            GoNextStep();
        }
    }

    private void CheckNode(int xx, int yy, int rest)
    {
        if (Nodes.Count > yy && yy >= 0)
        {
            if (Nodes[yy].Count > xx && xx >= 0)
            {
                var n = Nodes[yy][xx];
                int newRest = rest - n.cost;

                if (newRest > n.rest)
                {
                    n.rest = newRest;

                    if (n.rest > 0)
                    {
                        n.SetColor(Color.green);
                        tmp.Add(n);
                    }
                    else
                    {
                        n.SetColor(Color.red);
                    }
                }
            }
        }
    }
}
