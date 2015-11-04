using UnityEngine;
using System.Collections;

public class GenerateTreeExample : MonoBehaviour {

    public GameObject nodeGameObject;

    public TreeLayout tree;

    // Options de la génération
    public int maxGenerations = 3;
    public int minChildrenByParent = 0;
    public int maxChildrenByParent = 3;

    public void Start()
    {
        GenerateRandomExample();
    }

    public void GenerateRandomExample()
    {
        tree.rootNode = RandomNode();

        Node currentNode = tree.rootNode;
        int nbGenerations = Random.Range(1, maxGenerations);
        for(int i = 0; i < nbGenerations; i++)
        {
            int nbChildren = Random.Range(minChildrenByParent, maxChildrenByParent);


        }

        tree.UpdateLayout();
    }

    public Node RandomNode()
    {
        GameObject g = Instantiate(nodeGameObject, Vector3.zero, Quaternion.identity) as GameObject;
        g.transform.parent = tree.transform;

        Node node = g.GetComponent<Node>();
        
        node.nodeName = RandomNames.PickName();        

        return node;
    }
}
