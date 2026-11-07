using UnityEngine;
using UnityEngine.UI;
public class HealthP : MonoBehaviour
{
    public Image image;
    public Character character;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = character.percentageHealth;
    }
}
