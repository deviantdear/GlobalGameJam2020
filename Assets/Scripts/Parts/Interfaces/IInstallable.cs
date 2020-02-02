﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInstallable
{
    /// <summary>
    /// Installs the replacement gear
    /// </summary>
    /// <param name="replacementGear"></param>
    bool Install(Gear newGear);
}
