using System;
using System.Linq;
using System.Collections.Generic;
using txstudio.DataMerge;
using Newtonsoft.Json;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Member> _target;
            List<Member> _source;

            _target = new List<Member>();
            _source = new List<Member>();

            _target.Add(new Member() { No = 1, Name = "Lucas Yang", Birthday = new DateTime(1984, 2, 13), Email = "lucas@txstudio.com" });
            _target.Add(new Member() { No = 2, Name = "Peter Chang", Birthday = new DateTime(1975, 10, 29), Email = "peter@txstudio.com" });
            _target.Add(new Member() { No = 3, Name = "Will Pao", Birthday = new DateTime(1988, 2, 20), Email = "will@txstudio.com" });
            _target.Add(new Member() { No = 6, Name = "Wei Chen", Birthday = new DateTime(1992, 1, 3), Email = "wei@txstudio.com" });

            _source.Add(new Member() { No = 2, Name = "Peter Chang", Birthday = new DateTime(1975, 10, 29), Email = "peter@txstudio.tw" });
            _source.Add(new Member() { No = 3, Name = "Will Pao", Birthday = new DateTime(1988, 2, 29), Email = "will@txstudio.com" });
            _source.Add(new Member() { No = 4, Name = "Lewis Wang", Birthday = new DateTime(1990, 9, 3), Email = "lewis@txstudio.com" });
            _source.Add(new Member() { No = 5, Name = "Lucy Joy", Birthday = new DateTime(1991, 12, 25), Email = "lucy@txstudio.com" });
            _source.Add(new Member() { No = 6, Name = "Wei Chen", Birthday = new DateTime(1992, 1, 3), Email = "wei@txstudio.com" });

            DataMergeOption _option;

            _option = new DataMergeOption();

            MemberDataMerge _merge = new MemberDataMerge(_option);

            _merge.Merge(_target, _source);

            Console.WriteLine("Created List");
            Console.WriteLine(JsonConvert.SerializeObject(_merge.Created, Formatting.Indented));

            Console.WriteLine();
            Console.WriteLine("Updated List");
            Console.WriteLine(JsonConvert.SerializeObject(_merge.Updated, Formatting.Indented));

            Console.WriteLine();
            Console.WriteLine("Deleted List");
            Console.WriteLine(JsonConvert.SerializeObject(_merge.Deleted, Formatting.Indented));

            //進行資料同步

            //取得要新增的清單

            //取得要更新的清單

            //取得要刪除的清單

            Console.WriteLine("press any key to exit !");
            Console.ReadKey();
        }

        public class MemberDataMerge : DataMergeProvider<Member>
        {
            public MemberDataMerge(DataMergeOption option) : base(option) { }
        }

        public class Member : IKeyEquals
        {
            public int? No { get; set; }
            public string Email { get; set; }
            public string Name { get; set; }
            public DateTime? Birthday { get; set; }

            public bool KeyEquals(object obj)
            {
                if (obj is Member)
                {
                    var _member = obj as Member;

                    if (int.Equals(this.No, _member.No) == false)
                        return false;

                    return true;
                }

                return false;
            }

            public override bool Equals(object obj)
            {
                if(obj is Member)
                {
                    var _comparison = StringComparison.OrdinalIgnoreCase;
                    var _member = obj as Member;

                    if (int.Equals(this.No, _member.No) == false)
                        return false;

                    if (string.Equals(this.Email, _member.Email, _comparison) == false)
                        return false;

                    if (string.Equals(this.Name, _member.Name, _comparison) == false)
                        return false;

                    if (DateTime.Equals(this.Birthday, _member.Birthday) == false)
                        return false;

                    return true;
                }

                return false;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(No, Email, Name, Birthday);
            }
        }
    }
}
