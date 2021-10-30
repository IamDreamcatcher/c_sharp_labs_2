using System.Collections.Generic;

namespace Serialization.Domain
{
    public interface ISerializer 
    {
        IEnumerable<Hospital> DeSerializeByLINQ(string fileName);
        IEnumerable<Hospital> DeSerializeXML(string fileName);
        IEnumerable<Hospital> DeSerializeJSON(string fileName);
        void SerializeByLINQ(IEnumerable<Hospital> hospitals, string fileName);
        void SerializeXML(IEnumerable<Hospital> hospitals, string fileName);
        void SerializeJSON(IEnumerable<Hospital> hospitals, string fileName);
    }
}
