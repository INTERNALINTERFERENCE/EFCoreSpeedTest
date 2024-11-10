using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace EFCoreSpeedTest.Common;

public static class TaskExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NoWait(this Task _)
    {
        
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NoWait(this Task @this, ILogger? logger)
    {
        if (logger != null)
            @this.LogExceptions(logger);
    }

    private static void LogExceptions(this Task @this, ILogger? logger) =>
        @this.ContinueWith(task =>
        {
            var exception = task.Exception;
            
            try
            {
                exception?.Flatten().Handle(e => e is OperationCanceledException);
            }
            catch (Exception ex)
            {
                logger?.LogError(ex, "exception in unawaited task");
            }
            
        }, TaskContinuationOptions.OnlyOnFaulted);
}