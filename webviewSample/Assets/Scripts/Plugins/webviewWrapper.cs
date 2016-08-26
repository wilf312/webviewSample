using UnityEngine;
using System.Collections;

public class webviewWrapper : MonoBehaviour {

	// 初期読み込みURL
	private string url = "https://www.google.co.jp/#q=nogty";
	WebViewObject webViewObject;

	// Use this for initialization
	void Start () {

		// プラグインの読み込み
		webViewObject = (new GameObject("WebViewObject")).AddComponent<WebViewObject>();

		// インスタンス生成
		webViewObject.Init(
			// JSコールバック
			cb: (msg) =>
			{
				Debug.Log(string.Format("CallFromJS[{0}]", msg));
//				status.text = msg;
//				status.GetComponent<Animation>().Play();
			},
			// エラーコールバック
			err: (msg) =>
			{
				Debug.Log(string.Format("CallOnError[{0}]", msg));
//				status.text = msg;
//				status.GetComponent<Animation>().Play();
			},
			// ロード時コールバック
			ld: (msg) =>
			{
				Debug.Log(string.Format("CallOnLoaded[{0}]", msg));
			},
			// iPhone webkit webview で起動
			enableWKWebView: true);


		// 全画面描画
		// webViewObject.SetMargins (left, top, right, bottom);
		webViewObject.SetMargins(0, 0, 0, 0);

		// 描画開始
		webViewObject.SetVisibility(true);

		// URLの読み込み開始
		webViewObject.LoadURL(url);
	}
}
