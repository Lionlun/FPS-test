using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Health health;

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = health.MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
	}

    void UpdateHealth()
    {
        slider.value = health.CurrentHealth;
    }
}
