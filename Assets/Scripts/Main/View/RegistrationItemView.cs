/*
 * RegistrationItemView.cs
 * 
 * Copyright (c) 2015 [ A Legge Up Consulting].  All Rights Reserved.
 * 
 * Unauthorized copying or redistribution of this file in whole or
 * in part, or use in source and binary forms, with or without
 * modification via any medium is strictly prohibited.
 * 
 * Proprietary and confidential.
 * 
 * Created: February 2015
 * Author: Stephen Legge <stephen@aleggeup.com>
 * 
 * THIS IS UNPUBLISHED PROPRIETARY SOURCE CODE OF A LEGGE UP CONSULTING
 * 
 * The copyright notice above does not evidence any
 * actual or intended publication of such source code.
 */

using UnityEngine;
using UnityEngine.UI;

using strange.extensions.signal.impl;
using strange.extensions.mediation.impl;

using System.Collections;

namespace aleggeup.leggefamilyflicks.main
{
    public class RegistrationItemView : View
    {

        #region public editor fields

        [Header("Links to Text Fields")]
        public Text registrationHeaderText;

        public Text authLinkButtonText;

        public Text cancelAuthButtonText;

        #endregion

        public IRequestToken RequestToken { get; set; }

        public void Init()
        {
            registrationHeaderText.text = RequestToken.Token;
        }

    }
}
