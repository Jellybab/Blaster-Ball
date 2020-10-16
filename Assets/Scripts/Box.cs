using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Box : MonoBehaviour
{
    private GameObject textGO;
    private Text text;
    [SerializeField]
    private int _health;
    [SerializeField]

    private void Start() {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag != "Enemy") {
            int damage = 1;
            if (collision.gameObject.tag == "Ball") {
                damage = collision.gameObject.GetComponent<Ball>().GetDamage();
            } else if (collision.gameObject.tag == "Player") {
                damage = 1;
            }
            Health -= damage;
            Game_Controller.GC.AwardCoins(1);
            if (Health >= 0) {
                UpdateHealthDisplay();
            } else {
                Destroy(this);
            }
        }
    }

    private void OnDestroy() {
        BoxController.BXC.currentBoxes.Remove(this.gameObject);
        Destroy(textGO);
    }

    void UpdateHealthDisplay() {
        text.text = Health.ToString();
        if (Health <= 0) {
            Destroy(this.gameObject);
        }
    }

    public void CreateHealthText(int Health, GameObject Text) {
        this.Health = Health;
        textGO = Text;
        text = textGO.gameObject.GetComponent<Text>();
        UpdateHealthDisplay();
    }

    public int Health {
        get { return _health; }
        set { _health = value; }
    }
}
