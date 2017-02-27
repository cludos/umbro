using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
    public Material lit, unlit;
    private Renderer r;

    public void Start() {
        r = GetComponent<Renderer>();
    }

    public void SetLight(bool light) {
        r.material = light ? lit : unlit;
    }
}
