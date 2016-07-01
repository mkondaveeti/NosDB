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
using Alachisoft.NosDB.Common.Communication;
using Alachisoft.NosDB.Common.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alachisoft.NosDB.Common.Protobuf.ManagementCommands
{
    public class ManagementResponse : IResponse, ICompactSerializable
    {
        private object _response;
        private long requestId_;
        private System.Exception exception_;

        public System.Exception Exception
        {
            get
            {
                return exception_;
            }
            set
            {
                exception_ = value;
            }
        }

        public object ResponseMessage
        {
            get
            {
                return _response;
            }
            set
            {
                _response = value;
            }
        }

        public IChannel Channel
        {
            get;
            set;
        }

        public Net.Address Source
        {
            get;
            set;
        }

        #region ICompactSerializable Members
        public void Deserialize(Serialization.IO.CompactReader reader)
        {
            RequestId = reader.ReadInt64();
            ResponseMessage = reader.ReadObject();
            Source = reader.ReadObject() as Net.Address;
            Exception = reader.ReadObject() as System.Exception;
            ReturnVal = reader.ReadObject() as byte[];
        }

        public void Serialize(Serialization.IO.CompactWriter writer)
        {
            writer.Write(RequestId);
            writer.WriteObject(ResponseMessage);
            writer.WriteObject(Source);
            writer.WriteObject(Exception);
            writer.WriteObject(ReturnVal);
        }
        #endregion


        public System.Exception Error
        {
            get
            {
                return null;
            }
            set
            {

            }
        }

        public long RequestId
        {
            get
            {
                return requestId_;
            }
            set
            {
                requestId_ = value;
            }
        }

        public int Version { get; set; }

        public string MethodName { get; set; }

        public byte[] ReturnVal { get; set; }
    }
}
