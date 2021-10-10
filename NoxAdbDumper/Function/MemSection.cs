using System;
using System.Text;

namespace NoxAdbDumper
{
    public class MemSection
    {
        public uint start;
        public uint end;
        public string flags;
        public string desc;
        public MemSection(string info)
        {
            start = Convert.ToUInt32(info.Substring(0, 8), 16);
            end = Convert.ToUInt32(info.Substring(9, 8), 16);
            flags = info.Substring(18, 4);
            if (info.Length > 49)
                desc = info.Substring(49);
            else
                desc = "";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}-{1} {2} {3} {4}", start.ToString("X8"), end.ToString("X8"), (end - start).ToString("X8"), flags, desc);
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            MemSection objAsPart = obj as MemSection;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return Convert.ToInt32(start);
        }
        public bool Equals(MemSection other)
        {
            if (other == null) return false;
            return (this.start.Equals(other.start));
        }
    }
}
