using System;
using System.Collections.Generic;
using System.Text;

namespace txstudio.DataMerge.Test
{
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
            if (obj is Member)
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
