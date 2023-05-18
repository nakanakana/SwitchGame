using UnityEngine;
using UnityEngine.UI;

public class DarkScreen : MonoBehaviour
{
    public Image darkImage; // 画像を表示するためのImageコンポーネント
    public Sprite darkSprite; // 表示する画像

    private void Start()
    {
        // 初期状態では画像を非表示にする
        darkImage.enabled = false;
    }

    // 暗転開始時に呼び出す関数
    public void StartDark()
    {
        // 画像を表示する
        darkImage.sprite = darkSprite;
        darkImage.enabled = true;

        // カメラの描画範囲をフルスクリーンにする
        Camera.main.rect = new Rect(0, 0, 1, 1);
    }

    // 暗転終了時に呼び出す関数
    public void EndDark()
    {
        // 画像を非表示にする
        darkImage.enabled = false;

        // カメラの描画範囲を元に戻す
        Camera.main.rect = new Rect(0, 0, 0.5f, 0.5f);
    }
}