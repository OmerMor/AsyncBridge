using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#if NET45
using TaskEx = System.Threading.Tasks.Task;
#endif

#if NET45
namespace ReferenceAsync.Tests
#elif NET35
namespace AsyncBridge.Net35.Tests
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
            var GotState = false;
            TestUtils.RunAsync(() => TaskEx.Run(() => { }).ContinueWith((task, state) => { GotState = (bool)state; }, true));
            Assert.IsTrue(GotState);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ActionNull()
        {
            TaskEx.Run(() => { }).ContinueWith((Action<Task, object>)null, false);
        }

        [TestMethod]
        public void ActionToken()
        {
            var GotState = false;
            TestUtils.RunAsync(() => TaskEx.Run(() => { }).ContinueWith((task, state) => { GotState = (bool)state; }, true, CancellationToken.None));
            Assert.IsTrue(GotState);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ActionTokenNull()
        {
            TaskEx.Run(() => { }).ContinueWith((Action<Task, object>)null, false, CancellationToken.None);
        }

        [TestMethod]
        public void ActionOptions()
        {
            var GotState = false;
            TestUtils.RunAsync(() => TaskEx.Run(() => { }).ContinueWith((task, state) => { GotState = (bool)state; }, true, TaskContinuationOptions.None));
            Assert.IsTrue(GotState);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ActionOptionsNull()
        {
            TaskEx.Run(() => { }).ContinueWith((Action<Task, object>)null, false, TaskContinuationOptions.None);
        }

        [TestMethod]
        public void ActionScheduler()
        {
            var GotState = false;
            TestUtils.RunAsync(() => TaskEx.Run(() => { }).ContinueWith((task, state) => { GotState = (bool)state; }, true, TaskScheduler.Current));
            Assert.IsTrue(GotState);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ActionSchedulerNull()
        {
            TaskEx.Run(() => { }).ContinueWith((Action<Task, object>)null, false, TaskScheduler.Current);
        }

        [TestMethod]
        public void ActionTokenOptionsScheduler()
        {
            var GotState = false;
            TestUtils.RunAsync(() => TaskEx.Run(() => { }).ContinueWith((task, state) => { GotState = (bool)state; }, true, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.Current));
            Assert.IsTrue(GotState);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ActionTokenOptionsSchedulerNull()
        {
            TaskEx.Run(() => { }).ContinueWith((Action<Task, object>)null, false, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.Current);
        }

        [TestMethod]
        public void ActionResult()
        {
            var GotState = false;
            TestUtils.RunAsync(() => TaskEx.Run(() => true).ContinueWith((task, state) => { GotState = (bool)state; }, true));
            Assert.IsTrue(GotState);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ActionResultNull()
        {
            TaskEx.Run(() => true).ContinueWith((Action<Task<bool>, object>)null, false);
        }

        [TestMethod]
        public void ActionResultToken()
        {
            var GotState = false;
            TestUtils.RunAsync(() => TaskEx.Run(() => true).ContinueWith((task, state) => { GotState = (bool)state; }, true, CancellationToken.None));
            Assert.IsTrue(GotState);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ActionResultTokenNull()
        {
            TaskEx.Run(() => true).ContinueWith((Action<Task<bool>, object>)null, false, CancellationToken.None);
        }

        [TestMethod]
        public void ActionResultOptions()
        {
            var GotState = false;
            TestUtils.RunAsync(() => TaskEx.Run(() => true).ContinueWith((task, state) => { GotState = (bool)state; }, true, TaskContinuationOptions.None));
            Assert.IsTrue(GotState);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ActionResultOptionsNull()
        {
            TaskEx.Run(() => true).ContinueWith((Action<Task<bool>, object>)null, false, TaskContinuationOptions.None);
        }

        [TestMethod]
        public void ActionResultScheduler()
        {
            var GotState = false;
            TestUtils.RunAsync(() => TaskEx.Run(() => true).ContinueWith((task, state) => { GotState = (bool)state; }, true, TaskScheduler.Current));
            Assert.IsTrue(GotState);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ActionResultSchedulerNull()
        {
            TaskEx.Run(() => true).ContinueWith((Action<Task<bool>, object>)null, false, TaskScheduler.Current);
        }

        [TestMethod]
        public void ActionResultTokenOptionsScheduler()
        {
            var GotState = false;
            TestUtils.RunAsync(() => TaskEx.Run(() => true).ContinueWith((task, state) => { GotState = (bool)state; }, true, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.Current));
            Assert.IsTrue(GotState);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ActionResultTokenOptionsSchedulerNull()
        {
            TaskEx.Run(() => true).ContinueWith((Action<Task<bool>, object>)null, false, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.Current);
        }

        [TestMethod]
        public void Func()
        {
            var GotState = false;
            TestUtils.RunAsync(() => TaskEx.Run(() => { }).ContinueWith((task, state) => { return GotState = (bool)state; }, true));
            Assert.IsTrue(GotState);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void FuncNull()
        {
            TaskEx.Run(() => { }).ContinueWith((Func<Task, object, bool>)null, false);
        }

        [TestMethod]
        public void FuncToken()
        {
            var GotState = false;
            var GotResult = TestUtils.RunAsync(() => TaskEx.Run(() => { }).ContinueWith((task, state) => { return GotState = (bool)state; }, true, CancellationToken.None));
            Assert.IsTrue(GotState);
            Assert.IsTrue(GotResult);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void FuncTokenNull()
        {
            TaskEx.Run(() => { }).ContinueWith((Func<Task, object, bool>)null, false, CancellationToken.None);
        }

        [TestMethod]
        public void FuncOptions()
        {
            var GotState = false;
            var GotResult = TestUtils.RunAsync(() => TaskEx.Run(() => { }).ContinueWith((task, state) => { return GotState = (bool)state; }, true, TaskContinuationOptions.None));
            Assert.IsTrue(GotState);
            Assert.IsTrue(GotResult);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void FuncOptionsNull()
        {
            TaskEx.Run(() => { }).ContinueWith((Func<Task, object, bool>)null, false, TaskContinuationOptions.None);
        }

        [TestMethod]
        public void FuncScheduler()
        {
            var GotState = false;
            var GotResult = TestUtils.RunAsync(() => TaskEx.Run(() => { }).ContinueWith((task, state) => { return GotState = (bool)state; }, true, TaskScheduler.Current));
            Assert.IsTrue(GotState);
            Assert.IsTrue(GotResult);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void FuncSchedulerNull()
        {
            TaskEx.Run(() => { }).ContinueWith((Func<Task, object, bool>)null, false, TaskScheduler.Current);
        }

        [TestMethod]
        public void FuncTokenOptionsScheduler()
        {
            var GotState = false;
            var GotResult = TestUtils.RunAsync(() => TaskEx.Run(() => { }).ContinueWith((task, state) => { return GotState = (bool)state; }, true, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.Current));
            Assert.IsTrue(GotState);
            Assert.IsTrue(GotResult);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void FuncTokenOptionsSchedulerNull()
        {
            TaskEx.Run(() => { }).ContinueWith((Func<Task, object, bool>)null, false, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.Current);
        }

        [TestMethod]
        public void FuncResult()
        {
            var GotState = false;
            var GotResult = TestUtils.RunAsync(() => TaskEx.Run(() => true).ContinueWith((task, state) => { return GotState = (bool)state; }, true));
            Assert.IsTrue(GotState);
            Assert.IsTrue(GotResult);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void FuncResultNull()
        {
            TaskEx.Run(() => true).ContinueWith((Func<Task<bool>, object, bool>)null, false);
        }

        [TestMethod]
        public void FuncResultToken()
        {
            var GotState = false;
            var GotResult = TestUtils.RunAsync(() => TaskEx.Run(() => true).ContinueWith((task, state) => { return GotState = (bool)state; }, true, CancellationToken.None));
            Assert.IsTrue(GotState);
            Assert.IsTrue(GotResult);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void FuncResultTokenNull()
        {
            TaskEx.Run(() => true).ContinueWith((Func<Task<bool>, object, bool>)null, false, CancellationToken.None);
        }

        [TestMethod]
        public void FuncResultOptions()
        {
            var GotState = false;
            var GotResult = TestUtils.RunAsync(() => TaskEx.Run(() => true).ContinueWith((task, state) => { return GotState = (bool)state; }, true, TaskContinuationOptions.None));
            Assert.IsTrue(GotState);
            Assert.IsTrue(GotResult);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void FuncResultOptionsNull()
        {
            TaskEx.Run(() => true).ContinueWith((Func<Task<bool>, object, bool>)null, false, TaskContinuationOptions.None);
        }

        [TestMethod]
        public void FuncResultScheduler()
        {
            var GotState = false;
            var GotResult = TestUtils.RunAsync(() => TaskEx.Run(() => true).ContinueWith((task, state) => { return GotState = (bool)state; }, true, TaskScheduler.Current));
            Assert.IsTrue(GotState);
            Assert.IsTrue(GotResult);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void FuncResultSchedulerNull()
        {
            TaskEx.Run(() => true).ContinueWith((Func<Task<bool>, object, bool>)null, false, TaskScheduler.Current);
        }

        [TestMethod]
        public void FuncResultTokenOptionsScheduler()
        {
            var GotState = false;
            var GotResult = TestUtils.RunAsync(() => TaskEx.Run(() => true).ContinueWith((task, state) => { return GotState = (bool)state; }, true, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.Current));
            Assert.IsTrue(GotState);
            Assert.IsTrue(GotResult);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void FuncResultTokenOptionsSchedulerNull()
        {
            TaskEx.Run(() => true).ContinueWith((Func<Task<bool>, object, bool>)null, false, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.Current);
        }
    }
#endif
}
