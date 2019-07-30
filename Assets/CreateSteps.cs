using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSteps : MonoBehaviour {
    
    void Start() {
        settings();
    }

    void Update() {

    }

    //エスカレーター配置
    private void settings() {
        for (int i = 0; i < variables.stepSum; i++) {
            for (int j = 0; j < variables.stepLimite; j++) {
                GameObject stepTmp = GameObject.CreatePrimitive(PrimitiveType.Cube);
                stepTmp.gameObject.name = i.ToString() + j.ToString();
                stepTmp.transform.position = variables.stepParent.transform.position + new Vector3(i, i, j * 2);
                stepTmp.transform.parent = variables.stepParent.transform;
            }
        }
    }
}
