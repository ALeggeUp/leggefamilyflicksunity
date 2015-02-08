/*
 * PersistentDataModels.cs
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

namespace aleggeup.leggefamilyflicks.main
{
    public class RequestToken : IRequestToken
    {
        public long ID { get; set; }

        public long BinaryTime { get; set; }

        public string Token { get; set; }

        public string TokenSecret { get; set; }

        public bool completed { get; set; }
    }

    public class User : IUserModel
    {
        public string UserId { get; set; }

        public string Username { get; set; }

        public string FullName { get; set; }

        public bool authenticated { get; set; }

        public string Token { get; set; }

        public string TokenSecret { get; set; }
    }
}
