using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueKey<T> {

    public string key;
    public T value;
    public T defaultValue;

    public ValueKey(string _key, T _defaultValue)
    {
        this.defaultValue = _defaultValue;
        this.key = _key;
        this.value = _defaultValue;
    }

}
