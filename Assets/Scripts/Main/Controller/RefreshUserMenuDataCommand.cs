/*
 * RefreshUserMenuDataCommand.cs
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

using strange.extensions.context.api;
using strange.extensions.command.impl;

namespace aleggeup.leggefamilyflicks.main
{
    public class RefreshUserMenuDataCommand : Command
    {
        private IPersistentData persistentData;
        private UserListSignal userListSignal;
        private RequestTokenListSignal requestTokenListSignal;

        [Construct]
        public RefreshUserMenuDataCommand(IPersistentData persistentData, UserListSignal userListSignal, RequestTokenListSignal requestTokenListSignal) {
            this.persistentData = persistentData;
            this.userListSignal = userListSignal;
            this.requestTokenListSignal = requestTokenListSignal;
        }

        override public void Execute()
        {
            Debug.Log("RefreshUserMenuDataCommand.Execute()");
            userListSignal.Dispatch(persistentData.Users);
            requestTokenListSignal.Dispatch(persistentData.RequestTokens);
        }
    }

}
