namespace System
{
    internal static class SR
    {
        public static string Arg_WrongType;
        public static string Argument_AddingDuplicateWithKey;
        public static string Argument_DestinationTooShort;
        public static string AggregateException_ctor_DefaultMessage;
        public static string AggregateException_DeserializationFailure;
        public static string AggregateException_ToString;
        public static string Argument_InvalidTypeWithPointersNotSupported;
        public static string AggregateException_ctor_InnerExceptionNull;
        public static string OperationCanceled;
        public static string CancellationTokenSource_Disposed;
        public static string CancellationToken_CreateLinkedToken_TokensIsEmpty;
        public static string ArgumentNull_Obj;
        public static string TaskT_DebuggerNoResult;
        public static string Lazy_StaticInit_InvalidOperation;
        public static string Lazy_CreateValue_NoParameterlessCtorForT;
        public static string ManualResetEventSlim_ctor_TooManyWaiters;
        public static string ManualResetEventSlim_ctor_SpinCountOutOfRange;
        public static string ManualResetEventSlim_Disposed;
        public static string SpinLock_TryEnter_ArgumentOutOfRange;
        public static string SpinLock_TryReliableEnter_ArgumentException;
        public static string SpinLock_TryEnter_LockRecursionException;
        public static string SpinLock_Exit_SynchronizationLockException;
        public static string SpinLock_IsHeldByCurrentThread;
        public static string SpinWait_SpinUntil_TimeoutWrong;
        public static string SpinWait_SpinUntil_ArgumentNull;
        public static string TaskCanceledException_ctor_DefaultMessage;
        public static string Task_MultiTaskContinuation_NullTask;
        public static string Task_FromAsync_LongRunning;
        public static string TaskExceptionHolder_UnknownExceptionType;
        public static string Task_FromAsync_PreferFairness;
        public static string Task_MultiTaskContinuation_EmptyTaskList;
        public static string TaskExceptionHolder_UnhandledException;
        public static string TaskScheduler_ExecuteTask_WrongTaskScheduler;
        public static string ArgumentException_TupleIncorrectType;
        public static string TaskSchedulerException_ctor_DefaultMessage;
        public static string TaskScheduler_FromCurrentSynchronizationContext_NoCurrent;
        public static string TaskScheduler_InconsistentStateAfterTryExecuteTaskInline;
        public static string Task_MultiTaskContinuation_FireOptions;
        public static string ArgumentException_TupleLastArgumentNotATuple;
        public static string Task_ContinueWith_ESandLR;
        public static string Arg_KeyNotFoundWithKey;
        public static string Arg_TypeNotSupported;
        public static string Argument_OverlapAlignmentMismatch;
        public static string AggregateException_InnerException;
        public static string CountdownEvent_Decrement_BelowZero;
        public static string CountdownEvent_Increment_AlreadyMax;
        public static string CountdownEvent_Increment_AlreadyZero;
        internal static string Lazy_ctor_ModeInvalid;
        internal static string Lazy_Value_RecursiveCallsToValue;
        internal static string Lazy_ToString_ValueNotCreated;
        public static string BlockingCollection_CopyTo_IncorrectType;
        public static string BlockingCollection_CopyTo_MultiDim;
        public static string Collection_CopyTo_TooManyElems;
        public static string BlockingCollection_CopyTo_NonNegative;
        public static string ConcurrentCollection_SyncRoot_NotSupported;
        public static string BlockingCollection_Add_ConcurrentCompleteAdd;
        public static string BlockingCollection_Add_Failed;
        public static string BlockingCollection_Completed;
        public static string BlockingCollection_ctor_BoundedCapacityRange;
        public static string BlockingCollection_ctor_CountMoreThanCapacity;
        public static string BlockingCollection_Take_CollectionModified;
        public static string BlockingCollection_ValidateCollectionsArray_ZeroSize;
        public static string Common_OperationCanceled;
        public static string BlockingCollection_CantAddAnyWhenCompleted;
        public static string BlockingCollection_CantTakeAnyWhenAllDone;
        public static string BlockingCollection_TimeoutInvalid;
        public static string BlockingCollection_ValidateCollectionsArray_DispElems;
        public static string BlockingCollection_ValidateCollectionsArray_NullElems;
        public static string BlockingCollection_ValidateCollectionsArray_LargeSize;
        public static string SemaphoreSlim_ctor_InitialCountWrong;
        public static string SemaphoreSlim_ctor_MaxCountWrong;
        public static string BlockingCollection_CantTakeWhenDone;
        public static string BlockingCollection_Disposed;
        public static string SemaphoreSlim_Release_CountWrong;
        public static string SemaphoreSlim_Wait_TimeoutWrong;
        public static string SemaphoreSlim_Disposed;
        public static string Collection_CopyTo_ArgumentOutOfRangeException;
        public static Exception ConcurrentBag_Ctor_ArgumentNullException;
        public static string ThreadLocal_Disposed;
        public static string ThreadLocal_Value_RecursiveCallsToValue;
        public static string ConcurrentBag_Enumerator_EnumerationNotStartedOrAlreadyFinished;
        public static Exception ConcurrentBag_CopyTo_ArgumentNullException;
        public static string ThreadLocal_ValuesNotAvailable;
        public static string ConcurrentDictionary_ArrayIncorrectType;
        public static string ConcurrentDictionary_ArrayNotLargeEnough;
        public static string ConcurrentDictionary_IndexIsNegative;
        public static string ConcurrentDictionary_ConcurrencyLevelMustBePositive;
        public static string ConcurrentDictionary_CapacityMustNotBeNegative;
        public static Exception ConcurrentDictionary_ItemKeyIsNull;
        public static string ConcurrentDictionary_KeyAlreadyExisted;
        public static string ConcurrentDictionary_SourceContainsDuplicateKeys;
        public static string ConcurrentDictionary_TypeOfKeyIncorrect;
        public static string ConcurrentDictionary_TypeOfValueIncorrect;
        public static string ConcurrentStack_PushPopRange_CountOutOfRange;
        public static string ConcurrentStack_PushPopRange_StartOutOfRange;
        public static string ConcurrentStack_PushPopRange_InvalidCount;
        public static string Partitioner_DynamicPartitionsNotSupported;
        public static string PartitionerStatic_CanNotCallGetEnumeratorAfterSourceHasBeenDisposed;
        public static string PartitionerStatic_CurrentCalledBeforeMoveNext;
        public static string BarrierPostPhaseException;
        public static string Barrier_SignalAndWait_InvalidOperation_ZeroTotal;
        public static string Barrier_SignalAndWait_InvalidOperation_ThreadsExceeded;
        public static string Barrier_AddParticipants_NonPositive_ArgumentOutOfRange;
        public static string Barrier_AddParticipants_Overflow_ArgumentOutOfRange;
        public static string Barrier_InvalidOperation_CalledFromPHA;
        public static string Barrier_ctor_ArgumentOutOfRange;
        public static string Barrier_Dispose;
        public static string Barrier_RemoveParticipants_ArgumentOutOfRange;
        public static string Barrier_RemoveParticipants_InvalidOperation;
        public static string Barrier_RemoveParticipants_NonPositive_ArgumentOutOfRange;
        public static string Barrier_SignalAndWait_ArgumentOutOfRange;
        public static string Parallel_ForEach_OrderedPartitionerKeysNotNormalized;
        public static string Parallel_ForEach_PartitionerNotDynamic;
        public static string Parallel_ForEach_PartitionerReturnedNull;
        public static string Parallel_Invoke_ActionNull;
        public static string ParallelState_NotSupportedException_UnsupportedMethod;
        public static string ParallelState_Stop_InvalidOperationException_StopAfterBreak;
        public static string ParallelState_Break_InvalidOperationException_BreakAfterStop;
        public static string Parallel_ForEach_NullEnumerator;

        internal static string GetResourceString(string resourceString)
        {
            return resourceString;
        }

        internal static string Format(string resourceFormat, object p1)
        {
            return string.Format(resourceFormat, p1);
        }

        internal static string Format(string resourceFormat, object p1, object p2)
        {
            return string.Format(resourceFormat, p1, p2);
        }

        internal static string Format(string resourceFormat, object p1, object p2, object p3)
        {
            return string.Format(resourceFormat, p1, p2, p3);
        }
    }
}
