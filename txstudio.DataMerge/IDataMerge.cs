using System;
using System.Collections.Generic;

namespace txstudio.DataMerge
{
    /// <summary>
    /// 定義資料同步提供的方法與屬性介面 (兩筆物件型別需相同)
    /// </summary>
    /// <typeparam name="T">要同步的物件型別</typeparam>
    public interface IDataMerge<T>
        where T: IKeyEquals
    {
        /// <summary>進行資料物件的同步作業</summary>
        void Merge(IEnumerable<T> target, IEnumerable<T> source);

        /// <summary>要新增的物件清單</summary>
        IEnumerable<T> Created { get; }

        /// <summary>要修改的物件清單</summary>
        IEnumerable<T> Updated { get; }

        /// <summary>要刪除的物件清單</summary>
        IEnumerable<T> Deleted { get; }
    }
}
