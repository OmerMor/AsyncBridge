// ReSharper disable InconsistentNaming

namespace System
{
    internal static class SR
    {
        public const string AggregateException_DeserializationFailure = "The serialization stream contains no inner exceptions.";
        public const string AggregateException_InnerException = "(Inner Exception #{0}) ";
        public const string AggregateException_ctor_DefaultMessage = "One or more errors occurred.";
        public const string AggregateException_ctor_InnerExceptionNull = "An element of innerExceptions was null.";
        public const string Arg_KeyNotFoundWithKey = "The given key '{0}' was not present in the dictionary.";
        public const string Arg_TypeNotSupported = "Specified type is not supported";
        public const string Arg_WrongType = "The value \"{0}\" is not of type \"{1}\" and cannot be used in this generic collection.";
        public const string ArgumentException_TupleIncorrectType = "Argument must be of type {0}.";
        public const string ArgumentException_TupleLastArgumentNotATuple = "The last element of an eight element tuple must be a Tuple.";
        public const string ArgumentNull_Obj = "Object cannot be null.";
        public const string Argument_AddingDuplicateWithKey = "An item with the same key has already been added. Key: {0}";
        public const string Argument_DestinationTooShort = "Destination is too short.";
        public const string Argument_InvalidTypeWithPointersNotSupported = "Cannot use type '{0}'. Only value types without pointers or references are supported.";
        public const string Argument_OverlapAlignmentMismatch = "Overlapping spans have mismatching alignment.";
        public const string BarrierPostPhaseException = "The postPhaseAction failed with an exception.";
        public const string Barrier_AddParticipants_NonPositive_ArgumentOutOfRange = "The participantCount argument must be a positive value.";
        public const string Barrier_AddParticipants_Overflow_ArgumentOutOfRange = "Adding participantCount participants would result in the number of participants exceeding the maximum number allowed.";
        public const string Barrier_Dispose = "The barrier has been disposed.";
        public const string Barrier_InvalidOperation_CalledFromPHA = "This method may not be called from within the postPhaseAction.";
        public const string Barrier_RemoveParticipants_ArgumentOutOfRange = "The participantCount argument must be less than or equal the number of participants.";
        public const string Barrier_RemoveParticipants_InvalidOperation = "The participantCount argument is greater than the number of participants that haven't yet arrived at the barrier in this phase.";
        public const string Barrier_RemoveParticipants_NonPositive_ArgumentOutOfRange = "The participantCount argument must be a positive value.";
        public const string Barrier_SignalAndWait_ArgumentOutOfRange = "The specified timeout must represent a value between -1 and Int32.MaxValue, inclusive.";
        public const string Barrier_SignalAndWait_InvalidOperation_ThreadsExceeded = "The number of threads using the barrier exceeded the total number of registered participants.";
        public const string Barrier_SignalAndWait_InvalidOperation_ZeroTotal = "The barrier has no registered participants.";
        public const string Barrier_ctor_ArgumentOutOfRange = "The participantCount argument must be non-negative and less than or equal to 32767.";
        public const string BlockingCollection_Add_ConcurrentCompleteAdd = "CompleteAdding may not be used concurrently with additions to the collection.";
        public const string BlockingCollection_Add_Failed = "The underlying collection didn't accept the item.";
        public const string BlockingCollection_CantAddAnyWhenCompleted = "At least one of the specified collections is marked as complete with regards to additions.";
        public const string BlockingCollection_CantTakeAnyWhenAllDone = "All collections are marked as complete with regards to additions.";
        public const string BlockingCollection_CantTakeWhenDone = "The collection argument is empty and has been marked as complete with regards to additions.";
        public const string BlockingCollection_Completed = "The collection has been marked as complete with regards to additions.";
        public const string BlockingCollection_CopyTo_IncorrectType = "The array argument is of the incorrect type.";
        public const string BlockingCollection_CopyTo_MultiDim = "The array argument is multidimensional.";
        public const string BlockingCollection_CopyTo_NonNegative = "The index argument must be greater than or equal zero.";
        public const string BlockingCollection_Disposed = "The collection has been disposed.";
        public const string BlockingCollection_Take_CollectionModified = "The underlying collection was modified from outside of the BlockingCollection<T>.";
        public const string BlockingCollection_TimeoutInvalid = "The specified timeout must represent a value between -1 and {0}, inclusive.";
        public const string BlockingCollection_ValidateCollectionsArray_DispElems = "The collections argument contains at least one disposed element.";
        public const string BlockingCollection_ValidateCollectionsArray_LargeSize = "The collections length is greater than the supported range for 32 bit machine.";
        public const string BlockingCollection_ValidateCollectionsArray_NullElems = "The collections argument contains at least one null element.";
        public const string BlockingCollection_ValidateCollectionsArray_ZeroSize = "The collections argument is a zero-length array.";
        public const string BlockingCollection_ctor_BoundedCapacityRange = "The boundedCapacity argument must be positive.";
        public const string BlockingCollection_ctor_CountMoreThanCapacity = "The collection argument contains more items than are allowed by the boundedCapacity.";
        public const string CancellationTokenSource_Disposed = "The CancellationTokenSource has been disposed.";
        public const string CancellationToken_CreateLinkedToken_TokensIsEmpty = "No tokens were supplied.";
        public const string Collection_CopyTo_ArgumentOutOfRangeException = "The index argument must be greater than or equal zero.";
        public const string Collection_CopyTo_TooManyElems = "The number of elements in the collection is greater than the available space from index to the end of the destination array.";
        public const string Common_OperationCanceled = "The operation was canceled.";
        public const string ConcurrentBag_CopyTo_ArgumentNullException = "The array argument is null.";
        public const string ConcurrentBag_Ctor_ArgumentNullException = "The collection argument is null.";
        public const string ConcurrentBag_Enumerator_EnumerationNotStartedOrAlreadyFinished = "Enumeration has either not started or has already finished.";
        public const string ConcurrentCollection_SyncRoot_NotSupported = "The SyncRoot property may not be used for the synchronization of concurrent collections.";
        public const string ConcurrentDictionary_ArrayIncorrectType = "The array is multidimensional, or the type parameter for the set cannot be cast automatically to the type of the destination array.";
        public const string ConcurrentDictionary_ArrayNotLargeEnough = "The index is equal to or greater than the length of the array, or the number of elements in the dictionary is greater than the available space from index to the end of the destination array.";
        public const string ConcurrentDictionary_CapacityMustNotBeNegative = "The capacity argument must be greater than or equal to zero.";
        public const string ConcurrentDictionary_ConcurrencyLevelMustBePositive = "The concurrencyLevel argument must be positive.";
        public const string ConcurrentDictionary_IndexIsNegative = "The index argument is less than zero.";
        public const string ConcurrentDictionary_ItemKeyIsNull = "TKey is a reference type and item.Key is null.";
        public const string ConcurrentDictionary_KeyAlreadyExisted = "The key already existed in the dictionary.";
        public const string ConcurrentDictionary_SourceContainsDuplicateKeys = "The source argument contains duplicate keys.";
        public const string ConcurrentDictionary_TypeOfKeyIncorrect = "The key was of an incorrect type for this dictionary.";
        public const string ConcurrentDictionary_TypeOfValueIncorrect = "The value was of an incorrect type for this dictionary.";
        public const string ConcurrentStack_PushPopRange_CountOutOfRange = "The count argument must be greater than or equal to zero.";
        public const string ConcurrentStack_PushPopRange_InvalidCount = "The sum of the startIndex and count arguments must be less than or equal to the collection's Count.";
        public const string ConcurrentStack_PushPopRange_StartOutOfRange = "The startIndex argument must be greater than or equal to zero.";
        public const string CountdownEvent_Decrement_BelowZero = "Invalid attempt made to decrement the event's count below zero.";
        public const string CountdownEvent_Increment_AlreadyMax = "The increment operation would cause the CurrentCount to overflow.";
        public const string CountdownEvent_Increment_AlreadyZero = "The event is already signaled and cannot be incremented.";
        public const string Lazy_CreateValue_NoParameterlessCtorForT = "The lazily-initialized type does not have a public, parameterless constructor.";
        public const string Lazy_StaticInit_InvalidOperation = "ValueFactory returned null.";
        public const string Lazy_ToString_ValueNotCreated = "Value is not created.";
        public const string Lazy_Value_RecursiveCallsToValue = "ValueFactory attempted to access the Value property of this instance.";
        public const string Lazy_ctor_ModeInvalid = "The mode argument specifies an invalid value.";
        public const string ManualResetEventSlim_Disposed = "The event has been disposed.";
        public const string ManualResetEventSlim_ctor_SpinCountOutOfRange = "The spinCount argument must be in the range 0 to {0}, inclusive.";
        public const string ManualResetEventSlim_ctor_TooManyWaiters = "There are too many threads currently waiting on the event. A maximum of {0} waiting threads are supported.";
        public const string OperationCanceled = "The operation was canceled.";
        public const string ParallelState_Break_InvalidOperationException_BreakAfterStop = "Break was called after Stop was called.";
        public const string ParallelState_NotSupportedException_UnsupportedMethod = "This method is not supported.";
        public const string ParallelState_Stop_InvalidOperationException_StopAfterBreak = "Stop was called after Break was called.";
        public const string Parallel_ForEach_NullEnumerator = "The Partitioner source returned a null enumerator.";
        public const string Parallel_ForEach_OrderedPartitionerKeysNotNormalized = "This method requires the use of an OrderedPartitioner with the KeysNormalized property set to true.";
        public const string Parallel_ForEach_PartitionerNotDynamic = "The Partitioner used here must support dynamic partitioning.";
        public const string Parallel_ForEach_PartitionerReturnedNull = "The Partitioner used here returned a null partitioner source.";
        public const string Parallel_Invoke_ActionNull = "One of the actions was null.";
        public const string PartitionerStatic_CanNotCallGetEnumeratorAfterSourceHasBeenDisposed = "Can not call GetEnumerator on partitions after the source enumerable is disposed";
        public const string PartitionerStatic_CurrentCalledBeforeMoveNext = "MoveNext must be called at least once before calling Current.";
        public const string Partitioner_DynamicPartitionsNotSupported = "Dynamic partitions are not supported by this partitioner.";
        public const string SemaphoreSlim_Disposed = "The semaphore has been disposed.";
        public const string SemaphoreSlim_Release_CountWrong = "The releaseCount argument must be greater than zero.";
        public const string SemaphoreSlim_Wait_TimeoutWrong = "The timeout must represent a value between -1 and Int32.MaxValue, inclusive.";
        public const string SemaphoreSlim_ctor_InitialCountWrong = "The initialCount argument must be non-negative and less than or equal to the maximumCount.";
        public const string SemaphoreSlim_ctor_MaxCountWrong = "The maximumCount argument must be a positive number. If a maximum is not required, use the constructor without a maxCount parameter.";
        public const string SpinLock_Exit_SynchronizationLockException = "The calling thread does not hold the lock.";
        public const string SpinLock_IsHeldByCurrentThread = "Thread tracking is disabled.";
        public const string SpinLock_TryEnter_ArgumentOutOfRange = "The timeout must be a value between -1 and Int32.MaxValue, inclusive.";
        public const string SpinLock_TryEnter_LockRecursionException = "The calling thread already holds the lock.";
        public const string SpinLock_TryReliableEnter_ArgumentException = "The tookLock argument must be set to false before calling this method.";
        public const string SpinWait_SpinUntil_ArgumentNull = "The condition argument is null.";
        public const string SpinWait_SpinUntil_TimeoutWrong = "The timeout must represent a value between -1 and Int32.MaxValue, inclusive.";
        public const string TaskCanceledException_ctor_DefaultMessage = "A task was canceled.";
        public const string TaskExceptionHolder_UnhandledException = "A Task's exception(s) were not observed either by Waiting on the Task or accessing its Exception property. As a result, the unobserved exception was rethrown by the finalizer thread.";
        public const string TaskExceptionHolder_UnknownExceptionType = "(Internal)Expected an Exception or an IEnumerable<Exception>";
        public const string TaskSchedulerException_ctor_DefaultMessage = "An exception was thrown by a TaskScheduler.";
        public const string TaskScheduler_ExecuteTask_WrongTaskScheduler = "ExecuteTask may not be called for a task which was previously queued to a different TaskScheduler.";
        public const string TaskScheduler_FromCurrentSynchronizationContext_NoCurrent = "The current SynchronizationContext may not be used as a TaskScheduler.";
        public const string TaskScheduler_InconsistentStateAfterTryExecuteTaskInline = "The TryExecuteTaskInline call to the underlying scheduler succeeded, but the task body was not invoked.";
        public const string TaskT_DebuggerNoResult = "{Not yet computed}";
        public const string Task_ContinueWith_ESandLR = "The specified TaskContinuationOptions combined LongRunning and ExecuteSynchronously.  Synchronous continuations should not be long running.";
        public const string Task_FromAsync_LongRunning = "It is invalid to specify TaskCreationOptions.LongRunning in calls to FromAsync.";
        public const string Task_FromAsync_PreferFairness = "It is invalid to specify TaskCreationOptions.PreferFairness in calls to FromAsync.";
        public const string Task_MultiTaskContinuation_EmptyTaskList = "The tasks argument contains no tasks.";
        public const string Task_MultiTaskContinuation_FireOptions = "It is invalid to exclude specific continuation kinds for continuations off of multiple tasks.";
        public const string Task_MultiTaskContinuation_NullTask = "The tasks argument included a null value.";
        public const string ThreadLocal_Disposed = "The ThreadLocal object has been disposed.";
        public const string ThreadLocal_Value_RecursiveCallsToValue = "ValueFactory attempted to access the Value property of this instance.";
        public const string ThreadLocal_ValuesNotAvailable = "The ThreadLocal object is not tracking values. To use the Values property, use a ThreadLocal constructor that accepts the trackAllValues parameter and set the parameter to true.";

        public static string GetResourceString(string resourceString)
        {
            return resourceString;
        }

        public static string Format(string resourceFormat, object p1)
        {
            return string.Format(resourceFormat, p1);
        }

        public static string Format(string resourceFormat, object p1, object p2)
        {
            return string.Format(resourceFormat, p1, p2);
        }
    }
}
