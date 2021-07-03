using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIManager : MonoBehaviour {

	public Text textNumberDiscs;
	public Text textNumberMoves;
	public Text textBestMoves;
	public Text textResultTotalMoves;
	private int numberDiscs;
	private int numberMoves;
	public SaveLoadManager slm;
	public GameObject confirmExit;
	public GameObject clearedGameObject;
	public GameObject newBestText;
	private bool isPlay;
	
	public void SetIsPlay(bool isPlay2){
		this.isPlay = isPlay2;
	}
	public bool GetIsPlay(){
		return this.isPlay;
	}
	
	// Use this for initialization
	void Start () {
		slm.loadData();
		isPlay = true;
		//validasi sesuai dengan scene yang sedang di-load
		if(Application.loadedLevelName == "SelectNumberDiscs"){
			numberDiscs = slm.numberDiscs;
			textNumberDiscs.text = ""+numberDiscs;
		}else if(Application.loadedLevelName == "hanoiTower"){
			numberMoves = 0;
			textNumberMoves.text = "Moves: "+numberMoves;
			if(slm.bestMoves[slm.numberDiscs] == 0){
				textBestMoves.text = "Best Moves: -";
			}else{
				textBestMoves.text = "Best Moves: "+slm.bestMoves[slm.numberDiscs];
			}
		}
		Camera.main.aspect = 1980f / 1080f;
	}
	//untuk menunjukan window clear
	public void cleared(){
		clearedGameObject.SetActive(true);
		if(slm.bestMoves[slm.numberDiscs] == 0 || numberMoves < slm.bestMoves[slm.numberDiscs]){
			newBestText.SetActive(true);
			slm.bestMoves[slm.numberDiscs] = numberMoves;
			slm.saveData();
		}else{
			newBestText.SetActive(false);
		}
		textResultTotalMoves.text = "Total Moves: "+numberMoves;
		
	}
	//untuk restart game
	public void RestartGame(){
		Application.LoadLevel("hanoiTower");
	}
	//untuk menambah counter move
	public void addMove(){
		numberMoves++;
		textNumberMoves.text = "Moves: "+numberMoves;
	}
	
	//untuk kembali ke mainmenu
	public void backToMainMenu(){
		isPlay = false;
		confirmExit.SetActive(true);
	}
	
	//untuk mereset record best move
	public void resetRecord(){
		slm.clearData();
	}
	
	//ketika tombol no diklik
	public void noBackToMainMenu(){
		isPlay = true;
		confirmExit.SetActive(false);
	}
	
	//ketika tombol yes diklik
	public void yesBackToMainMenu(){
		Application.LoadLevel("mainMenu");
	}
	
	//untuk masuk ke scene pemilihan jumlah discs
	public void startGame(){
		Application.LoadLevel("SelectNumberDiscs");
	}
	
	//untuk menambah jumlah discs (maximal 8)
	public void upNumberDiscs(){
		if(numberDiscs < 8){
			numberDiscs++;
			textNumberDiscs.text = ""+numberDiscs;
		}
	}
	
	//untuk mengurangi jumlah discs (minimal 2)
	public void downNumberDiscs(){
		if(numberDiscs > 2){
			numberDiscs--;
			textNumberDiscs.text = ""+numberDiscs;
		}
	}
	
	//untuk masuk ke scene play game hanoi tower
	public void playGame(){
		slm.numberDiscs = numberDiscs;
		slm.saveData();
		Application.LoadLevel("hanoiTower");
	}
	
	//keluar dari aplikasi
	public void exitGame(){
		Application.Quit();
	}
}
