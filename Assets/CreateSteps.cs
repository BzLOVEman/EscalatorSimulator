using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* このスクリプトがやること
 * エスカレーターのステップ作成
 * waitゾーンの作成
 * targetゾーンの作成
 */
public class CreateSteps : MonoBehaviour {

    void Start() {
        WaitSettings();
        TargetSettings();
        StepSettings();
    }

    void Update() {

    }

    //waitゾーン配置
    private void WaitSettings() {
        GameObject waitZone = GameObject.CreatePrimitive(PrimitiveType.Cube);
        waitZone.gameObject.name = "waitZone";

        //表示
        waitZone.transform.position = new Vector3(-( variables.humanNum / 2f / variables.squareSideLength * variables.humanRange + 2 ), -1f, 1);
        waitZone.transform.localScale = new Vector3(variables.squareSideLength * variables.humanRange, 1, variables.squareSideLength * variables.humanRange);
        waitZone.GetComponent<MeshRenderer>().material.color = new Color(0f, 0f, 0f, 1f);
    }

    //targetゾーン配置
    private void TargetSettings() {
        GameObject targetZone = GameObject.CreatePrimitive(PrimitiveType.Cube);
        targetZone.gameObject.name = "targetZone";

        //表示
        targetZone.transform.position = new Vector3(variables.humanNum / 2f / variables.squareSideLength * variables.humanRange + variables.stepSum + 2, variables.stepSum, 1);
        targetZone.transform.localScale = new Vector3(variables.squareSideLength * variables.humanRange, 1, variables.squareSideLength * variables.humanRange);
        targetZone.GetComponent<MeshRenderer>().material.color = new Color(0f, 0f, 0f, 1f);
    }

    //エスカレーター配置
    private void StepSettings() {
        for (int i = 0; i < variables.stepSum; i++) {
            for (int j = 0; j < variables.stepLimite; j++) {
                GameObject stepTmp = GameObject.CreatePrimitive(PrimitiveType.Cube);
                stepTmp.gameObject.name = i.ToString() + j.ToString();
                stepTmp.transform.position = variables.stepParent.transform.position + new Vector3(i, i, j * 2);
                stepTmp.transform.parent = variables.stepParent.transform;
                stepTmp.GetComponent<MeshRenderer>().material.color = new Color(0.4f, 0.4f, 0.4f, 1f);
            }
        }
    }
}
