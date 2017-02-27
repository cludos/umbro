using UnityEngine;
using UnityEngine.UI;

class Timer : MonoBehaviour {
    public Text text;
    public float time;

    public void Start() {
        text = GetComponent<Text>();
    }

    public void Update() {
        time -= Time.deltaTime;
        if (time < 0) {
            Board.Instance.LoseLevel();
        }

        int minutes = (int)time / 60;
        int seconds = (int)time % 60;
        text.text = "Time left: " + minutes + ":" + seconds.ToString("D2");
    }
}
