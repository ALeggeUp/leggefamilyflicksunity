/*
 * IPersistentData.cs
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

using System.Collections.Generic;

namespace aleggeup.leggefamilyflicks.main
{
    public interface IPersistentData
    {
        int NumberOfTokens { get; }

        int NumberOfUsers { get; }

        List<IRequestToken> RequestTokens { get; }

        List<IUserModel> Users { get; }

        void AddRequestToken (IRequestToken token);
    }

    public interface IRequestToken
    {
        long ID { get; set; }

        long BinaryTime { get; set; }

        string Token { get; set; }

        string TokenSecret { get; set; }

        bool completed { get; set; }
    }

    public interface IUserModel
    {
        string UserId { get; set; }

        string Username { get; set; }

        string FullName { get; set; }

        bool authenticated { get; set; }

        string Token { get; set; }

        string TokenSecret { get; set; }
    }
}
