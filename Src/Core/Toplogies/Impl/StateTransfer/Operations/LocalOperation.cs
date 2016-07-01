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
using Alachisoft.NosDB.Common.Server.Engine;
using Alachisoft.NosDB.Common.Server.Engine.Impl;
using Alachisoft.NosDB.Common.Security.Interfaces;

namespace Alachisoft.NosDB.Core.Toplogies.Impl.StateTransfer
{
    public class LocalOperation : IDBOperation
    {
        protected IOperationContext _operationContext = new OperationContext();
        public long RequestId
        {
            get;
            set;
        }

        public string Database
        {
            get;
            set;
        }

        public string Collection
        {
            get;
            set;
        }

        public bool NoResponse { get; set; }

        public IOperationContext Context
        {
            get { return _operationContext; }
            set { _operationContext = value; } 
        }

        public virtual byte[] Serialize()
        {
            return null;
        }

        public virtual Common.Server.Engine.Impl.DatabaseOperationType OperationType
        {
            get;
            set;
        }

        public virtual IDBOperation Clone()
        {
            return null;
        }

        public virtual IDBResponse CreateResponse()
        {
            return new LocalResponse();
        }

        /// <summary>
        /// used to identify which client is performing an operatoin on database engine
        /// </summary>
        public ISessionId SessionId { set; get; }


        public object Message
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Common.Communication.IChannel Channel
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Common.Net.Address Source
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
