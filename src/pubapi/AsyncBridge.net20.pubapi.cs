// Name:       AsyncBridge
// Public key: ACQAAASAAACUAAAABgIAAAAkAABSU0ExAAQAAAEAAQCLFl3K4YXiNrRI+T6dQfJ73C164NxT1pBidQ9sJZMSKVrEBhi53LnGTBdJZj0s83kCjfQ8tdBvxM4IDe7zH3TxhJDdo40tiZ4ZFOwnDv00373pftuR6JDZ3J3AIeWuhsFhxaofTb5UDfwsMW6M8ypuaTJpFG6v9EaSKJ9hajJPoA==

namespace System
{
    public delegate void Action();

    public delegate void Action<in T1, in T2>(T1 arg1, T2 arg2);

    public delegate void Action<in T1, in T2, in T3>(T1 arg1, T2 arg2, T3 arg3);

    public delegate void Action<in T1, in T2, in T3, in T4>(T1 arg1, T2 arg2, T3 arg3, T4 arg4);

    [System.Diagnostics.DebuggerDisplay("Count = {InnerExceptionCount}")]
    public class AggregateException : Exception
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<Exception> InnerExceptions { get; }

        public override string Message { get; }

        public AggregateException();

        public AggregateException(string message);

        public AggregateException(string message, Exception innerException);

        public AggregateException(System.Collections.Generic.IEnumerable<Exception> innerExceptions);

        public AggregateException(params Exception[] innerExceptions);

        public AggregateException(string message, System.Collections.Generic.IEnumerable<Exception> innerExceptions);

        public AggregateException(string message, params Exception[] innerExceptions);

        [System.Security.SecurityCritical]
        protected AggregateException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context);

        public AggregateException Flatten();

        public override Exception GetBaseException();

        [System.Security.SecurityCritical]
        public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context);

        public void Handle(Func<Exception, bool> predicate);

        public override string ToString();
    }

    public delegate TResult Func<out TResult>();

    public delegate TResult Func<in T, out TResult>(T arg);

    public delegate TResult Func<in T1, in T2, out TResult>(T1 arg1, T2 arg2);

    public delegate TResult Func<in T1, in T2, in T3, out TResult>(T1 arg1, T2 arg2, T3 arg3);

    public delegate TResult Func<in T1, in T2, in T3, in T4, out TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4);

    public delegate TResult Func<in T1, in T2, in T3, in T4, in T5, out TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);

    [System.Runtime.InteropServices.ComVisible(false)]
    [System.Diagnostics.DebuggerTypeProxy(typeof(LazyDebugView<>))]
    [System.Diagnostics.DebuggerDisplay("ThreadSafetyMode={Mode}, IsValueCreated={IsValueCreated}, IsValueFaulted={IsValueFaulted}, Value={ValueForDebugDisplay}")]
    public class Lazy<T>
    {
        public bool IsValueCreated { get; }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public T Value { get; }

        public Lazy();

        public Lazy(T value);

        public Lazy(Func<T> valueFactory);

        public Lazy(bool isThreadSafe);

        public Lazy(System.Threading.LazyThreadSafetyMode mode);

        public Lazy(Func<T> valueFactory, bool isThreadSafe);

        public Lazy(Func<T> valueFactory, System.Threading.LazyThreadSafetyMode mode);

        public override string ToString();
    }
}
namespace System.Collections.Concurrent
{
    [System.Runtime.InteropServices.ComVisible(false)]
    [System.Diagnostics.DebuggerTypeProxy(typeof(BlockingCollectionDebugView<>))]
    [System.Diagnostics.DebuggerDisplay("Count = {Count}, Type = {_collection}")]
    public class BlockingCollection<T> : System.Collections.Generic.IEnumerable<T>, System.Collections.IEnumerable, System.Collections.ICollection, System.IDisposable
    {
        public int BoundedCapacity { get; }

        public int Count { get; }

        public bool IsAddingCompleted { get; }

        public bool IsCompleted { get; }

        public static int AddToAny(BlockingCollection<T>[] collections, T item);

        public static int AddToAny(BlockingCollection<T>[] collections, T item, System.Threading.CancellationToken cancellationToken);

        public static int TakeFromAny(BlockingCollection<T>[] collections, out T item);

        public static int TakeFromAny(BlockingCollection<T>[] collections, out T item, System.Threading.CancellationToken cancellationToken);

        public static int TryAddToAny(BlockingCollection<T>[] collections, T item);

        public static int TryAddToAny(BlockingCollection<T>[] collections, T item, System.TimeSpan timeout);

        public static int TryAddToAny(BlockingCollection<T>[] collections, T item, int millisecondsTimeout);

        public static int TryAddToAny(BlockingCollection<T>[] collections, T item, int millisecondsTimeout, System.Threading.CancellationToken cancellationToken);

        public static int TryTakeFromAny(BlockingCollection<T>[] collections, out T item);

        public static int TryTakeFromAny(BlockingCollection<T>[] collections, out T item, System.TimeSpan timeout);

        public static int TryTakeFromAny(BlockingCollection<T>[] collections, out T item, int millisecondsTimeout);

        public static int TryTakeFromAny(BlockingCollection<T>[] collections, out T item, int millisecondsTimeout, System.Threading.CancellationToken cancellationToken);

        public BlockingCollection();

        public BlockingCollection(int boundedCapacity);

        public BlockingCollection(IProducerConsumerCollection<T> collection, int boundedCapacity);

        public BlockingCollection(IProducerConsumerCollection<T> collection);

        public void Add(T item);

        public void Add(T item, System.Threading.CancellationToken cancellationToken);

        public void CompleteAdding();

        public void CopyTo(T[] array, int index);

        public void Dispose();

        protected virtual void Dispose(bool disposing);

        public System.Collections.Generic.IEnumerable<T> GetConsumingEnumerable();

        public System.Collections.Generic.IEnumerable<T> GetConsumingEnumerable(System.Threading.CancellationToken cancellationToken);

        public T Take();

        public T Take(System.Threading.CancellationToken cancellationToken);

        public T[] ToArray();

        public bool TryAdd(T item);

        public bool TryAdd(T item, System.TimeSpan timeout);

        public bool TryAdd(T item, int millisecondsTimeout);

        public bool TryAdd(T item, int millisecondsTimeout, System.Threading.CancellationToken cancellationToken);

        public bool TryTake(out T item);

        public bool TryTake(out T item, System.TimeSpan timeout);

        public bool TryTake(out T item, int millisecondsTimeout);

        public bool TryTake(out T item, int millisecondsTimeout, System.Threading.CancellationToken cancellationToken);
    }

    [System.Runtime.InteropServices.ComVisible(false)]
    [System.Diagnostics.DebuggerTypeProxy(typeof(IProducerConsumerCollectionDebugView<>))]
    [System.Diagnostics.DebuggerDisplay("Count = {Count}")]
    public class ConcurrentBag<T> : IProducerConsumerCollection<T>, System.Collections.Generic.IEnumerable<T>, System.Collections.IEnumerable, System.Collections.ICollection
    {
        public int Count { get; }

        public bool IsEmpty { get; }

        public ConcurrentBag();

        public ConcurrentBag(System.Collections.Generic.IEnumerable<T> collection);

        public void Add(T item);

        public void Clear();

        public void CopyTo(T[] array, int index);

        public System.Collections.Generic.IEnumerator<T> GetEnumerator();

        public T[] ToArray();

        public bool TryPeek(out T result);

        public bool TryTake(out T result);
    }

    [System.Runtime.InteropServices.ComVisible(false)]
    [System.Diagnostics.DebuggerTypeProxy(typeof(IDictionaryDebugView<,>))]
    [System.Diagnostics.DebuggerDisplay("Count = {Count}")]
    public class ConcurrentDictionary<TKey, TValue> : System.Collections.Generic.IDictionary<TKey, TValue>, System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<TKey, TValue>>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<TKey, TValue>>, System.Collections.IEnumerable, System.Collections.IDictionary, System.Collections.ICollection
    {
        public int Count { get; }

        public bool IsEmpty { get; }

        public TValue this[TKey key] { get; set; }

        public System.Collections.Generic.ICollection<TKey> Keys { get; }

        public System.Collections.Generic.ICollection<TValue> Values { get; }

        public ConcurrentDictionary();

        public ConcurrentDictionary(int concurrencyLevel, int capacity);

        public ConcurrentDictionary(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<TKey, TValue>> collection);

        public ConcurrentDictionary(System.Collections.Generic.IEqualityComparer<TKey> comparer);

        public ConcurrentDictionary(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<TKey, TValue>> collection, System.Collections.Generic.IEqualityComparer<TKey> comparer);

        public ConcurrentDictionary(int concurrencyLevel, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<TKey, TValue>> collection, System.Collections.Generic.IEqualityComparer<TKey> comparer);

        public ConcurrentDictionary(int concurrencyLevel, int capacity, System.Collections.Generic.IEqualityComparer<TKey> comparer);

        public TValue AddOrUpdate<TArg>(TKey key, System.Func<TKey, TArg, TValue> addValueFactory, System.Func<TKey, TValue, TArg, TValue> updateValueFactory, TArg factoryArgument);

