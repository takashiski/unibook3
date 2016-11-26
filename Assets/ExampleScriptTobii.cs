using UnityEngine;
using System.Collections;
using Tobii.EyeTracking;

[RequireComponent(typeof(GazeAware))]
[RequireComponent(typeof(AudioSource))]
public class ExampleScriptTobii : MonoBehaviour
{
    public GameObject explosion;//爆発プレハブ
    public GameObject sight;//照準画像（私はquadに適当な画像いれた）
    public AudioClip sightSE;//照準SE
    private GazeAware _gazeAware;
    private bool lockonFlag;
    private GameObject sightIns;
    private AudioSource audiosource;

    void Start()
    {
        _gazeAware = GetComponent<GazeAware>();
        lockonFlag = false;
        audiosource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (_gazeAware.HasGazeFocus)
        {
            //視線が当たった時にオブジェクトをちょっと大きくする
            this.transform.localScale = Vector3.one * 1.2f;
            //ボタンが押されていたら照準あてる
            if (Input.GetButton("Jump"))
            {
                if (!sightIns)
                {
                    audiosource.PlayOneShot(sightSE);
                    sightIns = Instantiate(sight) as GameObject;
                    sightIns.transform.parent = this.transform;
                    sightIns.transform.position = this.transform.position + (Vector3.forward * (-0.6f));
                    lockonFlag = true;
                }

            }
        }
        else
        {
            //視線が外れたら小さくする
            this.transform.localScale = Vector3.one;
        }
        //照準があたったオブジェクトかつボタンが離されたら爆破＆削除処理
        if(lockonFlag==true && Input.GetButtonUp("Jump"))
        {
            //transform.Rotate(Vector3.forward);
            Destroy(sightIns);
            GameObject obj = Instantiate(explosion) as GameObject;
            obj.transform.position = this.transform.position;
            Destroy(obj, 5);
            Destroy(this.gameObject);
        }


    }
}
