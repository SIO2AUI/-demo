using UnityEngine;

public class SwordAnimationsController : MonoBehaviour
{
    public GameObject swordLight1;
    public GameObject swordLight2;
    public GameObject swordLight3;
    public void ShowSlash1()
    {
        swordLight1.SetActive(true);
        swordLight1.GetComponent<Animator>().Play("SwordLight", 0, 0f);
    }
    public void HideSlash1()
    {
        swordLight1.SetActive(false);

    }

    public void ShowSlash2()
    {
        swordLight2.SetActive(true);
        swordLight2.GetComponent<Animator>().Play("SwordLight", 0, 0f);
    }
    public void HideSlash2()
    {
        swordLight2.SetActive(false);

    }
    public void ShowSlash3()
    {
        swordLight3.SetActive(true);
        swordLight3.GetComponent<Animator>().Play("SwordLight", 0, 0f);
    }
    public void HideSlash3()
    {
        swordLight3.SetActive(false);

    }
}