        public TValue AddOrUpdate(TKey key, System.Func<TKey, TValue> addValueFactory, System.Func<TKey, TValue, TValue> updateValueFactory);

        public TValue AddOrUpdate(TKey key, TValue addValue, System.Func<TKey, TValue, TValue> updateValueFactory);

        public void Clear();

        public bool ContainsKey(TKey key);

        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>> GetEnumerator();

        public TValue GetOrAdd(TKey key, System.Func<TKey, TValue> valueFactory);

        public TValue GetOrAdd<TArg>(TKey key, System.Func<TKey, TArg, TValue> valueFactory, TArg factoryArgument);

        public TValue GetOrAdd(TKey key, TValue value);

        public System.Collections.Generic.KeyValuePair<TKey, TValue>[] ToArray();

        public bool TryAdd(TKey key, TValue value);

        public bool TryGetValue(TKey key, out TValue value);

        public bool TryRemove(TKey key, out TValue value);

        public bool TryUpdate(TKey key, TValue newValue, TValue comparisonValue);
    }

    [System.Runtime.InteropServices.ComVisible(false)]
    [System.Diagnostics.DebuggerDisplay("Count = {Count}")]
    [System.Diagnostics.DebuggerTypeProxy(typeof(IProducerConsumerCollectionDebugView<>))]
    public class ConcurrentQueue<T> : IProducerConsumerCollection<T>, System.Collections.Generic.IEnumerable<T>, System.Collections.IEnumerable, System.Collections.ICollection
    {
        public int Count { get; }

        public bool IsEmpty { get; }

        public ConcurrentQueue();

        public ConcurrentQueue(System.Collections.Generic.IEnumerable<T> collection);

        public void Clear();

        public void CopyTo(T[] array, int index);

        public void Enqueue(T item);

        public System.Collections.Generic.IEnumerator<T> GetEnumerator();

        public T[] ToArray();

        public bool TryDequeue(out T result);

        public bool TryPeek(out T result);
    }

    [System.Diagnostics.DebuggerDisplay("Count = {Count}")]
    [System.Diagnostics.DebuggerTypeProxy(typeof(IProducerConsumerCollectionDebugView<>))]
    public class ConcurrentStack<T> : IProducerConsumerCollection<T>, System.Collections.Generic.IEnumerable<T>, System.Collections.IEnumerable, System.Collections.ICollection
    {
        public int Count { get; }

        public bool IsEmpty { get; }

        public ConcurrentStack();

        public ConcurrentStack(System.Collections.Generic.IEnumerable<T> collection);

        public void Clear();

        public void CopyTo(T[] array, int index);

        public System.Collections.Generic.IEnumerator<T> GetEnumerator();

        public void Push(T item);

        public void PushRange(T[] items);

        public void PushRange(T[] items, int startIndex, int count);

        public T[] ToArray();

        public bool TryPeek(out T result);

        public bool TryPop(out T result);

        public int TryPopRange(T[] items);

        public int TryPopRange(T[] items, int startIndex, int count);
    }

    [System.Flags]
    public enum EnumerablePartitionerOptions : int
    {
        None = 0,
        NoBuffering = 1
    }

    public interface IProducerConsumerCollection<T> : System.Collections.Generic.IEnumerable<T>, System.Collections.IEnumerable, System.Collections.ICollection
    {
        void CopyTo(T[] array, int index);

        T[] ToArray();

        bool TryAdd(T item);

        bool TryTake(out T item);
    }

    public abstract class OrderablePartitioner<TSource> : Partitioner<TSource>
    {
        public bool KeysNormalized { get; }

        public bool KeysOrderedAcrossPartitions { get; }

        public bool KeysOrderedInEachPartition { get; }

        protected OrderablePartitioner(bool keysOrderedInEachPartition, bool keysOrderedAcrossPartitions, bool keysNormalized);

        public override System.Collections.Generic.IEnumerable<TSource> GetDynamicPartitions();

        public virtual System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<long, TSource>> GetOrderableDynamicPartitions();

        public abstract System.Collections.Generic.IList<System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<long, TSource>>> GetOrderablePartitions(int partitionCount);

        public override System.Collections.Generic.IList<System.Collections.Generic.IEnumerator<TSource>> GetPartitions(int partitionCount);
    }

    public static class Partitioner
    {
        public static OrderablePartitioner<TSource> Create<TSource>(System.Collections.Generic.IList<TSource> list, bool loadBalance);

        public static OrderablePartitioner<TSource> Create<TSource>(TSource[] array, bool loadBalance);

        public static OrderablePartitioner<TSource> Create<TSource>(System.Collections.Generic.IEnumerable<TSource> source);

        public static OrderablePartitioner<TSource> Create<TSource>(System.Collections.Generic.IEnumerable<TSource> source, EnumerablePartitionerOptions partitionerOptions);
    }

    public abstract class Partitioner<TSource>
    {
        public virtual bool SupportsDynamicPartitions { get; }

        protected Partitioner();

        public virtual System.Collections.Generic.IEnumerable<TSource> GetDynamicPartitions();

