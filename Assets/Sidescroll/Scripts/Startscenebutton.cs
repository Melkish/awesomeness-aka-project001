using UnityEngine;
using System.Collections;

public class Startscenebutton : MonoBehaviour {

	public void Startlevel(int level){
		Application.LoadLevel (level);
	}
	public void Endgame(){
		Application.Quit ();
	}
}
