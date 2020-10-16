using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextClamp : MonoBehaviour {

    [SerializeField]
    GameObject textPrefab;


    // Start is called before the first frame update
    void Start() {

     //   Text tempTextBox = Instantiate(textPrefab, healthText.transform.position, transform.rotation) as Text;
        //Parent to the panel
      //  tempTextBox.transform.SetParent(C, false);
        //Set the text box's text element font size and style:
     //   tempTextBox.fontSize = defaultFontSize;
        //Set the text box's text element to the current textToDisplay:
     //   tempTextBox.text = textToDisplay;
    }

    // Update is called once per frame
    void Update()
    {
    //    Vector2 healthPOS = Camera.main.WorldToScreenPoint(this.transform.position);
     //   healthText.transform.position = healthPOS;
    }
}