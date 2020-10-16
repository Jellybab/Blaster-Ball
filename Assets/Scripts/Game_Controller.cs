using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Game_Controller : MonoBehaviour
{
    public static Game_Controller GC;
    private static BallController BC;
    private static BoxController BXC;


    private readonly int health = 0;
    private int level = 1;
    [SerializeField]
    private int coins = 100;
    private bool loadingNextLevel = false;

    // Start is called before the first frame update

    private void Awake() {
        if (GC == null) {
            DontDestroyOnLoad(gameObject);
            GC = this;
        } else if (GC != this) {
            Destroy(gameObject);
        }

    }

    void Start() {
        BC = this.gameObject.GetComponent<BallController>();
        BXC = this.gameObject.GetComponent<BoxController>();
        SavingScript.SS.Load();
        LoadData();
    }

    private void Update() {
        if (BXC.currentBoxes.Count <= 0 && !loadingNextLevel) {
            loadingNextLevel = true;
            SaveData();
            BXC.NewBoxes();
            BXC.LoadBoxes();
            loadingNextLevel = false;
        }
    }


    public void AwardCoins(int amount) {
        coins += amount;
    }

    public void SpeedUpgrade(int ballTypeId) { 
        
    }


    //----------------------------------------------------------------------------------------------Load Data---------------------------------------------------------------------------//

    private void LoadData() {
        BC.LoadBalls();
        BXC.LoadBoxes();
    }


    //-----------------------------------------------------------------------------------------------End of Loading Data-----------------------------------------------------------//

    //---------------------------------------------------------------------------------------------Saving Data---------------------------------------------------------------------//
    public void SaveData() {

        BXC.SaveBoxes();
        BC.SaveBalls();
    }



}
//----------------------------------------------------------------------------------------------End OF Saving---------------------------------------------------------------------------//

//------------------------------------------------------------------------------------------Class for Data-----------------------------------------------------------------------------//


[System.Serializable]
public class BaseUpgrades {
    public int damage;
    public int speed;
    public int splitLife;
    public int electricalDamage;
    public int electricalRange;
}

[System.Serializable]
public class UserInformation {
    public int coins;
    public float damageMultipler;
    public float moneyMultipler;

}



