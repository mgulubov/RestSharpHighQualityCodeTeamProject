namespace RestSharp.Authenticators.OAuth
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;

    internal class WebPairCollection : IList<WebPair>
    {
        private IList<WebPair> parameters;

        public virtual WebPair this[string name]
        {
            get
            {
                return this.SingleOrDefault(p => p.Name.Equals(name));
            }
        }

        public virtual IEnumerable<string> Names
        {
            get
            {
                return this.parameters.Select(p => p.Name);
            }
        }

        public virtual IEnumerable<string> Values
        {
            get
            {
                return this.parameters.Select(p => p.Value);
            }
        }

        public WebPairCollection(IEnumerable<WebPair> parameters)
        {
            this.parameters = new List<WebPair>(parameters);
        }

#if !WINDOWS_PHONE && !SILVERLIGHT && !PocketPC
        public WebPairCollection(NameValueCollection collection)
            : this()
        {
            this.AddCollection(collection);
        }

        public virtual void AddRange(NameValueCollection collection)
        {
            this.AddCollection(collection);
        }

        private void AddCollection(NameValueCollection collection)
        {
            var parameters = collection.AllKeys.Select(key => new WebPair(key, collection[key]));
            foreach (var parameter in parameters)
            {
                this.parameters.Add(parameter);
            }
        }
#endif

        public WebPairCollection(IDictionary<string, string> collection)
            : this()
        {
            this.AddCollection(collection);
        }

        public void AddCollection(IDictionary<string, string> collection)
        {
            foreach (var key in collection.Keys)
            {
                var parameter = new WebPair(key, collection[key]);
                parameters.Add(parameter);
            }
        }

        public WebPairCollection()
        {
            this.parameters = new List<WebPair>(0);
        }

        public WebPairCollection(int capacity)
        {
            this.parameters = new List<WebPair>(capacity);
        }

        private void AddCollection(IEnumerable<WebPair> collection)
        {
            foreach (var parameter in collection)
            {
                var pair = new WebPair(parameter.Name, parameter.Value);
                this.parameters.Add(pair);
            }
        }

        public virtual void AddRange(WebPairCollection collection)
        {
            this.AddCollection(collection);
        }

        public virtual void AddRange(IEnumerable<WebPair> collection)
        {
            this.AddCollection(collection);
        }

        public virtual void Sort(Comparison<WebPair> comparison)
        {
            var sorted = new List<WebPair>(parameters);
            sorted.Sort(comparison);
            this.parameters = sorted;
        }

        public virtual bool RemoveAll(IEnumerable<WebPair> parameters)
        {
            var success = true;
            var array = parameters.ToArray();

            for (var p = 0; p < array.Length; p++)
            {
                var parameter = array[p];
                success &= this.parameters.Remove(parameter);
            }

            return success && array.Length > 0;
        }

        public virtual void Add(string name, string value)
        {
            var pair = new WebPair(name, value);
            this.parameters.Add(pair);
        }

        #region IList<WebParameter> Members

        public virtual IEnumerator<WebPair> GetEnumerator()
        {
            return this.parameters.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public virtual void Add(WebPair parameter)
        {
            this.parameters.Add(parameter);
        }

        public virtual void Clear()
        {
            this.parameters.Clear();
        }

        public virtual bool Contains(WebPair parameter)
        {
            return this.parameters.Contains(parameter);
        }

        public virtual void CopyTo(WebPair[] parameters, int arrayIndex)
        {
            this.parameters.CopyTo(parameters, arrayIndex);
        }

        public virtual bool Remove(WebPair parameter)
        {
            return this.parameters.Remove(parameter);
        }

        public virtual int Count
        {
            get
            {
                return parameters.Count;
            }
        }

        public virtual bool IsReadOnly
        {
            get
            {
                return this.parameters.IsReadOnly;
            }
        }

        public virtual int IndexOf(WebPair parameter)
        {
            return this.parameters.IndexOf(parameter);
        }

        public virtual void Insert(int index, WebPair parameter)
        {
            this.parameters.Insert(index, parameter);
        }

        public virtual void RemoveAt(int index)
        {
            this.parameters.RemoveAt(index);
        }

        public virtual WebPair this[int index]
        {
            get
            {
                return this.parameters[index];
            }
            set
            {
                this.parameters[index] = value;
            }
        }

        #endregion
    }
}
