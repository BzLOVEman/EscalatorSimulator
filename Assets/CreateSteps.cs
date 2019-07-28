using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSteps : MonoBehaviour {

    //エスカレーターのステップ数
    private int stepSum;
    //エスカレーターのステップ一段あたりに乗れる人数
    private int stepLimite = 2;
    //このオブジェクトの下にすべて配置
    public GameObject stepParent;

    void Start() {
        stepSum = 10;
        settings();
    }

    void Update() {

    }
    //エレベーター配置
    private void settings() {
        for (int i = 0; i < stepSum; i++) {
            for (int j = 0; j < stepLimite; j++) {
                GameObject stepTmp = GameObject.CreatePrimitive(PrimitiveType.Cube);
                stepTmp.gameObject.name = i.ToString() + j.ToString();
                stepTmp.transform.position = stepParent.transform.position + new Vector3(i, i, j * 2);
                stepTmp.transform.parent = stepParent.transform;
            }
        }
    }
}
