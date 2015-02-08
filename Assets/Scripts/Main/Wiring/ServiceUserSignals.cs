/*
 * ServiceUserSignals.cs
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
using strange.extensions.signal.impl;

using System.Collections.Generic;

namespace aleggeup.leggefamilyflicks.main
{
    public class DisplayFirstWindow : Signal {}

    public class UserListSignal : Signal<List<IUserModel>> {}

    public class RequestTokenListSignal : Signal<List<IRequestToken>> {}

    public class AddNewRequestTokenSignal : Signal<IRequestToken> {}

    public class NoUserSignal : Signal {}

    public class RegisterNewUser : Signal {}
}
