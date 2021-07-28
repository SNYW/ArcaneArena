using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthDisplay : MonoBehaviour
{
    public List<Image> stockImages;

    public void ManageStockImages(int i)
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
