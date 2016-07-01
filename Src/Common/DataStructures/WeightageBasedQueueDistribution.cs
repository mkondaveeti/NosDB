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
using System.Text;
using Alachisoft.NosDB.Common.Enum;

namespace Alachisoft.NosDB.Common.DataStructures
{
    class WeightageBasedQueueDistribution : IQueueDistributionStrategy
    {
        private double _noOfLowPriorityMessages;
        private double _noOfNormalPriorityMessages;
        private readonly float TOTAL_MESSAGES = 10;
        private Priority _currentPriority = Priority.Normal;
        private int _messageCount;
        private float _lowPriorityMessagePercentage;

        public WeightageBasedQueueDistribution(float lowPriorityMessagePercentage)
        {
            if (lowPriorityMessagePercentage <= 0 || lowPriorityMessagePercentage > 100)
                throw new Exception("Invalid distribution percentage");

            _lowPriorityMessagePercentage = lowPriorityMessagePercentage;
            _noOfLowPriorityMessages = Math.Ceiling((TOTAL_MESSAGES * (lowPriorityMessagePercentage / 100)));
            _noOfNormalPriorityMessages = TOTAL_MESSAGES - _noOfLowPriorityMessages;
        }



        public Alachisoft.NosDB.Common.Enum.Priority GetDistributionPriority()
        {
            Priority priority;
            lock (this)
            {
                switch (_currentPriority)
                {
                    case Priority.Normal:
                        if (_messageCount >= _noOfNormalPriorityMessages)
                        {
                            _messageCount = 0;
                            _currentPriority = Priority.Low;
                        }
                        break;

                    case Priority.Low:
                        if (_messageCount >= _noOfLowPriorityMessages)
                        {
                            _messageCount = 0;
                            _currentPriority = Priority.Normal;
                        }
                        break;
                }

                _messageCount++;
                priority = _currentPriority;
            }

            return priority;
        }
    }
}
