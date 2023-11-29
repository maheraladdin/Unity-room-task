using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private float timer = 0f;
    bool colorChanging = false;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (colorChanging)
        {
            timer += Time.deltaTime;
            if(timer > 1f)
            {
                player.transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
            }
        }
        else
        {
            timer = 0f;
            meshRenderer.material.color = Color.Lerp(meshRenderer.material.color, inactiveColor, Time.deltaTime * 2);
        }
    }
}
