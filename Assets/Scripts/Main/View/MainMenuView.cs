/*
 * MainMenuView.cs
 * 
 * Copyright (c) 2015 [ A Legge Up Consulting].  All Rights Reserved.
 * 
 * Unauthorized copying or redistribution of this file in whole or
 * in part, or use in source and binary forms, with or without
 * modification via any medium is strictly prohibited.
 * 
 * Proprietary and confidential.
 * 
 * Created: January 2015
 * Author: Stephen Legge <stephen@aleggeup.com>
 * 
 * THIS IS UNPUBLISHED PROPRIETARY SOURCE CODE OF A LEGGE UP CONSULTING
 * 
 * The copyright notice above does not evidence any
 * actual or intended publication of such source code.
 */

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

using System;
using System.Collections;

using strange.extensions.mediation.impl;

namespace aleggeup.leggefamilyflicks.main
{
    public class MainMenuView : View
    {

        public string MyName()
        {
            return transform.name;
        }

        public void Toggler()
        {
            Animator anim = transform.GetComponent<Animator>();
            anim.SetBool("Open", !anim.GetBool("Open"));
        }
    }
}
