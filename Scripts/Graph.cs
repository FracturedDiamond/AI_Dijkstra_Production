using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph
{
    List<Connection> mConnections;

    // an array of connections outgoing from the given node
    public List<Connection> getConnections(Node fromNode)
    {
        List<Connection> connections = new List<Connection>();
        foreach (Connection c in mConnections)
        {
            if (c.getFromNode() == fromNode)
            {
                connections.Add(c);
            }
        }
        return connections;
    }

    public void Build()
    {
        // find all nodes in scene
        // iterate over the nodes
        //   create connection objects,
        //   stuff them in mConnections
        mConnections = new List<Connection>();

        Node[] nodes = GameObject.FindObjectsOfType<Node>();
        foreach (Node fromNode in nodes)
        {
            foreach (Node toNode in fromNode.ConnectsTo)
            {
                if (toNode.tollRoad == true && toNode.teleporter == false)
                {
                    toNode.cost = 50;
                    Debug.Log(toNode.cost);
                }
                else if (toNode.tollRoad == false && toNode.teleporter == true)
                {
                    toNode.cost = 0;
                    Debug.Log(toNode.cost);
                } else
                {
                    toNode.cost = (toNode.transform.position - fromNode.transform.position).magnitude;
                    Debug.Log(toNode.cost);
                }

                Connection c = new Connection(toNode.cost, fromNode, toNode);
                mConnections.Add(c);
            }
        }
    }
}

public class Connection
{
    float cost;
    Node fromNode;
    Node toNode;

    public Connection(float cost, Node fromNode, Node toNode)
    {
        this.cost = cost;
        this.fromNode = fromNode;
        this.toNode = toNode;
    }
    public float getCost()
    {
        return cost;
    }

    public Node getFromNode()
    {
        return fromNode;
    }

    public Node getToNode()
    {
        return toNode;
    }
}