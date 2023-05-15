using UnityEngine;
using UnityEngine.UI;

public class DarkScreen : MonoBehaviour
{
    public Image darkImage; // �摜��\�����邽�߂�Image�R���|�[�l���g
    public Sprite darkSprite; // �\������摜

    private void Start()
    {
        // ������Ԃł͉摜���\���ɂ���
        darkImage.enabled = false;
    }

    // �Ó]�J�n���ɌĂяo���֐�
    public void StartDark()
    {
        // �摜��\������
        darkImage.sprite = darkSprite;
        darkImage.enabled = true;

        // �J�����̕`��͈͂��t���X�N���[���ɂ���
        Camera.main.rect = new Rect(0, 0, 1, 1);
    }

    // �Ó]�I�����ɌĂяo���֐�
    public void EndDark()
    {
        // �摜���\���ɂ���
        darkImage.enabled = false;

        // �J�����̕`��͈͂����ɖ߂�
        Camera.main.rect = new Rect(0, 0, 0.5f, 0.5f);
    }
}