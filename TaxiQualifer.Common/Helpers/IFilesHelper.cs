using System.IO;

namespace TaxiQualifer.Common.Helpers
{
    public interface IFilesHelper
    {
        byte[] ReadFully(Stream input);
    }

}
