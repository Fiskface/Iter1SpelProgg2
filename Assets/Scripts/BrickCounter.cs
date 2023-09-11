using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BrickCounter : MonoBehaviour
{
    private int bricksAlive = 0;

    public void BrickSpawned()
    {
        bricksAlive++;
    }
    
    public void BrickDestroyed()
    {
        bricksAlive--;
        CheckIfBricksAlive();
    }

    private void CheckIfBricksAlive()
    {
        if (bricksAlive <= 0)
        {
            foreach (Transform child in GameObject.Find("GameOverScreen").transform)
            {
                child.GameObject().SetActive(true);
            }
        }
    }
}
