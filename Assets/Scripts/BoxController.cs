using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public static BoxController BXC;

    [SerializeField]
    private GameObject boxgo = null;
    [SerializeField]
    private GameObject textPrefab = null;
    [SerializeField]
    private Canvas canvas = null;

    //box info
    private readonly float boxWidth = 0.6f;
    private readonly float boxHeight = 0.28f;
    //screen position(should be)
    private readonly float screenHeightBound = 4.06f;
    private readonly float screenWidthBound = 2.1f;


    private readonly int row = 27;
    private readonly int column = 8;

    //list for loading the next level
    public List<BoxData> levelBoxData = new List<BoxData>();
    //list for boxes that are currently live
    public List<GameObject> currentBoxes = new List<GameObject>();

    private void Awake() {
        if (BXC == null) {
            DontDestroyOnLoad(gameObject);
            BXC = this;
        } else if (BXC != this) {
            Destroy(gameObject);
        }
    }

    void NewBox(int x,int y) {
        BoxData boxData = new BoxData {
            x = -screenWidthBound + (boxWidth * x),
            y = -screenHeightBound + (boxHeight * (y + 3)),
            health = 10
        };
        levelBoxData.Add(boxData);

    }

    public void NewBoxes() {
        for (int y = 0; y < row; y++) {
            for (int x = 0; x < column; x++) {
                NewBox(x, y);
            }
        }
    }

    public void LoadBoxes() {
        foreach (BoxData boxData in levelBoxData) {

            GameObject BoxGO = Instantiate(boxgo, new Vector2(boxData.x, boxData.y), Quaternion.identity);
            currentBoxes.Add(BoxGO);
            GameObject BoxTextGO = Instantiate(textPrefab, BoxGO.gameObject.transform.position, transform.rotation);
            BoxTextGO.transform.SetParent(canvas.transform, false);
            BoxTextGO.transform.position = BoxGO.gameObject.transform.position;
            Box Boxcontroller = BoxGO.GetComponent<Box>();
            Boxcontroller.CreateHealthText(boxData.health, BoxTextGO);

        }

    }

    public void SaveBoxes() {
        levelBoxData.Clear();
        Debug.Log("Saving Boxes");
        foreach (GameObject box in currentBoxes) {

            BoxData boxData = new BoxData {
                x = box.transform.position.x,
                y = box.transform.position.y,
                health = box.GetComponent<Box>().Health
            };
            levelBoxData.Add(boxData);
        }
    }
}

[System.Serializable]
public class BoxData
{
    public float x, y;
    public int health;
}
