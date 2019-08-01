using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Administlator : MonoBehaviour {

    private int flame = 0;

    private void Awake() {
    }

    void Start() {
        //        Debug.Log(variables.slowlyColumn.Length);
    }

    void Update() {
        flame++;
        if (variables.simulationSpeed <= flame) {
            flame = 0;
            Simulation();
        }
    }

    private void Simulation() {
        //ゆっくりの人で最上段の人をtargetに配置する
        if (variables.slowlyEscalator[variables.stepSum - 1] != -1) {
            //targetの配列の空きを確認する
            int i = 0;
            while (variables.endHuman[i] != -1 && i < variables.humanNum)
                i++;
            //問題なく見つかれば
            if (i < variables.humanNum) {
                //保存する
                variables.endHuman[i] = variables.slowlyEscalator[variables.stepSum - 1];
                //エスカレーターのステップを空いてる状態に
                variables.slowlyEscalator[variables.stepSum - 1] = -1;
            } else {
                //問題発生
                Debug.LogWarning("Error.");
            }
        }

        //ゆっくりの人で既にエスカレータに乗ってる人を一つ上の段に上げる
        for (int j = variables.stepSum - 2; 0 <= j; j--) {
            variables.slowlyEscalator[j + 1] = variables.slowlyEscalator[j];
            variables.slowlyEscalator[j] = -1;
        }

        //ゆっくりの人でwaitにいる人をエスカレータの一段目に載せる
        int k = 0;
        while (variables.slowlyColumn[k] == -1) {
            k++;
            if (variables.slowlyHuman <= k) {
                k = -1;
                break;
            }
        }
        if (0 <= k) {
            variables.slowlyEscalator[0] = variables.slowlyColumn[k];
            variables.slowlyColumn[k] = -1;
        }

        //急ぐ人

        //座標をそれぞれに与える
        //既にエスカレーターにいる人数を数える
        int n = 0;
        for (int m = 0; m < variables.stepSum; m++)
            if (variables.slowlyEscalator[m] != -1)
                n++;
        //座標計算
        for (int l = 0; l < variables.stepSum && 0 < n; l++) {
            //空きの場合は処理しない
            if (variables.slowlyEscalator[l] != -1) {
                //Humanのうち、ゆっくりの人用エスカレーターのL番目の者を取得
                GameObject SHuman = GameObject.Find("Human" + variables.slowlyEscalator[l].ToString());
                //L番目のエスカレーターのステップを取得
                GameObject SStep = variables.stepParent.transform.Find(l.ToString() + 1.ToString()).gameObject;
                //Debug.Log("L: " + l + "  human: " + variables.slowlyEscalator[l].ToString());
                //            Debug.Log("SHuman: "+SHuman.transform.name);
                //SHumanをSStepの上に移動させる
                SHuman.transform.position = SStep.transform.position + Vector3.up;
                n--;
            }
            Debug.Log("L: " + l.ToString() + " = " + variables.slowlyEscalator[l]);
        }
        //targetの行き先（仮）
        n = 0;
        for (int m = 0; m < variables.humanNum; m++)
            if (variables.endHuman[m] != -1)
                n++;
        for (int l = 0; l < variables.humanNum && l < n; l++) {
            GameObject.Find("Human" + variables.endHuman[l].ToString()).transform.position = new Vector3(0, 5, 0);
        }
    }
}
