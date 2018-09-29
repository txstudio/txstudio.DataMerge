namespace txstudio.DataMerge
{
    /// <summary>資料同步選項</summary>
    public sealed class DataMergeOption
    {
        public DataMergeOption()
        {
            this.GetCreatedList = true;
            this.GetUpdatedList = true;
            this.GetDeletedList = true;
        }

        /// <summary>同步新增清單</summary>
        public bool GetCreatedList { get; set; }

        /// <summary>同步修改清單</summary>
        public bool GetUpdatedList { get; set; }

        /// <summary>同步刪除清單</summary>
        public bool GetDeletedList { get; set; }
    }

}
