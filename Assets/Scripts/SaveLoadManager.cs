using UnityEngine;
using System.Collections;

public class SaveLoadManager : MonoBehaviour {

	public int numberDiscs = 2;
	public int [] bestMoves = new int[10];
	
	//untuk save data pada playerprefs
	public void saveData(){
		PlayerPrefs.SetInt("numberDiscs",numberDiscs);
		for(int i=0; i<10; i++){
			PlayerPrefs.SetInt("bestMoves"+i,bestMoves[i]);
		}
		PlayerPrefs.Save();
	}
	
	//untuk load data pada playerprefs
	public void loadData(){
		if(!PlayerPrefs.HasKey("numberDiscs")){
			saveData();
		}else{
			numberDiscs = PlayerPrefs.GetInt("numberDiscs");
			for(int i=0; i<10; i++){
				bestMoves[i] = PlayerPrefs.GetInt("bestMoves"+i);
			}
		}
	}
	//inisialisasi array pada best moves
	public void initializationArray(){
		for(int i=0; i<10; i++){
			bestMoves[i] = 0;
		}
	}
	//untuk reset data
	public void clearData(){
		PlayerPrefs.DeleteAll();
	}
	void Start () {
		initializationArray();
		loadData();
	}
}