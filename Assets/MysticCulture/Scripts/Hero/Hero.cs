using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : CharacterBase
{
    // Start is called before the first frame update
    void Start()
    {
        this.setCurrentHp(this.getHpMax());
        this.setCurrentMana(this.getManaMax());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
