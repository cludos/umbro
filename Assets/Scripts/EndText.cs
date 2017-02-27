using UnityEngine;
using UnityEngine.UI;

class EndText : MonoBehaviour {
    public Text text;

    public void Start() {
        text = GetComponent<Text>();
        text.text = PlayerPrefs.GetString("endtext");
    }
}
