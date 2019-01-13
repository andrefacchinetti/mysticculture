using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    //futuramente pegar os valores dos atributos no banco
    public int id; 
    public string nome;
    public int attack, magicAttack, hpMax, manaMax;
    private int currentHp, currentMana;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getAttack()
    {
        return this.attack;
    }

    public int getMagicAttack()
    {
        return this.magicAttack;
    }

    public int getHpMax()
    {
        return this.hpMax;
    }

    public int getManaMax()
    {
        return this.manaMax;
    }

    public float getMoveSpeed()
    {
        return this.moveSpeed;
    }

    public int getCurrentHp()
    {
        return this.currentHp;
    }

    public int getCurrentMana()
    {
       return this.currentMana;
    }

    public void setCurrentHp(int hp)
    {
        this.currentHp = hp;
    }

    public void setCurrentMana(int mana)
    {
        this.currentMana = mana;
    }
}
