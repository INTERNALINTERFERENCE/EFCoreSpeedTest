using System.Runtime.CompilerServices;

namespace EFCoreSpeedTest.Common;

public static class CollectionExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNullOrEmpty<T>(this IEnumerable<T>? collection) =>
        collection is null || collection.IsEmpty();
    
    [MethodImpl( MethodImplOptions.AggressiveInlining )]
    public static bool IsEmpty<T>( this IEnumerable<T> @this ) =>
        !@this.GetEnumerator().MoveNext();
}