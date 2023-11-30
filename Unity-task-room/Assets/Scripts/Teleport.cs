using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Color inactiveColor = new Color(0.5f, 0.5f, 0.5f);
    [SerializeField] private Color activeColor = new Color(1f, 1f, 1f);
    [SerializeField] private GameObject player;
    private float timer = 0f;
    bool colorChanging = false;
    private MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.color = inactiveColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (colorChanging)
        {
            meshRenderer.material.color = Color.Lerp(meshRenderer.material.color, activeColor, Time.deltaTime * 2);
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

    public void OnPointerEnter()
    {
        // IsGazedAt(true);
        colorChanging = true;
    }

    /// <summary>
    /// This method is called by the Main Camera when it stops gazing at this GameObject.
    /// </summary>
    public void OnPointerExit()
    {
        // IsGazedAt(false);
        colorChanging = false;
    }
    void IsGazedAt(bool gazedAt)
    {
        meshRenderer.material.color = gazedAt ? activeColor : inactiveColor;
    }
}
