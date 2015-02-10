/*
 * UserMenuMediator.cs
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
using System.Collections;
using System.Collections.Generic;

using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace aleggeup.leggefamilyflicks.main
{
    public class UserMenuMediator : Mediator
    {
        [Inject]
        public UserMenuView userMenuView { get; set; }

        [Inject]
        public UserListSignal userListSignal { get; set; }

        [Inject]
        public RequestTokenListSignal requestTokenListSignal { get; set; }

        [Inject]
        public DisplayFirstWindowSignal displayFirstWindowSignal { get; set; }

        [Inject]
        public RegisterNewUser RegisterNewUserSignal { get; set; }

        public override void OnRegister()
        {
            Debug.Log("UserMenuMediator - OnRegister");
            userListSignal.AddListener(OnRefreshUserList);
            requestTokenListSignal.AddListener(OnRefreshRequestTokenList);
            displayFirstWindowSignal.AddListener(Display);
            userMenuView.registerNewUserSignal.AddListener(Register);
        }

        public override void OnRemove()
        {
            displayFirstWindowSignal.RemoveListener(Display);
        }

        public void Display()
        {
            userMenuView.DisplayWindow();
        }

        public void Register()
        {
            RegisterNewUserSignal.Dispatch();
        }

        public void OnRefreshUserList(List<IUserModel> users)
        {
            Debug.Log("OnRefreshUserList " + users.Count);
        }

        public void OnRefreshRequestTokenList(List<IRequestToken> requestTokens)
        {
            Debug.Log("OnRefreshRequestTokenList " + requestTokens.Count);
            userMenuView.RefreshRequestTokenItems(requestTokens);
        }
    }
}
