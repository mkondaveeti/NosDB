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
using Alachisoft.NosDB.Common.Enum;

namespace Alachisoft.NosDB.Common.Queries.Results
{
    public interface IResultSet<T> : ICloneable, IEnumerable<T>, IDisposable
    {
        void Add(T result);
        void Remove(T result);
        void Populate(IEnumerator<T> enumerator);
        int Count { get; }
        void Clear();
        ResultType ResultType { get; }
        T this[T reference] { get; set; }
        bool Contains(T value);
    }
}
