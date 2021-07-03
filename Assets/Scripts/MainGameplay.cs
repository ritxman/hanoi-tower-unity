using UnityEngine;
using System.Collections;

public class MainGameplay : MonoBehaviour {
	
	public GameObject [] discs = new GameObject[9];
	public GUIManager gm;
	private bool gameOver;
	//untuk menampung discs di masing masing pole
	private GameObject [] discsPole1 = new GameObject[9];
	private GameObject [] discsPole2 = new GameObject[9];
	private GameObject [] discsPole3 = new GameObject[9];
	private float posisiBawah;
	private int totalDiscs;
	private bool flagCanPlaced;
	private int counterPole1;
	private int counterPole2;
	private int counterPole3;
	public Color colorUnselected;
	
	public bool GetGameOver(){
		return this.gameOver;
	}
	public void SetGameOver(bool gameOver2){
		this.gameOver = gameOver2;
	}
	// Use this for initialization
	void Start () {
		colorUnselected.r = 255f;
		colorUnselected.g = 255f;
		colorUnselected.b = 255f;
		colorUnselected.a = 1f;
		flagCanPlaced = true;
		totalDiscs = gm.slm.numberDiscs;
		posisiBawah = -4.39f;
		//selisih = 0.57f
		counterPole1 = 0;
		counterPole2 = 0;
		counterPole3 = 0;
		gameOver = false;
		//inisialisasi discs
		for(int i=totalDiscs-1; i>=0; i--){
			discs[i].transform.localPosition = new Vector3(discs[i].GetComponent<Discs>().lokasiX,posisiBawah,discs[i].transform.localPosition.z);
			discsPole1[counterPole1] = discs[i];
			posisiBawah = posisiBawah + 0.55f;
			counterPole1++;
		}
		discs[0].GetComponent<Discs>().isTop = true;
	}
	//melakukan check pada pole 1
	public void checkPole1(int indexDiscs){
		if(indexDiscs != 0){
			//jika pole masih kosong
			if(counterPole1 == 0){
				if(discs[indexDiscs-1].GetComponent<Discs>().posisiPole == 1){
					discsPole1[counterPole1-1] = null;
					counterPole1--;
					if(counterPole1>0)discsPole1[counterPole1-1].GetComponent<Discs>().isTop = true;
				}else if(discs[indexDiscs-1].GetComponent<Discs>().posisiPole == 2){
					gm.addMove();
					discsPole2[counterPole2-1] = null;
					counterPole2--;
					if(counterPole2>0)discsPole2[counterPole2-1].GetComponent<Discs>().isTop = true;
				}else if(discs[indexDiscs-1].GetComponent<Discs>().posisiPole == 3){
					gm.addMove();
					discsPole3[counterPole3-1] = null;
					counterPole3--;
					if(counterPole3>0)discsPole3[counterPole3-1].GetComponent<Discs>().isTop = true;
				}
				posisiBawah = -4.39f;
				discs[indexDiscs-1].GetComponent<SpriteRenderer>().color = colorUnselected;
				discs[indexDiscs-1].GetComponent<Discs>().isTop = true;
				discs[indexDiscs-1].transform.localPosition = new Vector3(discs[indexDiscs-1].GetComponent<Discs>().lokasiX,posisiBawah,discs[indexDiscs-1].transform.localPosition.z);
				discs[indexDiscs-1].GetComponent<Discs>().posisiPole = 1;
				discs[indexDiscs-1].GetComponent<Discs>().isSelected = false;
				discsPole1[counterPole1] = discs[indexDiscs-1];
				counterPole1++;
			}
			//jika pole sudah berisi disc, maka lakukan check bobot disc
			else{
				flagCanPlaced = true;
				if(discsPole1[counterPole1-1].GetComponent<Discs>().bobot < discs[indexDiscs-1].GetComponent<Discs>().bobot){
					discs[indexDiscs-1].GetComponent<SpriteRenderer>().color = colorUnselected;
					discs[indexDiscs-1].GetComponent<Discs>().isSelected = false;
					discs[indexDiscs-1].GetComponent<Discs>().isTop = true;
					flagCanPlaced = false;
				}
				if(flagCanPlaced == true){
					if(discs[indexDiscs-1].GetComponent<Discs>().posisiPole == 1){
						discsPole1[counterPole1-1] = null;
						counterPole1--;
						if(counterPole1>0)discsPole1[counterPole1-1].GetComponent<Discs>().isTop = true;
					}else if(discs[indexDiscs-1].GetComponent<Discs>().posisiPole == 2){
						gm.addMove();
						discsPole2[counterPole2-1] = null;
						counterPole2--;
						if(counterPole2>0)discsPole2[counterPole2-1].GetComponent<Discs>().isTop = true;
					}else if(discs[indexDiscs-1].GetComponent<Discs>().posisiPole == 3){
						gm.addMove();
						discsPole3[counterPole3-1] = null;
						counterPole3--;
						if(counterPole3>0)discsPole3[counterPole3-1].GetComponent<Discs>().isTop = true;
					}
					posisiBawah = -4.39f;
					for(int i=0; i<counterPole1; i++){
						posisiBawah = posisiBawah + 0.55f;
					}
					discs[indexDiscs-1].GetComponent<SpriteRenderer>().color = colorUnselected;
					discs[indexDiscs-1].GetComponent<Discs>().isTop = true;
					discs[indexDiscs-1].transform.localPosition = new Vector3(discs[indexDiscs-1].GetComponent<Discs>().lokasiX,posisiBawah,discs[indexDiscs-1].transform.localPosition.z);
					discs[indexDiscs-1].GetComponent<Discs>().posisiPole = 1;
					discs[indexDiscs-1].GetComponent<Discs>().isSelected = false;
					discsPole1[counterPole1] = discs[indexDiscs-1];
					if(counterPole1>0)discsPole1[counterPole1-1].GetComponent<Discs>().isTop = false;
					counterPole1++;
				}
			}
		}
	}
	//melakukan check pada pole 2
	public void checkPole2(int indexDiscs){
		if(indexDiscs != 0){
			//jika pole 2 masih kosong
			if(counterPole2 == 0){
				if(discs[indexDiscs-1].GetComponent<Discs>().posisiPole == 1){
					gm.addMove();
					discsPole1[counterPole1-1] = null;
					counterPole1--;
					if(counterPole1>0)discsPole1[counterPole1-1].GetComponent<Discs>().isTop = true;
				}else if(discs[indexDiscs-1].GetComponent<Discs>().posisiPole == 2){
					discsPole2[counterPole2-1] = null;
					counterPole2--;
					if(counterPole2>0)discsPole2[counterPole2-1].GetComponent<Discs>().isTop = true;
				}else if(discs[indexDiscs-1].GetComponent<Discs>().posisiPole == 3){
					gm.addMove();
					discsPole3[counterPole3-1] = null;
					counterPole3--;
					if(counterPole3>0)discsPole3[counterPole3-1].GetComponent<Discs>().isTop = true;
				}
				posisiBawah = -4.39f;
				discs[indexDiscs-1].GetComponent<SpriteRenderer>().color = colorUnselected;
				discs[indexDiscs-1].GetComponent<Discs>().isTop = true;
				discs[indexDiscs-1].transform.localPosition = new Vector3(discs[indexDiscs-1].GetComponent<Discs>().lokasiX+6,posisiBawah,discs[indexDiscs-1].transform.localPosition.z);
				discs[indexDiscs-1].GetComponent<Discs>().posisiPole = 2;
				discs[indexDiscs-1].GetComponent<Discs>().isSelected = false;
				discsPole2[counterPole2] = discs[indexDiscs-1];
				counterPole2++;
			}
			//jika pole sudah berisi disc, maka lakukan check bobot disc
			else{
				flagCanPlaced = true;
				if(discsPole2[counterPole2-1].GetComponent<Discs>().bobot < discs[indexDiscs-1].GetComponent<Discs>().bobot){
					discs[indexDiscs-1].GetComponent<SpriteRenderer>().color = colorUnselected;
					discs[indexDiscs-1].GetComponent<Discs>().isSelected = false;
					discs[indexDiscs-1].GetComponent<Discs>().isTop = true;
					flagCanPlaced = false;
				}
				if(flagCanPlaced == true){
					if(discs[indexDiscs-1].GetComponent<Discs>().posisiPole == 1){
						gm.addMove();
						discsPole1[counterPole1-1] = null;
						counterPole1--;
						if(counterPole1>0)discsPole1[counterPole1-1].GetComponent<Discs>().isTop = true;
					}else if(discs[indexDiscs-1].GetComponent<Discs>().posisiPole == 2){
						discsPole2[counterPole2-1] = null;
						counterPole2--;
						if(counterPole2>0)discsPole2[counterPole2-1].GetComponent<Discs>().isTop = true;
					}else if(discs[indexDiscs-1].GetComponent<Discs>().posisiPole == 3){
						gm.addMove();
						discsPole3[counterPole3-1] = null;
						counterPole3--;
						if(counterPole3>0)discsPole3[counterPole3-1].GetComponent<Discs>().isTop = true;
					}
					posisiBawah = -4.39f;
					for(int i=0; i<counterPole2; i++){
						posisiBawah = posisiBawah + 0.55f;
					}
					discs[indexDiscs-1].GetComponent<SpriteRenderer>().color = colorUnselected;
					discs[indexDiscs-1].GetComponent<Discs>().isTop = true;
					discs[indexDiscs-1].transform.localPosition = new Vector3(discs[indexDiscs-1].GetComponent<Discs>().lokasiX+6,posisiBawah,discs[indexDiscs-1].transform.localPosition.z);
					discs[indexDiscs-1].GetComponent<Discs>().posisiPole = 2;
					discs[indexDiscs-1].GetComponent<Discs>().isSelected = false;
					discsPole2[counterPole2] = discs[indexDiscs-1];
					if(counterPole2>0)discsPole2[counterPole2-1].GetComponent<Discs>().isTop = false;
					counterPole2++;
				}
			}
		}
	}
	//melakukan check pada pole 3
	public void checkPole3(int indexDiscs){
		if(indexDiscs != 0){
			//jika pole 3 masih kosong
			if(counterPole3 == 0){
				if(discs[indexDiscs-1].GetComponent<Discs>().posisiPole == 1){
					gm.addMove();
					discsPole1[counterPole1-1] = null;
					counterPole1--;
					if(counterPole1>0)discsPole1[counterPole1-1].GetComponent<Discs>().isTop = true;
				}else if(discs[indexDiscs-1].GetComponent<Discs>().posisiPole == 2){
					gm.addMove();
					discsPole2[counterPole2-1] = null;
					counterPole2--;
					if(counterPole2>0)discsPole2[counterPole2-1].GetComponent<Discs>().isTop = true;
				}else if(discs[indexDiscs-1].GetComponent<Discs>().posisiPole == 3){
					discsPole3[counterPole3-1] = null;
					counterPole3--;
					if(counterPole3>0)discsPole3[counterPole3-1].GetComponent<Discs>().isTop = true;
				}
				posisiBawah = -4.39f;
				discs[indexDiscs-1].GetComponent<SpriteRenderer>().color = colorUnselected;
				discs[indexDiscs-1].GetComponent<Discs>().isTop = true;
				discs[indexDiscs-1].transform.localPosition = new Vector3(discs[indexDiscs-1].GetComponent<Discs>().lokasiX+12,posisiBawah,discs[indexDiscs-1].transform.localPosition.z);
				discs[indexDiscs-1].GetComponent<Discs>().posisiPole = 3;
				discs[indexDiscs-1].GetComponent<Discs>().isSelected = false;
				discsPole3[counterPole3] = discs[indexDiscs-1];
				counterPole3++;
			}
			//jika pole sudah berisi disc, maka lakukan check bobot disc
			else{
				flagCanPlaced = true;
				if(discsPole3[counterPole3-1].GetComponent<Discs>().bobot < discs[indexDiscs-1].GetComponent<Discs>().bobot){
					discs[indexDiscs-1].GetComponent<SpriteRenderer>().color = colorUnselected;
					discs[indexDiscs-1].GetComponent<Discs>().isSelected = false;
					discs[indexDiscs-1].GetComponent<Discs>().isTop = true;
					flagCanPlaced = false;
				}
				if(flagCanPlaced == true){
					if(discs[indexDiscs-1].GetComponent<Discs>().posisiPole == 1){
						gm.addMove();
						discsPole1[counterPole1-1] = null;
						counterPole1--;
						if(counterPole1>0)discsPole1[counterPole1-1].GetComponent<Discs>().isTop = true;
					}else if(discs[indexDiscs-1].GetComponent<Discs>().posisiPole == 2){
						gm.addMove();
						discsPole2[counterPole2-1] = null;
						counterPole2--;
						if(counterPole2>0)discsPole2[counterPole2-1].GetComponent<Discs>().isTop = true;
					}else if(discs[indexDiscs-1].GetComponent<Discs>().posisiPole == 3){
						discsPole3[counterPole3-1] = null;
						counterPole3--;
						if(counterPole3>0)discsPole3[counterPole3-1].GetComponent<Discs>().isTop = true;
					}
					posisiBawah = -4.39f;
					for(int i=0; i<counterPole3; i++){
						posisiBawah = posisiBawah + 0.55f;
					}
					discs[indexDiscs-1].GetComponent<SpriteRenderer>().color = colorUnselected;
					discs[indexDiscs-1].GetComponent<Discs>().isTop = true;
					discs[indexDiscs-1].transform.localPosition = new Vector3(discs[indexDiscs-1].GetComponent<Discs>().lokasiX+12,posisiBawah,discs[indexDiscs-1].transform.localPosition.z);
					discs[indexDiscs-1].GetComponent<Discs>().posisiPole = 3;
					discs[indexDiscs-1].GetComponent<Discs>().isSelected = false;
					discsPole3[counterPole3] = discs[indexDiscs-1];
					if(counterPole3>0)discsPole3[counterPole3-1].GetComponent<Discs>().isTop = false;
					counterPole3++;
				}
			}
		}
		//game selesai, semua disc berada di pole paling kanan
		if(counterPole3 == totalDiscs){
			gameOver = true;
			gm.cleared();
		}
	}
}
