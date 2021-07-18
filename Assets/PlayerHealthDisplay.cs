using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthDisplay : MonoBehaviour
{
    public Player targetPlayer;
    public List<Image> stockImages;

    private void Update()
    {
        ManageStockImages(targetPlayer.stock);
    }

    private void ManageStockImages(int i)
    {
        int index = 0;
        foreach (var image in stockImages)
        {
            if (index < i)
            {
                image.enabled = true;
            }
            else
            {
                image.enabled = false;
            }
            index++;
        }
    }
}
