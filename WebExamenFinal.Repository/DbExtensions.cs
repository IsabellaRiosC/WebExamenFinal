using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExamenFinal.Repository
{
    public static class DbExtensions
    {

        public static IEnumerable<TSource> Page<TSource>(
            this IEnumerable<TSource> source,
            int page,
            int size)
        {
            return source.Skip((page - 1) * size).Take(size);
        }

    }
}
