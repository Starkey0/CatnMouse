using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

    public HitBox hitbox;
    private static Rect Window;
    private string message;

	// Use this for initialization
	void Start () {
        Window = new Rect(20, 20, 120, 50);
        
    }
    void OnGUI() {
        Window = GUI.Window(0, Window, DoMyWindow, "My window");
    }
    void DoMyWindow (int windowID){
        if (GUI.Button(new Rect(10, 20, 100, 20), message))
            print("Got a click");
    }
	
	// Update is called once per frame
	void Update () {
        if (hitbox.getHit()) {
            message = "Cat wins";
            Time.timeScale = 0;
        }
        
	}
}
