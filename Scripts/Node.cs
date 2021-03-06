using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour
{
    public Node[] ConnectsTo;
    public float cost;
    public bool tollRoad = false;
    public bool teleporter = false;

    public Text theText;

    public GameObject sphere;

    public void Teleport()
    {
        teleporter = !teleporter;

        if (teleporter)
        {
            theText.text = "Teleport: 0";
            theText.color = Color.magenta;
        } else if (tollRoad)
        {
            theText.text = "Toll Road: 50";
            theText.color = Color.red;
        } else
        {
            theText.text = "Road: ~15";
            theText.color = new Color32(32, 32, 32, 255);
        }

        sphere.GetComponent<Pathfinder>().Restart();
    }

    public void Toll()
    {
        tollRoad = !tollRoad;

        if (teleporter)
        {
            theText.text = "Teleport: 0";
            theText.color = Color.magenta;
        }
        else if (tollRoad)
        {
            theText.text = "Toll Road: 50";
            theText.color = Color.red;
        }
        else
        {
            theText.text = "Road: ~15";
            theText.color = new Color32(32, 32, 32, 255);
        }

        sphere.GetComponent<Pathfinder>().Restart();



    }

    private void OnDrawGizmos()
    {
        foreach (Node n in ConnectsTo)
        {
            Gizmos.color = Color.gray;
            Gizmos.DrawLine(transform.position, n.transform.position);
            //Gizmos.DrawRay(transform.position, (n.transform.position - transform.position).normalized * 2);
        }
    }

}