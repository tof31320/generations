﻿using UnityEngine;
using System.Collections;

public class GenerateTreeExample : MonoBehaviour {

    public GameObject nodeGameObject;

    public TreeLayout tree;

    // Options de la génération
    public int maxGenerations = 4;
    public int minChildrenByParent = 0;
    public int maxChildrenByParent = 3;

    public static int i = 0;

    public void Start()
    {
        GenerateRandomExample();
    }

    public void GenerateRandomExample()
    {
        tree.rootNode = RandomNode(null);        

        GenerateDescendanceOfNode(tree.rootNode, 1);

        tree.UpdateLayout();
    }

    public void GenerateDescendanceOfNode(Node nodeParent, int generation)
    {
        if (generation > maxGenerations)
        {
            return;
        }

        int nbChildren = Random.Range(minChildrenByParent, maxChildrenByParent);

        for(int i = 1; i < 3; i++)
        {
            Node child = RandomNode(nodeParent);

            GenerateDescendanceOfNode(child, generation + 1);
        }
    }

    public Node RandomNode(Node nodeParent)
    {
        GameObject g = Instantiate(nodeGameObject, Vector3.zero, Quaternion.identity) as GameObject;
        g.name = "NODE " + i++;
        if (nodeParent == null)
        {
            g.transform.parent = tree.transform;
        }
        else
        {
            g.transform.parent = nodeParent.transform;
        }        

        Node node = g.GetComponent<Node>();
        
        node.person.personName = RandomNames.PickName();
        if (nodeParent == null)
        {
            node.person.naissance = -100;
        }
        else
        {
            node.person.naissance = nodeParent.person.naissance + Random.Range(18, 40);
        }

        return node;        
    }
}
