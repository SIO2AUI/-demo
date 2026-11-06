using UnityEngine;

public class SwordAnimationsController : MonoBehaviour
{
    public GameObject swordLight;
    public void ShowSlash()
    {
        swordLight.SetActive(true);
        swordLight.GetComponent<Animator>().Play("SwordLight", 0, 0f);
    }
    public void HideSlash()
    {
        swordLight.SetActive(false);

    }
}
