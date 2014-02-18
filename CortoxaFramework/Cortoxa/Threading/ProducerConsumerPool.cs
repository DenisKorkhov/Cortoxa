#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	ProducerConsumerPool.cs
//  *  Date:		05/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Cortoxa.Threading
{
    public class ProducerConsumerPool : IDisposable
    {
        private readonly ConcurrentQueue<PoolTask> tasks = new ConcurrentQueue<PoolTask>();

        private readonly ManualResetEvent signal = new ManualResetEvent(false);
        private readonly IList<CancellationTokenSource> cancellationTokens = new List<CancellationTokenSource>();

        public ProducerConsumerPool(int threadsCount = 1)
        {
            for (int i = 0; i < threadsCount; i++)
            {
                var cts = new CancellationTokenSource();
                cancellationTokens.Add(cts);
                Task.Run(() =>
                {
                    var cancelation = cts;
                    ProcessQueue(cancelation);
                }, cts.Token);
            }
            
        }
        public void ExecuteTask(Action action)
        {
            EnqueueTask(new PoolTask(action));
        }

        public async Task ExecuteTaskAsync(Action action)
        {
            await Task.Factory.StartNew(() =>
            {
                var taskEvent = new AutoResetEvent(false);
                Exception result = null;
                EnqueueTask(new PoolTask(action, e =>
                {
                    taskEvent.Set();
                    result = e;
                }));
                taskEvent.WaitOne();
                if (result != null)
                {
                    throw result;
                }
            });
        }

        private void EnqueueTask(PoolTask poolTask)
        {
            tasks.Enqueue(poolTask);
            signal.Set();
        }


        private void ProcessQueue(CancellationTokenSource cancelation)
        {
            while (true)
            {
                if (cancelation.IsCancellationRequested)
                {
                    break;
                }
                PoolTask task;
                if (tasks.TryDequeue(out task))
                {
                    try
                    {
                        task.Action.DynamicInvoke();
                    }
                    catch (Exception e)
                    {
                        if (task.OnFinish != null)
                        {
                            task.OnFinish(e);
                        }
                    }
                    if (task.OnFinish != null)
                    {
                        task.OnFinish(null);
                    }
                }
                else
                {
                    signal.Reset();
                    signal.WaitOne();
                }
            }
        }

        public void StopAll()
        {
            foreach (var token in cancellationTokens)
            {
                token.Cancel();
            }
            signal.Set();
        }

        public void Dispose()
        {
            StopAll();
        }
    }
}