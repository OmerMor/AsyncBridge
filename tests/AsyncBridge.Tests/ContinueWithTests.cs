using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#if !NET40
using TaskEx = System.Threading.Tasks.Task;
#endif

#if NET45
namespace ReferenceAsync.Tests
#elif ATP
namespace AsyncTargetingPack.Tests
#else
namespace AsyncBridge.Tests
#endif
{
#if !ATP
    [TestClass]
    public class ContinueWithTests
    {
        [TestMethod]
        public void Action()
        {
            var gotState = false;
            TestUtils.RunAsync(() => TaskEx.Run(() => { }).ContinueWith((task, state) => { gotState = (bool)state; }, true));
            Assert.IsTrue(gotState);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ActionNull()
        {
            TaskEx.Run(() => { }).ContinueWith((Action<Task, object>)null, false);
        }

        [TestMethod]
        public void ActionToken()
        {
            var gotState = false;
            TestUtils.RunAsync(() => TaskEx.Run(() => { }).ContinueWith((task, state) => { gotState = (bool)state; }, true, CancellationToken.None));
            Assert.IsTrue(gotState);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ActionTokenNull()
        {
            TaskEx.Run(() => { }).ContinueWith((Action<Task, object>)null, false, CancellationToken.None);
        }

        [TestMethod]
        public void ActionOptions()
        {
            var gotState = false;
            TestUtils.RunAsync(() => TaskEx.Run(() => { }).ContinueWith((task, state) => { gotState = (bool)state; }, true, TaskContinuationOptions.None));
            Assert.IsTrue(gotState);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ActionOptionsNull()
        {
            TaskEx.Run(() => { }).ContinueWith((Action<Task, object>)null, false, TaskContinuationOptions.None);
        }

        [TestMethod]
        public void ActionScheduler()
        {
            var gotState = false;
            TestUtils.RunAsync(() => TaskEx.Run(() => { }).ContinueWith((task, state) => { gotState = (bool)state; }, true, TaskScheduler.Current));
            Assert.IsTrue(gotState);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ActionSchedulerNull()
        {
            TaskEx.Run(() => { }).ContinueWith((Action<Task, object>)null, false, TaskScheduler.Current);
        }

        [TestMethod]
        public void ActionTokenOptionsScheduler()
        {
            var gotState = false;
            TestUtils.RunAsync(() => TaskEx.Run(() => { }).ContinueWith((task, state) => { gotState = (bool)state; }, true, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.Current));
            Assert.IsTrue(gotState);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ActionTokenOptionsSchedulerNull()
        {
            TaskEx.Run(() => { }).ContinueWith((Action<Task, object>)null, false, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.Current);
        }

        [TestMethod]
        public void ActionResult()
        {
            var gotState = false;
            TestUtils.RunAsync(() => TaskEx.Run(() => true).ContinueWith((task, state) => { gotState = (bool)state; }, true));
            Assert.IsTrue(gotState);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ActionResultNull()
        {
            TaskEx.Run(() => true).ContinueWith((Action<Task<bool>, object>)null, false);
        }

        [TestMethod]
        public void ActionResultToken()
        {
            var gotState = false;
            TestUtils.RunAsync(() => TaskEx.Run(() => true).ContinueWith((task, state) => { gotState = (bool)state; }, true, CancellationToken.None));
            Assert.IsTrue(gotState);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ActionResultTokenNull()
        {
            TaskEx.Run(() => true).ContinueWith((Action<Task<bool>, object>)null, false, CancellationToken.None);
        }

        [TestMethod]
        public void ActionResultOptions()
        {
            var gotState = false;
            TestUtils.RunAsync(() => TaskEx.Run(() => true).ContinueWith((task, state) => { gotState = (bool)state; }, true, TaskContinuationOptions.None));
            Assert.IsTrue(gotState);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ActionResultOptionsNull()
        {
            TaskEx.Run(() => true).ContinueWith((Action<Task<bool>, object>)null, false, TaskContinuationOptions.None);
        }

        [TestMethod]
        public void ActionResultScheduler()
        {
            var gotState = false;
            TestUtils.RunAsync(() => TaskEx.Run(() => true).ContinueWith((task, state) => { gotState = (bool)state; }, true, TaskScheduler.Current));
            Assert.IsTrue(gotState);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ActionResultSchedulerNull()
        {
            TaskEx.Run(() => true).ContinueWith((Action<Task<bool>, object>)null, false, TaskScheduler.Current);
        }

        [TestMethod]
        public void ActionResultTokenOptionsScheduler()
        {
            var gotState = false;
            TestUtils.RunAsync(() => TaskEx.Run(() => true).ContinueWith((task, state) => { gotState = (bool)state; }, true, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.Current));
            Assert.IsTrue(gotState);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ActionResultTokenOptionsSchedulerNull()
        {
            TaskEx.Run(() => true).ContinueWith((Action<Task<bool>, object>)null, false, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.Current);
        }

        [TestMethod]
        public void Func()
        {
            var gotState = false;
            TestUtils.RunAsync(() => TaskEx.Run(() => { }).ContinueWith((task, state) => { return gotState = (bool)state; }, true));
            Assert.IsTrue(gotState);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void FuncNull()
        {
            TaskEx.Run(() => { }).ContinueWith((Func<Task, object, bool>)null, false);
        }

        [TestMethod]
        public void FuncToken()
        {
            var gotState = false;
            var result = TestUtils.RunAsync(() => TaskEx.Run(() => { }).ContinueWith((task, state) => { return gotState = (bool)state; }, true, CancellationToken.None));
            Assert.IsTrue(gotState);
            Assert.IsTrue(result);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void FuncTokenNull()
        {
            TaskEx.Run(() => { }).ContinueWith((Func<Task, object, bool>)null, false, CancellationToken.None);
        }

        [TestMethod]
        public void FuncOptions()
        {
            var gotState = false;
            var result = TestUtils.RunAsync(() => TaskEx.Run(() => { }).ContinueWith((task, state) => { return gotState = (bool)state; }, true, TaskContinuationOptions.None));
            Assert.IsTrue(gotState);
            Assert.IsTrue(result);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void FuncOptionsNull()
        {
            TaskEx.Run(() => { }).ContinueWith((Func<Task, object, bool>)null, false, TaskContinuationOptions.None);
        }

        [TestMethod]
        public void FuncScheduler()
        {
            var gotState = false;
            var result = TestUtils.RunAsync(() => TaskEx.Run(() => { }).ContinueWith((task, state) => { return gotState = (bool)state; }, true, TaskScheduler.Current));
            Assert.IsTrue(gotState);
            Assert.IsTrue(result);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void FuncSchedulerNull()
        {
            TaskEx.Run(() => { }).ContinueWith((Func<Task, object, bool>)null, false, TaskScheduler.Current);
        }

        [TestMethod]
        public void FuncTokenOptionsScheduler()
        {
            var gotState = false;
            var result = TestUtils.RunAsync(() => TaskEx.Run(() => { }).ContinueWith((task, state) => { return gotState = (bool)state; }, true, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.Current));
            Assert.IsTrue(gotState);
            Assert.IsTrue(result);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void FuncTokenOptionsSchedulerNull()
        {
            TaskEx.Run(() => { }).ContinueWith((Func<Task, object, bool>)null, false, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.Current);
        }

        [TestMethod]
        public void FuncResult()
        {
            var gotState = false;
            var result = TestUtils.RunAsync(() => TaskEx.Run(() => true).ContinueWith((task, state) => { return gotState = (bool)state; }, true));
            Assert.IsTrue(gotState);
            Assert.IsTrue(result);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void FuncResultNull()
        {
            TaskEx.Run(() => true).ContinueWith((Func<Task<bool>, object, bool>)null, false);
        }

        [TestMethod]
        public void FuncResultToken()
        {
            var gotState = false;
            var result = TestUtils.RunAsync(() => TaskEx.Run(() => true).ContinueWith((task, state) => { return gotState = (bool)state; }, true, CancellationToken.None));
            Assert.IsTrue(gotState);
            Assert.IsTrue(result);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void FuncResultTokenNull()
        {
            TaskEx.Run(() => true).ContinueWith((Func<Task<bool>, object, bool>)null, false, CancellationToken.None);
        }

        [TestMethod]
        public void FuncResultOptions()
        {
            var gotState = false;
            var result = TestUtils.RunAsync(() => TaskEx.Run(() => true).ContinueWith((task, state) => { return gotState = (bool)state; }, true, TaskContinuationOptions.None));
            Assert.IsTrue(gotState);
            Assert.IsTrue(result);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void FuncResultOptionsNull()
        {
            TaskEx.Run(() => true).ContinueWith((Func<Task<bool>, object, bool>)null, false, TaskContinuationOptions.None);
        }

        [TestMethod]
        public void FuncResultScheduler()
        {
            var gotState = false;
            var result = TestUtils.RunAsync(() => TaskEx.Run(() => true).ContinueWith((task, state) => { return gotState = (bool)state; }, true, TaskScheduler.Current));
            Assert.IsTrue(gotState);
            Assert.IsTrue(result);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void FuncResultSchedulerNull()
        {
            TaskEx.Run(() => true).ContinueWith((Func<Task<bool>, object, bool>)null, false, TaskScheduler.Current);
        }

        [TestMethod]
        public void FuncResultTokenOptionsScheduler()
        {
            var gotState = false;
            var result = TestUtils.RunAsync(() => TaskEx.Run(() => true).ContinueWith((task, state) => { return gotState = (bool)state; }, true, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.Current));
            Assert.IsTrue(gotState);
            Assert.IsTrue(result);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void FuncResultTokenOptionsSchedulerNull()
        {
            TaskEx.Run(() => true).ContinueWith((Func<Task<bool>, object, bool>)null, false, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.Current);
        }
    }
#endif
}
