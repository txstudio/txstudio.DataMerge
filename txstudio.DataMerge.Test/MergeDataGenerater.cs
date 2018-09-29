using System;
using System.Collections.Generic;
using System.Text;

namespace txstudio.DataMerge.Test
{
    public sealed class MergeDataGenerater
    {
        public static IEnumerable<Member> GetTargets()
        {
            List<Member> _target = new List<Member>();

            _target.Add(new Member() { No = 1, Name = "Lucas Yang", Birthday = new DateTime(1984, 2, 13), Email = "lucas@txstudio.com" });
            _target.Add(new Member() { No = 2, Name = "Peter Chang", Birthday = new DateTime(1975, 10, 29), Email = "peter@txstudio.com" });
            _target.Add(new Member() { No = 3, Name = "Will Pao", Birthday = new DateTime(1988, 2, 20), Email = "will@txstudio.com" });
            _target.Add(new Member() { No = 6, Name = "Wei Chen", Birthday = new DateTime(1992, 1, 3), Email = "wei@txstudio.com" });
            
            return _target;
        }

        public static IEnumerable<Member> GetSources()
        {
            List<Member> _source = new List<Member>();

            _source.Add(new Member() { No = 2, Name = "Peter Chang", Birthday = new DateTime(1975, 10, 29), Email = "peter@txstudio.tw" });
            _source.Add(new Member() { No = 3, Name = "Will Pao", Birthday = new DateTime(1988, 2, 29), Email = "will@txstudio.com" });
            _source.Add(new Member() { No = 4, Name = "Lewis Wang", Birthday = new DateTime(1990, 9, 3), Email = "lewis@txstudio.com" });
            _source.Add(new Member() { No = 5, Name = "Lucy Joy", Birthday = new DateTime(1991, 12, 25), Email = "lucy@txstudio.com" });
            _source.Add(new Member() { No = 6, Name = "Wei Chen", Birthday = new DateTime(1992, 1, 3), Email = "wei@txstudio.com" });

            return _source;
        }
    }
}
