using UnityEngine;

public class CharacterStats : MonoBehaviour {
    
    public enum ExternalName {
        HEALTH,
        STAMINA,
        MANA,
        ENAMES
    };

    public enum InternalName {
        DAMAGE,
        DEFENCE,
        INAMES
    }
    
    // the external stats of the characer (eg health, stamina)
    [System.Serializable]
    public struct ExternalStat {
        public ExternalName characterStat;
        public float current;
        public float maximum;
    }

    // the internal stats of the character (eg strength, intelligence)
    [System.Serializable]
    public struct InternalStat {
        public InternalName characterStat;
        public float current;
    }

    public ExternalStat[] m_externalStats;
    public InternalStat[] m_internalStats;
    
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.A)) {
            Damage(ExternalName.HEALTH, 10);
        }
	}

    float CalculateDamage(float damage) {
        // Place any stats for calculating damage here
        InternalStat internalStat1 = GetIntStat(InternalName.DEFENCE);

        // This is where the damage calculation will take place
        damage = damage - internalStat1.current;
        
        // to avoid healing the target with an attack, do not delete this
        if (damage > 0) {
            return damage;
        } else {
            return 0;
        }
    }

    void Damage(ExternalName listIndex, float damage) {
        ExternalStat extTemp = GetExtStat(listIndex);

        extTemp.current = extTemp.current - CalculateDamage(damage);
        
        m_externalStats[(int)ExternalName.HEALTH] = extTemp;
    } 

    public ExternalStat GetExtStat(ExternalName name) {
        return m_externalStats[(int)name];
    }
    InternalStat GetIntStat(InternalName name) {
        return m_internalStats[(int)name];
    }
}
