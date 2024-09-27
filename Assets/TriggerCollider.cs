using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCollider : MonoBehaviour
{
    [SerializeField] private string colliderTag;
    [SerializeField] private OnEventStruct onEventStruct;
    [SerializeField] private bool isPressingInterractKey;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag(colliderTag) && isPressingInterractKey) {
            FPSRaycastController.Instance().isInTrigger = true;
            UIController.Instance().interractHelper.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag(colliderTag) && isPressingInterractKey) {
            FPSRaycastController.Instance().isInTrigger = false;
            UIController.Instance().interractHelper.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag(colliderTag)) {
            UIController.Instance().interractHelper.SetActive(true);
            if (isPressingInterractKey && !Input.GetKeyDown(KeyCode.E)) return;
            onEventStruct.OnEvent();
        }

    }
}
