using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class movePartyObject : MonoBehaviour
{
    public GameObject partymember;

    public GameObject target;

    private List<GameObject> gos = new List<GameObject>();

    // Use this for initialization
    void Start()
    {

    }

    float rate = 0.0f;
    bool trans = false;

    // Update is called once per frame
    void Update()
    {
        if (trans)
        {
            rate += Time.deltaTime * 3.0f;
            Transform transform = gos[0].transform.GetChild(0);

            //transform.position = Vector3.Lerp(transform.position, target.transform.position, rate);

            transform.position = new Vector3(transform.position.x + 10, transform.position.y) ;// = target.transform.position;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            GameObject go = Instantiate(partymember);
            gos.Add(go);
            go.transform.parent = this.transform;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            trans = true;
            rate = 0;
        }


        if (rate >= 1)
        {
            rate = 0.0f;
            trans = false;
        }
    }
}

