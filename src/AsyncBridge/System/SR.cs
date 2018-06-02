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
