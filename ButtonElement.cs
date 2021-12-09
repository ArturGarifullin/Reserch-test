using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonElement {
    private readonly Button buttonComponent;

    public ButtonElement(Button buttonComponent) {
        this.buttonComponent = buttonComponent;
    }

    public void Click() {
        buttonComponent.onClick.Invoke();
    }
}
