using UnityEngine;
using UnityEngine.UI;
public class PlayerStateBar: MonoBehaviour
{
    public Image healthImage;
    public void OnHealthChange(float persentage)
    {
        healthImage.fillAmount = persentage;
    }
}
