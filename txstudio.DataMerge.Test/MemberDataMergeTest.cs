using System;
using System.Collections.Generic;
using Xunit;

namespace txstudio.DataMerge.Test
{
    public class MemberDataMergeTest
    {
        [Fact]
        public void DefaultMergeOption()
        {
            var _targets = MergeDataGenerater.GetTargets();
            var _sources = MergeDataGenerater.GetSources();

            var _memberDataMerge = new MemberDataMerge();
            _memberDataMerge.Merge(_targets, _sources);

            var _actualCreatedList = _memberDataMerge.Created;
            var _expectCreatedList = MergeDataGenerater.GetExpectCreatedList();

            Assert.Equal(_actualCreatedList, _expectCreatedList);

            var _actualUpdatedList = _memberDataMerge.Updated;
            var _expectUpdatedList = MergeDataGenerater.GetExpectUpdatedList();

            Assert.Equal(_actualUpdatedList, _expectUpdatedList);

            var _actualDeletedList = _memberDataMerge.Deleted;
            var _expectDeletedList = MergeDataGenerater.GetExpectDeletedList();

            Assert.Equal(_actualDeletedList, _expectDeletedList);
        }

        [Fact]
        public void MergeDisableCreated()
        {
            var _targets = MergeDataGenerater.GetTargets();
            var _sources = MergeDataGenerater.GetSources();

            var _option = new DataMergeOption();
            _option.GetCreatedList = false;

            var _memberDataMerge = new MemberDataMerge(_option);
            _memberDataMerge.Merge(_targets, _sources);

            var _actualCreatedList = _memberDataMerge.Created;

            Assert.Null(_actualCreatedList);

            var _actualUpdatedList = _memberDataMerge.Updated;
            var _expectUpdatedList = MergeDataGenerater.GetExpectUpdatedList();

            Assert.Equal(_actualUpdatedList, _expectUpdatedList);

            var _actualDeletedList = _memberDataMerge.Deleted;
            var _expectDeletedList = MergeDataGenerater.GetExpectDeletedList();

            Assert.Equal(_actualDeletedList, _expectDeletedList);
        }
        
        [Fact]
        public void MergeDisableUpdated()
        {
            var _targets = MergeDataGenerater.GetTargets();
            var _sources = MergeDataGenerater.GetSources();

            var _option = new DataMergeOption();
            _option.GetUpdatedList = false;

            var _memberDataMerge = new MemberDataMerge(_option);
            _memberDataMerge.Merge(_targets, _sources);
            
            var _actualCreatedList = _memberDataMerge.Created;
            var _expectCreatedList = MergeDataGenerater.GetExpectCreatedList();

            Assert.Equal(_actualCreatedList, _expectCreatedList);

            var _actualUpdatedList = _memberDataMerge.Updated;

            Assert.Null(_actualUpdatedList);

            var _actualDeletedList = _memberDataMerge.Deleted;
            var _expectDeletedList = MergeDataGenerater.GetExpectDeletedList();

            Assert.Equal(_actualDeletedList, _expectDeletedList);
        }

        [Fact]
        public void MergeDisableDeleted()
        {
            var _targets = MergeDataGenerater.GetTargets();
            var _sources = MergeDataGenerater.GetSources();

            var _option = new DataMergeOption();
            _option.GetDeletedList = false;

            var _memberDataMerge = new MemberDataMerge(_option);
            _memberDataMerge.Merge(_targets, _sources);

            var _actualCreatedList = _memberDataMerge.Created;
            var _expectCreatedList = MergeDataGenerater.GetExpectCreatedList();

            Assert.Equal(_actualCreatedList, _expectCreatedList);

            var _actualUpdatedList = _memberDataMerge.Updated;
            var _expectUpdatedList = MergeDataGenerater.GetExpectUpdatedList();

            Assert.Equal(_actualUpdatedList, _expectUpdatedList);

            var _actualDeletedList = _memberDataMerge.Deleted;

            Assert.Null(_actualDeletedList);
        }
    }
}
