using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusManager : MonoBehaviour
{
    public int bullets = 0;
    public int shield = 0;
    [SerializeField] private Weapon weapon;
    [SerializeField] private CharacterController player;
    [SerializeField] private Text text;

    private void GetRandomBonus()
	{
        int r = Random.Range(0, 2);
        switch (r)
		{
            case 0:
                bullets++;
                break;
            case 1:
                shield+=2;
                break;
        }
        text.text = "weapon x" + bullets + "\n shield x" + shield;
        UpdateWeapon();
	}
    public void Hurt()
	{
        if (shield > 0) shield--;
        else if (bullets > 0) bullets--;
        else this.gameObject.SendMessage("Death");
        text.text = "weapon x" + bullets + "\n shield x" + shield;
        UpdateWeapon();
    }
    private void UpdateWeapon()
	{
        player.weaponCount = bullets+1;
        if(bullets>3)
		{
            if (bullets == 4) player.rpm = 90f;
            else if (bullets == 5) player.rpm = 120f;
        }
        else player.rpm = 60f;
    }
}
