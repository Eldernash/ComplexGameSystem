using UnityEngine;
using UnityEngine.UI;

public class StatCard : MonoBehaviour {

    public CharacterStats characterStats;
    
    public CharacterStats.ExternalName affectedStat;

    private float currentValue;
    private float maxValue;
    private Image meter;

	// Use this for initialization
	void Start () {
        meter = gameObject.GetComponent<Image>();
        currentValue = characterStats.GetExtStat(affectedStat).current;
        maxValue = characterStats.GetExtStat(affectedStat).maximum;
    }
	
	// Update is called once per frame
	void Update () {
        currentValue = characterStats.GetExtStat(affectedStat).current;
        maxValue = characterStats.GetExtStat(affectedStat).maximum;
        meter.fillAmount = currentValue / maxValue;
	}
}
