using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCycle : MonoBehaviour
{
    public Color[] colors;
    public Color currentColor;
    public Color currentEmission;

    public GameObject bullet;
    private int playerIndex;
    private Material bulletMat;
    
    void Start()
    {
        bulletMat = bullet.GetComponent<MeshRenderer>().sharedMaterial;
        playerIndex = 0;

        PlayerChange(bulletMat);
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PlayerChange(bulletMat);
        }
    }

    private void PlayerChange(Material mat)
    {
        mat.SetColor("_BaseColor", colors[playerIndex]);
        mat.SetColor("_EmissionColor", colors[playerIndex] * Mathf.LinearToGammaSpace(2f));

        if(playerIndex >= 2)
        {
            playerIndex = 0;
        }
        else
        {
            playerIndex++;
        }
    }
}
