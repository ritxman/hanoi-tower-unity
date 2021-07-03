using UnityEngine;
using System.Collections;

public class RayCastingMouse : MonoBehaviour {

	Color colorSelected;
	public int indexDisc;
	public MainGameplay mgp;
	void Start(){
		//untuk melakukan set warna colorSelected dengan nilai alpha 0.5
		colorSelected.r = 255f;
		colorSelected.g = 255f;
		colorSelected.b = 255f;
		colorSelected.a = 0.5f;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			//melakukan raycasting koordinat x,y mouse
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			if(hit.collider != null && mgp.GetGameOver() == false){
				if(mgp.gm.GetIsPlay() == true){
					GameObject recipient = hit.collider.gameObject;
					if(recipient.tag == "disc"){
						if(recipient.GetComponent<Discs>().isTop == true){
							//ketika selected discs
							if(recipient.GetComponent<Discs>().isSelected == false){
								if(indexDisc != 0){
									GameObject.Find(""+indexDisc).GetComponent<SpriteRenderer>().color = mgp.colorUnselected;
									GameObject.Find(""+indexDisc).GetComponent<Discs>().isSelected = false;
								}
								indexDisc = recipient.GetComponent<Discs>().bobot;
								recipient.GetComponent<Discs>().isSelected = true;
								recipient.GetComponent<SpriteRenderer>().color = colorSelected;
							}
							//ketika unselected discs
							else if(recipient.GetComponent<Discs>().isSelected == true){
								indexDisc = 0;
								recipient.GetComponent<Discs>().isSelected = false;
								recipient.GetComponent<SpriteRenderer>().color = mgp.colorUnselected;
							}
						}
						//ketika memilih pole 1
					}else if(recipient.name == "tiang1"){
						mgp.checkPole1(indexDisc);
						indexDisc = 0;
						//ketika memilih pole 2
					}else if(recipient.name == "tiang2"){
						mgp.checkPole2(indexDisc);
						indexDisc = 0;
						//ketika memilih pole 3
					}else if(recipient.name == "tiang3"){
						mgp.checkPole3(indexDisc);
						indexDisc = 0;
					}
				}
			}
		}
	}
}
