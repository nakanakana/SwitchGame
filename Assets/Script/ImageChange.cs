using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChange : MonoBehaviour
{
    public Image image;
    private Sprite sprite;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneChange.instance.count == 0)
        {
            sprite = Resources.Load<Sprite>("0");
            image = this.GetComponent<Image>();
            image.sprite = sprite;
        }
        else if (SceneChange.instance.count == 1)
        {
            sprite = Resources.Load<Sprite>("1");
            image = this.GetComponent<Image>();
            image.sprite = sprite;
        }
        else if (SceneChange.instance.count == 2)
        {
            sprite = Resources.Load<Sprite>("2");
            image = this.GetComponent<Image>();
            image.sprite = sprite;
        }
        else if (SceneChange.instance.count == 3)
        {
            sprite = Resources.Load<Sprite>("3");
            image = this.GetComponent<Image>();
            image.sprite = sprite;
        }
        else if (SceneChange.instance.count == 4)
        {
            sprite = Resources.Load<Sprite>("4");
            image = this.GetComponent<Image>();
            image.sprite = sprite;
        }
        else if (SceneChange.instance.count == 5)
        {
            sprite = Resources.Load<Sprite>("5");
            image = this.GetComponent<Image>();
            image.sprite = sprite;
        }
        else if (SceneChange.instance.count == 6)
        {
            sprite = Resources.Load<Sprite>("6");
            image = this.GetComponent<Image>();
            image.sprite = sprite;
        }
        else if (SceneChange.instance.count == 7)
        {
            sprite = Resources.Load<Sprite>("7");
            image = this.GetComponent<Image>();
            image.sprite = sprite;
        }
        else if (SceneChange.instance.count == 8)
        {
            sprite = Resources.Load<Sprite>("8");
            image = this.GetComponent<Image>();
            image.sprite = sprite;
        }
        else if (SceneChange.instance.count == 9)
        {
            sprite = Resources.Load<Sprite>("9");
            image = this.GetComponent<Image>();
            image.sprite = sprite;
        }
        else if (SceneChange.instance.count == 10)
        {
            sprite = Resources.Load<Sprite>("0");
            image = this.GetComponent<Image>();
            image.sprite = sprite;
        }
        else if (SceneChange.instance.count == 11)
        {
            sprite = Resources.Load<Sprite>("1");
            image = this.GetComponent<Image>();
            image.sprite = sprite;
        }
        else if (SceneChange.instance.count == 12)
        {
            sprite = Resources.Load<Sprite>("2");
            image = this.GetComponent<Image>();
            image.sprite = sprite;
        }
        else if (SceneChange.instance.count == 13)
        {
            sprite = Resources.Load<Sprite>("3");
            image = this.GetComponent<Image>();
            image.sprite = sprite;
        }
        else if (SceneChange.instance.count == 14)
        {
            sprite = Resources.Load<Sprite>("4");
            image = this.GetComponent<Image>();
            image.sprite = sprite;
        }
        else if (SceneChange.instance.count == 15)
        {
            sprite = Resources.Load<Sprite>("5");
            image = this.GetComponent<Image>();
            image.sprite = sprite;
        }
        else if (SceneChange.instance.count == 16)
        {
            sprite = Resources.Load<Sprite>("6");
            image = this.GetComponent<Image>();
            image.sprite = sprite;
        }
    }

    //    //�\���ʒu
    //Vector3 init_pos;

    ////�\���֘A
    //private int point;      //�\������l
    //private float size = 1; //�\���T�C�Y

    //private static int dam_sort = 0;    //�����̕\����
    //private const int SORT_MAX = 30000;

    //// Start is called before the first frame update
    //void Start() {
    //    //������
    //    //�����ł̓e�X�g�p�ɃX�^�[�g�ŏ��������Ă��邯�ǁA������\�����������^�C�~���O�ŌĂяo���̂��x�^�[
    //    Init(125, new Vector3(0, 0, 0));

    //}
    //public void Init(int point, Vector3 pos)
    //{
    //    //�K�v�ȏ����i�[
    //    this.point = point;

    //    //�\���p�̃_���[�W�����
    //    CreateNum(point);

    //    init_pos = pos;

    //    //�\��������ԏ��
    //    GetComponent<SortingGroup>().sortingOrder = dam_sort;


    //    dam_sort++;
    //    if (dam_sort > SORT_MAX)
    //    {
    //        dam_sort = 0;
    //    }
    //}

    ////�`��p�̐��������
    //private void CreateNum(int point)
    //{

    //    //��������o��
    //    int digit = ChkDigit(point);

    //    //�����v���n�u��ǂݍ��ށA�e�X�g�p�̃t�H���_�ƃt�@�C����
    //    GameObject obj = LoadGObject("test", "pref_num_test");


    //    //���̕������I�u�W�F�N�g�����o�^���Ă���
    //    for (int i = 0; i < digit; i++)
    //    {

    //        GameObject numObj = Instantiate(obj) as GameObject;

    //        //�q���Ƃ��ēo�^
    //        numObj.transform.parent = transform;

    //        //���݃`�F�b�N���Ă��錅�̐���������o��
    //        int digNum = GetPointDigit(point, i + 1);

    //        //�|�C���g���琔����؂�ւ���
    //        numObj.GetComponent<NumCtrl>().ChangeSprite(digNum);

    //        //�T�C�Y���Q�b�g����
    //    float size_w = numObj.GetComponent<SpriteRenderer>().bounds.size.x;

    //    //�ʒu�����炷
    //    float ajs_x = size_w * i - (size_w * digit) / 2;
    //    Vector3 pos = new Vector3(numObj.transform.position.x - ajs_x, numObj.transform.position.y, numObj.transform.position.z);
    //    numObj.transform.position = pos;

    //    numObj = null;
    //    }
    //}

    ///**
    //* �����̌�����Ԃ�
    //* */
    //public static int ChkDigit(int num)
    //{

    //    //0�̏ꍇ1���Ƃ��ĕԂ�
    //    if (num == 0) return 1;

    //    //�ΐ��Ƃ����g���ĕԂ�
    //    return (num == 0) ? 1 : ((int)Mathf.Log10(num) + 1);

    //}
    ///**
    //* ���l�̒�����w�肵�����̒l��������
    //* */
    //public static int GetPointDigit(int num, int digit)
    //{

    //    int res = 0;
    //    int pow_dig = (int)Mathf.Pow(10, digit);
    //    if (digit == 1)
    //    {
    //        res = num - (num / pow_dig) * pow_dig;
    //    }
    //    else
    //    {
    //        res = (num - (num / pow_dig) * pow_dig) / (int)Mathf.Pow(10, (digit - 1));
    //    }

    //    return res;
    //}
    ///**
    //* �I�u�W�F�N�g��ǂݍ���
    //* ���\�[�X�t�H���_����ǂݍ���
    //* */
    //public static GameObject LoadGObject(string dir_name, string filename)
    //{

    //    GameObject obj;

    //    //���\�[�X����ǂݍ��ރp�^�[��
    //    obj = (GameObject)Resources.Load(dir_name + "/" + filename);

    //    return obj;

    //}
}

