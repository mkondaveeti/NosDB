﻿// /*
// * Copyright (c) 2016, Alachisoft. All Rights Reserved.
// *
// * Licensed under the Apache License, Version 2.0 (the "License");
// * you may not use this file except in compliance with the License.
// * You may obtain a copy of the License at
// *
// * http://www.apache.org/licenses/LICENSE-2.0
// *
// * Unless required by applicable law or agreed to in writing, software
// * distributed under the License is distributed on an "AS IS" BASIS,
// * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// * See the License for the specific language governing permissions and
// * limitations under the License.
// */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alachisoft.NosDB.Common.Exceptions
{
    public class DistributorException : DatabaseException
    {
        public DistributorException(string message) : base(message) { }

        public DistributorException(int errCode) : base(errCode) { }

        public DistributorException(int errCode, string[] parameters) : base(errCode, parameters) { }

        public DistributorException(int errCode, string message, string[] parameters) : base(errCode, message, parameters) { }

        public DistributorException(int errcode, string message, Exception inner, string[] parameters) : base(errcode, message, inner, parameters) { }

        public DistributorException(int errCode, string message, Exception inner) : base(errCode, message, inner) { }
    }
}
