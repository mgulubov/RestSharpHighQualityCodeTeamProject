namespace RestSharp.Extensions.MonoHttp
{
    using System.Collections.Specialized;
    using System.Text;

    internal sealed class HttpQSCollection : NameValueCollection
    {
        public override string ToString()
        {
            int count = Count;

            if (count == 0)
                return string.Empty;

            StringBuilder output = new StringBuilder();
            string[] keys = AllKeys;

            for (int i = 0; i < count; i++)
            {
                output.AppendFormat("{0}={1}&", keys[i], this[keys[i]]);
            }

            if (output.Length > 0)
                output.Length--;

            return output.ToString();
        }
    }
}
