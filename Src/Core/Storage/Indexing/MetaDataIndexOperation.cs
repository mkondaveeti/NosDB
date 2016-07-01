// /*
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
using Alachisoft.NosDB.Core.Storage.Operations;

namespace Alachisoft.NosDB.Core.Storage.Indexing
{
    public class MetaDataIndexOperation
    {
        public long ActualDocumentSize { get; set; }
        public long FileId { get; set; }
        public long RowId { get; set; }
        public OperationType OperationType { get; set; }
    }
}