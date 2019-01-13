using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    private Hero hero;
    private Text txt_hp;
    private Text txt_mana;
    private PhotonView photon;

    // Start is called before the first frame update
    void Start()
    {
        hero = this.GetComponent<Hero>();
        txt_hp = GameObject.Find("txt_hero_hp_value").GetComponent<Text>();
        txt_mana = GameObject.Find("txt_hero_mana_value").GetComponent<Text>();
        photon = this.GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (photon.isMine)
        {
            txt_hp.text = hero.getCurrentHp().ToString();
            txt_mana.text = hero.getCurrentMana().ToString();
        }  
    }
}
