using System;
using System.Collections.Generic;

public static class CustomLinqExtensions
{
    public static IEnumerable<T> CustomWhere<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        foreach (var item in source)
        {
            if (predicate(item))
            {
                yield return item;
            }
        }
    }

    public static IEnumerable<TResult> CustomSelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
    {
        foreach (var item in source)
        {
            yield return selector(item);
        }
    }

    public static int CustomCount<T>(this IEnumerable<T> source, Func<T, bool> predicate = null)
    {
        int count = 0;
        foreach (var item in source)
        {
            if (predicate == null || predicate(item))
            {
                count++;
            }
        }
        return count;
    }

    public static bool CustomAny<T>(this IEnumerable<T> source, Func<T, bool> predicate = null)
    {
        foreach (var item in source)
        {
            if (predicate == null || predicate(item))
            {
                return true;
            }
        }
        return false;
    }

    public static bool CustomAll<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        foreach (var item in source)
        {
            if (!predicate(item))
            {
                return false;
            }
        }
        return true;
    }

    public static T CustomFirst<T>(this IEnumerable<T> source, Func<T, bool> predicate = null)
    {
        foreach (var item in source)
        {
            if (predicate == null || predicate(item))
            {
                return item;
            }
        }
        throw new InvalidOperationException();
    }

    public static T CustomFirstOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate = null)
    {
        foreach (var item in source)
        {
            if (predicate == null || predicate(item))
            {
                return item;
            }
        }
        return default;
    }

    public static T CustomLast<T>(this IEnumerable<T> source, Func<T, bool> predicate = null)
    {
        bool found = false;
        T result = default;

        foreach (var item in source)
        {
            if (predicate == null || predicate(item))
            {
                result = item;
                found = true;
            }
        }

        if (!found)
        {
            throw new InvalidOperationException();
        }

        return result;
    }

    public static T CustomLastOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate = null)
    {
        T result = default;
        foreach (var item in source)
        {
            if (predicate == null || predicate(item))
            {
                result = item;
            }
        }
        return result;
    }

    public static T CustomSingle<T>(this IEnumerable<T> source, Func<T, bool> predicate = null)
    {
        bool found = false;
        T result = default;

        foreach (var item in source)
        {
            if (predicate == null || predicate(item))
            {
                if (found)
                {
                    throw new InvalidOperationException();
                }
                result = item;
                found = true;
            }
        }

        if (!found)
        {
            throw new InvalidOperationException();
        }

        return result;
    }

    public static T CustomSingleOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate = null)
    {
        bool found = false;
        T result = default;

        foreach (var item in source)
        {
            if (predicate == null || predicate(item))
            {
                if (found)
                {
                    throw new InvalidOperationException();
                }
                result = item;
                found = true;
            }
        }

        return result;
    }

    public static IEnumerable<T> CustomTake<T>(this IEnumerable<T> source, int count)
    {
        int index = 0;
        foreach (var item in source)
        {
            if (index < count)
            {
                yield return item;
                index++;
            }
            else
            {
                break;
            }
        }
    }

    public static IEnumerable<T> CustomSkip<T>(this IEnumerable<T> source, int count)
    {
        int index = 0;
        foreach (var item in source)
        {
            if (index >= count)
            {
                yield return item;
            }
            index++;
        }
    }

    public static IEnumerable<T> CustomTakeWhile<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        foreach (var item in source)
        {
            if (predicate(item))
            {
                yield return item;
            }
            else
            {
                break;
            }
        }
    }

    public static IEnumerable<T> CustomSkipWhile<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        bool skip = true;
        foreach (var item in source)
        {
            if (skip && !predicate(item))
            {
                skip = false;
            }

            if (!skip)
            {
                yield return item;
            }
        }
    }

    public static IEnumerable<T> CustomDistinct<T>(this IEnumerable<T> source)
    {
        List<T> uniqueList = new List<T>();
        foreach (var item in source)
        {
            if (!uniqueList.Contains(item))
            {
                uniqueList.Add(item);
                yield return item;
            }
        }
    }
}
