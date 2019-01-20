using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

	//ボールが見える可能性のあるz軸の最大値
	private float visiblePosZ = -6.5f;

	//ゲームオーバを表示するテキスト
	private GameObject gameoverText;

	//スコアを表示するテキスト
	private GameObject scoreText;

	//得点
	private int score = 0;

	// Use this for initialization
	void Start () {
		//シーン中のGameOverTextオブジェクトを取得
		this.gameoverText = GameObject.Find("GameOverText");

		//シーン中のScoreTextを取得
		this.scoreText = GameObject.Find ("ScoreText");
		
	}
	
	// Update is called once per frame
	void Update () {
		//ボールが画面外に出た場合
		if (this.transform.position.z < this.visiblePosZ) {
			//GameoverTextにゲームオーバを表示
			this.gameoverText.GetComponent<Text> ().text = "Game Over";
		}
	}

	//他のオブジェクトと接触した場合の処理
	void OnCollisionEnter(Collision other) {

		//小さい星に衝突した場合
		if (other.gameObject.tag == "SmallStarTag") {

			//スコアを加算
			this.score += 10;

			//ScoreText獲得した点数を表示
			this.scoreText.GetComponent<Text> ().text = " Score " + this.score + "pt";

		}

		//大きい星に衝突した場合	
		if (other.gameObject.tag == "LargeStarTag") {

			//スコアを加算
			this.score += 20;

			//ScoreText獲得した点数を表示
			this.scoreText.GetComponent<Text> ().text = "Score " + this.score + "pt";

		}
	}
}
