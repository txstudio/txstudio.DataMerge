using System.Collections.Generic;
using System.Linq;

namespace txstudio.DataMerge
{
    public abstract class DataMergeProvider<T> : IDataMerge<T>
        where T : IKeyEquals
    {
        private List<T> _createdList;
        private List<T> _updatedList;
        private List<T> _deletedList;

        private DataMergeOption _option;

        protected DataMergeProvider() : this(new DataMergeOption()) { }

        protected DataMergeProvider(DataMergeOption option)
        {
            this._option = option;

            this._createdList = new List<T>();
            this._updatedList = new List<T>();
            this._deletedList = new List<T>();
        }

        public IEnumerable<T> Created
        {
            get
            {
                if (this._createdList.Count == 0)
                    return null;

                return this._createdList;
            }
        }

        public IEnumerable<T> Updated
        {
            get
            {
                if (this._updatedList.Count == 0)
                    return null;

                return this._updatedList;
            }
        }

        public IEnumerable<T> Deleted
        {
            get
            {
                if (this._deletedList.Count == 0)
                    return null;

                return this._deletedList;
            }
        }

        public void Merge(IEnumerable<T> target, IEnumerable<T> source)
        {
            if (this._option.GetCreatedList == true
                || this._option.GetUpdatedList == true)
            {
                foreach (var item in source)
                {
                    var _match = target.Where(x => x.KeyEquals(item) == true).FirstOrDefault();

                    if (_match == null)
                    {
                        if (this._option.GetCreatedList == true)
                            this._createdList.Add(item);
                    }
                    else
                    {
                        if (_match.Equals(item) == false)
                        {
                            if (this._option.GetUpdatedList == true)
                                this._updatedList.Add(item);
                        }
                    }
                }
            }

            if (this._option.GetDeletedList == false)
                return;

            foreach (var item in target)
            {
                var _match = source.Where(x => x.KeyEquals(item) == true).FirstOrDefault();

                if (_match == null)
                    this._deletedList.Add(item);
            }
        }
    }

}
