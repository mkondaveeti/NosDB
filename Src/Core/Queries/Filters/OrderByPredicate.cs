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
using System.Collections.Generic;
using System.IO;
using Alachisoft.NosDB.Common.JSON.Indexing;
using Alachisoft.NosDB.Common.Queries;
using Alachisoft.NosDB.Common.Queries.Filters;
using Alachisoft.NosDB.Common.Queries.Results;
using Alachisoft.NosDB.Core.Queries.Results;

namespace Alachisoft.NosDB.Core.Queries.Filters
{
    public class OrderByPredicate : TerminalPredicate
    {
        public override IEnumerable<KeyValuePair<AttributeValue, long>> Enumerate(QueryCriteria value)
        {
            using (IResultSet<ResultWrapper<KeyValuePair<AttributeValue, long>>> resultSet =
                new SortedResultSet<ResultWrapper<KeyValuePair<AttributeValue, long>>>())
            {
                if (_childPredicates != null)
                {
                    foreach (var child in _childPredicates)
                    {
                        var terminal = (TerminalPredicate) child;
                        if (terminal != null)
                        {
                            foreach (var kvp in terminal.Enumerate(value))
                            {
                                var wrapper = new ResultWrapper<KeyValuePair<AttributeValue, long>>(kvp);
                                AttributeValue attValue;
                                if (value.OrderByField.GetAttributeValue(value.Store.GetDocument(kvp.Value, null),
                                    out attValue))
                                {
                                    wrapper.SortField = attValue;
                                    if (resultSet.Contains(wrapper))
                                    {
                                        ResultWrapper<KeyValuePair<AttributeValue, long>> oldWrapper =
                                            resultSet[wrapper];
                                        ResultWrapperList<KeyValuePair<AttributeValue, long>> list = oldWrapper.ToList();
                                        list.List.Add(kvp);
                                        resultSet[wrapper] = list;
                                    }
                                    else resultSet.Add(wrapper);
                                }
                            }
                        }
                    }
                }
                foreach (var resultWrapper in resultSet)
                {
                    var list = resultWrapper as ResultWrapperList<KeyValuePair<AttributeValue, long>>;
                    if (list == null)
                        yield return resultWrapper.Value;
                    else
                    {
                        foreach (var rowId in list.List)
                        {
                            yield return rowId;
                        }
                    }
                }
            }
        }

        public override void Print(TextWriter output)
        {
            output.Write("OrderByPredicate:{");
            base.Print(output);
            output.Write("}");
        }
    }
}
