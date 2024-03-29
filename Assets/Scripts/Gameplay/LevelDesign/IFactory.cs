﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFactory<T>
{
    T Create(int meters);
    void Remove();
}