        public abstract System.Collections.Generic.IList<System.Collections.Generic.IEnumerator<TSource>> GetPartitions(int partitionCount);
    }
}
namespace System.Runtime.CompilerServices
{
    [System.AttributeUsage(System.AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public sealed class AsyncStateMachineAttribute : StateMachineAttribute
    {
        public AsyncStateMachineAttribute(System.Type stateMachineType);
    }

    public struct AsyncTaskMethodBuilder
    {
        public System.Threading.Tasks.Task Task { get; }

        public static AsyncTaskMethodBuilder Create();

        public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : INotifyCompletion where TStateMachine : IAsyncStateMachine;

        public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : ICriticalNotifyCompletion where TStateMachine : IAsyncStateMachine;

        public void SetException(System.Exception exception);

        public void SetResult();

        public void SetStateMachine(IAsyncStateMachine stateMachine);

        [System.Security.SecuritySafeCritical]
        public void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine;
    }

    public struct AsyncTaskMethodBuilder<TResult>
    {
        public System.Threading.Tasks.Task<TResult> Task { get; }

        public static AsyncTaskMethodBuilder<TResult> Create();

        public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : INotifyCompletion where TStateMachine : IAsyncStateMachine;

        [System.Security.SecuritySafeCritical]
        public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : ICriticalNotifyCompletion where TStateMachine : IAsyncStateMachine;

        public void SetException(System.Exception exception);

        public void SetResult(TResult result);

        public void SetStateMachine(IAsyncStateMachine stateMachine);

        [System.Security.SecuritySafeCritical]
        public void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine;
    }

    public struct AsyncVoidMethodBuilder
    {
        public static AsyncVoidMethodBuilder Create();

        public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : INotifyCompletion where TStateMachine : IAsyncStateMachine;

        [System.Security.SecuritySafeCritical]
        public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : ICriticalNotifyCompletion where TStateMachine : IAsyncStateMachine;

        public void SetException(System.Exception exception);

        public void SetResult();

        public void SetStateMachine(IAsyncStateMachine stateMachine);

        [System.Security.SecuritySafeCritical]
        public void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine;
    }

    public readonly struct ConfiguredTaskAwaitable
    {
        public ConfiguredTaskAwaitable.ConfiguredTaskAwaiter GetAwaiter();

        public readonly struct ConfiguredTaskAwaiter
        {
            public bool IsCompleted { get; }

            public void GetResult();

            [System.Security.SecuritySafeCritical]
            public void OnCompleted(System.Action continuation);

            [System.Security.SecurityCritical]
            public void UnsafeOnCompleted(System.Action continuation);
        }
    }

    public readonly struct ConfiguredTaskAwaitable<TResult>
    {
        public ConfiguredTaskAwaitable<TResult>.ConfiguredTaskAwaiter GetAwaiter();

        public readonly struct ConfiguredTaskAwaiter
        {
            public bool IsCompleted { get; }

            public TResult GetResult();

            [System.Security.SecuritySafeCritical]
            public void OnCompleted(System.Action continuation);

            [System.Security.SecurityCritical]
            public void UnsafeOnCompleted(System.Action continuation);
        }
    }

    public interface IAsyncStateMachine
    {
        void MoveNext();

        void SetStateMachine(IAsyncStateMachine stateMachine);
    }

    public interface ICriticalNotifyCompletion : INotifyCompletion
    {
        [System.Security.SecurityCritical]
        void UnsafeOnCompleted(System.Action continuation);
    }

    public interface INotifyCompletion
    {
        void OnCompleted(System.Action continuation);
    }

    [System.AttributeUsage(System.AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public sealed class IteratorStateMachineAttribute : StateMachineAttribute
    {
        public IteratorStateMachineAttribute(System.Type stateMachineType);
    }

    [System.AttributeUsage(System.AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class StateMachineAttribute : System.Attribute
    {
        public System.Type StateMachineType { get; }

        public StateMachineAttribute(System.Type stateMachineType);
    }

    public readonly struct TaskAwaiter
    {
        public bool IsCompleted { get; }

        public void GetResult();

        [System.Security.SecuritySafeCritical]
        public void OnCompleted(System.Action continuation);

        [System.Security.SecurityCritical]
        public void UnsafeOnCompleted(System.Action continuation);
    }

    public readonly struct TaskAwaiter<TResult>
    {
        public bool IsCompleted { get; }

        public TResult GetResult();

        [System.Security.SecuritySafeCritical]
        public void OnCompleted(System.Action continuation);

        [System.Security.SecurityCritical]
        public void UnsafeOnCompleted(System.Action continuation);
    }

    public readonly struct YieldAwaitable
    {
        public YieldAwaitable.YieldAwaiter GetAwaiter();

        public readonly struct YieldAwaiter
        {
            public bool IsCompleted { get; }

            public void GetResult();

            [System.Security.SecuritySafeCritical]
            public void OnCompleted(System.Action continuation);

            [System.Security.SecurityCritical]
            public void UnsafeOnCompleted(System.Action continuation);
        }
    }
}
namespace System.Runtime.ExceptionServices
{
    public sealed class ExceptionDispatchInfo
    {
        public System.Exception SourceException { get; }

        public static ExceptionDispatchInfo Capture(System.Exception source);

        public static void Throw(System.Exception source);

        public void Throw();
    }
}
namespace System.Threading
{
    [System.Runtime.InteropServices.ComVisible(false)]
    [System.Diagnostics.DebuggerDisplay("Participant Count={ParticipantCount},Participants Remaining={ParticipantsRemaining}")]
    public class Barrier : System.IDisposable
    {
        public long CurrentPhaseNumber { get; }

        public int ParticipantCount { get; }

        public int ParticipantsRemaining { get; }

        public Barrier(int participantCount);

        public Barrier(int participantCount, System.Action<Barrier> postPhaseAction);

        public long AddParticipant();

        public long AddParticipants(int participantCount);

        public void Dispose();

        protected virtual void Dispose(bool disposing);

        public void RemoveParticipant();

        public void RemoveParticipants(int participantCount);

        public void SignalAndWait();

        public void SignalAndWait(CancellationToken cancellationToken);

        public bool SignalAndWait(System.TimeSpan timeout);

        public bool SignalAndWait(System.TimeSpan timeout, CancellationToken cancellationToken);

        public bool SignalAndWait(int millisecondsTimeout);

        public bool SignalAndWait(int millisecondsTimeout, CancellationToken cancellationToken);
    }

    public class BarrierPostPhaseException : System.Exception
    {
        public BarrierPostPhaseException();

        public BarrierPostPhaseException(System.Exception innerException);

        public BarrierPostPhaseException(string message);

        public BarrierPostPhaseException(string message, System.Exception innerException);

        [System.Security.SecurityCritical]
        protected BarrierPostPhaseException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context);
    }

    [System.Runtime.InteropServices.ComVisible(false)]
    [System.Diagnostics.DebuggerDisplay("IsCancellationRequested = {IsCancellationRequested}")]
    public readonly struct CancellationToken
    {
        public static CancellationToken None { get; }

        public bool CanBeCanceled { get; }

        public bool IsCancellationRequested { get; }

        public WaitHandle WaitHandle { get; }

        public CancellationToken(bool canceled);

        public bool Equals(CancellationToken other);

        public override bool Equals(object other);

        public override int GetHashCode();

        public CancellationTokenRegistration Register(System.Action callback);

        public CancellationTokenRegistration Register(System.Action callback, bool useSynchronizationContext);

        public CancellationTokenRegistration Register(System.Action<object> callback, object state);

        public CancellationTokenRegistration Register(System.Action<object> callback, object state, bool useSynchronizationContext);

        public void ThrowIfCancellationRequested();

        public static bool operator ==(CancellationToken left, CancellationToken right);

        public static bool operator !=(CancellationToken left, CancellationToken right);
    }

    public readonly struct CancellationTokenRegistration
    {
        public CancellationToken Token { get; }

        public void Dispose();

        public override bool Equals(object obj);

        public bool Equals(CancellationTokenRegistration other);

        public override int GetHashCode();

        public static bool operator ==(CancellationTokenRegistration left, CancellationTokenRegistration right);

        public static bool operator !=(CancellationTokenRegistration left, CancellationTokenRegistration right);
    }

    [System.Runtime.InteropServices.ComVisible(false)]
    public class CancellationTokenSource : System.IDisposable
    {
        public bool IsCancellationRequested { get; }

        public CancellationToken Token { get; }

        public static CancellationTokenSource CreateLinkedTokenSource(CancellationToken token1, CancellationToken token2);

        public static CancellationTokenSource CreateLinkedTokenSource(params CancellationToken[] tokens);

        public CancellationTokenSource();

        public CancellationTokenSource(System.TimeSpan delay);

        public CancellationTokenSource(int millisecondsDelay);

        public void Cancel();

        public void Cancel(bool throwOnFirstException);

        public void CancelAfter(System.TimeSpan delay);

        public void CancelAfter(int millisecondsDelay);

        public void Dispose();

        protected virtual void Dispose(bool disposing);
    }

    [System.Runtime.InteropServices.ComVisible(false)]
    [System.Diagnostics.DebuggerDisplay("Initial Count={InitialCount}, Current Count={CurrentCount}")]
    public class CountdownEvent : System.IDisposable
    {
        public int CurrentCount { get; }

        public int InitialCount { get; }

        public bool IsSet { get; }

        public WaitHandle WaitHandle { get; }

        public CountdownEvent(int initialCount);

        public void AddCount();

        public void AddCount(int signalCount);

        public void Dispose();

        protected virtual void Dispose(bool disposing);

        public void Reset();

        public void Reset(int count);

        public bool Signal();

        public bool Signal(int signalCount);

        public bool TryAddCount();

        public bool TryAddCount(int signalCount);

        public void Wait();

        public void Wait(CancellationToken cancellationToken);

        public bool Wait(System.TimeSpan timeout);

        public bool Wait(System.TimeSpan timeout, CancellationToken cancellationToken);

        public bool Wait(int millisecondsTimeout);

        public bool Wait(int millisecondsTimeout, CancellationToken cancellationToken);
    }

    public static class LazyInitializer
    {
        public static T EnsureInitialized<T>(ref T target) where T : class;

        public static T EnsureInitialized<T>(ref T target, System.Func<T> valueFactory) where T : class;

        public static T EnsureInitialized<T>(ref T target, ref bool initialized, ref object syncLock);

        public static T EnsureInitialized<T>(ref T target, ref bool initialized, ref object syncLock, System.Func<T> valueFactory);

        public static T EnsureInitialized<T>(ref T target, ref object syncLock, System.Func<T> valueFactory) where T : class;
    }

    public enum LazyThreadSafetyMode : int
    {
        None = 0,
        PublicationOnly = 1,
        ExecutionAndPublication = 2
    }

    public class LockRecursionException : System.Exception
    {
        public LockRecursionException();

        public LockRecursionException(string message);

        public LockRecursionException(string message, System.Exception innerException);

        protected LockRecursionException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context);
    }

    [System.Runtime.InteropServices.ComVisible(false)]
    [System.Diagnostics.DebuggerDisplay("Set = {IsSet}")]
    public class ManualResetEventSlim : System.IDisposable
    {
        public bool IsSet { get; }

        public int SpinCount { get; }

        public WaitHandle WaitHandle { get; }

        public ManualResetEventSlim();

        public ManualResetEventSlim(bool initialState);

        public ManualResetEventSlim(bool initialState, int spinCount);

        public void Dispose();

        protected virtual void Dispose(bool disposing);

        public void Reset();

        public void Set();

        public void Wait();

        public void Wait(CancellationToken cancellationToken);

        public bool Wait(System.TimeSpan timeout);

        public bool Wait(System.TimeSpan timeout, CancellationToken cancellationToken);

        public bool Wait(int millisecondsTimeout);

        public bool Wait(int millisecondsTimeout, CancellationToken cancellationToken);
    }

    [System.Runtime.InteropServices.ComVisible(false)]
    [System.Diagnostics.DebuggerDisplay("Current Count = {m_currentCount}")]
    public class SemaphoreSlim : System.IDisposable
    {
        public WaitHandle AvailableWaitHandle { get; }

        public int CurrentCount { get; }

        public SemaphoreSlim(int initialCount);

        public SemaphoreSlim(int initialCount, int maxCount);

        public void Dispose();

        protected virtual void Dispose(bool disposing);

        public int Release();

        public int Release(int releaseCount);

        public void Wait();

        public void Wait(CancellationToken cancellationToken);

        public bool Wait(System.TimeSpan timeout);

        public bool Wait(System.TimeSpan timeout, CancellationToken cancellationToken);

        public bool Wait(int millisecondsTimeout);

        public bool Wait(int millisecondsTimeout, CancellationToken cancellationToken);

        public System.Threading.Tasks.Task WaitAsync();

        public System.Threading.Tasks.Task WaitAsync(CancellationToken cancellationToken);

        public System.Threading.Tasks.Task<bool> WaitAsync(int millisecondsTimeout);

        public System.Threading.Tasks.Task<bool> WaitAsync(System.TimeSpan timeout);

        public System.Threading.Tasks.Task<bool> WaitAsync(System.TimeSpan timeout, CancellationToken cancellationToken);

        public System.Threading.Tasks.Task<bool> WaitAsync(int millisecondsTimeout, CancellationToken cancellationToken);
    }

    [System.Runtime.InteropServices.ComVisible(false)]
    [System.Diagnostics.DebuggerTypeProxy(typeof(SpinLock.SystemThreading_SpinLockDebugView))]
    [System.Diagnostics.DebuggerDisplay("IsHeld = {IsHeld}")]
    public struct SpinLock
    {
        public bool IsHeld { get; }

        public bool IsHeldByCurrentThread { get; }

        public bool IsThreadOwnerTrackingEnabled { get; }

        public SpinLock(bool enableThreadOwnerTracking);

        public void Enter(ref bool lockTaken);

        public void Exit();

        public void Exit(bool useMemoryBarrier);

        public void TryEnter(ref bool lockTaken);

        public void TryEnter(System.TimeSpan timeout, ref bool lockTaken);

        public void TryEnter(int millisecondsTimeout, ref bool lockTaken);
    }

    public struct SpinWait
    {
        public int Count { get; }

        public bool NextSpinWillYield { get; }

        public static void SpinUntil(System.Func<bool> condition);

        public static bool SpinUntil(System.Func<bool> condition, System.TimeSpan timeout);

        public static bool SpinUntil(System.Func<bool> condition, int millisecondsTimeout);

        public void Reset();

        public void SpinOnce();
    }

    [System.Diagnostics.DebuggerTypeProxy(typeof(SystemThreading_ThreadLocalDebugView<>))]
    [System.Diagnostics.DebuggerDisplay("IsValueCreated={IsValueCreated}, Value={ValueForDebugDisplay}, Count={ValuesCountForDebugDisplay}")]
    public class ThreadLocal<T> : System.IDisposable
    {
        public bool IsValueCreated { get; }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public T Value { get; set; }

        public System.Collections.Generic.IList<T> Values { get; }

        public ThreadLocal();

        public ThreadLocal(bool trackAllValues);

        public ThreadLocal(System.Func<T> valueFactory);

        public ThreadLocal(System.Func<T> valueFactory, bool trackAllValues);

        public void Dispose();

        protected virtual void Dispose(bool disposing);

        protected override void Finalize();

        public override string ToString();
    }

    public static class Volatile
    {
        public static bool Read(ref bool location);

        [System.CLSCompliant(false)]
        public static sbyte Read(ref sbyte location);

        public static byte Read(ref byte location);

        public static short Read(ref short location);

        [System.CLSCompliant(false)]
        public static ushort Read(ref ushort location);

        public static int Read(ref int location);

        [System.CLSCompliant(false)]
        public static uint Read(ref uint location);

        public static long Read(ref long location);

        [System.CLSCompliant(false)]
        [System.Security.SecuritySafeCritical]
        public static ulong Read(ref ulong location);

        public static System.IntPtr Read(ref System.IntPtr location);

        [System.CLSCompliant(false)]
        public static System.UIntPtr Read(ref System.UIntPtr location);

        public static float Read(ref float location);

        public static double Read(ref double location);

        [System.Security.SecuritySafeCritical]
        public static T Read<T>(ref T location) where T : class;

        public static void Write(ref bool location, bool value);

        [System.CLSCompliant(false)]
        public static void Write(ref sbyte location, sbyte value);

        public static void Write(ref byte location, byte value);

        public static void Write(ref short location, short value);

        [System.CLSCompliant(false)]
        public static void Write(ref ushort location, ushort value);

        public static void Write(ref int location, int value);

        [System.CLSCompliant(false)]
        public static void Write(ref uint location, uint value);

        public static void Write(ref long location, long value);

        [System.CLSCompliant(false)]
        [System.Security.SecuritySafeCritical]
        public static void Write(ref ulong location, ulong value);

        public static void Write(ref System.IntPtr location, System.IntPtr value);

        [System.CLSCompliant(false)]
        public static void Write(ref System.UIntPtr location, System.UIntPtr value);

        public static void Write(ref float location, float value);

        public static void Write(ref double location, double value);

        [System.Security.SecuritySafeCritical]
        public static void Write<T>(ref T location, T value) where T : class;
    }
}
namespace System.Threading.Tasks
{
    public static class Parallel
    {
        public static ParallelLoopResult For(int fromInclusive, int toExclusive, System.Action<int> body);

        public static ParallelLoopResult For(long fromInclusive, long toExclusive, System.Action<long> body);

        public static ParallelLoopResult For(int fromInclusive, int toExclusive, ParallelOptions parallelOptions, System.Action<int> body);

        public static ParallelLoopResult For(long fromInclusive, long toExclusive, ParallelOptions parallelOptions, System.Action<long> body);

        public static ParallelLoopResult For(int fromInclusive, int toExclusive, System.Action<int, ParallelLoopState> body);

        public static ParallelLoopResult For(long fromInclusive, long toExclusive, System.Action<long, ParallelLoopState> body);

        public static ParallelLoopResult For(int fromInclusive, int toExclusive, ParallelOptions parallelOptions, System.Action<int, ParallelLoopState> body);

        public static ParallelLoopResult For(long fromInclusive, long toExclusive, ParallelOptions parallelOptions, System.Action<long, ParallelLoopState> body);

        public static ParallelLoopResult For<TLocal>(int fromInclusive, int toExclusive, System.Func<TLocal> localInit, System.Func<int, ParallelLoopState, TLocal, TLocal> body, System.Action<TLocal> localFinally);

        public static ParallelLoopResult For<TLocal>(long fromInclusive, long toExclusive, System.Func<TLocal> localInit, System.Func<long, ParallelLoopState, TLocal, TLocal> body, System.Action<TLocal> localFinally);

        public static ParallelLoopResult For<TLocal>(int fromInclusive, int toExclusive, ParallelOptions parallelOptions, System.Func<TLocal> localInit, System.Func<int, ParallelLoopState, TLocal, TLocal> body, System.Action<TLocal> localFinally);

        public static ParallelLoopResult For<TLocal>(long fromInclusive, long toExclusive, ParallelOptions parallelOptions, System.Func<TLocal> localInit, System.Func<long, ParallelLoopState, TLocal, TLocal> body, System.Action<TLocal> localFinally);

        public static ParallelLoopResult ForEach<TSource>(System.Collections.Generic.IEnumerable<TSource> source, System.Action<TSource> body);

        public static ParallelLoopResult ForEach<TSource>(System.Collections.Generic.IEnumerable<TSource> source, ParallelOptions parallelOptions, System.Action<TSource> body);

        public static ParallelLoopResult ForEach<TSource>(System.Collections.Generic.IEnumerable<TSource> source, System.Action<TSource, ParallelLoopState> body);

        public static ParallelLoopResult ForEach<TSource>(System.Collections.Generic.IEnumerable<TSource> source, ParallelOptions parallelOptions, System.Action<TSource, ParallelLoopState> body);

        public static ParallelLoopResult ForEach<TSource>(System.Collections.Generic.IEnumerable<TSource> source, System.Action<TSource, ParallelLoopState, long> body);

        public static ParallelLoopResult ForEach<TSource>(System.Collections.Generic.IEnumerable<TSource> source, ParallelOptions parallelOptions, System.Action<TSource, ParallelLoopState, long> body);

        public static ParallelLoopResult ForEach<TSource, TLocal>(System.Collections.Generic.IEnumerable<TSource> source, System.Func<TLocal> localInit, System.Func<TSource, ParallelLoopState, TLocal, TLocal> body, System.Action<TLocal> localFinally);

        public static ParallelLoopResult ForEach<TSource, TLocal>(System.Collections.Generic.IEnumerable<TSource> source, ParallelOptions parallelOptions, System.Func<TLocal> localInit, System.Func<TSource, ParallelLoopState, TLocal, TLocal> body, System.Action<TLocal> localFinally);

        public static ParallelLoopResult ForEach<TSource, TLocal>(System.Collections.Generic.IEnumerable<TSource> source, System.Func<TLocal> localInit, System.Func<TSource, ParallelLoopState, long, TLocal, TLocal> body, System.Action<TLocal> localFinally);

        public static ParallelLoopResult ForEach<TSource, TLocal>(System.Collections.Generic.IEnumerable<TSource> source, ParallelOptions parallelOptions, System.Func<TLocal> localInit, System.Func<TSource, ParallelLoopState, long, TLocal, TLocal> body, System.Action<TLocal> localFinally);

        public static ParallelLoopResult ForEach<TSource>(System.Collections.Concurrent.Partitioner<TSource> source, System.Action<TSource> body);

        public static ParallelLoopResult ForEach<TSource>(System.Collections.Concurrent.Partitioner<TSource> source, System.Action<TSource, ParallelLoopState> body);

        public static ParallelLoopResult ForEach<TSource>(System.Collections.Concurrent.OrderablePartitioner<TSource> source, System.Action<TSource, ParallelLoopState, long> body);

        public static ParallelLoopResult ForEach<TSource, TLocal>(System.Collections.Concurrent.Partitioner<TSource> source, System.Func<TLocal> localInit, System.Func<TSource, ParallelLoopState, TLocal, TLocal> body, System.Action<TLocal> localFinally);

        public static ParallelLoopResult ForEach<TSource, TLocal>(System.Collections.Concurrent.OrderablePartitioner<TSource> source, System.Func<TLocal> localInit, System.Func<TSource, ParallelLoopState, long, TLocal, TLocal> body, System.Action<TLocal> localFinally);

        public static ParallelLoopResult ForEach<TSource>(System.Collections.Concurrent.Partitioner<TSource> source, ParallelOptions parallelOptions, System.Action<TSource> body);

        public static ParallelLoopResult ForEach<TSource>(System.Collections.Concurrent.Partitioner<TSource> source, ParallelOptions parallelOptions, System.Action<TSource, ParallelLoopState> body);

        public static ParallelLoopResult ForEach<TSource>(System.Collections.Concurrent.OrderablePartitioner<TSource> source, ParallelOptions parallelOptions, System.Action<TSource, ParallelLoopState, long> body);

        public static ParallelLoopResult ForEach<TSource, TLocal>(System.Collections.Concurrent.Partitioner<TSource> source, ParallelOptions parallelOptions, System.Func<TLocal> localInit, System.Func<TSource, ParallelLoopState, TLocal, TLocal> body, System.Action<TLocal> localFinally);

        public static ParallelLoopResult ForEach<TSource, TLocal>(System.Collections.Concurrent.OrderablePartitioner<TSource> source, ParallelOptions parallelOptions, System.Func<TLocal> localInit, System.Func<TSource, ParallelLoopState, long, TLocal, TLocal> body, System.Action<TLocal> localFinally);

        public static void Invoke(params System.Action[] actions);

        public static void Invoke(ParallelOptions parallelOptions, params System.Action[] actions);
    }

    public struct ParallelLoopResult
    {
        public bool IsCompleted { get; }

        public long? LowestBreakIteration { get; }
    }

    [System.Diagnostics.DebuggerDisplay("ShouldExitCurrentIteration = {ShouldExitCurrentIteration}")]
    public class ParallelLoopState
    {
        public bool IsExceptional { get; }

        public bool IsStopped { get; }

        public long? LowestBreakIteration { get; }

        public bool ShouldExitCurrentIteration { get; }

        public void Break();

        public void Stop();
    }

    public class ParallelOptions
    {
        public System.Threading.CancellationToken CancellationToken { get; set; }

        public int MaxDegreeOfParallelism { get; set; }

        public TaskScheduler TaskScheduler { get; set; }

        public ParallelOptions();
    }

    [System.Diagnostics.DebuggerTypeProxy(typeof(SystemThreadingTasks_TaskDebugView))]
    [System.Diagnostics.DebuggerDisplay("Id = {Id}, Status = {Status}, Method = {DebuggerDisplayMethodDescription}")]
    public class Task : System.IAsyncResult, System.IDisposable
    {
        public static Task CompletedTask { get; }

        public static int? CurrentId { get; }

        public static TaskFactory Factory { get; }

        public object AsyncState { get; }

        public TaskCreationOptions CreationOptions { get; }

        public System.AggregateException Exception { get; }

        public int Id { get; }

        public bool IsCanceled { get; }

        public bool IsCompleted { get; }

        public bool IsCompletedSuccessfully { get; }

        public bool IsFaulted { get; }

        public TaskStatus Status { get; }

        public static Task Delay(System.TimeSpan delay);

        public static Task Delay(System.TimeSpan delay, System.Threading.CancellationToken cancellationToken);

        public static Task Delay(int millisecondsDelay);

        public static Task Delay(int millisecondsDelay, System.Threading.CancellationToken cancellationToken);

        public static Task FromCanceled(System.Threading.CancellationToken cancellationToken);

        public static Task<TResult> FromCanceled<TResult>(System.Threading.CancellationToken cancellationToken);

        public static Task FromException(System.Exception exception);

        public static Task<TResult> FromException<TResult>(System.Exception exception);

        public static Task<TResult> FromResult<TResult>(TResult result);

        public static Task Run(System.Action action);

        public static Task Run(System.Action action, System.Threading.CancellationToken cancellationToken);

        public static Task<TResult> Run<TResult>(System.Func<TResult> function);

        public static Task<TResult> Run<TResult>(System.Func<TResult> function, System.Threading.CancellationToken cancellationToken);

        public static Task Run(System.Func<Task> function);

        public static Task Run(System.Func<Task> function, System.Threading.CancellationToken cancellationToken);

        public static Task<TResult> Run<TResult>(System.Func<Task<TResult>> function);

        public static Task<TResult> Run<TResult>(System.Func<Task<TResult>> function, System.Threading.CancellationToken cancellationToken);

        public static void WaitAll(params Task[] tasks);

        public static bool WaitAll(Task[] tasks, System.TimeSpan timeout);

        public static bool WaitAll(Task[] tasks, int millisecondsTimeout);

        public static void WaitAll(Task[] tasks, System.Threading.CancellationToken cancellationToken);

        public static bool WaitAll(Task[] tasks, int millisecondsTimeout, System.Threading.CancellationToken cancellationToken);

        public static int WaitAny(params Task[] tasks);

        public static int WaitAny(Task[] tasks, System.TimeSpan timeout);

        public static int WaitAny(Task[] tasks, System.Threading.CancellationToken cancellationToken);

        public static int WaitAny(Task[] tasks, int millisecondsTimeout);

        public static int WaitAny(Task[] tasks, int millisecondsTimeout, System.Threading.CancellationToken cancellationToken);

        public static Task WhenAll(System.Collections.Generic.IEnumerable<Task> tasks);

        public static Task WhenAll(params Task[] tasks);

        public static Task<TResult[]> WhenAll<TResult>(System.Collections.Generic.IEnumerable<Task<TResult>> tasks);

        public static Task<TResult[]> WhenAll<TResult>(params Task<TResult>[] tasks);

        public static Task<Task> WhenAny(params Task[] tasks);

        public static Task<Task> WhenAny(System.Collections.Generic.IEnumerable<Task> tasks);

        public static Task<Task<TResult>> WhenAny<TResult>(params Task<TResult>[] tasks);

        public static Task<Task<TResult>> WhenAny<TResult>(System.Collections.Generic.IEnumerable<Task<TResult>> tasks);

        public static System.Runtime.CompilerServices.YieldAwaitable Yield();

        public Task(System.Action action);

        public Task(System.Action action, System.Threading.CancellationToken cancellationToken);

        public Task(System.Action action, TaskCreationOptions creationOptions);

        public Task(System.Action action, System.Threading.CancellationToken cancellationToken, TaskCreationOptions creationOptions);

        public Task(System.Action<object> action, object state);

        public Task(System.Action<object> action, object state, System.Threading.CancellationToken cancellationToken);

        public Task(System.Action<object> action, object state, TaskCreationOptions creationOptions);

        public Task(System.Action<object> action, object state, System.Threading.CancellationToken cancellationToken, TaskCreationOptions creationOptions);

        public System.Runtime.CompilerServices.ConfiguredTaskAwaitable ConfigureAwait(bool continueOnCapturedContext);

        public Task ContinueWith(System.Action<Task> continuationAction);

        public Task ContinueWith(System.Action<Task> continuationAction, System.Threading.CancellationToken cancellationToken);

        public Task ContinueWith(System.Action<Task> continuationAction, TaskScheduler scheduler);

        public Task ContinueWith(System.Action<Task> continuationAction, TaskContinuationOptions continuationOptions);

        public Task ContinueWith(System.Action<Task> continuationAction, System.Threading.CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public Task ContinueWith(System.Action<Task, object> continuationAction, object state);

        public Task ContinueWith(System.Action<Task, object> continuationAction, object state, System.Threading.CancellationToken cancellationToken);

        public Task ContinueWith(System.Action<Task, object> continuationAction, object state, TaskScheduler scheduler);

        public Task ContinueWith(System.Action<Task, object> continuationAction, object state, TaskContinuationOptions continuationOptions);

        public Task ContinueWith(System.Action<Task, object> continuationAction, object state, System.Threading.CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public Task<TResult> ContinueWith<TResult>(System.Func<Task, TResult> continuationFunction);

        public Task<TResult> ContinueWith<TResult>(System.Func<Task, TResult> continuationFunction, System.Threading.CancellationToken cancellationToken);

        public Task<TResult> ContinueWith<TResult>(System.Func<Task, TResult> continuationFunction, TaskScheduler scheduler);

        public Task<TResult> ContinueWith<TResult>(System.Func<Task, TResult> continuationFunction, TaskContinuationOptions continuationOptions);

        public Task<TResult> ContinueWith<TResult>(System.Func<Task, TResult> continuationFunction, System.Threading.CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public Task<TResult> ContinueWith<TResult>(System.Func<Task, object, TResult> continuationFunction, object state);

        public Task<TResult> ContinueWith<TResult>(System.Func<Task, object, TResult> continuationFunction, object state, System.Threading.CancellationToken cancellationToken);

        public Task<TResult> ContinueWith<TResult>(System.Func<Task, object, TResult> continuationFunction, object state, TaskScheduler scheduler);

        public Task<TResult> ContinueWith<TResult>(System.Func<Task, object, TResult> continuationFunction, object state, TaskContinuationOptions continuationOptions);

        public Task<TResult> ContinueWith<TResult>(System.Func<Task, object, TResult> continuationFunction, object state, System.Threading.CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public void Dispose();

        protected virtual void Dispose(bool disposing);

        public System.Runtime.CompilerServices.TaskAwaiter GetAwaiter();

        public void RunSynchronously();

        public void RunSynchronously(TaskScheduler scheduler);

        public void Start();

        public void Start(TaskScheduler scheduler);

        public void Wait();

        public bool Wait(System.TimeSpan timeout);

        public void Wait(System.Threading.CancellationToken cancellationToken);

        public bool Wait(int millisecondsTimeout);

        public bool Wait(int millisecondsTimeout, System.Threading.CancellationToken cancellationToken);
    }

    [System.Diagnostics.DebuggerTypeProxy(typeof(SystemThreadingTasks_FutureDebugView<>))]
    [System.Diagnostics.DebuggerDisplay("Id = {Id}, Status = {Status}, Method = {DebuggerDisplayMethodDescription}, Result = {DebuggerDisplayResultDescription}")]
    public class Task<TResult> : Task
    {
        public static TaskFactory<TResult> Factory { get; }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public TResult Result { get; }

        public Task(System.Func<TResult> function);

        public Task(System.Func<TResult> function, System.Threading.CancellationToken cancellationToken);

        public Task(System.Func<TResult> function, TaskCreationOptions creationOptions);

        public Task(System.Func<TResult> function, System.Threading.CancellationToken cancellationToken, TaskCreationOptions creationOptions);

        public Task(System.Func<object, TResult> function, object state);

        public Task(System.Func<object, TResult> function, object state, System.Threading.CancellationToken cancellationToken);

        public Task(System.Func<object, TResult> function, object state, TaskCreationOptions creationOptions);

        public Task(System.Func<object, TResult> function, object state, System.Threading.CancellationToken cancellationToken, TaskCreationOptions creationOptions);

        public System.Runtime.CompilerServices.ConfiguredTaskAwaitable<TResult> ConfigureAwait(bool continueOnCapturedContext);

        public Task ContinueWith(System.Action<Task<TResult>> continuationAction);

        public Task ContinueWith(System.Action<Task<TResult>> continuationAction, System.Threading.CancellationToken cancellationToken);

        public Task ContinueWith(System.Action<Task<TResult>> continuationAction, TaskScheduler scheduler);

        public Task ContinueWith(System.Action<Task<TResult>> continuationAction, TaskContinuationOptions continuationOptions);

        public Task ContinueWith(System.Action<Task<TResult>> continuationAction, System.Threading.CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public Task ContinueWith(System.Action<Task<TResult>, object> continuationAction, object state);

        public Task ContinueWith(System.Action<Task<TResult>, object> continuationAction, object state, System.Threading.CancellationToken cancellationToken);

        public Task ContinueWith(System.Action<Task<TResult>, object> continuationAction, object state, TaskScheduler scheduler);

        public Task ContinueWith(System.Action<Task<TResult>, object> continuationAction, object state, TaskContinuationOptions continuationOptions);

        public Task ContinueWith(System.Action<Task<TResult>, object> continuationAction, object state, System.Threading.CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public Task<TNewResult> ContinueWith<TNewResult>(System.Func<Task<TResult>, TNewResult> continuationFunction);

        public Task<TNewResult> ContinueWith<TNewResult>(System.Func<Task<TResult>, TNewResult> continuationFunction, System.Threading.CancellationToken cancellationToken);

        public Task<TNewResult> ContinueWith<TNewResult>(System.Func<Task<TResult>, TNewResult> continuationFunction, TaskScheduler scheduler);

        public Task<TNewResult> ContinueWith<TNewResult>(System.Func<Task<TResult>, TNewResult> continuationFunction, TaskContinuationOptions continuationOptions);

        public Task<TNewResult> ContinueWith<TNewResult>(System.Func<Task<TResult>, TNewResult> continuationFunction, System.Threading.CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public Task<TNewResult> ContinueWith<TNewResult>(System.Func<Task<TResult>, object, TNewResult> continuationFunction, object state);

        public Task<TNewResult> ContinueWith<TNewResult>(System.Func<Task<TResult>, object, TNewResult> continuationFunction, object state, System.Threading.CancellationToken cancellationToken);

        public Task<TNewResult> ContinueWith<TNewResult>(System.Func<Task<TResult>, object, TNewResult> continuationFunction, object state, TaskScheduler scheduler);

        public Task<TNewResult> ContinueWith<TNewResult>(System.Func<Task<TResult>, object, TNewResult> continuationFunction, object state, TaskContinuationOptions continuationOptions);

        public Task<TNewResult> ContinueWith<TNewResult>(System.Func<Task<TResult>, object, TNewResult> continuationFunction, object state, System.Threading.CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public System.Runtime.CompilerServices.TaskAwaiter<TResult> GetAwaiter();
    }

    public class TaskCanceledException : System.OperationCanceledException
    {
        public Task Task { get; }

        public TaskCanceledException();

        public TaskCanceledException(string message);

        public TaskCanceledException(string message, System.Exception innerException);

        public TaskCanceledException(string message, System.Exception innerException, System.Threading.CancellationToken token);

        public TaskCanceledException(Task task);

        protected TaskCanceledException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context);
    }

    public class TaskCompletionSource<TResult>
    {
        public Task<TResult> Task { get; }

        public TaskCompletionSource();

        public TaskCompletionSource(TaskCreationOptions creationOptions);

        public TaskCompletionSource(object state);

        public TaskCompletionSource(object state, TaskCreationOptions creationOptions);

        public void SetCanceled();

        public void SetException(System.Exception exception);

        public void SetException(System.Collections.Generic.IEnumerable<System.Exception> exceptions);

        public void SetResult(TResult result);

        public bool TrySetCanceled();

        public bool TrySetCanceled(System.Threading.CancellationToken cancellationToken);

        public bool TrySetException(System.Exception exception);

        public bool TrySetException(System.Collections.Generic.IEnumerable<System.Exception> exceptions);

        public bool TrySetResult(TResult result);
    }

    [System.Flags]
    public enum TaskContinuationOptions : int
    {
        None = 0,
        PreferFairness = 1,
        LongRunning = 2,
        AttachedToParent = 4,
        DenyChildAttach = 8,
        HideScheduler = 16,
        LazyCancellation = 32,
        RunContinuationsAsynchronously = 64,
        NotOnRanToCompletion = 65_536,
        NotOnFaulted = 131_072,
        OnlyOnCanceled = 196_608,
        NotOnCanceled = 262_144,
        OnlyOnFaulted = 327_680,
        OnlyOnRanToCompletion = 393_216,
        ExecuteSynchronously = 524_288
    }

    [System.Flags]
    public enum TaskCreationOptions : int
    {
        None = 0,
        PreferFairness = 1,
        LongRunning = 2,
        AttachedToParent = 4,
        DenyChildAttach = 8,
        HideScheduler = 16,
        RunContinuationsAsynchronously = 64
    }

    public static class TaskExtensions
    {
        public static Task Unwrap(this Task<Task> task);

        public static Task<TResult> Unwrap<TResult>(this Task<Task<TResult>> task);
    }

    public class TaskFactory
    {
        public System.Threading.CancellationToken CancellationToken { get; }

        public TaskContinuationOptions ContinuationOptions { get; }

        public TaskCreationOptions CreationOptions { get; }

        public TaskScheduler Scheduler { get; }

        public TaskFactory();

        public TaskFactory(System.Threading.CancellationToken cancellationToken);

        public TaskFactory(TaskScheduler scheduler);

        public TaskFactory(TaskCreationOptions creationOptions, TaskContinuationOptions continuationOptions);

        public TaskFactory(System.Threading.CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public Task ContinueWhenAll(Task[] tasks, System.Action<Task[]> continuationAction);

        public Task ContinueWhenAll(Task[] tasks, System.Action<Task[]> continuationAction, System.Threading.CancellationToken cancellationToken);

        public Task ContinueWhenAll(Task[] tasks, System.Action<Task[]> continuationAction, TaskContinuationOptions continuationOptions);

        public Task ContinueWhenAll(Task[] tasks, System.Action<Task[]> continuationAction, System.Threading.CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public Task ContinueWhenAll<TAntecedentResult>(Task<TAntecedentResult>[] tasks, System.Action<Task<TAntecedentResult>[]> continuationAction);

        public Task ContinueWhenAll<TAntecedentResult>(Task<TAntecedentResult>[] tasks, System.Action<Task<TAntecedentResult>[]> continuationAction, System.Threading.CancellationToken cancellationToken);

        public Task ContinueWhenAll<TAntecedentResult>(Task<TAntecedentResult>[] tasks, System.Action<Task<TAntecedentResult>[]> continuationAction, TaskContinuationOptions continuationOptions);

        public Task ContinueWhenAll<TAntecedentResult>(Task<TAntecedentResult>[] tasks, System.Action<Task<TAntecedentResult>[]> continuationAction, System.Threading.CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public Task<TResult> ContinueWhenAll<TResult>(Task[] tasks, System.Func<Task[], TResult> continuationFunction);

        public Task<TResult> ContinueWhenAll<TResult>(Task[] tasks, System.Func<Task[], TResult> continuationFunction, System.Threading.CancellationToken cancellationToken);

        public Task<TResult> ContinueWhenAll<TResult>(Task[] tasks, System.Func<Task[], TResult> continuationFunction, TaskContinuationOptions continuationOptions);

        public Task<TResult> ContinueWhenAll<TResult>(Task[] tasks, System.Func<Task[], TResult> continuationFunction, System.Threading.CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public Task<TResult> ContinueWhenAll<TAntecedentResult, TResult>(Task<TAntecedentResult>[] tasks, System.Func<Task<TAntecedentResult>[], TResult> continuationFunction);

        public Task<TResult> ContinueWhenAll<TAntecedentResult, TResult>(Task<TAntecedentResult>[] tasks, System.Func<Task<TAntecedentResult>[], TResult> continuationFunction, System.Threading.CancellationToken cancellationToken);

        public Task<TResult> ContinueWhenAll<TAntecedentResult, TResult>(Task<TAntecedentResult>[] tasks, System.Func<Task<TAntecedentResult>[], TResult> continuationFunction, TaskContinuationOptions continuationOptions);

        public Task<TResult> ContinueWhenAll<TAntecedentResult, TResult>(Task<TAntecedentResult>[] tasks, System.Func<Task<TAntecedentResult>[], TResult> continuationFunction, System.Threading.CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public Task ContinueWhenAny(Task[] tasks, System.Action<Task> continuationAction);

        public Task ContinueWhenAny(Task[] tasks, System.Action<Task> continuationAction, System.Threading.CancellationToken cancellationToken);

        public Task ContinueWhenAny(Task[] tasks, System.Action<Task> continuationAction, TaskContinuationOptions continuationOptions);

        public Task ContinueWhenAny(Task[] tasks, System.Action<Task> continuationAction, System.Threading.CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public Task<TResult> ContinueWhenAny<TResult>(Task[] tasks, System.Func<Task, TResult> continuationFunction);

        public Task<TResult> ContinueWhenAny<TResult>(Task[] tasks, System.Func<Task, TResult> continuationFunction, System.Threading.CancellationToken cancellationToken);

        public Task<TResult> ContinueWhenAny<TResult>(Task[] tasks, System.Func<Task, TResult> continuationFunction, TaskContinuationOptions continuationOptions);

        public Task<TResult> ContinueWhenAny<TResult>(Task[] tasks, System.Func<Task, TResult> continuationFunction, System.Threading.CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public Task<TResult> ContinueWhenAny<TAntecedentResult, TResult>(Task<TAntecedentResult>[] tasks, System.Func<Task<TAntecedentResult>, TResult> continuationFunction);

        public Task<TResult> ContinueWhenAny<TAntecedentResult, TResult>(Task<TAntecedentResult>[] tasks, System.Func<Task<TAntecedentResult>, TResult> continuationFunction, System.Threading.CancellationToken cancellationToken);

        public Task<TResult> ContinueWhenAny<TAntecedentResult, TResult>(Task<TAntecedentResult>[] tasks, System.Func<Task<TAntecedentResult>, TResult> continuationFunction, TaskContinuationOptions continuationOptions);

        public Task<TResult> ContinueWhenAny<TAntecedentResult, TResult>(Task<TAntecedentResult>[] tasks, System.Func<Task<TAntecedentResult>, TResult> continuationFunction, System.Threading.CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public Task ContinueWhenAny<TAntecedentResult>(Task<TAntecedentResult>[] tasks, System.Action<Task<TAntecedentResult>> continuationAction);

        public Task ContinueWhenAny<TAntecedentResult>(Task<TAntecedentResult>[] tasks, System.Action<Task<TAntecedentResult>> continuationAction, System.Threading.CancellationToken cancellationToken);

        public Task ContinueWhenAny<TAntecedentResult>(Task<TAntecedentResult>[] tasks, System.Action<Task<TAntecedentResult>> continuationAction, TaskContinuationOptions continuationOptions);

        public Task ContinueWhenAny<TAntecedentResult>(Task<TAntecedentResult>[] tasks, System.Action<Task<TAntecedentResult>> continuationAction, System.Threading.CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public Task FromAsync(System.IAsyncResult asyncResult, System.Action<System.IAsyncResult> endMethod);

        public Task FromAsync(System.IAsyncResult asyncResult, System.Action<System.IAsyncResult> endMethod, TaskCreationOptions creationOptions);

        public Task FromAsync(System.IAsyncResult asyncResult, System.Action<System.IAsyncResult> endMethod, TaskCreationOptions creationOptions, TaskScheduler scheduler);

        public Task FromAsync(System.Func<System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Action<System.IAsyncResult> endMethod, object state);

        public Task FromAsync(System.Func<System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Action<System.IAsyncResult> endMethod, object state, TaskCreationOptions creationOptions);

        public Task FromAsync<TArg1>(System.Func<TArg1, System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Action<System.IAsyncResult> endMethod, TArg1 arg1, object state);

        public Task FromAsync<TArg1>(System.Func<TArg1, System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Action<System.IAsyncResult> endMethod, TArg1 arg1, object state, TaskCreationOptions creationOptions);

        public Task FromAsync<TArg1, TArg2>(System.Func<TArg1, TArg2, System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Action<System.IAsyncResult> endMethod, TArg1 arg1, TArg2 arg2, object state);

        public Task FromAsync<TArg1, TArg2>(System.Func<TArg1, TArg2, System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Action<System.IAsyncResult> endMethod, TArg1 arg1, TArg2 arg2, object state, TaskCreationOptions creationOptions);

        public Task FromAsync<TArg1, TArg2, TArg3>(System.Func<TArg1, TArg2, TArg3, System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Action<System.IAsyncResult> endMethod, TArg1 arg1, TArg2 arg2, TArg3 arg3, object state);

        public Task FromAsync<TArg1, TArg2, TArg3>(System.Func<TArg1, TArg2, TArg3, System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Action<System.IAsyncResult> endMethod, TArg1 arg1, TArg2 arg2, TArg3 arg3, object state, TaskCreationOptions creationOptions);

        public Task<TResult> FromAsync<TResult>(System.IAsyncResult asyncResult, System.Func<System.IAsyncResult, TResult> endMethod);

        public Task<TResult> FromAsync<TResult>(System.IAsyncResult asyncResult, System.Func<System.IAsyncResult, TResult> endMethod, TaskCreationOptions creationOptions);

        public Task<TResult> FromAsync<TResult>(System.IAsyncResult asyncResult, System.Func<System.IAsyncResult, TResult> endMethod, TaskCreationOptions creationOptions, TaskScheduler scheduler);

        public Task<TResult> FromAsync<TResult>(System.Func<System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Func<System.IAsyncResult, TResult> endMethod, object state);

        public Task<TResult> FromAsync<TResult>(System.Func<System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Func<System.IAsyncResult, TResult> endMethod, object state, TaskCreationOptions creationOptions);

        public Task<TResult> FromAsync<TArg1, TResult>(System.Func<TArg1, System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Func<System.IAsyncResult, TResult> endMethod, TArg1 arg1, object state);

        public Task<TResult> FromAsync<TArg1, TResult>(System.Func<TArg1, System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Func<System.IAsyncResult, TResult> endMethod, TArg1 arg1, object state, TaskCreationOptions creationOptions);

        public Task<TResult> FromAsync<TArg1, TArg2, TResult>(System.Func<TArg1, TArg2, System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Func<System.IAsyncResult, TResult> endMethod, TArg1 arg1, TArg2 arg2, object state);

        public Task<TResult> FromAsync<TArg1, TArg2, TResult>(System.Func<TArg1, TArg2, System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Func<System.IAsyncResult, TResult> endMethod, TArg1 arg1, TArg2 arg2, object state, TaskCreationOptions creationOptions);

        public Task<TResult> FromAsync<TArg1, TArg2, TArg3, TResult>(System.Func<TArg1, TArg2, TArg3, System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Func<System.IAsyncResult, TResult> endMethod, TArg1 arg1, TArg2 arg2, TArg3 arg3, object state);

        public Task<TResult> FromAsync<TArg1, TArg2, TArg3, TResult>(System.Func<TArg1, TArg2, TArg3, System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Func<System.IAsyncResult, TResult> endMethod, TArg1 arg1, TArg2 arg2, TArg3 arg3, object state, TaskCreationOptions creationOptions);

        public Task StartNew(System.Action action);

        public Task StartNew(System.Action action, System.Threading.CancellationToken cancellationToken);

        public Task StartNew(System.Action action, TaskCreationOptions creationOptions);

        public Task StartNew(System.Action action, System.Threading.CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskScheduler scheduler);

        public Task StartNew(System.Action<object> action, object state);

        public Task StartNew(System.Action<object> action, object state, System.Threading.CancellationToken cancellationToken);

        public Task StartNew(System.Action<object> action, object state, TaskCreationOptions creationOptions);

        public Task StartNew(System.Action<object> action, object state, System.Threading.CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskScheduler scheduler);

        public Task<TResult> StartNew<TResult>(System.Func<TResult> function);

        public Task<TResult> StartNew<TResult>(System.Func<TResult> function, System.Threading.CancellationToken cancellationToken);

        public Task<TResult> StartNew<TResult>(System.Func<TResult> function, TaskCreationOptions creationOptions);

        public Task<TResult> StartNew<TResult>(System.Func<TResult> function, System.Threading.CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskScheduler scheduler);

        public Task<TResult> StartNew<TResult>(System.Func<object, TResult> function, object state);

        public Task<TResult> StartNew<TResult>(System.Func<object, TResult> function, object state, System.Threading.CancellationToken cancellationToken);

        public Task<TResult> StartNew<TResult>(System.Func<object, TResult> function, object state, TaskCreationOptions creationOptions);

        public Task<TResult> StartNew<TResult>(System.Func<object, TResult> function, object state, System.Threading.CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskScheduler scheduler);
    }

    public class TaskFactory<TResult>
    {
        public System.Threading.CancellationToken CancellationToken { get; }

        public TaskContinuationOptions ContinuationOptions { get; }

        public TaskCreationOptions CreationOptions { get; }

        public TaskScheduler Scheduler { get; }

        public TaskFactory();

        public TaskFactory(System.Threading.CancellationToken cancellationToken);

        public TaskFactory(TaskScheduler scheduler);

        public TaskFactory(TaskCreationOptions creationOptions, TaskContinuationOptions continuationOptions);

        public TaskFactory(System.Threading.CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public Task<TResult> ContinueWhenAll(Task[] tasks, System.Func<Task[], TResult> continuationFunction);

        public Task<TResult> ContinueWhenAll(Task[] tasks, System.Func<Task[], TResult> continuationFunction, System.Threading.CancellationToken cancellationToken);

        public Task<TResult> ContinueWhenAll(Task[] tasks, System.Func<Task[], TResult> continuationFunction, TaskContinuationOptions continuationOptions);

        public Task<TResult> ContinueWhenAll(Task[] tasks, System.Func<Task[], TResult> continuationFunction, System.Threading.CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public Task<TResult> ContinueWhenAll<TAntecedentResult>(Task<TAntecedentResult>[] tasks, System.Func<Task<TAntecedentResult>[], TResult> continuationFunction);

        public Task<TResult> ContinueWhenAll<TAntecedentResult>(Task<TAntecedentResult>[] tasks, System.Func<Task<TAntecedentResult>[], TResult> continuationFunction, System.Threading.CancellationToken cancellationToken);

        public Task<TResult> ContinueWhenAll<TAntecedentResult>(Task<TAntecedentResult>[] tasks, System.Func<Task<TAntecedentResult>[], TResult> continuationFunction, TaskContinuationOptions continuationOptions);

        public Task<TResult> ContinueWhenAll<TAntecedentResult>(Task<TAntecedentResult>[] tasks, System.Func<Task<TAntecedentResult>[], TResult> continuationFunction, System.Threading.CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public Task<TResult> ContinueWhenAny(Task[] tasks, System.Func<Task, TResult> continuationFunction);

        public Task<TResult> ContinueWhenAny(Task[] tasks, System.Func<Task, TResult> continuationFunction, System.Threading.CancellationToken cancellationToken);

        public Task<TResult> ContinueWhenAny(Task[] tasks, System.Func<Task, TResult> continuationFunction, TaskContinuationOptions continuationOptions);

        public Task<TResult> ContinueWhenAny(Task[] tasks, System.Func<Task, TResult> continuationFunction, System.Threading.CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public Task<TResult> ContinueWhenAny<TAntecedentResult>(Task<TAntecedentResult>[] tasks, System.Func<Task<TAntecedentResult>, TResult> continuationFunction);

        public Task<TResult> ContinueWhenAny<TAntecedentResult>(Task<TAntecedentResult>[] tasks, System.Func<Task<TAntecedentResult>, TResult> continuationFunction, System.Threading.CancellationToken cancellationToken);

        public Task<TResult> ContinueWhenAny<TAntecedentResult>(Task<TAntecedentResult>[] tasks, System.Func<Task<TAntecedentResult>, TResult> continuationFunction, TaskContinuationOptions continuationOptions);

        public Task<TResult> ContinueWhenAny<TAntecedentResult>(Task<TAntecedentResult>[] tasks, System.Func<Task<TAntecedentResult>, TResult> continuationFunction, System.Threading.CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);

        public Task<TResult> FromAsync(System.IAsyncResult asyncResult, System.Func<System.IAsyncResult, TResult> endMethod);

        public Task<TResult> FromAsync(System.IAsyncResult asyncResult, System.Func<System.IAsyncResult, TResult> endMethod, TaskCreationOptions creationOptions);

        public Task<TResult> FromAsync(System.IAsyncResult asyncResult, System.Func<System.IAsyncResult, TResult> endMethod, TaskCreationOptions creationOptions, TaskScheduler scheduler);

        public Task<TResult> FromAsync(System.Func<System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Func<System.IAsyncResult, TResult> endMethod, object state);

        public Task<TResult> FromAsync(System.Func<System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Func<System.IAsyncResult, TResult> endMethod, object state, TaskCreationOptions creationOptions);

        public Task<TResult> FromAsync<TArg1>(System.Func<TArg1, System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Func<System.IAsyncResult, TResult> endMethod, TArg1 arg1, object state);

        public Task<TResult> FromAsync<TArg1>(System.Func<TArg1, System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Func<System.IAsyncResult, TResult> endMethod, TArg1 arg1, object state, TaskCreationOptions creationOptions);

        public Task<TResult> FromAsync<TArg1, TArg2>(System.Func<TArg1, TArg2, System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Func<System.IAsyncResult, TResult> endMethod, TArg1 arg1, TArg2 arg2, object state);

        public Task<TResult> FromAsync<TArg1, TArg2>(System.Func<TArg1, TArg2, System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Func<System.IAsyncResult, TResult> endMethod, TArg1 arg1, TArg2 arg2, object state, TaskCreationOptions creationOptions);

        public Task<TResult> FromAsync<TArg1, TArg2, TArg3>(System.Func<TArg1, TArg2, TArg3, System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Func<System.IAsyncResult, TResult> endMethod, TArg1 arg1, TArg2 arg2, TArg3 arg3, object state);

        public Task<TResult> FromAsync<TArg1, TArg2, TArg3>(System.Func<TArg1, TArg2, TArg3, System.AsyncCallback, object, System.IAsyncResult> beginMethod, System.Func<System.IAsyncResult, TResult> endMethod, TArg1 arg1, TArg2 arg2, TArg3 arg3, object state, TaskCreationOptions creationOptions);

        public Task<TResult> StartNew(System.Func<TResult> function);

        public Task<TResult> StartNew(System.Func<TResult> function, System.Threading.CancellationToken cancellationToken);

        public Task<TResult> StartNew(System.Func<TResult> function, TaskCreationOptions creationOptions);

        public Task<TResult> StartNew(System.Func<TResult> function, System.Threading.CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskScheduler scheduler);

        public Task<TResult> StartNew(System.Func<object, TResult> function, object state);

        public Task<TResult> StartNew(System.Func<object, TResult> function, object state, System.Threading.CancellationToken cancellationToken);

        public Task<TResult> StartNew(System.Func<object, TResult> function, object state, TaskCreationOptions creationOptions);

        public Task<TResult> StartNew(System.Func<object, TResult> function, object state, System.Threading.CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskScheduler scheduler);
    }

    [System.Diagnostics.DebuggerDisplay("Id={Id}")]
    [System.Diagnostics.DebuggerTypeProxy(typeof(TaskScheduler.SystemThreadingTasks_TaskSchedulerDebugView))]
    public abstract class TaskScheduler
    {
        public static TaskScheduler Current { get; }

        public static TaskScheduler Default { get; }

        public int Id { get; }

        public virtual int MaximumConcurrencyLevel { get; }

        public static event System.EventHandler<UnobservedTaskExceptionEventArgs> UnobservedTaskException;

        public static TaskScheduler FromCurrentSynchronizationContext();

        protected TaskScheduler();

        [System.Security.SecurityCritical]
        protected abstract System.Collections.Generic.IEnumerable<Task> GetScheduledTasks();

        [System.Security.SecurityCritical]
        protected abstract void QueueTask(Task task);

        [System.Security.SecurityCritical]
        protected virtual bool TryDequeue(Task task);

        [System.Security.SecurityCritical]
        protected bool TryExecuteTask(Task task);

        [System.Security.SecurityCritical]
        protected abstract bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued);
    }

    public class TaskSchedulerException : System.Exception
    {
        public TaskSchedulerException();

        public TaskSchedulerException(string message);

        public TaskSchedulerException(System.Exception innerException);

        public TaskSchedulerException(string message, System.Exception innerException);

        protected TaskSchedulerException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context);
    }

    public enum TaskStatus : int
    {
        Created = 0,
        WaitingForActivation = 1,
        WaitingToRun = 2,
        Running = 3,
        WaitingForChildrenToComplete = 4,
        RanToCompletion = 5,
        Canceled = 6,
        Faulted = 7
    }

    public class UnobservedTaskExceptionEventArgs : System.EventArgs
    {
        public System.AggregateException Exception { get; }

        public bool Observed { get; }

        public UnobservedTaskExceptionEventArgs(System.AggregateException exception);

        public void SetObserved();
    }
}
